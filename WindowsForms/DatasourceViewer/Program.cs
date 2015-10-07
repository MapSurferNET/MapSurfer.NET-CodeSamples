//==========================================================================================
//
//		Copyright (c) 2008-2015, MapSurfer.NET
//
//    Authors: Maxim Rylov
//
//==========================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using MapSurfer.Utilities;

namespace DatasourceViewer
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
      MSNUtility.SetCurrentMSNVersion(version);
      AssemblyLoader.Register(AppDomain.CurrentDomain, version);

      Application.Run(new frmDatasourceViewer());
    }
  }
}
