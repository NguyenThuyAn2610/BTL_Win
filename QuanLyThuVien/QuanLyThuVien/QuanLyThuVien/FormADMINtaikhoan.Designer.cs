
namespace QuanLyThuVien
{
    partial class FormADMINtaikhoan
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
            this.nhânViênThưViệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caapjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhânViênThưViệnToolStripMenuItem,
            this.caapjToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // nhânViênThưViệnToolStripMenuItem
            // 
            this.nhânViênThưViệnToolStripMenuItem.Name = "nhânViênThưViệnToolStripMenuItem";
            this.nhânViênThưViệnToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.nhânViênThưViệnToolStripMenuItem.Text = "Quản lý tài khoản";
            this.nhânViênThưViệnToolStripMenuItem.Click += new System.EventHandler(this.nhânViênThưViệnToolStripMenuItem_Click);
            // 
            // caapjToolStripMenuItem
            // 
            this.caapjToolStripMenuItem.Name = "caapjToolStripMenuItem";
            this.caapjToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.caapjToolStripMenuItem.Text = "Cập nhật nhân viên";
            this.caapjToolStripMenuItem.Click += new System.EventHandler(this.caapjToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 479);
            this.panel1.TabIndex = 41;
            // 
            // FormADMINtaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1067, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormADMINtaikhoan";
            this.Text = "FormADMINtaikhoan";
            this.Load += new System.EventHandler(this.FormADMINtaikhoan_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nhânViênThưViệnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caapjToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}