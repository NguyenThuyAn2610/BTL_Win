
namespace QuanLyThuVien.GiayTo
{
    partial class FormGIAYTO
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
            this.menuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuMượnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuTrảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuDànhChoThủThưToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchPhiếuMượnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchPhiếuMượnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuTrảSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchPhiếuTrảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuPhạtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuGiaHạnSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuDànhChoNhânViênKhoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuNhậpSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuThanhLýSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNhanVien,
            this.phiếuDànhChoThủThưToolStripMenuItem,
            this.phiếuDànhChoNhânViênKhoToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuNhanVien
            // 
            this.menuNhanVien.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phiếuMượnToolStripMenuItem,
            this.phiếuTrảToolStripMenuItem});
            this.menuNhanVien.Name = "menuNhanVien";
            this.menuNhanVien.Size = new System.Drawing.Size(128, 24);
            this.menuNhanVien.Text = "Phiếu Mượn/Trả";
            this.menuNhanVien.Click += new System.EventHandler(this.menuNhanVien_Click);
            // 
            // phiếuMượnToolStripMenuItem
            // 
            this.phiếuMượnToolStripMenuItem.Name = "phiếuMượnToolStripMenuItem";
            this.phiếuMượnToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.phiếuMượnToolStripMenuItem.Text = "Đăng kí mượn sách";
            this.phiếuMượnToolStripMenuItem.Click += new System.EventHandler(this.phiếuMượnToolStripMenuItem_Click);
            // 
            // phiếuTrảToolStripMenuItem
            // 
            this.phiếuTrảToolStripMenuItem.Name = "phiếuTrảToolStripMenuItem";
            this.phiếuTrảToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.phiếuTrảToolStripMenuItem.Text = "Trả sách";
            this.phiếuTrảToolStripMenuItem.Click += new System.EventHandler(this.phiếuTrảToolStripMenuItem_Click);
            // 
            // phiếuDànhChoThủThưToolStripMenuItem
            // 
            this.phiếuDànhChoThủThưToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchPhiếuMượnToolStripMenuItem,
            this.danhSáchPhiếuMượnToolStripMenuItem1,
            this.phiếuTrảSáchToolStripMenuItem,
            this.danhSáchPhiếuTrảToolStripMenuItem,
            this.phiếuPhạtToolStripMenuItem,
            this.phiếuGiaHạnSáchToolStripMenuItem});
            this.phiếuDànhChoThủThưToolStripMenuItem.Name = "phiếuDànhChoThủThưToolStripMenuItem";
            this.phiếuDànhChoThủThưToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.phiếuDànhChoThủThưToolStripMenuItem.Text = "Phiếu dành cho Thủ Thư";
            // 
            // danhSáchPhiếuMượnToolStripMenuItem
            // 
            this.danhSáchPhiếuMượnToolStripMenuItem.Name = "danhSáchPhiếuMượnToolStripMenuItem";
            this.danhSáchPhiếuMượnToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.danhSáchPhiếuMượnToolStripMenuItem.Text = "Danh sách chờ phiếu mượn";
            this.danhSáchPhiếuMượnToolStripMenuItem.Click += new System.EventHandler(this.danhSáchPhiếuMượnToolStripMenuItem_Click);
            // 
            // danhSáchPhiếuMượnToolStripMenuItem1
            // 
            this.danhSáchPhiếuMượnToolStripMenuItem1.Name = "danhSáchPhiếuMượnToolStripMenuItem1";
            this.danhSáchPhiếuMượnToolStripMenuItem1.Size = new System.Drawing.Size(272, 26);
            this.danhSáchPhiếuMượnToolStripMenuItem1.Text = "Danh sách phiếu mượn";
            this.danhSáchPhiếuMượnToolStripMenuItem1.Click += new System.EventHandler(this.danhSáchPhiếuMượnToolStripMenuItem1_Click);
            // 
            // phiếuTrảSáchToolStripMenuItem
            // 
            this.phiếuTrảSáchToolStripMenuItem.Name = "phiếuTrảSáchToolStripMenuItem";
            this.phiếuTrảSáchToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.phiếuTrảSáchToolStripMenuItem.Text = "Danh sách chờ phiếu trả";
            this.phiếuTrảSáchToolStripMenuItem.Click += new System.EventHandler(this.phiếuTrảSáchToolStripMenuItem_Click);
            // 
            // danhSáchPhiếuTrảToolStripMenuItem
            // 
            this.danhSáchPhiếuTrảToolStripMenuItem.Name = "danhSáchPhiếuTrảToolStripMenuItem";
            this.danhSáchPhiếuTrảToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.danhSáchPhiếuTrảToolStripMenuItem.Text = "Danh sách phiếu trả";
            this.danhSáchPhiếuTrảToolStripMenuItem.Click += new System.EventHandler(this.danhSáchPhiếuTrảToolStripMenuItem_Click);
            // 
            // phiếuPhạtToolStripMenuItem
            // 
            this.phiếuPhạtToolStripMenuItem.Name = "phiếuPhạtToolStripMenuItem";
            this.phiếuPhạtToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.phiếuPhạtToolStripMenuItem.Text = "Phiếu phạt";
            this.phiếuPhạtToolStripMenuItem.Click += new System.EventHandler(this.phiếuPhạtToolStripMenuItem_Click);
            // 
            // phiếuGiaHạnSáchToolStripMenuItem
            // 
            this.phiếuGiaHạnSáchToolStripMenuItem.Name = "phiếuGiaHạnSáchToolStripMenuItem";
            this.phiếuGiaHạnSáchToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.phiếuGiaHạnSáchToolStripMenuItem.Text = "Phiếu gia hạn sách";
            this.phiếuGiaHạnSáchToolStripMenuItem.Click += new System.EventHandler(this.phiếuGiaHạnSáchToolStripMenuItem_Click);
            // 
            // phiếuDànhChoNhânViênKhoToolStripMenuItem1
            // 
            this.phiếuDànhChoNhânViênKhoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phiếuNhậpSáchToolStripMenuItem,
            this.phiếuThanhLýSáchToolStripMenuItem});
            this.phiếuDànhChoNhânViênKhoToolStripMenuItem1.Name = "phiếuDànhChoNhânViênKhoToolStripMenuItem1";
            this.phiếuDànhChoNhânViênKhoToolStripMenuItem1.Size = new System.Drawing.Size(222, 24);
            this.phiếuDànhChoNhânViênKhoToolStripMenuItem1.Text = "Phiếu dành cho Nhân viên kho";
            // 
            // phiếuNhậpSáchToolStripMenuItem
            // 
            this.phiếuNhậpSáchToolStripMenuItem.Name = "phiếuNhậpSáchToolStripMenuItem";
            this.phiếuNhậpSáchToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.phiếuNhậpSáchToolStripMenuItem.Text = "Phiếu nhập sách";
            this.phiếuNhậpSáchToolStripMenuItem.Click += new System.EventHandler(this.phiếuNhậpSáchToolStripMenuItem_Click);
            // 
            // phiếuThanhLýSáchToolStripMenuItem
            // 
            this.phiếuThanhLýSáchToolStripMenuItem.Name = "phiếuThanhLýSáchToolStripMenuItem";
            this.phiếuThanhLýSáchToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.phiếuThanhLýSáchToolStripMenuItem.Text = "Phiếu thanh lý sách";
            this.phiếuThanhLýSáchToolStripMenuItem.Click += new System.EventHandler(this.phiếuThanhLýSáchToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 439);
            this.panel1.TabIndex = 1;
            // 
            // FormGIAYTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1067, 467);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGIAYTO";
            this.Text = "FormGIAYTO";
            this.Load += new System.EventHandler(this.FormGIAYTO_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem phiếuDànhChoThủThưToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuMượnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuTrảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuDànhChoNhânViênKhoToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem danhSáchPhiếuMượnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchPhiếuMượnToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem phiếuTrảSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchPhiếuTrảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuNhậpSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuThanhLýSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuPhạtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuGiaHạnSáchToolStripMenuItem;
    }
}