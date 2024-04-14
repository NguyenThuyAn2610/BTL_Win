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
    public partial class FormDELETEACC : Form
    {
        string TenDangNhap = "";
        string MatKhau = "";
        string Quyen = "";
        string Email = "";
        public FormDELETEACC()
        {
            InitializeComponent();
        }
        public FormDELETEACC(string TenDangNhap, string MatKhau, string Quyen, string Email)
        {
            this.TenDangNhap = TenDangNhap;
            this.MatKhau = MatKhau;
            this.Quyen = Quyen;
            this.Email = Email;
            InitializeComponent();
        }

        private void FormDELETEACC_Load(object sender, EventArgs e)
        {

        }
    }
}
