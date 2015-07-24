namespace MapSurfer.Samples
{
  partial class frmMain
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuZoomToExtent = new System.Windows.Forms.ToolStripMenuItem();
      this.zoomToExtentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuZoomToExtent});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(699, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenProject,
            this.toolStripMenuItem1,
            this.mnuExit});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // mnuOpenProject
      // 
      this.mnuOpenProject.Name = "mnuOpenProject";
      this.mnuOpenProject.Size = new System.Drawing.Size(152, 22);
      this.mnuOpenProject.Text = "Open Project...";
      this.mnuOpenProject.Click += new System.EventHandler(this.mnuOpenProject_Click);
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
      // mnuZoomToExtent
      // 
      this.mnuZoomToExtent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToExtentToolStripMenuItem});
      this.mnuZoomToExtent.Name = "mnuZoomToExtent";
      this.mnuZoomToExtent.Size = new System.Drawing.Size(44, 20);
      this.mnuZoomToExtent.Text = "View";
      // 
      // zoomToExtentToolStripMenuItem
      // 
      this.zoomToExtentToolStripMenuItem.Name = "zoomToExtentToolStripMenuItem";
      this.zoomToExtentToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
      this.zoomToExtentToolStripMenuItem.Text = "Zoom To Extent";
      this.zoomToExtentToolStripMenuItem.Click += new System.EventHandler(this.mnuZoomToExtent_Click);
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(699, 536);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "frmMain";
      this.Text = "MapViewer Demo";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem mnuOpenProject;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem mnuExit;
    private System.Windows.Forms.ToolStripMenuItem mnuZoomToExtent;
    private System.Windows.Forms.ToolStripMenuItem zoomToExtentToolStripMenuItem;
  }
}

