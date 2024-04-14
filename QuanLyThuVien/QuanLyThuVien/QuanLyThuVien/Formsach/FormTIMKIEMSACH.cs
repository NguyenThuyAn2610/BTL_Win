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
    public partial class FormTIMKIEMSACH : Form
    {
        public FormTIMKIEMSACH()
        {
            InitializeComponent();
        }
        
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormTIMKIEMSACH_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed )
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from dbo.Sach", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }
        public void Ketnoi()
        {
            try
            {
                if (conn.State == 0)
                {
                    conn.ConnectionString = "Data Source=DESKTOP-8HCDGC7\\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True";
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable XemDL(string sql)
        {
            Ketnoi();

            SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            return dt;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                string selectedItem = comboBox1.SelectedItem.ToString();
                int minValue = 0;
                switch (selectedItem)
                {
                    case ">10000":
                        minValue = 10000;
                        break;
                    // Thêm các trường hợp xử lý cho các item khác nếu cần
                    case ">20000":
                        minValue = 20000;
                        break;
                    case ">30000":
                        minValue = 30000;
                        break;
                }
                string selectQuery = "select * from dbo.Sach where SoTien >" + minValue;
                SqlCommand command = new SqlCommand(selectQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

            }
            else if (checkBox1.Checked)
            {
                
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Thông báo", "Bạn chưa nhập thông tin tìm kiếm");
                    textBox1.Focus();
                }
                else
                {
                    dataGridView1.DataSource = XemDL("Select * from dbo.Sach where MaSach like '%" + textBox1.Text + "%' ");
                }
            }
            else if (checkBox2.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Thông báo", "Bạn chưa nhập thông tin tìm kiếm");
                    textBox1.Focus();
                }
                else
                {
                    dataGridView1.DataSource = XemDL("Select * from dbo.Sach where TenSach like '%" + textBox1.Text + "%' ");
                }
                
            }
            
            else
            {
                SqlCommand cmd = new SqlCommand("Select * from dbo.Sach", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from dbo.Sach", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
