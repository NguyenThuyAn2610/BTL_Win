﻿using System;
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
    public partial class FormCHANGEPASS : Form
    {
        string TenDangNhap = "";
        string MatKhau = "";
        string Quyen = "";
        string Email = "";
        public FormCHANGEPASS()
        {
            InitializeComponent();
        }
        public FormCHANGEPASS(string TenDangNhap, string MatKhau, string Quyen, string Email)
        {
            this.TenDangNhap = TenDangNhap;
            this.MatKhau = MatKhau;
            this.Quyen = Quyen;
            this.Email = Email;
            InitializeComponent();
        }

        private void FormCHANGEPASS_Load(object sender, EventArgs e)
        {

        }
    }
}
