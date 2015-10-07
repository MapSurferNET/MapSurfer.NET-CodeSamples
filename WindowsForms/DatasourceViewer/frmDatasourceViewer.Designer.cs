namespace DatasourceViewer
{
  partial class frmDatasourceViewer
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatasourceViewer));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuConnect = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuDiconnect = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.txtFilter = new System.Windows.Forms.TextBox();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tbpResults = new System.Windows.Forms.TabPage();
      this.dgvResults = new System.Windows.Forms.DataGridView();
      this.tbpMessages = new System.Windows.Forms.TabPage();
      this.txtMessages = new System.Windows.Forms.TextBox();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.btnExecute = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.lblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblEmptySpace = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblRows = new System.Windows.Forms.ToolStripStatusLabel();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.tbpResults.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
      this.tbpMessages.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1029, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // mnuFile
      // 
      this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnect,
            this.mnuDiconnect,
            this.toolStripMenuItem1,
            this.mnuExit});
      this.mnuFile.Name = "mnuFile";
      this.mnuFile.Size = new System.Drawing.Size(37, 20);
      this.mnuFile.Text = "File";
      // 
      // mnuConnect
      // 
      this.mnuConnect.Name = "mnuConnect";
      this.mnuConnect.Size = new System.Drawing.Size(152, 22);
      this.mnuConnect.Text = "Connect...";
      this.mnuConnect.Click += new System.EventHandler(this.mnuConnect_Click);
      // 
      // mnuDiconnect
      // 
      this.mnuDiconnect.Name = "mnuDiconnect";
      this.mnuDiconnect.Size = new System.Drawing.Size(152, 22);
      this.mnuDiconnect.Text = "Disconnect";
      this.mnuDiconnect.Click += new System.EventHandler(this.mnuDiconnect_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
      // 
      // mnuExit
      // 
      this.mnuExit.Name = "mnuExit";
      this.mnuExit.Size = new System.Drawing.Size(152, 22);
      this.mnuExit.Text = "Exit";
      this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 49);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.txtFilter);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tabControl);
      this.splitContainer1.Size = new System.Drawing.Size(1029, 599);
      this.splitContainer1.SplitterDistance = 115;
      this.splitContainer1.TabIndex = 1;
      // 
      // txtFilter
      // 
      this.txtFilter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtFilter.Location = new System.Drawing.Point(0, 0);
      this.txtFilter.Multiline = true;
      this.txtFilter.Name = "txtFilter";
      this.txtFilter.Size = new System.Drawing.Size(1029, 115);
      this.txtFilter.TabIndex = 0;
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.tbpResults);
      this.tabControl.Controls.Add(this.tbpMessages);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.ImageList = this.imageList1;
      this.tabControl.Location = new System.Drawing.Point(0, 0);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(1029, 480);
      this.tabControl.TabIndex = 0;
      // 
      // tbpResults
      // 
      this.tbpResults.Controls.Add(this.dgvResults);
      this.tbpResults.ImageIndex = 0;
      this.tbpResults.Location = new System.Drawing.Point(4, 23);
      this.tbpResults.Name = "tbpResults";
      this.tbpResults.Padding = new System.Windows.Forms.Padding(3);
      this.tbpResults.Size = new System.Drawing.Size(1021, 453);
      this.tbpResults.TabIndex = 0;
      this.tbpResults.Text = "Results";
      this.tbpResults.UseVisualStyleBackColor = true;
      // 
      // dgvResults
      // 
      this.dgvResults.BackgroundColor = System.Drawing.SystemColors.Window;
      this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvResults.Location = new System.Drawing.Point(3, 3);
      this.dgvResults.Name = "dgvResults";
      this.dgvResults.Size = new System.Drawing.Size(1015, 447);
      this.dgvResults.TabIndex = 0;
      // 
      // tbpMessages
      // 
      this.tbpMessages.Controls.Add(this.txtMessages);
      this.tbpMessages.ImageIndex = 1;
      this.tbpMessages.Location = new System.Drawing.Point(4, 23);
      this.tbpMessages.Name = "tbpMessages";
      this.tbpMessages.Padding = new System.Windows.Forms.Padding(3);
      this.tbpMessages.Size = new System.Drawing.Size(1021, 492);
      this.tbpMessages.TabIndex = 1;
      this.tbpMessages.Text = "Messages";
      this.tbpMessages.UseVisualStyleBackColor = true;
      // 
      // txtMessages
      // 
      this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtMessages.Location = new System.Drawing.Point(3, 3);
      this.txtMessages.Multiline = true;
      this.txtMessages.Name = "txtMessages";
      this.txtMessages.Size = new System.Drawing.Size(1015, 486);
      this.txtMessages.TabIndex = 1;
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "table.png");
      this.imageList1.Images.SetKeyName(1, "messages.png");
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExecute,
            this.toolStripSeparator1,
            this.toolStripLabel1});
      this.toolStrip1.Location = new System.Drawing.Point(0, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(1029, 25);
      this.toolStrip1.TabIndex = 2;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // btnExecute
      // 
      this.btnExecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExecute.Image")));
      this.btnExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnExecute.Name = "btnExecute";
      this.btnExecute.Size = new System.Drawing.Size(67, 22);
      this.btnExecute.Text = "Execute";
      this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(38, 22);
      this.toolStripLabel1.Text = "Rows:";
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnectionStatus,
            this.lblEmptySpace,
            this.lblRows});
      this.statusStrip1.Location = new System.Drawing.Point(0, 648);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(1029, 24);
      this.statusStrip1.TabIndex = 3;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // lblConnectionStatus
      // 
      this.lblConnectionStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.lblConnectionStatus.Name = "lblConnectionStatus";
      this.lblConnectionStatus.Size = new System.Drawing.Size(120, 19);
      this.lblConnectionStatus.Text = "Status: disconnected";
      // 
      // lblEmptySpace
      // 
      this.lblEmptySpace.Name = "lblEmptySpace";
      this.lblEmptySpace.Size = new System.Drawing.Size(849, 19);
      this.lblEmptySpace.Spring = true;
      this.lblEmptySpace.Text = " ";
      // 
      // lblRows
      // 
      this.lblRows.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
      this.lblRows.Name = "lblRows";
      this.lblRows.Size = new System.Drawing.Size(45, 19);
      this.lblRows.Text = "0 rows";
      // 
      // frmDatasourceViewer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1029, 672);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "frmDatasourceViewer";
      this.Text = "Datasource Viewer";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.tabControl.ResumeLayout(false);
      this.tbpResults.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
      this.tbpMessages.ResumeLayout(false);
      this.tbpMessages.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem mnuFile;
    private System.Windows.Forms.ToolStripMenuItem mnuConnect;
    private System.Windows.Forms.ToolStripMenuItem mnuDiconnect;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem mnuExit;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TextBox txtFilter;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tbpResults;
    private System.Windows.Forms.DataGridView dgvResults;
    private System.Windows.Forms.TabPage tbpMessages;
    private System.Windows.Forms.TextBox txtMessages;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton btnExecute;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
    private System.Windows.Forms.ToolStripStatusLabel lblEmptySpace;
    private System.Windows.Forms.ToolStripStatusLabel lblRows;
  }
}

