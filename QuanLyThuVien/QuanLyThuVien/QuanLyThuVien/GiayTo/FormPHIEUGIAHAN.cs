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
    public partial class FormPHIEUGIAHAN : Form
    {
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        private int State;
        string MaNV = "";
        public FormPHIEUGIAHAN()
        {
            InitializeComponent();
        }
        public FormPHIEUGIAHAN(string MaNV)
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
            textBox7.Enabled = edit;
            dateTimePicker1.Enabled = edit;
            dateTimePicker2.Enabled = edit;
            button2.Enabled = !edit;
            button3.Enabled = !edit;
            button4.Enabled = edit;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormPHIEUGIAHAN_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = "select * from dbo.PhieuGiaHanSach";
                myDataAdapter = new SqlDataAdapter(cmd, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "PhieuGiaHanSach");
                myTable = myDataSet.Tables["PhieuGiaHanSach"];

                dataGridView1.DataSource = myTable;
                setControl(false);
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
                dateTimePicker1.Value = DateTime.Parse(myTable.Rows[row]["NgayGiaHan"].ToString());
                dateTimePicker2.Value = DateTime.Parse(myTable.Rows[row]["NgayTaoPhieu"].ToString());
                textBox1.Text = myTable.Rows[row]["MaPhieuGiaHan"].ToString();
                textBox2.Text = myTable.Rows[row]["MaPhieuMuon"].ToString();
                textBox3.Text = myTable.Rows[row]["MaSach"].ToString();
                textBox6.Text = myTable.Rows[row]["SoLuong"].ToString();
                textBox7.Text = myTable.Rows[row]["TenSach"].ToString();
                textBox4.Text = myTable.Rows[row]["MaKH"].ToString();
                textBox5.Text = myTable.Rows[row]["MaNV"].ToString();

            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from dbo.PhieuGiaHanSach where MaPhieuGiaHan = '" + textBox1.Text + "'", conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                FormPHIEUGIAHAN_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setControl(true);
            State = 0;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            if (State == 0)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand smd = new SqlCommand("Update dbo.PhieuGiaHanSach set MaPhieuMuon = @MaPhieuMuon, MaSach = @MaSach, MaKH = @MaKH, MaNV = @MaNV, NgayGiaHan = @NgayGiaHan, NgayTaoPhieu = @NgayTaoPhieu, SoLuong = @SoLuong, TenSach = @TenSach where MaPhieuGiaHan = @MaPhieuGiaHan", conn);
                    smd.Parameters.AddWithValue("@MaPhieuGiaHan", textBox1.Text);
                    smd.Parameters.AddWithValue("@MaPhieuMuon", textBox2.Text);
                    smd.Parameters.AddWithValue("@MaSach", textBox3.Text);
                    smd.Parameters.AddWithValue("@MaKH", textBox4.Text);
                    smd.Parameters.AddWithValue("@MaNV", textBox5.Text);
                    smd.Parameters.AddWithValue("@NgayGiaHan", dateTimePicker1.Value.ToString());
                    smd.Parameters.AddWithValue("@NgayTaoPhieu", dateTimePicker2.Value.ToString());
                    smd.Parameters.AddWithValue("@SoLuong", textBox6.Text);
                    smd.Parameters.AddWithValue("@TenSach", textBox7.Text);
                    smd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công");
                    FormPHIEUGIAHAN_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
        }
    }
}
