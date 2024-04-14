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
    public partial class FormTHEKHACHHANG : Form
    {
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        private DataTable myTableTK;
        public int State;
        string MaNV = "";
        public FormTHEKHACHHANG()
        {
            InitializeComponent();
        }
        public FormTHEKHACHHANG(string MaNV)
        {
            this.MaNV = MaNV;
            InitializeComponent();
        }
        public void setControl(bool edit)
        {
            textBox1.Enabled = edit;
            textBox2.Enabled = edit;
            textBox3.Enabled = edit;
            textBox4.Enabled = edit;
            textBox5.Enabled = edit;
            textBox6.Enabled = edit;
            dateTimePicker1.Enabled = edit;
            dateTimePicker2.Enabled = edit;
            button1.Enabled = !edit;
            button2.Enabled = !edit;
            button3.Enabled = !edit;
            button4.Enabled = edit;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormTHEKHACHHANG_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = "select * from dbo.TheKhachHang";
                myDataAdapter = new SqlDataAdapter(cmd, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "TheKhachHang");
                myTable = myDataSet.Tables["TheKhachHang"];
                setControl(false);
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            dateTimePicker1.Value = DateTime.Parse(myTable.Rows[row]["NgayLap"].ToString());
            dateTimePicker2.Value = DateTime.Parse(myTable.Rows[row]["NgayHetHan"].ToString());
            textBox1.Text = myTable.Rows[row]["MaTheKhachHang"].ToString();
            textBox2.Text = myTable.Rows[   row]["MaKH"].ToString();
            textBox3.Text = myTable.Rows[row]["MaNV"].ToString();
            textBox6.Text = myTable.Rows[row]["Email"].ToString();
            textBox5.Text = myTable.Rows[row]["SDT"].ToString();
            textBox4.Text = myTable.Rows[row]["TenKH"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from dbo.TheKhachHang where MaTheKhachHang = '" + textBox1.Text + "'", conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                FormTHEKHACHHANG_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setControl(true);
            State = 1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox5.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (State == 1)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT dbo.AUTO_IDTKH()", conn);
                    string id = cmd.ExecuteScalar().ToString();
                    SqlCommand smd = new SqlCommand("Insert into dbo.TheKhachHang values(@MaTheKhachHang, @MaKH, @MaNV,@NgayLap,@NgayHetHan,@TenKH,@SDT, @Email)", conn);
                    smd.Parameters.AddWithValue("@MaTheKhachHang", id);
                    smd.Parameters.AddWithValue("@MaKH", textBox2.Text);
                    smd.Parameters.AddWithValue("@MaNV", textBox3.Text);
                    smd.Parameters.AddWithValue("@NgayHetHan", dateTimePicker2.Value.ToString("MM/dd/yyyy"));
                    smd.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                    smd.Parameters.AddWithValue("@TenKH", textBox4.Text);
                    smd.Parameters.AddWithValue("@SDT", textBox5.Text);
                    smd.Parameters.AddWithValue("@Email", textBox6.Text);
                    smd.ExecuteNonQuery();
                    FormTHEKHACHHANG_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
            else if (State == 0)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand smd = new SqlCommand("Update dbo.TheKhachHang set MaKH = @MaKH, MaNV = @MaNV, NgayLap = @NgayLap, NgayHetHan = @NgayHetHan, TenKH = @TenKH, SDT = @SDT, Email = @Email where MaTheKhachHang = @MaTheKhachHang", conn);
                    smd.Parameters.AddWithValue("@MaTheKhachHang", textBox1.Text);
                    smd.Parameters.AddWithValue("@MaKH", textBox2.Text);
                    smd.Parameters.AddWithValue("@MaNV", textBox3.Text);
                    smd.Parameters.AddWithValue("@NgayHetHan", dateTimePicker2.Value.ToString("MM/dd/yyyy"));
                    smd.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                    smd.Parameters.AddWithValue("@TenKH", textBox4.Text);
                    smd.Parameters.AddWithValue("@SDT", textBox5.Text);
                    smd.Parameters.AddWithValue("@Email", textBox6.Text);
                    smd.ExecuteNonQuery();
                    FormTHEKHACHHANG_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            setControl(true);
            State = 0;
            textBox1.Enabled = false;
            textBox2.Focus();
        }
    }
}
