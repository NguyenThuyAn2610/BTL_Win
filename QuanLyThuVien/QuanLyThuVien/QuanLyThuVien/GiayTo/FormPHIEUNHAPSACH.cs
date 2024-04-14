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
    public partial class FormPHIEUNHAPSACH : Form
    {
        string MaNV = "";
        public FormPHIEUNHAPSACH()
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
        public FormPHIEUNHAPSACH(string MaNV)
        {
            this.MaNV = MaNV;
            InitializeComponent();
        }
        
        private void FormPHIEUNHAPSACH_Load(object sender, EventArgs e)
        {
            //DateTime currentDate = DateTime.Now;

            //if (currentDate.Day == DateTime.DaysInMonth(currentDate.Year, currentDate.Month))
            //{
            //    button5.Enabled = true;

            //}
            //else
            //{
             //   button5.Enabled = false;
            //}

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string cmd = "select * from dbo.PhieuNhapSach";
                myDataAdapter = new SqlDataAdapter(cmd, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "PhieuNhapSach");
                myTable = myDataSet.Tables["PhieuNhapSach"];
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
        public void setControl(bool edit)
        {
            textBox1.Enabled = edit;
            textBox2.Enabled = edit;
            textBox3.Enabled = edit;
            textBox4.Enabled = edit;
            textBox5.Enabled = edit;
            textBox7.Enabled = edit;
            dateTimePicker1.Enabled = edit;
            textBox6.Enabled = edit;
            button1.Enabled = !edit;
            button2.Enabled = !edit;
            button3.Enabled = !edit;
            button4.Enabled = edit;
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
                    string checkValueQuery = "IF EXISTS(SELECT 1 FROM dbo.KhoSach WHERE MaSach = '" + textBox3.Text + "') SELECT 1 ELSE SELECT 0";
                    SqlCommand cmd = new SqlCommand(checkValueQuery, conn);
                    int exists = (int)cmd.ExecuteScalar();
                    if (exists == 1)
                    {
                        MessageBox.Show("Loại sách này đã có trong kho, sẽ thêm số lượng sách đã nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SqlCommand smd2 = new SqlCommand("Update dbo.KhoSach set  SoLuong += '"+ textBox6.Text +"' where MaSach = '"+ textBox3.Text +"'", conn);
                        smd2.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật số lượng của loại sách " + textBox3.Text + "thành công", "Thông báo");
                    }
                    else
                    {
                        SqlCommand cmd1 = new SqlCommand("SELECT dbo.AUTO_IDPN()", conn);
                        string id = cmd1.ExecuteScalar().ToString();
                        SqlCommand smd = new SqlCommand("Insert into dbo.PhieuNhapSach(MaNV, MaPhieuNhap, MaSach, TenSach,NgayTao,SoLuong, SoTienNhap, TacGia) values(@MaNV, @MaPhieuNhap, @MaSach, @TenSach,@NgayTao,@SoLuong, @SoTienNhap, @TacGia)", conn);
                        smd.Parameters.AddWithValue("@MaNV", textBox1.Text);
                        smd.Parameters.AddWithValue("@MaPhieuNhap", id);
                        smd.Parameters.AddWithValue("@MaSach", textBox3.Text);
                        smd.Parameters.AddWithValue("@TenSach", textBox4.Text);
                        smd.Parameters.AddWithValue("@NgayTao", dateTimePicker1.Value.ToString());
                        smd.Parameters.AddWithValue("@SoLuong", textBox6.Text);
                        smd.Parameters.AddWithValue("@SoTienNhap", textBox5.Text);
                        smd.Parameters.AddWithValue("@TacGia", textBox7.Text);
                        

                        //SqlCommand cmd12 = new SqlCommand("SELECT dbo.AUTO_IDB()", conn);
                        //string id = cmd12.ExecuteScalar().ToString();
                        SqlCommand smd2 = new SqlCommand("insert into KhoSach( MaSach, TenSach,TacGia, SoLuong) values('"+ textBox3.Text +"', '"+ textBox4.Text +"', '"+ textBox7.Text +"', '"+ textBox6.Text +"')", conn);
                        

                        smd.ExecuteNonQuery();
                        smd2.ExecuteNonQuery();


                        FormPHIEUNHAPSACH_Load(sender, e);
                        MessageBox.Show("Thêm thành công");


                    }
                   

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
                    SqlCommand smd = new SqlCommand("Update dbo.PhieuNhapSach set MaNV = @MaNV, MaPhieuNhap = @MaPhieuNhap, MaSach = @MaSach, TenSach = @TenSach,NgayTao = @NgayTao,SoLuong = @SoLuong, SoTienNhap = @SoTienNhap where MaPhieuNhap = @MaPhieuNhap", conn);
                    smd.Parameters.AddWithValue("@MaNV", textBox1.Text);
                    smd.Parameters.AddWithValue("@MaPhieuNhap", textBox2.Text);
                    smd.Parameters.AddWithValue("@MaSach", textBox3.Text);
                    smd.Parameters.AddWithValue("@TenSach", textBox4.Text);
                    smd.Parameters.AddWithValue("@NgayTao", dateTimePicker1.Value.ToString());
                    smd.Parameters.AddWithValue("@SoLuong", textBox6.Text);
                    smd.Parameters.AddWithValue("@SoTienNhap", textBox5.Text);
                    smd.ExecuteNonQuery();
                    FormPHIEUNHAPSACH_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from dbo.PhieuNhapSach where MaPhieuNhap = '" + textBox2.Text + "'", conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                FormPHIEUNHAPSACH_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            decimal sum = 0;
            string SoTienNhap = "SoTienNhap";
            string tableName = "PhieuNhapSach";
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;
            string query = $"SELECT SUM({SoTienNhap}) FROM {tableName} WHERE MONTH(NgayTao) = {month} AND YEAR(NgayTao) = {year}";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    sum = Convert.ToDecimal(result);
                }
            }

           
            
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM DoanhThu WHERE Thang=@Thang AND Nam=@Nam", conn);
            cmd.Parameters.AddWithValue("@Thang", month);
            cmd.Parameters.AddWithValue("@Nam", year);

            int count = (int)cmd.ExecuteScalar();
                
               if(count == 0)
            {
                SqlCommand smd = new SqlCommand("Insert into dbo.DoanhThu(Thang, Nam, SoTienThu, SoTienChi) values(@Thang, @Nam, @SoTienThu, @SoTienChi)", conn);
                smd.Parameters.AddWithValue("@Thang", month.ToString());
                smd.Parameters.AddWithValue("@Nam", year.ToString());
                smd.Parameters.AddWithValue("@SoTienChi", sum);
                smd.Parameters.AddWithValue("@SoTienThu", 0);
                MessageBox.Show("Cập nhật doanh thu thành công");
                smd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand smd1 = new SqlCommand("Update dbo.DoanhThu set SoTienChi += '" + sum + "' where Thang = '" + month + "' and Nam = '" + year + "'", conn);
                MessageBox.Show("Cập nhật doanh thu thành công");
                smd1.ExecuteNonQuery();
            }
                
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                int row = e.RowIndex;
                textBox3.Text = myTable.Rows[row]["MaSach"].ToString();
                dateTimePicker1.Text = myTable.Rows[row]["NgayTao"].ToString();
                textBox2.Text = myTable.Rows[row]["MaPhieuNhap"].ToString();
                textBox4.Text = myTable.Rows[row]["TenSach"].ToString();
                textBox6.Text = myTable.Rows[row]["SoLuong"].ToString();
                textBox1.Text = myTable.Rows[row]["MaNV"].ToString();
                textBox5.Text = myTable.Rows[row]["SoTienNhap"].ToString();
                textBox7.Text = myTable.Rows[row]["TacGia"].ToString();
            } catch { }
        }
    }
}
