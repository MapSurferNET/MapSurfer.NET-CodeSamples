namespace DatasourceViewer
{
  partial class frmChooseDatasource
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.cmbDatasourceTypes = new System.Windows.Forms.ComboBox();
      this.btnOk = new System.Windows.Forms.Button();
      this.lblDatasourceTypes = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // cmbDatasourceTypes
      // 
      this.cmbDatasourceTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbDatasourceTypes.FormattingEnabled = true;
      this.cmbDatasourceTypes.Location = new System.Drawing.Point(11, 24);
      this.cmbDatasourceTypes.Name = "cmbDatasourceTypes";
      this.cmbDatasourceTypes.Size = new System.Drawing.Size(169, 21);
      this.cmbDatasourceTypes.TabIndex = 0;
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Location = new System.Drawing.Point(105, 65);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // lblDatasourceTypes
      // 
      this.lblDatasourceTypes.AutoSize = true;
      this.lblDatasourceTypes.Location = new System.Drawing.Point(8, 8);
      this.lblDatasourceTypes.Name = "lblDatasourceTypes";
      this.lblDatasourceTypes.Size = new System.Drawing.Size(93, 13);
      this.lblDatasourceTypes.TabIndex = 2;
      this.lblDatasourceTypes.Text = "Datasource types:";
      // 
      // label1
      // 
      this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.label1.Location = new System.Drawing.Point(8, 58);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(178, 2);
      this.label1.TabIndex = 3;
      this.label1.Text = "label1";
      // 
      // frmChooseDatasource
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(188, 92);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lblDatasourceTypes);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.cmbDatasourceTypes);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmChooseDatasource";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Choose Datasource Type";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cmbDatasourceTypes;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Label lblDatasourceTypes;
    private System.Windows.Forms.Label label1;
  }
}