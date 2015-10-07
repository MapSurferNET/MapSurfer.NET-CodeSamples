//==========================================================================================
//
//		Copyright (c) 2008-2015, MapSurfer.NET
//
//    Authors: Maxim Rylov
//
//==========================================================================================
using System.Windows.Forms;

using MapSurfer.Data.Providers;

namespace DatasourceViewer
{
  public partial class frmChooseDatasource : Form
  {
    public frmChooseDatasource()
    {
      InitializeComponent();

      foreach (string provName in DataSourceProviderManager.Names)
      {
        cmbDatasourceTypes.Items.Add(provName);
      }

      cmbDatasourceTypes.SelectedIndex = 0;
    }

    public string SelectedProvider
    {
      get
      {
        return (string)cmbDatasourceTypes.SelectedItem;
      }
    }
  }
}
