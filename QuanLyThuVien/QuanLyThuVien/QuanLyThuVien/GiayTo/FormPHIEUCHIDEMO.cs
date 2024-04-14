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
    public partial class FormPHIEUCHIDEMO : Form
    {
        string MaNV = "";
        string bangchuchi = "";
        int sotienchi = 0;
        string Nam = "";
        string Thang = "";
        public FormPHIEUCHIDEMO()
        {
            InitializeComponent();
        }
        public FormPHIEUCHIDEMO(string MaNV, string bangchuchi, int sotienchi, string Nam, string Thang)
        {
            this.MaNV = MaNV;
            this.bangchuchi = bangchuchi;
            this.sotienchi = sotienchi;
            this.Nam = Nam;
            this.Thang = Thang;
            InitializeComponent();
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
                SqlCommand cmd = new SqlCommand("SELECT dbo.AUTO_IDPC()", conn);
                string id = cmd.ExecuteScalar().ToString();
                SqlCommand smd = new SqlCommand("Insert into dbo.PhieuChi values(@MaPhieuThu,@Nam, @Thang, @MaNV, @BangChu,@SoTienChi, @NgayTaoPhieu)", conn);
                smd.Parameters.AddWithValue("@MaPhieuThu", id);
                smd.Parameters.AddWithValue("@Nam", textBox5.Text);
                smd.Parameters.AddWithValue("@Thang", textBox3.Text);
                smd.Parameters.AddWithValue("@MaNV", MaNV);
                smd.Parameters.AddWithValue("@BangChu", textBox2.Text);
                smd.Parameters.AddWithValue("@SoTienChi", textBox4.Text);
                smd.Parameters.AddWithValue("@NgayTaoPhieu", DateTime.Now);
                MessageBox.Show("Tạo phiếu chi thành công");
                smd.ExecuteNonQuery();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }

        private void FormPHIEUCHIDEMO_Load(object sender, EventArgs e)
        {
            textBox1.Text = MaNV;
            textBox2.Text = bangchuchi;
            textBox4.Text = sotienchi.ToString();
            dateTimePicker1.Value = DateTime.Now;
            textBox5.Text = Nam;
            textBox3.Text = Thang;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }
    }
}
