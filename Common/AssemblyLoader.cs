//==========================================================================================
//
//		MapSurfer.Utilities
//		Copyright (c) 2008-2015, MapSurfer.NET
//
//    Authors: Maxim Rylov
//
//==========================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Threading;


/// NOTE!!!!
/// AssemblyLoader class should not depend on any additional assembly except those that are in GAC.
/// Otherwise CLR won't be able to find an assembly and AssemblyResolve event will not be fired.
/// 

namespace MapSurfer.Utilities
{
  public static class AssemblyLoader
  {
    private static bool m_registered = false;
    private static bool m_preJitMethods = false;
    private static string m_version = string.Empty;
    private static AppDomain m_appDomain;
    private static List<string> m_searchPaths = new List<string>();
    private static object m_syncObj = new object();
    private static Dictionary<string, string[]> m_dictionariesCache = new Dictionary<string, string[]>();

    public static bool AllowPreJITMethods
    {
      get
      {
        return m_preJitMethods;
      }
      set
      {
        m_preJitMethods = value;
      }
    }

    public static void AddSearchPath(string path)
    {
      m_searchPaths.Add(path);
    }

    public static void Register(AppDomain domain)
    {
      string version = MSNUtility.GetCurrentMSNVersion();

      if (!MSNUtility.IsMSNVersionInstalled(version))
        version = MSNUtility.TryDetectInstalledVersion();

      Register(domain, version);
    }

    public static void Register(AppDomain domain, string version)
    {
      if (m_registered)
        return;

      m_version = version;
      m_appDomain = domain;
      m_appDomain.AssemblyResolve += new ResolveEventHandler(Domain_AssemblyResolve);
      m_appDomain.AssemblyLoad += Domain_AssemblyLoad;
     // m_appDomain.TypeResolve += new ResolveEventHandler(Domain_TypeResolve);

      m_registered = true;
    }

    private static void Domain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
    {
      if (m_preJitMethods)
        PreJITMethodsThread(args.LoadedAssembly);
    }

    static Assembly Domain_TypeResolve(object sender, ResolveEventArgs args)
    {
      Console.WriteLine(args.Name);

      return args.RequestingAssembly;
    }

    public static void Unregister()
    {
      if (m_registered)
      {
        m_appDomain.AssemblyResolve -= new ResolveEventHandler(Domain_AssemblyResolve);
        m_appDomain.AssemblyLoad -= Domain_AssemblyLoad;
   //     m_appDomain.TypeResolve -= new ResolveEventHandler(Domain_TypeResolve);
        m_appDomain = null;

        m_registered = false;
      }
    }

    private static void PreJITMethodsThread(Assembly assembly)
    {
      if (assembly.GlobalAssemblyCache)
        return;
      
      Thread jitter = new Thread(() =>
      {
        try
        {
          PreJITMethodsInternal(assembly);
        }
        catch
        {
        }
      });

      jitter.Priority = ThreadPriority.Lowest;
      jitter.Start();
    }

    private static void PreJITMethodsInternal(Assembly assembly)
    {
      if (assembly.GlobalAssemblyCache)
        return;

      Type[] types = assembly.GetTypes();
      foreach (Type curType in types)
      {
        MethodInfo[] methods = curType.GetMethods(
                BindingFlags.DeclaredOnly |
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.Static);

        foreach (MethodInfo curMethod in methods)
        {
          if (curMethod.IsAbstract ||
              curMethod.ContainsGenericParameters)
            continue;

          System.Runtime.CompilerServices.RuntimeHelpers.PrepareMethod(curMethod.MethodHandle);
        }
      }
    }

    public static void ForceLoadAll(Assembly assembly)
    {
      ForceLoadAll(assembly, new HashSet<Assembly>());
    }

    private static void ForceLoadAll(Assembly assembly, HashSet<Assembly> loadedAssmblies)
    {
      bool alreadyLoaded = !loadedAssmblies.Add(assembly);
      if (alreadyLoaded)
        return;

      AssemblyName[] refrencedAssemblies = assembly.GetReferencedAssemblies();

      foreach (AssemblyName curAssemblyName in refrencedAssemblies)
      {
        Assembly nextAssembly = Assembly.Load(curAssemblyName);
        if (nextAssembly.GlobalAssemblyCache)
          continue;

        ForceLoadAll(nextAssembly, loadedAssmblies);
      }
    }

    public static Assembly Load(string assemblyName)
    {
      string path = Path.Combine(MSNUtility.GetMSNCorePath(), assemblyName);
      AssemblyName name = AssemblyName.GetAssemblyName(path);
      Assembly assembly = Assembly.Load(name);

      return assembly;
    }

    public static Assembly LoadFrom(string path)
    {
      AssemblyName name = AssemblyName.GetAssemblyName(path);
      Assembly assembly = Assembly.Load(name);

      return assembly;
    }

    private static IEnumerable<string> GetDirectories(string path)
    {
      yield return path;

      string[] directories = null;

      lock (m_syncObj)
      {
        if (!m_dictionariesCache.TryGetValue(path, out directories))
        {
          // Calling Direcotry.GetDirectories is expensive. Therefore, we use cache approach.
          directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
          m_dictionariesCache.Add(path, directories);
        }
      }

      if (directories != null)
      {
        foreach (string dir in directories)
        {
          yield return dir;
        }
      }

      if (m_searchPaths.Count > 0)
      {
        foreach (string dir in m_searchPaths)
        {
          yield return dir;
        }
      }
    }

    private static Assembly Domain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
      try
      {
        //Retrieve the list of referenced assemblies in an array of AssemblyName.
        Assembly objExecutingAssemblies = Assembly.GetExecutingAssembly();
        AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

        string dirAssemblies = MSNUtility.GetMSNCorePath();
        if (Directory.Exists(dirAssemblies))
        {
          string dirSeparator = Path.DirectorySeparatorChar.ToString();
          if (!dirAssemblies.EndsWith(dirSeparator))
            dirAssemblies += dirSeparator;

          string assemblyName = string.Empty;
          string fileName = string.Empty;

          int p = args.Name.IndexOf(",");
          assemblyName = (p > 0) ? args.Name.Substring(0, p) : assemblyName.Replace(".dll", string.Empty);

          fileName = assemblyName + ".dll";

          string[] files = Directory.GetFiles(dirAssemblies, fileName, SearchOption.AllDirectories);
          /// Do not use the following function as CLR produceds StackOverflowException
          /// http://blogs.msdn.com/b/junfeng/archive/2004/09/29/235763.aspx
          /// DirectoryUtility.GetFiles(dirAssemblies, fileName, SearchOption.AllDirectories);

          if (files != null && files.Length > 0)
          {
            Assembly assembly = LoadFrom(files[0]);

            if (m_preJitMethods)
              PreJITMethodsThread(assembly);

            return assembly;
          }

          string path = string.Empty;
          string[] dirList = GetDirectories(dirAssemblies).ToArray();

          //Loop through the array of referenced assembly names.
          foreach (AssemblyName asmName in arrReferencedAssmbNames)
          {
            //Check for the assembly names that have raised the "AssemblyResolve" event.
            if (asmName.FullName.Substring(0, asmName.FullName.IndexOf(",")) == assemblyName)
            {
              if (dirList.Length > 0)
              {
                foreach (string strDirPath in dirList)
                {
                  //Build the path of the assembly from where it has to be loaded.
                  //The following line is probably the only line of code in this method you may need to modify:
                  path = Path.Combine(strDirPath, fileName);

                  if (File.Exists(path))
                  {
                    //Load the assembly from the specified path.
                    Assembly assembly = LoadFrom(path);
                    if (m_preJitMethods)
                      PreJITMethodsThread(assembly);

                    return assembly;
                  }
                }
              }
              else
              {
                path = Path.Combine(dirAssemblies, fileName);

                if (File.Exists(path))
                {
                  //Load the assembly from the specified path.
                  Assembly assembly = LoadFrom(path);

                  if (m_preJitMethods)
                    PreJITMethodsThread(assembly);

                  return assembly;
                }
              }
            }
          }
        }
      }
      catch
      { }

      return null;
    }
  }
}
