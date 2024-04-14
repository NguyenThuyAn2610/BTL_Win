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
    public partial class FormPHIEUPHAT : Form
    {
        public FormPHIEUPHAT()
        {
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");


        List<string> MaKHL = new List<string>();
        public void TaoComboMaKhachHang()
        {
            MaKHL.Add(" ");
            string query = "SELECT DISTINCT MaKH FROM PhieuPhat";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string chude = reader.GetString(0);
                MaKHL.Add(chude);
            }
            comboBox1.DataSource = MaKHL;
            comboBox1.DisplayMember = "MaKH";

        }
        private void FormPHIEUPHAT_Load(object sender, EventArgs e)
        {
            //DateTime currentDate = DateTime.Now;

           // if (currentDate.Day == DateTime.DaysInMonth(currentDate.Year, currentDate.Month) && textBox1.Text !="" )
            //{
            //    button3.Enabled = true;

            //}
            //else
            //{
               // button3.Enabled = false;
           // }
            
            comboBox1.Enabled = false;
            button1.Enabled = false;
            textBox1.Enabled = false;
           
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd1 = "select * from dbo.PhieuPhat";
                myDataAdapter = new SqlDataAdapter(cmd1, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "PhieuPhat");
                myTable = myDataSet.Tables["PhieuPhat"];
                TaoComboMaKhachHang();
                dataGridView1.DataSource = myTable;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string MaPhieuPhat = dataGridView1.CurrentRow.Cells["MaPhieuPhat"].Value.ToString();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from dbo.PhieuPhat where MaPhieuPhat = '" + MaPhieuPhat + "'", conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                FormPHIEUPHAT_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != " ")
            {
                button1.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Enabled = true;
                checkBox2.Checked = false;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SoTienPhat = "SoTienPhat";
            string tableName = "PhieuPhat";
            decimal sum = 0;
            if (checkBox2.Checked == true)
            {
                string query = $"SELECT SUM({SoTienPhat}) FROM {tableName} ";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        sum = Convert.ToDecimal(result);
                        MessageBox.Show("Số tiền phạt là" + sum.ToString());
                        textBox1.Text = sum.ToString();
                    }
                }

            }
            else
            {
                string query = $"SELECT SUM({SoTienPhat}) FROM {tableName} where MaKH = '"+ comboBox1.Text +"'";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        sum = Convert.ToDecimal(result);
                        MessageBox.Show(sum.ToString());
                        
                    }
                }
            }
          
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                button1.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal sum = 0;
            string SoTienPhat = "SoTienPhat";
            string tableName = "PhieuPhat";
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;
            string query = $"SELECT SUM({SoTienPhat}) FROM {tableName} WHERE MONTH(NgayTaoPhieu) = {month} AND YEAR(NgayTaoPhieu) = {year}";
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
                    SqlCommand smd = new SqlCommand("Insert into dbo.DoanhThu values(@Thang, @Nam, @SoTienThu, @SoTienChi)", conn);
                    smd.Parameters.AddWithValue("@Thang", month);
                    smd.Parameters.AddWithValue("@Nam", year);
                    smd.Parameters.AddWithValue("@SoTienThu", sum);
                    smd.Parameters.AddWithValue("@SoTienChi", 0);
                    smd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công số tiền "+ sum + "vào doanh thu");
                }

                else
                {
                    SqlCommand smd1 = new SqlCommand("Update dbo.DoanhThu set SoTienThu += '" + sum + "' where Thang = '" + month.ToString() + "' and Nam = '" + year.ToString() + "'", conn);
                    smd1.ExecuteNonQuery();
                }
            
           
        }
    }
}
