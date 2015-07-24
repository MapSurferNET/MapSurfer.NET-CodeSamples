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
using System.IO;
using System.Windows.Forms;

using MapSurfer.IO;
using MapSurfer.IO.FileTypes;
using MapSurfer.Geometries;
using MapSurfer.Reflection;
using MapSurfer.Utilities;
using MapSurfer.Windows.Forms;
using MapSurfer.Rendering;

namespace MapSurfer.Samples
{
  public partial class frmMain : Form
  {
    private MapViewer m_mapViewer;
    private Renderer m_renderer;

    public frmMain()
    {
      InitializeComponent();

      CoreUtility.Initialize(); 
      CoreUtility.CheckAndFixCulture();

      m_renderer = (MapSurfer.Rendering.Renderer)MapSurfer.Rendering.RendererManager.CreateDefaultInstance();

      m_mapViewer = new MapViewer();
      m_mapViewer.Dock = DockStyle.Fill;
      m_mapViewer.RedrawOnAttach = true;
      m_mapViewer.ActiveTool = MapTool.Zoom;
      m_mapViewer.RedrawOnResizing = true;
      this.Controls.Add(m_mapViewer);

      // Initialize file types
      FileTypeManager<Map> ftmMap = FileTypeManagerCache.GetFileTypeManager<Map>();
      ftmMap.AddSearchPath(typeof(Map).Assembly.GetLocation());
      ftmMap.AddSearchPath(MSNEnvironment.GetFolderPath(MSNSpecialFolder.StylingFormats));
      ftmMap.InitializeFileTypes();

      // Load map project
      string fileName = Path.Combine(MSNUtility.GetMSNInstallPath(), @"Samples\Projects\Bremen.msnpx");
      if (File.Exists(fileName))
      {
        LoadProject(fileName);

        Envelope env = new Envelope(978779.133679862, 6990983.0938755, 990289.718456316, 6997278.67914107); //map.Extent
        m_mapViewer.ZoomToEnvelope(env);
      }
    }

    private void LoadProject(string fileName)
    {
      Map map = Map.FromFile(fileName);
      map.Initialize(Path.GetDirectoryName(fileName), true);
      m_mapViewer.Map = map;
      m_mapViewer.ZoomToFullExtent();
    }

    private void mnuExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void mnuOpenProject_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        FileTypeCollection<Map> ftc = FileTypeManagerCache.GetFileTypeCollection<Map>(FileTypeFlags.ReadSupport);
        ofd.Filter = ftc.GetFileTypesFilter(false);

        if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          LoadProject(ofd.FileName);
        }
      }
    }

    private void mnuZoomToExtent_Click(object sender, EventArgs e)
    {
      m_mapViewer.ZoomToFullExtent();
      m_mapViewer.Redraw();
    }
  }
}
