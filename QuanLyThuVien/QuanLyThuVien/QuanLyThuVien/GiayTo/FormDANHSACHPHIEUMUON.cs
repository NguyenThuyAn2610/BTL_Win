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
    public partial class FormDANHSACHPHIEUMUON : Form
    {
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        public int State;
        public FormDANHSACHPHIEUMUON()
        {
            InitializeComponent();
        }
        public void setControl(bool edit)
        {
            textBox1.Enabled = edit;
            textBox2.Enabled = edit;
            textBox3.Enabled = edit;
            textBox4.Enabled = edit;
            textBox5.Enabled = edit;
            textBox9.Enabled = edit;
            dateTimePicker1.Enabled = edit;
            dateTimePicker2.Enabled = edit;
            button1.Enabled = !edit;
            button2.Enabled = !edit;
            button3.Enabled = !edit;
            button4.Enabled = edit;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormDANHSACHPHIEUMUON_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = "select * from dbo.PhieuMuon";
                myDataAdapter = new SqlDataAdapter(cmd, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "PhieuMuon");
                myTable = myDataSet.Tables["PhieuMuon"];
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
            try
            {
                int row = e.RowIndex;
                dateTimePicker1.Value = DateTime.Parse(myTable.Rows[row]["NgayHetHanMuon"].ToString());
                dateTimePicker2.Value = DateTime.Parse(myTable.Rows[row]["NgayTaoPhieu"].ToString());
                textBox1.Text = myTable.Rows[row]["MaPhieuMuon"].ToString();
                textBox2.Text = myTable.Rows[row]["MaSach"].ToString();
                textBox3.Text = myTable.Rows[row]["MaNV"].ToString();
                textBox4.Text = myTable.Rows[row]["MaKH"].ToString();
                textBox5.Text = myTable.Rows[row]["TenSach"].ToString();
                textBox9.Text = myTable.Rows[row]["SoLuong"].ToString();
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
            textBox5.Clear();
            textBox9.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setControl(true);
            State = 0;
            textBox1.Enabled = false;
            textBox2.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from dbo.PhieuMuon where MaPhieuMuon = '" + textBox1.Text + "'", conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                FormDANHSACHPHIEUMUON_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    SqlCommand smd1 = new SqlCommand("Update dbo.Sach set SoLuongCoTheMuon -= '" + textBox9.Text + "' where MaSach = '" + textBox2.Text + "'", conn);
                    smd1.ExecuteNonQuery();
                    SqlCommand smd = new SqlCommand("Insert into dbo.PhieuMuon values(@MaPhieuMuon, @MaSach, @MaNV,@MaKH,@TenSach,@NgayTaoPhieu,@SoLuong, @NgayHetHanMuon)", conn);
                    smd.Parameters.AddWithValue("@MaPhieuMuon", textBox1.Text);
                    smd.Parameters.AddWithValue("@MaSach", textBox2.Text);
                    smd.Parameters.AddWithValue("@MaNV", textBox3.Text);
                    smd.Parameters.AddWithValue("@NgayTaoPhieu", dateTimePicker2.Value.ToString("MM/dd/yyyy"));
                    smd.Parameters.AddWithValue("@NgayHetHanMuon", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                    smd.Parameters.AddWithValue("@MaKH", textBox4.Text);
                    smd.Parameters.AddWithValue("@TenSach", textBox5.Text);
                    smd.Parameters.AddWithValue("@SoLuong", textBox9.Text);
                    smd.ExecuteNonQuery();
                    FormDANHSACHPHIEUMUON_Load(sender, e);
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
                    SqlCommand smd = new SqlCommand("Update dbo.PhieuMuon set MaSach = @MaSach, MaNV = @MaNV, MaKH = @MaKH, TenSach = @TenSach, NgayTaoPhieu = @NgayTaoPhieu, SoLuong = @SoLuong, NgayHetHanMuon = @NgayHetHanMuon where MaPhieuMuon = @MaPhieuMuon", conn);
                    smd.Parameters.AddWithValue("@MaPhieuMuon", textBox1.Text);
                    smd.Parameters.AddWithValue("@MaSach", textBox2.Text);
                    smd.Parameters.AddWithValue("@MaNV", textBox3.Text);
                    smd.Parameters.AddWithValue("@NgayTaoPhieu", dateTimePicker2.Value.ToString("MM/dd/yyyy"));
                    smd.Parameters.AddWithValue("@NgayHetHanMuon", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                    smd.Parameters.AddWithValue("@MaKH", textBox4.Text);
                    smd.Parameters.AddWithValue("@TenSach", textBox5.Text);
                    smd.Parameters.AddWithValue("@SoLuong", textBox9.Text);
                    smd.ExecuteNonQuery();
                    FormDANHSACHPHIEUMUON_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
        }
    }
}
