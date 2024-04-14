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
    public partial class FormPHIEUTRADEMO : Form
    {
        string MaSach = "";
        string TenSach = "";
        string SoLuong = "";
        string MaKH = "";
        DateTime NgayTaoSach;
        DateTime NgayTraSach;
        string manv = "";
        string TinhTrang = "";
        DateTime NgayHetHanMuon;
        public FormPHIEUTRADEMO()
        {
            InitializeComponent();
        }
        public FormPHIEUTRADEMO(string MaSach, string TenSach, string SoLuong, string MaKH, DateTime NgayTaoSach, DateTime NgayTraSach,string manv, string TinhTrang, DateTime NgayHetHanMuon )
        {
            this.MaSach = MaSach;
            this.TenSach = TenSach;
            this.SoLuong = SoLuong;
            this.MaKH = MaKH;
            this.NgayTaoSach = NgayTaoSach;
            this.NgayTraSach = NgayTraSach;
            this.manv = manv;
            this.TinhTrang = TinhTrang;
            this.NgayHetHanMuon = NgayHetHanMuon;
            InitializeComponent();
        }
        private void FormPHIEUTRADEMO_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            textBox2.Text = SoLuong;
            textBox1.Text = MaSach;
            textBox3.Text = TenSach;
            textBox4.Text = MaKH;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = NgayHetHanMuon;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                

                SqlCommand smd1 = new SqlCommand("insert into dbo.PhieuTraSach(MaSach, MaKH, MaNhanVienTao, TenSach, NgayTaoPhieu, TinhTrangSach, SoLuong, NgayTraSach, NgayHetHanMuon) values(@MaSach, @MaKH, @MaNhanVienTao, @TenSach, @NgayTaoPhieu, @TinhTrangSach, @SoLuong, @NgayTraSach, @NgayHetHanMuon)", conn);
                smd1.Parameters.Add("@MaSach", MaSach);
                smd1.Parameters.Add("@MaKH", MaKH);
                smd1.Parameters.Add("@MaNhanVienTao", manv);
                smd1.Parameters.Add("@TenSach", TenSach);
                smd1.Parameters.Add("@NgayTaoPhieu", NgayTaoSach);
                smd1.Parameters.Add("@TinhTrangSach", TinhTrang);
                smd1.Parameters.Add("@SoLuong", SoLuong);
                smd1.Parameters.Add("@NgayTraSach", NgayTraSach);
                smd1.Parameters.Add("@NgayHetHanMuon", NgayHetHanMuon);
                smd1.ExecuteNonQuery();
                MessageBox.Show("Tạo phiếu trả thành công", "Thông báo");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }
    }
}
