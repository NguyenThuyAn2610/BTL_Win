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
    public partial class FormNHANVIEN : Form
    {
        public FormNHANVIEN()
        {
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        public int State;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormNHANVIEN_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                
                    string cmd = "select * from dbo.NhanVienThuVien";
                    myDataAdapter = new SqlDataAdapter(cmd, conn);
                    myDataSet = new DataSet();
                    myDataAdapter.Fill(myDataSet, "NhanVienThuVien");
                    myTable = myDataSet.Tables["NhanVienThuVien"];
                    dataGridView1.DataSource = myTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                setControl(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }
        public void setControl(bool edit)
        {
            textBox1.Enabled = edit;
            textBox2.Enabled = edit;
            textBox3.Enabled = edit;
            textBox4.Enabled = edit;
            comboBox1.Enabled = edit;
            button1.Enabled = !edit;
            button2.Enabled = !edit;
            button3.Enabled = !edit;
            button4.Enabled = edit;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            setControl(true);
            State = 1;
            textBox1.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd1 = new SqlCommand("Delete from dbo.NhanVienThuVien where Email = '" + textBox4.Text + "'", conn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                FormNHANVIEN_Load(sender, e);

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int row = e.RowIndex;

                textBox3.Text = myTable.Rows[row]["SDT"].ToString();
                comboBox1.Text = myTable.Rows[row]["ChucVu"].ToString();
                textBox2.Text = myTable.Rows[row]["TenNV"].ToString();
                textBox4.Text = myTable.Rows[row]["Email"].ToString();
                textBox1.Text = myTable.Rows[row]["MaNV"].ToString();
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            State = 0;
            setControl(true);
            textBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(State == 1)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT dbo.AUTO_IDNV()", conn);
                    string id = cmd.ExecuteScalar().ToString();
                    SqlCommand smd = new SqlCommand("Insert into dbo.NhanVienThuVien(MaNV, TenNV, SDT, Email, ChucVu) values(@MaNV,@TenNV, @SDT, @Email,@ChucVu)", conn);
                    smd.Parameters.AddWithValue("@Email", textBox4.Text);
                    smd.Parameters.AddWithValue("@TenNV", textBox2.Text);
                    smd.Parameters.AddWithValue("@ChucVu", comboBox1.Text);
                    smd.Parameters.AddWithValue("@SDT", textBox3.Text);
                    smd.Parameters.AddWithValue("@MaNV", id);
                    smd.ExecuteNonQuery();
                    FormNHANVIEN_Load(sender, e);
                    MessageBox.Show("Thêm thành công");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
            else
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand smd = new SqlCommand("Update dbo.NhanVienThuVien set TenNV = @TenNV, SDT = @SDT, Email = @Email, ChucVu = @ChucVu where MaNV = @MaNV", conn);
                    smd.Parameters.AddWithValue("@Email", textBox4.Text);
                    smd.Parameters.AddWithValue("@TenNV", textBox2.Text);
                    smd.Parameters.AddWithValue("@ChucVu", comboBox1.Text);
                    smd.Parameters.AddWithValue("@SDT", textBox3.Text);
                    smd.Parameters.AddWithValue("@MaNV", textBox1.Text);
                    smd.ExecuteNonQuery();
                    FormNHANVIEN_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
        }
    }
}
