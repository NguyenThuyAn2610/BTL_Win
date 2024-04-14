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
    public partial class FormPHIEUTHU : Form
    {
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        public int state = 0;
        public FormPHIEUTHU()
        {
            InitializeComponent();
        }
        public void setcontrol(bool edit)
        {
            textBox1.Enabled = edit;
            textBox2.Enabled = edit;
            textBox3.Enabled = edit;
            textBox4.Enabled = edit;
            textBox5.Enabled = edit;
            textBox6.Enabled = edit;
            button1.Enabled = !edit;
            button3.Enabled = edit;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormPHIEUTHU_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = "select * from dbo.PhieuThu";
                myDataAdapter = new SqlDataAdapter(cmd, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "PhieuThu");
                myTable = myDataSet.Tables["PhieuThu"];
                dataGridView1.DataSource = myTable;
                setcontrol(false);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
            textBox1.Text = myTable.Rows[row]["MaPhieuThu"].ToString();
            textBox2.Text = myTable.Rows[row]["Nam"].ToString();
            textBox3.Text = myTable.Rows[row]["Thang"].ToString();
            textBox4.Text = myTable.Rows[row]["MaNV"].ToString();
            textBox5.Text = myTable.Rows[row]["BangChu"].ToString();
            textBox6.Text = myTable.Rows[row]["SoTienThu"].ToString();
            dateTimePicker1.Value = DateTime.Parse(myTable.Rows[row]["NgayTaoPhieu"].ToString());
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from dbo.PhieuThu where MaPhieuThu = '" + textBox1.Text + "'", conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                FormPHIEUTHU_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            state = 1;
            setcontrol(true);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(state == 1)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand smd = new SqlCommand("Update dbo.PhieuThu set Nam = @Nam, Thang = @Thang, MaNV = @MaNV, BangChu = @BangChu, SoTienThu = @SoTienThu, NgayTaoPhieu = @NgayTaoPhieu where MaPhieuThu = @MaPhieuThu", conn);
                    smd.Parameters.AddWithValue("@MaPhieuThu", textBox1.Text);
                    smd.Parameters.AddWithValue("@Nam", textBox2.Text);
                    smd.Parameters.AddWithValue("@Thang", textBox3.Text);
                    smd.Parameters.AddWithValue("@NgayTaoPhieu", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                    smd.Parameters.AddWithValue("@MaNV", textBox4.Text);
                    smd.Parameters.AddWithValue("@BangChu", textBox5.Text);
                    smd.Parameters.AddWithValue("@SoTienThu", textBox6.Text);
                    smd.ExecuteNonQuery();
                    FormPHIEUTHU_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
        }
    }
}
