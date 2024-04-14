using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    
    public partial class FormSACH : Form
    {
        string TenDangNhap = "";
        string Quyen = "";
        string Email = "";
        string MaKH = "";
        public FormSACH()
        {
            InitializeComponent();
        }
        public FormSACH(string Quyen, string Email, string TenDangNhap, string MaKH)
        {
            this.TenDangNhap = TenDangNhap;
            this.Email = Email;
            this.Quyen = Quyen;
            this.MaKH = MaKH;
            InitializeComponent();
        }
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
            panel2.Controls.Add(formChild);
            panel2.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            QuanLyThuVien.Formsach.FormTIMKIEMSACH formTKS = new QuanLyThuVien.Formsach.FormTIMKIEMSACH();
            ShowForm(formTKS);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QuanLyThuVien.Formsach.FormCAPNHATSACH formSX = new QuanLyThuVien.Formsach.FormCAPNHATSACH();
            ShowForm(formSX);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QuanLyThuVien.Formsach.FormCHITIETSACH formCTS = new QuanLyThuVien.Formsach.FormCHITIETSACH(MaKH, Quyen);
            ShowForm(formCTS);
        }

        private void FormSACH_Load(object sender, EventArgs e)
        {
            if(Quyen == "KhachHang")
            {
                button3.Visible = false;
            }
            
        }
    }
}
