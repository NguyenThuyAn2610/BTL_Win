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
    public partial class FormPHIEUPHATDEMO : Form
    {
        string MaSach = "";
        string MaNV = "";
        string MaKH = "";
        string TenSach = "";

        public FormPHIEUPHATDEMO(string MaSach, string MaNV, string MaKH, string TenSach)
        {
            this.MaSach = MaSach;
            this.MaNV = MaNV;
            this.MaKH = MaKH;
            this.TenSach = TenSach;
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        private void FormPHIEUPHATDEMO_Load(object sender, EventArgs e)
        {
            textBox1.Text = MaKH;
            textBox1.Enabled = false;
            textBox2.Text = MaSach;
            textBox2.Enabled = false;
            textBox3.Text = MaNV;
            textBox3.Enabled = false;
            textBox4.Text = TenSach;
            textBox4.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
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
                SqlCommand cmd = new SqlCommand("SELECT dbo.AUTO_IDPP()", conn);
                string id = cmd.ExecuteScalar().ToString();
                SqlCommand smd = new SqlCommand("Insert into dbo.PhieuPhat(MaPhieuPhat, MaKH, MaSach, MaNV,TenSach,SoTienPhat, LyDoPhat, NgayTaoPhieu) values(@MaPhieuPhat, @MaKH, @MaSach, @MaNV,@TenSach,@SoTienPhat, @LyDoPhat, @NgayTaoPhieu)", conn);
                smd.Parameters.AddWithValue("@MaKH", textBox1.Text);
                smd.Parameters.AddWithValue("@MaPhieuPhat", id);
                smd.Parameters.AddWithValue("@MaSach", textBox2.Text);
                smd.Parameters.AddWithValue("@MaNV", MaNV);
                smd.Parameters.AddWithValue("@TenSach", textBox4.Text);
                smd.Parameters.AddWithValue("@SoTienPhat", textBox5.Text);
                smd.Parameters.AddWithValue("@LyDoPhat", textBox6.Text);
                smd.Parameters.AddWithValue("@NgayTaoPhieu", dateTimePicker1.Value.ToString());
                smd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công");
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }
    }
}
