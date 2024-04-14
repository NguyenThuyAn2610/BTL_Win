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
    public partial class FormKHOSACH : Form
    {
        string ChucVu = "";
        string Quyen = "";
        public FormKHOSACH()
        {
            InitializeComponent();
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
            SetInitialText();
        }
             
        public FormKHOSACH(string ChucVu, string Quyen)
        {
            this.Quyen = Quyen;
            this.ChucVu = ChucVu;
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormKHOSACH_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd1 = "select * from dbo.KhoSach";
                myDataAdapter = new SqlDataAdapter(cmd1, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "KhoSach");
                myTable = myDataSet.Tables["KhoSach"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
        private void button4_Click(object sender, EventArgs e)
        {
           
                dataGridView1.DataSource = XemDL("Select * from dbo.KhoSach where TenSach like '%" + textBox1.Text + "%' ");
            
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
            panel2.Controls.Add(formChild);
            panel2.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            string MaKH = dataGridView1.CurrentRow.Cells["MaSach"].Value.ToString();
            string TenSach = dataGridView1.CurrentRow.Cells["TenSach"].Value.ToString();
            string TacGia = dataGridView1.CurrentRow.Cells["TacGia"].Value.ToString();
            int SoLuong = int.Parse(dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString());
            GiayTo.FormLAYSACH fm1 = new GiayTo.FormLAYSACH(MaKH, TenSach, TacGia, SoLuong);
            fm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string MaSach = dataGridView1.CurrentRow.Cells["MaSach"].Value.ToString();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from dbo.KhoSach where MaSach = '" + MaSach + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                FormKHOSACH_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string MaSach = dataGridView1.CurrentRow.Cells["MaSach"].Value.ToString();
            string TenSach = dataGridView1.CurrentRow.Cells["TenSach"].Value.ToString();
            string TacGia = dataGridView1.CurrentRow.Cells["TacGia"].Value.ToString();
            int SoLuong = int.Parse(dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString());
            string STT = dataGridView1.CurrentRow.Cells["STT"].Value.ToString();
            GiayTo.FormCAPNHATKHO fm1 = new FormCAPNHATKHO(MaSach, TenSach, TacGia, SoLuong, STT);
            fm1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string MaSach = dataGridView1.CurrentRow.Cells["MaSach"].Value.ToString();
            //string TenSach = dataGridView1.CurrentRow.Cells["TenSach"].Value.ToString();
            //string TacGia = dataGridView1.CurrentRow.Cells["TacGia"].Value.ToString();
            //int SoLuong = int.Parse(dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString());
            ///string STT = dataGridView1.CurrentRow.Cells["STT"].Value.ToString();
            //GiayTo.FormTHEMSACHKHO fm1 = new FormTHEMSACHKHO(MaSach, TenSach, TacGia, SoLuong, STT);
            //fm1.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SetInitialText()
        {
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Vui lòng nhập tên sách";
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Vui lòng nhập tên sách")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.ControlText;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SetInitialText();
            }   
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Vui lòng nhập tên sách")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.ControlText;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Vui lòng nhập tên sách")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.ControlText;
            }
        }
    }
}
