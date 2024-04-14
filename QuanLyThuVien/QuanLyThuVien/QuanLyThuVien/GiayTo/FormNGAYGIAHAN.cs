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
    public partial class FormNGAYGIAHAN : Form
    {
        string maSach = "";
        string tenSach = "";
        string maKH = "";
        string manv = "";
        string maphieumuon = "";
        string soluong = "";
        public FormNGAYGIAHAN()
        {
            InitializeComponent();
        }
        public FormNGAYGIAHAN(string maSach, string tenSach, string maKH, string manv, string maphieumuon, string soluong)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.maKH = maKH;
            this.manv = manv;
            this.maphieumuon = maphieumuon;
            this.soluong = soluong;
            InitializeComponent();
        }
        private void FormNGAYGIAHAN_Load(object sender, EventArgs e)
        {

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
                SqlCommand cmd = new SqlCommand("SELECT dbo.AUTO_IDPGiaHanSach()", conn);
                string id = cmd.ExecuteScalar().ToString();
                SqlCommand smd = new SqlCommand("Insert into dbo.PhieuGiaHanSach values(@MaPhieuGiaHan, @MaPhieuMuon, @MaSach,@MaKH,@MaNV,@NgayGiaHan,@NgayTaoPhieu, @SoLuong, @TenSach)", conn);
                smd.Parameters.AddWithValue("@MaPhieuGiaHan", id);
                smd.Parameters.AddWithValue("@MaPhieuMuon", maphieumuon);
                smd.Parameters.AddWithValue("@MaSach", maSach);
                smd.Parameters.AddWithValue("@MaKH", maKH);
                smd.Parameters.AddWithValue("@MaNV", manv);
                smd.Parameters.AddWithValue("@NgayGiaHan", dateTimePicker1.Value.ToString());
                smd.Parameters.AddWithValue("@NgayTaoPhieu", DateTime.Now);
                smd.Parameters.AddWithValue("@SoLuong", soluong);
                smd.Parameters.AddWithValue("@TenSach", tenSach);
                smd.ExecuteNonQuery();
                MessageBox.Show("Tạo phiếu thành công");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }
    }
}
