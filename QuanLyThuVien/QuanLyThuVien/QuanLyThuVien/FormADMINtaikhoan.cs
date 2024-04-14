using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanLyThuVien
{
    public partial class FormADMINtaikhoan : Form
    {
        private Form currentChildForm;
        private void ShowForm(Form formChild)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = formChild;
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            formChild.Dock = DockStyle.Fill;
            panel1.Controls.Add(formChild);
            panel1.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();

        }
        string Quyen = "";
        string ChucVu = "";
        string MaNV = "";
        string MaNhanVien = "";
        string CV = "";
        public FormADMINtaikhoan(string Quyen, string ChucVu, string MaNV)
        {
            this.Quyen = Quyen;
            this.ChucVu = ChucVu;
            this.MaNV = MaNV;
            InitializeComponent();
        }
        public FormADMINtaikhoan()
        {
            InitializeComponent();
        }
        private void nhânViênThưViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new FormTAIKHOAN(Quyen));
        }

        private void caapjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new FormNHANVIEN());
        }

        private void FormADMINtaikhoan_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
