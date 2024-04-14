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
namespace QuanLyThuVien.GiayTo
{
    public partial class FormGIAYTO : Form
    {
        string Quyen = "";
        string MaKH = "";
        string MaNV = "";
        string ChucVu = "";
        public FormGIAYTO()
        {
            InitializeComponent();
        }
        public FormGIAYTO(string Quyen, string MaKH, string MaNV, string ChucVu)
        {
            this.Quyen = Quyen;
            this.MaKH = MaKH;
            this.MaNV = MaNV;
            this.ChucVu = ChucVu;
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
            panel1.Controls.Add(formChild);
            panel1.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();

        }
        private void phiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new Formsach.FormCHITIETSACH(MaKH, Quyen));
        }

        private void FormGIAYTO_Load(object sender, EventArgs e)
        {
            if(Quyen == "KhachHang")
            {
                phiếuDànhChoNhânViênKhoToolStripMenuItem1.Visible = false;
                phiếuDànhChoThủThưToolStripMenuItem.Visible = false;
            }
            if(ChucVu == "ThuThu" || ChucVu == "NhanVienKho")
            {
                menuNhanVien.Visible = false;
            }
            if(ChucVu == "ThuThu")
            {
                phiếuDànhChoNhânViênKhoToolStripMenuItem1.Visible = false;
            }
            if(ChucVu == "NhanVienKho")
            {
                phiếuDànhChoThủThưToolStripMenuItem.Visible = false;
            }
        }

        private void danhSáchPhiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new GiayTo.FormDANHSACHCHOPHIEUMUON(MaNV));
        }

        private void danhSáchPhiếuMượnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowForm(new GiayTo.FormDANHSACHPHIEUMUON());
        }

        private void phiếuTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new FormPHIEUMUONKHACHHANG(MaKH, Quyen));
        }

        private void phiếuTrảToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void phiếuTrảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new GiayTo.FormDANHSACHCHOPHIEUTRA(MaNV));
        }

        private void danhSáchPhiếuTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new GiayTo.FormPHIEUTRA(MaNV));
        }

        private void phiếuNhậpSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new GiayTo.FormPHIEUNHAPSACH(MaNV));
            
        }

        private void phiếuThanhLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new GiayTo.FormTHANHLYSACH(MaNV));
        }

        private void phiếuPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new GiayTo.FormPHIEUPHAT());
        }

        private void menuNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void phiếuGiaHạnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new GiayTo.FormPHIEUGIAHAN(MaNV));
        }
    }
}
