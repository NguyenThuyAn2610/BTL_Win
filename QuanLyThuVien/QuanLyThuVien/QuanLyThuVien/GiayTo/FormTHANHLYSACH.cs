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
    public partial class FormTHANHLYSACH : Form
    {
        string MaNV = "";
        public FormTHANHLYSACH()
        {
            InitializeComponent();
        }

        public FormTHANHLYSACH(string MaNV)
        {
            this.MaNV = MaNV;
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        public int State;
        public void setControl(bool edit)
        {
            textBox1.Enabled = edit;
            textBox2.Enabled = edit;
            textBox3.Enabled = edit;
            textBox4.Enabled = edit;
            dateTimePicker1.Enabled = edit;
            textBox6.Enabled = edit;
            button1.Enabled = !edit;
            button2.Enabled = !edit;
            button3.Enabled = !edit;
            button4.Enabled = edit;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormTHANHLYSACH_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string cmd = "select * from dbo.PhieuThanhLySach";
                myDataAdapter = new SqlDataAdapter(cmd, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "PhieuThanhLySach");
                myTable = myDataSet.Tables["PhieuThanhLySach"];
                textBox1.Text = MaNV;
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                setControl(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setControl(true);
            State = 1;
            textBox2.Clear();
            textBox2.Enabled = false;
            textBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setControl(true);
            State = 0;
            textBox2.Enabled = false;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from dbo.PhieuThanhLySach where MaPhieuThanhLy = '" + textBox2.Text + "'", conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                FormTHANHLYSACH_Load(sender, e);
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
                    SqlCommand cmd = new SqlCommand("SELECT dbo.AUTO_IDPTL()", conn);
                    string id = cmd.ExecuteScalar().ToString();
                    SqlCommand smd = new SqlCommand("Insert into dbo.PhieuThanhLySach(MaNhanVien, MaPhieuThanhLy, MaSach, TenSach,NgayTao,SoLuong, LyDoThanhLy) values(@MaNhanVien, @MaPhieuThanhLy, @MaSach, @TenSach,@NgayTao,@SoLuong,@LyDoThanhLy)", conn);
                    smd.Parameters.AddWithValue("@MaNhanVien", textBox1.Text);
                    smd.Parameters.AddWithValue("@MaPhieuThanhLy", id);
                    smd.Parameters.AddWithValue("@MaSach", textBox3.Text);
                    smd.Parameters.AddWithValue("@TenSach", textBox4.Text);
                    smd.Parameters.AddWithValue("@NgayTao", dateTimePicker1.Value.ToString());
                    smd.Parameters.AddWithValue("@SoLuong", textBox6.Text);
                    smd.Parameters.AddWithValue("@LyDoThanhLy", textBox5.Text);
                    smd.ExecuteNonQuery();
                    FormTHANHLYSACH_Load(sender, e);
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
                    SqlCommand smd = new SqlCommand("Update dbo.PhieuThanhLySach set MaNhanVien = @MaNhanVien, MaPhieuThanhLy = @MaPhieuThanhLy, MaSach = @MaSach, TenSach = @TenSach,NgayTao = @NgayTao,SoLuong = @SoLuong, LyDoThanhLy = @LyDoThanhLy where MaPhieuThanhLy = @MaPhieuThanhLy", conn);
                    smd.Parameters.AddWithValue("@MaNhanVien", textBox1.Text);
                    smd.Parameters.AddWithValue("@MaPhieuThanhLy", textBox2.Text);
                    smd.Parameters.AddWithValue("@MaSach", textBox3.Text);
                    smd.Parameters.AddWithValue("@TenSach", textBox4.Text);
                    smd.Parameters.AddWithValue("@NgayTao", dateTimePicker1.Value.ToString());
                    smd.Parameters.AddWithValue("@SoLuong", textBox6.Text);
                    smd.Parameters.AddWithValue("@LyDoThanhLy", textBox5.Text);
                    smd.ExecuteNonQuery();
                    FormTHANHLYSACH_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int row = e.RowIndex;

                textBox3.Text = myTable.Rows[row]["MaSach"].ToString();
                dateTimePicker1.Text = myTable.Rows[row]["NgayTao"].ToString();
                textBox2.Text = myTable.Rows[row]["MaPhieuThanhLy"].ToString();
                textBox4.Text = myTable.Rows[row]["TenSach"].ToString();
                textBox6.Text = myTable.Rows[row]["SoLuong"].ToString();
                textBox1.Text = myTable.Rows[row]["MaNV"].ToString();
                textBox5.Text = myTable.Rows[row]["LyDoThanhLy"].ToString();
            }
            catch
            {

            }
        }
    }
}
