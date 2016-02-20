//==========================================================================================
//
//		MapSurfer.Samples
//		Copyright (c) 2008-2015, MapSurfer.NET
//
//    Authors: Maxim Rylov
//
//==========================================================================================
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using MapSurfer;
using MapSurfer.Rendering;
using MapSurfer.Utilities;

namespace ConsoleApplication
{
  class Program
  {
    static Program()
    {
      // Register assembly loader
      // Uncomment if needed
      string version = MSNUtility.TryDetectInstalledVersion();
      MSNUtility.SetCurrentMSNVersion(version);
      AssemblyLoader.Register(AppDomain.CurrentDomain, version);
    }

    static void Main(string[] args) 
    {
      // Initialize internals 
      CoreUtility.Initialize();

      string mapPath = @"C:\Users\Public\Documents\MapSurfer.NET\2.4\Samples\Projects\Bremen.msnpx";// @"\map\example.msnpx";
      // Load map from file and initialize data source providers.
      using (Map map = Map.FromFile(mapPath, true))
      {
        map.Size = new SizeF(600, 600);
        map.ZoomToFullExtent();

        using (IRenderer renderer = RendererManager.CreateDefaultInstance())
        {
          using (RenderSurface surface = RenderContext.Render(map, renderer))
          {
            surface.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "msn_output.png"), new object[] { ImageFormat.Png });
          }
        }
      }
    }
  }
}
