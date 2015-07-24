//==========================================================================================
//
//		MapSurfer.Utilities
//		Copyright (c) 2008-2015, MapSurfer.NET
//
//    Authors: Maxim Rylov
//
//==========================================================================================
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

using Microsoft.Win32;

namespace MapSurfer.Utilities
{
	public static class MSNUtility 
	{
		private static string m_msnInstallPath = null;
    private static string m_msnCurrentVersion = null;
    private static bool m_checkVersionValidity = true;

    static MSNUtility()
    {
      string strInstallPath = (string)ConfigurationManager.AppSettings["MapSurfer.InstallPath"];

      //strInstallPath = @"E:\MapSurfer.NET\1.15";
      if (strInstallPath != null)
      {
        if (!Directory.Exists(strInstallPath))
          throw new DirectoryNotFoundException(strInstallPath);

        string path = Path.Combine(strInstallPath, @"Core\MapSurfer.System.dll");
        Assembly assembly = Assembly.LoadFrom(path);

        if (assembly == null)
          throw new FileNotFoundException(path);

        m_msnCurrentVersion = GetMSNVersion(assembly);
        m_msnInstallPath = strInstallPath;
        m_checkVersionValidity = false;
      }
    }

		private static string GetVersionNumberString(Version version, int fieldCount)
		{
			if ((fieldCount < 1) || (fieldCount > 4))
			{
				throw new ArgumentOutOfRangeException("fieldCount", "must be in the range [1, 4]");
			}

			StringBuilder sb = new StringBuilder();
			sb.Append(version.Major.ToString());
			if (fieldCount >= 2)
			{
				if (version.Minor == 0)
				{
					sb.AppendFormat(".{0}", version.Minor.ToString());
				}
				else if (((version.Minor % 10) == 0) && (fieldCount == 2))
				{
					sb.AppendFormat(".{0}", (version.Minor / 10).ToString());
				}
				else
				{
					sb.AppendFormat(".{0}.{1}", (version.Minor / 10).ToString(), (version.Minor % 10).ToString());
				}
			}
			if (fieldCount >= 3)
			{
				sb.AppendFormat(".{0}", version.Build.ToString());
			}
			if (fieldCount == 4)
			{
				sb.AppendFormat(".{0}", version.Revision.ToString());
			}
			return sb.ToString();
		}

    /// <summary>
    /// Returns the latest installed MapSurfer version.
    /// </summary>
    /// <returns></returns>
    public static string TryDetectInstalledVersion()
    {
      string result = null;

      string keyName = GetKeyName(string.Empty);

      RegistryKey regKey = GetRegistryKey(keyName, RegistryHive.LocalMachine);

      if (regKey == null)
      {
        regKey = GetRegistryKey(keyName, RegistryHive.CurrentUser);
      }

      if (regKey != null)
      {
        string[] keyNames = regKey.GetSubKeyNames();

        if (keyNames != null)
        {
          Version version = null;

          foreach (string key in keyNames)
          {
            Version version2 = null;
            if (Version.TryParse(key, out version2))
            {
              if (version == null)
              {
                version = version2;
                result = key;
              }
              else
              {
                if (version2 > version)
                {
                  version = version2;
                  result = key;
                }
              }
            }
          }
        }

        regKey.Dispose();
        regKey = null;
      }

      return result;
    }

    public static bool IsMSNVersionInstalled(string version)
    {
      if (!m_checkVersionValidity)
        return true;

      string keyName = GetKeyName(version);
      RegistryKey regKey = GetRegistryKey(keyName, RegistryHive.LocalMachine);

      if (regKey == null)
      {
        regKey = GetRegistryKey(keyName, RegistryHive.CurrentUser);
      }

      if (regKey != null)
      {
        regKey.Dispose();
        regKey = null;

        return true;
      }

      return false;
    }

    public static Version GetMSNVersionFull()
    {
      return Assembly.GetExecutingAssembly().GetName().Version;
    }

		public static string GetMSNVersion(Assembly assembly)
		{
			return GetVersionNumberString(assembly.GetName().Version, 2); 
		}

    public static void SetCurrentMSNVersion(string version)
    {
      m_msnCurrentVersion = version;
    }

		public static string GetCurrentMSNVersion()
		{
      if (m_msnCurrentVersion == null)
      {
        Assembly assembly = Assembly.GetExecutingAssembly();
        string version = GetVersionNumberString(assembly.GetName().Version, 2);

        if (!IsMSNVersionInstalled(version))
          version = TryDetectInstalledVersion();

        m_msnCurrentVersion = version;
      }

      return m_msnCurrentVersion;
		}

		private static RegistryKey GetBaseKey(RegistryHive regHive)
		{
			RegistryKey regKey = null;
			if (Is64BitOperatingSystem())
			{
				regKey = RegistryKey.OpenBaseKey(regHive, RegistryView.Registry64);
			}
			else
			{
				regKey = RegistryKey.OpenBaseKey(regHive, RegistryView.Registry32);
			}

			return regKey;
		}

		public static RegistryKey GetRegistryKey(string keyName, RegistryHive regHive, bool writable = false)
		{
			RegistryKey regKey = GetBaseKey(regHive);
			RegistryKey result = regKey.OpenSubKey(keyName, writable);

			regKey.Dispose();
			regKey = null;

			return result;
		}

    public static string GetMSNCorePath()
    {
      string installPath = GetMSNInstallPath();
      return Path.Combine(installPath, "Core");
    }

    private static string GetKeyName(string version)
    {
      return @"Software\MapSurfer.NET\" + version;
    }

    public static string GetMSNInstallPath(string version)
    {
      string installPath = null;
      string keyName = GetKeyName(version);

      RegistryKey regKey = GetRegistryKey(keyName, RegistryHive.LocalMachine);

      if (regKey != null)
      {
        installPath = (string)regKey.GetValue("InstallPath");

        // It might be that InstallPath is null as the previous version has been uninstalled or re-installed only for the current user. 
        if (string.IsNullOrEmpty(installPath))
        {
          regKey.Dispose();
          regKey = null;
        }
      }

      if (regKey == null)
      {
        regKey = GetRegistryKey(keyName, RegistryHive.CurrentUser);
      }

      if (regKey == null)
        throw new IOException("Unable to determine installed version.");

      installPath = (string)regKey.GetValue("InstallPath");

      if (string.IsNullOrEmpty(installPath))
        throw new IOException("InstallPath is null.");

      regKey.Dispose();
      regKey = null;

      return installPath;
    }

		public static string GetMSNInstallPath()
		{
			if (m_msnInstallPath == null)
			{
				string strVersion = GetCurrentMSNVersion();

        m_msnInstallPath = GetMSNInstallPath(strVersion);
			}

			return m_msnInstallPath;
		}

		public static void Install(string path, string version, string buildVersion)
		{
			RegistryHive rh = RegistryHive.LocalMachine;

      string keyName = GetKeyName(version);
      RegistryKey regKey = GetRegistryKey(keyName, rh, true);
			if (regKey == null)
			{
				RegistryKey regKey2 = null;
				try
				{
					regKey2 = GetRegistryKey(@"Software\", rh, true);

          if (regKey2 == null)
          {
            throw new Exception();
          }
				}
				catch
				{
#if MONO
					RegistryKey baseKey = GetBaseKey(rh);
					regKey2 = baseKey.CreateSubKey("Software");
#endif
				}

				if (regKey2 != null)
				{
					regKey = regKey2.CreateSubKey(@"MapSurfer.NET\" + version, RegistryKeyPermissionCheck.ReadWriteSubTree);
					regKey2.Dispose();
          regKey2 = null;
				}
			}

      if (regKey == null)
        throw new IOException(string.Format(@"Registry key '\Software\MapSurfer.NET\{0}' not found.", version));

			regKey.SetValue("InstallPath", path);
			regKey.SetValue("Version", buildVersion);
			regKey.Flush();
			regKey.Dispose();
      regKey = null;
		}

    public static bool Is64BitOperatingSystem()
    {
      if (IntPtr.Size == 8)  // 64-bit programs run only on Win64
      {
        return true;
      }
      else  // 32-bit programs run on both 32-bit and 64-bit Windows
      {
#if MONO
        return false; // TODO
#else
        // Detect whether the current process is a 32-bit process 
        // running on a 64-bit system.
        bool flag;
        return ((IsWin32MethodExist("kernel32.dll", "IsWow64Process") &&
            IsWow64Process(GetCurrentProcess(), out flag)) && flag);
#endif
      }
    }

#if !MONO
    public static bool IsWin32MethodExist(string moduleName, string methodName)
    {
      PlatformID pID = Environment.OSVersion.Platform;

      if (pID != PlatformID.MacOSX && pID != PlatformID.Unix && pID != PlatformID.Xbox)
      {
        IntPtr moduleHandle = GetModuleHandle(moduleName);

        if (moduleHandle == IntPtr.Zero)
        {
          return false;
        }

        return (GetProcAddress(moduleHandle, methodName) != IntPtr.Zero);
      }
      else
      {
        return false;
      }
    }

    [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr module, string procName);

		[DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool lpSystemInfo);

		[DllImport("kernel32.dll")]
    private static extern IntPtr GetCurrentProcess();

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr GetModuleHandle(string moduleName);
#endif
  }
}
