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
    public partial class FormTHEKHACHHANGDEMO : Form
    {
        string MaNV = "";
        string MaKH = "";
        string TenKH = "";
        string SDT = "";
        string Email = "";
        public FormTHEKHACHHANGDEMO()
        {
            InitializeComponent();
        }
        public FormTHEKHACHHANGDEMO(string MaNV, string MaKH, string TenKH, string SDT, string Email)
        {
            this.MaNV = MaNV;
            this.MaKH = MaKH;
            this.TenKH = TenKH;
            this.SDT = SDT;
            this.Email = Email;
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        private DataTable myTableTK;
        private void FormTHEKHACHHANGDEMO_Load(object sender, EventArgs e)
        {
            textBox1.Text = MaKH;
            textBox1.Enabled = false;
            textBox2.Text = TenKH;
            textBox2.Enabled = false;
            textBox3.Text = SDT;
            textBox3.Enabled = false;
            textBox4.Text = Email;
            textBox4.Enabled = false;
            dateTimePicker2.Enabled = false;
            dateTimePicker2.Value = DateTime.Now;
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
                SqlCommand cmd1 = new SqlCommand("SELECT dbo.AUTO_IDTKH()", conn);
                string id = cmd1.ExecuteScalar().ToString();
                SqlCommand smd = new SqlCommand("Insert into dbo.TheKhachHang(MaTheKhachHang, MaKH, MaNV, NgayLap, NgayHetHan, TenKH, SDT, Email) values(@MaTheKhachHang, @MaKH, @MaNV, @NgayLap, @NgayHetHan, @TenKH, @SDT, @Email)  ", conn);
                smd.Parameters.AddWithValue("@MaTheKhachHang", id);
                smd.Parameters.AddWithValue("@MaKH", textBox1.Text);
                smd.Parameters.AddWithValue("@MaNV", MaNV); ;
                smd.Parameters.AddWithValue("@NgayLap", dateTimePicker2.Value.ToString());
                smd.Parameters.AddWithValue("@NgayHetHan", dateTimePicker1.Value.ToString());
                smd.Parameters.AddWithValue("@TenKH", textBox2.Text);
                smd.Parameters.AddWithValue("@SDT", textBox3.Text); ;
                smd.Parameters.AddWithValue("@Email", textBox4.Text);
                smd.ExecuteNonQuery();
                MessageBox.Show("Tạo thành công thẻ khách hàng");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }
    }
}
