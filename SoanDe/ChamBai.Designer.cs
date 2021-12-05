
namespace SoanDe
{
    partial class ChamBai
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
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFile = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBaiLam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMade = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.exportFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(96, 27);
            this.openFile.Text = "&Open File";
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // exportFile
            // 
            this.exportFile.Name = "exportFile";
            this.exportFile.Size = new System.Drawing.Size(73, 27);
            this.exportFile.Text = "&Export";
            // 
            // txtBaiLam
            // 
            this.txtBaiLam.Enabled = false;
            this.txtBaiLam.Location = new System.Drawing.Point(478, 34);
            this.txtBaiLam.Multiline = true;
            this.txtBaiLam.Name = "txtBaiLam";
            this.txtBaiLam.Size = new System.Drawing.Size(310, 404);
            this.txtBaiLam.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã đề";
            // 
            // txtMade
            // 
            this.txtMade.Enabled = false;
            this.txtMade.Location = new System.Drawing.Point(65, 59);
            this.txtMade.Multiline = true;
            this.txtMade.Name = "txtMade";
            this.txtMade.Size = new System.Drawing.Size(64, 22);
            this.txtMade.TabIndex = 3;
            // 
            // ChamBai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBaiLam);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChamBai";
            this.Text = "ChamBai";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem exportFile;
        private System.Windows.Forms.TextBox txtBaiLam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMade;
    }
}