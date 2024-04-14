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
namespace QuanLyThuVien.Formsach
{
    public partial class FormCHITIETSACH : Form
    {
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        private DataTable myTableTG;
        private DataTable myTableCD;
        string MaKH = "";
        string Quyen = "";
        public FormCHITIETSACH()
        {
            InitializeComponent();
        }
        public FormCHITIETSACH(string MaKH, string Quyen)
        {
            this.MaKH = MaKH;
            this.Quyen = Quyen;
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void loadData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = "select * from dbo.Sach";
                myDataAdapter = new SqlDataAdapter(cmd, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "Sach");
                myTable = myDataSet.Tables["Sach"];

                dataGridView1.DataSource = myTable;
                TaoComboChuDe();
                TaoComboTacGia();
                comboBox1.DataSource = tinhtrang;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        List<string> chudeList = new List<string>();
        List<string> tacgiaList = new List<string>();
        string[] tinhtrang = { "Có thể mượn", "Không thể mượn" };
        private void FormCHITIETSACH_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            loadData();
        }
        public void TaoComboChuDe()
        {
            chudeList.Add("All");
            string query = "SELECT DISTINCT ChuDe FROM Sach";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string chude = reader.GetString(0);
                chudeList.Add(chude);
            }
            comboBox3.DataSource = chudeList;
            comboBox3.DisplayMember = "ChuDe";

        }
        public void TaoComboTacGia()
        {
            tacgiaList.Add("All");
            string query = "SELECT DISTINCT TacGia FROM Sach";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tacgia = reader.GetString(0);
                tacgiaList.Add(tacgia);
            }
            comboBox2.DataSource = tacgiaList;
            comboBox2.DisplayMember = "TacGia";

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            dateTimePicker1.Value = DateTime.Parse(myTable.Rows[row]["NamXB"].ToString());
            textBox1.Text = myTable.Rows[row]["MaSach"].ToString();
            textBox2.Text = myTable.Rows[row]["TenSach"].ToString();
            textBox3.Text = myTable.Rows[row]["TacGia"].ToString();
            textBox6.Text = myTable.Rows[row]["SoLuongCoTheMuon"].ToString();
            textBox7.Text = myTable.Rows[row]["ChuDe"].ToString();
            textBox4.Text = myTable.Rows[row]["SoTien"].ToString();
            comboBox1.Text = myTable.Rows[row]["TinhTrangMuon"].ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Quyen == "Admin" || Quyen == "KhachHang")
            {
                string SoLuongMuon = textBox5.Text;
                string MaSach = dataGridView1.CurrentRow.Cells["MaSach"].Value.ToString();
                string TenSach = dataGridView1.CurrentRow.Cells["TenSach"].Value.ToString();
                DateTime NamXB = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["NamXB"].Value);
                string TacGia = dataGridView1.CurrentRow.Cells["TacGia"].Value.ToString();
                string TinhTrangMuon = dataGridView1.CurrentRow.Cells["TinhTrangMuon"].Value.ToString();
                string SoLuongCoTheMuon = dataGridView1.CurrentRow.Cells["SoLuongCoTheMuon"].Value.ToString();
                string ChuDe = dataGridView1.CurrentRow.Cells["ChuDe"].Value.ToString();
                string SoTien = dataGridView1.CurrentRow.Cells["SoTien"].Value.ToString();
                GiayTo.FormPHIEUMUONDEMO fm1 = new GiayTo.FormPHIEUMUONDEMO(MaSach, TenSach, SoLuongCoTheMuon, MaKH, SoLuongMuon);
                fm1.Show();

            }
            else
            {
     
                MessageBox.Show("Bạn không có quyền đăng kí mượn sách");
            }
            
           
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tacgia = comboBox2.Text;
            string chude = comboBox3.Text;
            if(comboBox2.Text != "All")
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from dbo.Sach where TacGia = N'" + tacgia + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox3.Text != "All")
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from dbo.Sach where ChuDe = N'" + chude + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            else 
            {
                loadData();
            }






        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
