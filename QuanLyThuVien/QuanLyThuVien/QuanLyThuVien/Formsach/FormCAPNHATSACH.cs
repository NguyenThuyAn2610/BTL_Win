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
    public partial class FormCAPNHATSACH : Form
    {
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        public int State;
        public FormCAPNHATSACH()
        {
            InitializeComponent();
        }
        public void setControl(bool edit)
        {
            textBox1.Enabled = edit;
            textBox2.Enabled = edit;
            textBox3.Enabled = edit;
            textBox4.Enabled = edit;
            textBox6.Enabled = edit;
            textBox7.Enabled = edit;
            dateTimePicker1.Enabled = edit;
            comboBox1.Enabled = edit;
            button1.Enabled = !edit;
            button2.Enabled = !edit;
            button3.Enabled = !edit;
            button4.Enabled = edit;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Xóa dữ liệu từ bảng KhoSach dựa trên MaSach
                SqlCommand cmdKhoSach = new SqlCommand("DELETE FROM dbo.KhoSach WHERE MaSach = @MaSach", conn);
                cmdKhoSach.Parameters.AddWithValue("@MaSach", textBox1.Text);
                cmdKhoSach.ExecuteNonQuery();

                // Xóa dữ liệu từ bảng Sach dựa trên MaSach
                SqlCommand cmdSach = new SqlCommand("DELETE FROM dbo.Sach WHERE MaSach = @MaSach", conn);
                cmdSach.Parameters.AddWithValue("@MaSach", textBox1.Text);
                cmdSach.ExecuteNonQuery();

                MessageBox.Show("Xóa thành công", "Thông báo");

                if (conn.State == ConnectionState.Open)
                    conn.Close();

                FormCAPNHATSACH_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        string[] tinhtrang = { "Có thể mượn", "Không thể mượn" };
        private void FormCAPNHATSACH_Load(object sender, EventArgs e)
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
                setControl(false);
                comboBox1.DataSource = tinhtrang;
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
                dateTimePicker1.Value = DateTime.Parse(myTable.Rows[row]["NamXB"].ToString());
                textBox1.Text = myTable.Rows[row]["MaSach"].ToString();
                textBox2.Text = myTable.Rows[row]["TenSach"].ToString();
                textBox3.Text = myTable.Rows[row]["TacGia"].ToString();
                textBox6.Text = myTable.Rows[row]["SoLuongCoTheMuon"].ToString();
                textBox7.Text = myTable.Rows[row]["ChuDe"].ToString();
                textBox4.Text = myTable.Rows[row]["SoTien"].ToString();
                comboBox1.Text = myTable.Rows[row]["TinhTrangMuon"].ToString();
            }
            catch
            {

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
            textBox7.Clear();
            
            
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
                    SqlCommand smd = new SqlCommand("Insert into dbo.Sach values(@MaSach, @TenSach, @TacGia,@TinhTrangMuon,@NamXB,@SoLuongCoTheMuon,@ChuDe, @SoTien)", conn);
                    smd.Parameters.AddWithValue("@MaSach", textBox1.Text);
                    smd.Parameters.AddWithValue("@TenSach", textBox2.Text);
                    smd.Parameters.AddWithValue("@TacGia", textBox3.Text);
                    smd.Parameters.AddWithValue("@TinhTrangMuon", comboBox1.SelectedItem.ToString());
                    smd.Parameters.AddWithValue("@NamXB", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                    smd.Parameters.AddWithValue("@SoLuongCoTheMuon", textBox6.Text);
                    smd.Parameters.AddWithValue("@ChuDe", textBox7.Text);
                    smd.Parameters.AddWithValue("@SoTien", textBox4.Text);
                    smd.ExecuteNonQuery();
                    FormCAPNHATSACH_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
            else if(State == 0)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand smd = new SqlCommand("Update dbo.Sach set TenSach = @TenSach, TacGia = @TacGia, TinhTrangMuon = @TinhTrangMuon, NamXB = @NamXB, SoLuongCoTheMuon = @SoLuongCoTheMuon, ChuDe = @ChuDe, SoTien = @SoTien where MaSach = @MaSach", conn);
                    smd.Parameters.AddWithValue("@MaSach", textBox1.Text);
                    smd.Parameters.AddWithValue("@TenSach", textBox2.Text);
                    smd.Parameters.AddWithValue("@TacGia", textBox3.Text);
                    smd.Parameters.AddWithValue("@TinhTrangMuon", comboBox1.SelectedItem.ToString());
                    smd.Parameters.AddWithValue("@NamXB", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                    smd.Parameters.AddWithValue("@SoLuongCoTheMuon", textBox6.Text);
                    smd.Parameters.AddWithValue("@ChuDe", textBox7.Text);
                    smd.Parameters.AddWithValue("@SoTien", textBox4.Text);
                    smd.ExecuteNonQuery();
                    FormCAPNHATSACH_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setControl(true);
            State = 0;
            textBox1.Enabled = false;
            textBox2.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
