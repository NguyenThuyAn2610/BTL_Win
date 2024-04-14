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
    public partial class FormPHIEUTHUDEMO : Form
    {
        string MaNV = "";
        string bangchuthuduoc = "";
        int sotienthuduoc = 0;
        string Nam = "";
        string Thang = "";
        public FormPHIEUTHUDEMO()
        {
            InitializeComponent();
        }
        public FormPHIEUTHUDEMO(string MaNV, string bangchuthuduoc, int sotienthuduoc, string Nam, string Thang)
        {
            this.MaNV = MaNV;
            this.bangchuthuduoc = bangchuthuduoc;
            this.sotienthuduoc = sotienthuduoc;
            this.Nam = Nam;
            this.Thang = Thang;
            InitializeComponent();
        }

        private void FormTHUDEMO_Load(object sender, EventArgs e)
        {
            textBox1.Text = MaNV;
            textBox2.Text = bangchuthuduoc;
            textBox4.Text = sotienthuduoc.ToString();
            dateTimePicker1.Value = DateTime.Now;
            textBox5.Text = Nam;
            textBox3.Text = Thang;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
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
                SqlCommand cmd = new SqlCommand("SELECT dbo.AUTO_IDPT()", conn);
                string id = cmd.ExecuteScalar().ToString();
                SqlCommand smd = new SqlCommand("Insert into dbo.PhieuThu values(@MaPhieuThu,@Nam, @Thang, @MaNV, @BangChu,@SoTienThu, @NgayTaoPhieu)", conn);
                smd.Parameters.AddWithValue("@MaPhieuThu", id);
                smd.Parameters.AddWithValue("@MaNV", MaNV);
                smd.Parameters.AddWithValue("@BangChu", textBox2.Text);
                smd.Parameters.AddWithValue("@Nam", textBox5.Text);
                smd.Parameters.AddWithValue("@Thang", textBox3.Text);
                smd.Parameters.AddWithValue("@SoTienThu", textBox4.Text);
                smd.Parameters.AddWithValue("@NgayTaoPhieu", DateTime.Now);
                MessageBox.Show("Tạo phiếu thu thành công");
                smd.ExecuteNonQuery();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }
    }
}
