using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.SETTING
{
    public partial class FormSETTING : Form
    {
        string TenDangNhap = "";
        string MatKhau = "";
        string Quyen = "";
        string Email = "";
        public FormSETTING()
        {
            InitializeComponent();
        }
        public FormSETTING(string TenDangNhap, string MatKhau, string Quyen, string Email)
        {
            this.TenDangNhap = TenDangNhap;
            this.MatKhau = MatKhau;
            this.Quyen = Quyen;
            this.Email = Email;
            InitializeComponent();
        }
        

        private void FormSETTING_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SETTING.FormCHANGEPASS fm1 = new SETTING.FormCHANGEPASS(TenDangNhap, MatKhau, Quyen, Email);
            fm1.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SETTING.FormDELETEACC fm1 = new SETTING.FormDELETEACC(TenDangNhap, MatKhau, Quyen, Email);
            fm1.Show();
        }
    }
}
