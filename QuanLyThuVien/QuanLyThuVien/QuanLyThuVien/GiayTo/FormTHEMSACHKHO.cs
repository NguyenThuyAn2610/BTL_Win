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
    public partial class FormTHEMSACHKHO : Form
    {
        string STT = "";
        string MaSach = "";
        string TenSach = "";
        string TacGia = "";
        int SoLuong = 0;
        public FormTHEMSACHKHO()
        {
            InitializeComponent();
        }
        public FormTHEMSACHKHO(string MaSach, string TenSach, string TacGia, int SoLuong, string STT)
        {
            this.MaSach = MaSach;
            this.TenSach = TenSach;
            this.TacGia = TacGia;
            this.SoLuong = SoLuong;
            this.STT = STT;
            InitializeComponent();
        }
        private void FormTHEMSACHKHO_Load(object sender, EventArgs e)
        {
            textBox1.Text = STT;
            textBox2.Text = MaSach;
            textBox3.Text = TenSach;
            textBox4.Text = TacGia;
            textBox5.Text = SoLuong.ToString();
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
                SqlCommand cmd1 = new SqlCommand("SELECT dbo.AUTO_IDB()", conn);
                string id = cmd1.ExecuteScalar().ToString();
                SqlCommand smd = new SqlCommand("insert into KhoSach( MaSach, TenSach,TacGia, SoLuong) values(@MaSach, @TenSach, @TacGia, @Soluong)", conn);
                smd.Parameters.AddWithValue("@MaSach", id);
                smd.Parameters.AddWithValue("@TenSach", textBox3.Text);
                smd.Parameters.AddWithValue("@TacGia", textBox4.Text);
                smd.Parameters.AddWithValue("@SoLuong", textBox5.Text);
                smd.ExecuteNonQuery();
                MessageBox.Show("Thêm sách vào kho thành công");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }
    }
}
