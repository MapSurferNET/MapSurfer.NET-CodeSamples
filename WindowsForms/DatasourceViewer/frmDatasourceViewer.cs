//==========================================================================================
//
//		Copyright (c) 2008-2015, MapSurfer.NET
//
//    Authors: Maxim Rylov
//
//==========================================================================================
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using MapSurfer.Data;
using MapSurfer.Data.Providers;
using MapSurfer.Data.Expressions;
using MapSurfer.Data.Filters;
using MapSurfer.Geometries;
using MapSurfer.Utilities;

namespace DatasourceViewer
{
  public partial class frmDatasourceViewer : Form
  {
    private IDataSourceProvider m_dsProvider;
    private NumericUpDown nudRowsLimit;

    public frmDatasourceViewer()
    {
      InitializeComponent();

      ToolStripNumberControl ctrl = new ToolStripNumberControl();
      ctrl.Width = 100;
      toolStrip1.Items.Add((ToolStripItem)ctrl);
      nudRowsLimit = (NumericUpDown)ctrl.Control;

      dgvResults.AutoSize = true;

      // Initialize dependencies and internal structures
      CoreUtility.Initialize();
      CoreUtility.CheckAndFixCulture();

      UpdateControls();
    }

    private void btnExecute_Click(object sender, EventArgs e)
    {
      if (m_dsProvider != null)
      {
        dgvResults.Rows.Clear();

        try
        {
          // Comment the following line for versions less or equal v. 2.2
          IExpressionEvaluationContext exprEvalContext = new DefaultExpressionEvaluationContext();

          IFeatureExpressionFilter filterExpr = null;
          
          if (txtFilter.Text.Trim() != string.Empty)
          {
            filterExpr = new FeatureExpressionFilter();
            filterExpr.Compile(txtFilter.Text, m_dsProvider.Information.Attributes);
          }

          Envelope env = m_dsProvider.GetExtent();
          List<string> properties = m_dsProvider.Information.GetAttributeNames();
          properties.Remove("_geom_");
          DataSourceQuery query = new DataSourceQuery(env, 1, null, null, properties);
          IFeatureDataReader dataReader = m_dsProvider.GetFeatureReader(query, FeatureFactory.Default);
          int i = 0;

          if (dataReader != null)
          {
            int rowsLimit = (int)nudRowsLimit.Value;
            while (dataReader.Read())
            {
              Feature feature = dataReader.GetFeature();
              if (rowsLimit > 0 && i >= rowsLimit)
              {
                break;
              }

              bool bFeaturePass = true;
              if (filterExpr != null)
              {
                // Apply a given expression to filter features from the data source.
                // Change the following line for versions less or equal v. 2.2 by replacing the expression with filterExpr.Pass(feature)
                bFeaturePass = filterExpr.Pass(feature, exprEvalContext);
              }

              if (bFeaturePass)
              {
                DataGridViewRow row = (DataGridViewRow)dgvResults.Rows[0].Clone();

                object[] values = new object[feature.Attributes.Count];
                int j = 0;

                // Enumerate feature properties and fill the grid view.
                foreach (string attr in feature.Attributes.EnumerateNames())
                {
                  object value = feature.GetPropertyValue(attr);
                  if (attr == "_geom_")
                    value = value.ToString().Replace("MapSurfer.Geometries.", "");
                  values[j] = value;

                  row.Cells[j].Value = value;

                  j++;
                }

                row.SetValues(values);
                dgvResults.Rows.Add(row);

                i++;
              }
            }
             
            DisposeUtility.Dispose(ref dataReader);
          }

          lblRows.Text = i.ToString() + " rows";
          UpdateMessage(string.Format("{0} row(s) fetched.", i));
        }
        catch (Exception ex)
        {
          UpdateMessage("Exception: " + ex.Message);
        }
      }
    }

    private void mnuExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void mnuConnect_Click(object sender, EventArgs e)
    {
      try
      {
        using (frmChooseDatasource frmChooseDatasource = new frmChooseDatasource())
        {
          if (frmChooseDatasource.ShowDialog() == System.Windows.Forms.DialogResult.OK)
          {
            IDataSourceProviderEditor provEditor = DataSourceProviderManager.CreateProviderEditor(frmChooseDatasource.SelectedProvider);
            Form frmEditor = (Form)provEditor;
            if (frmEditor.ShowDialog() == DialogResult.OK)
            {
              this.Cursor = Cursors.WaitCursor;

              m_dsProvider = (DataSourceProvider)provEditor.CreateProvider();

              UpdateControls();
              UpdateDataGridView(m_dsProvider.Information);

              UpdateMessage("Data source of type '" + frmChooseDatasource.SelectedProvider + "' was successfully connected.");

              this.Cursor = Cursors.Default;
            }
          }
        }
      }
      catch(Exception ex)
      {
        this.Cursor = Cursors.Default;
        UpdateMessage("Exception: " + ex.Message);
        MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void mnuDiconnect_Click(object sender, EventArgs e)
    {
      if (m_dsProvider != null)
      {
        m_dsProvider.Close();
        m_dsProvider.Dispose();
        m_dsProvider = null;

        UpdateControls();
        UpdateDataGridView(null);

        UpdateMessage("Data source has been disconnected");
      }
    }

    private void UpdateMessage(string message)
    {
      txtMessages.Text = message;
    }

    private void UpdateDataGridView(DataSourceInfo dsInfo)
    {
      dgvResults.Columns.Clear();

      if (dsInfo != null)
      {
        SuspendDrawing(dgvResults);

        foreach (DataFieldAttribute attr in dsInfo.Attributes)
        {
          string fieldName = attr.Name == "_geom_" ? "geom" : attr.Name;

          DataGridViewColumn clm = new DataGridViewColumn();
          clm.CellTemplate = new DataGridViewTextBoxCell();
          clm.DataPropertyName = fieldName;
          clm.ValueType =attr.Name == "_geom_" ? typeof(string): attr.DataType;
          clm.HeaderText = fieldName;

          dgvResults.Columns.Add(clm);
        }

        ResumeDrawing(dgvResults);
      }
    }

    private void UpdateControls()
    {
      bool bConnected = m_dsProvider != null && m_dsProvider.IsInitialized;

      btnExecute.Enabled = bConnected;
      lblConnectionStatus.Text = "Status: " + (bConnected ? "connected" : "disconnected");
      lblRows.Text = "0 rows";
      statusStrip1.Refresh();

      mnuConnect.Enabled = !bConnected;
      mnuDiconnect.Enabled = bConnected;
    }

    #region Redraw Suspend/Resume

    [DllImport("user32.dll", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
    private const int WM_SETREDRAW = 0xB;

    private void SuspendDrawing(Control target)
    {
      SendMessage(target.Handle, WM_SETREDRAW, 0, 0);
    }

    private static void ResumeDrawing(Control target) { ResumeDrawing(target, true); }
    private static void ResumeDrawing(Control target, bool redraw)
    {
      SendMessage(target.Handle, WM_SETREDRAW, 1, 0);

      if (redraw)
      {
        target.Refresh();
      }
    }
    #endregion
  }
}
