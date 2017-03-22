//==========================================================================================
//
//		Copyright (c) 2008-2015, MapSurfer.NET
//
//    Authors: Maxim Rylov
//
//==========================================================================================
using System;
using System.IO;
using System.Windows.Forms;

using MapSurfer.Utilities;

namespace MapSurfer.Samples
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      string version = MSNUtility.TryDetectInstalledVersion();  // or one can define version manually MSNUtility.SetCurrentMSNVersion(..)
      MSNUtility.SetCurrentMSNVersion("2.6");
      AssemblyLoader.AddSearchPath(Path.Combine(MSNUtility.GetMSNInstallPath(), "Studio"));
      AssemblyLoader.Register(AppDomain.CurrentDomain, version);

      Application.Run(new frmMain());
    } 
  }
}
