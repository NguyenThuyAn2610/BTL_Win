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
    
    public partial class FormKhachHang : Form
    {
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        private DataTable myTableTK;
        public int state;
        string MaNV = "";
        string Quyen = "";
        public FormKhachHang()
        {
            InitializeComponent();
        }
        public FormKhachHang(string MaNV, string Quyen)
        {
            this.MaNV = MaNV;
            this.Quyen = Quyen;
            InitializeComponent();
        }
        public string conn = @"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True";

        public void setControl(bool edit)
        {
            textBox1.Enabled = edit;
            textBox2.Enabled = edit;
            textBox3.Enabled = edit;
            textBox4.Enabled = edit;
            comboBox1.Enabled = edit;
            button2.Enabled = !edit;
        }
        public void taoCombo()
        {
            try
            {
                string SqlStr = "SELECT * FROM TaiKhoan";
                //Tao thong qua xau ket noi da mo
                myDataAdapter = new SqlDataAdapter(SqlStr, myConnection);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "TaiKhoan");
                myTableTK = myDataSet.Tables["TaiKhoan"];
                //Tao combo donvi
                if (myTableTK.Rows.Count > 0)
                {
                    comboBox1.DataSource = myTableTK;
                    comboBox1.DisplayMember = "TenDangNhap";
                    comboBox1.ValueMember = "Email";
                }
            }
            catch { MessageBox.Show("Có lỗi dữ liệu", "Thông báo lỗi"); }

        }
        private void Display()
        {
            string SqlStr = "SELECT KhachHang.*, TenDangNhap FROM KhachHang INNER JOIN TaiKhoan ON KhachHang.Email = TaiKhoan.Email";
            //Tao thong qua xau ket noi da mo
            //string SqlStr = "SELECT * FROM KhachHang ";
            myDataAdapter = new SqlDataAdapter(SqlStr, myConnection);
            myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "KhachHang");
            myTable = myDataSet.Tables["KhachHang"];
            //Chuyen len luoi
            dataGridView1.DataSource = myTable;
            string Email = myTable.Rows[0]["Email"].ToString();
            textBox3.Text = Email;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            taoCombo();
            
        }

        private void FormKhashHang_Load(object sender, EventArgs e)
        {
            setControl(false);
            myConnection = new SqlConnection(conn);
            myConnection.Open();
            Display();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                textBox1.Text = myTable.Rows[row]["MaKH"].ToString();
                textBox2.Text = myTable.Rows[row]["TenKH"].ToString();
                textBox4.Text = myTable.Rows[row]["SDT"].ToString();
                textBox3.Text = myTable.Rows[row]["Email"].ToString();
                comboBox1.SelectedValue =
                myTable.Rows[row]["Email"].ToString();
            }
            catch (Exception) { }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            setControl(true);
            state = 1;
            textBox1.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (state == 1)
            {
                try
                {
                    if (myConnection.State == ConnectionState.Closed)
                    {
                        myConnection.Open();
                    }
                    SqlCommand smd = new SqlCommand("Update dbo.KhachHang set TenKH = @TenKH, Email = @Email, SDT = @SDT where MaKH = @MaKH", myConnection);
                    smd.Parameters.AddWithValue("@MaKH", textBox1.Text);
                    smd.Parameters.AddWithValue("@TenKH", textBox2.Text);
                    smd.Parameters.AddWithValue("@Email", comboBox1.SelectedValue.ToString());;
                    smd.Parameters.AddWithValue("@SDT", textBox4.Text);
                    smd.ExecuteNonQuery();
                    FormKhashHang_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
            else if(state == 0)
            {
                SqlCommand cmd1 = new SqlCommand("SELECT dbo.AUTO_IDKH()", myConnection);
                string id = cmd1.ExecuteScalar().ToString();
                try
                {
                    if (myConnection.State == ConnectionState.Closed)
                    {
                        myConnection.Open();
                    }
                    SqlCommand smd = new SqlCommand("Insert into dbo.KhachHang(MaKH, TenKH, Email, SDT) values(@MaKH, @TenKH, @Email, @SDT)  ", myConnection);
                    smd.Parameters.AddWithValue("@MaKH", id);
                    smd.Parameters.AddWithValue("@TenKH", textBox2.Text);
                    smd.Parameters.AddWithValue("@Email", textBox3.Text); ;
                    smd.Parameters.AddWithValue("@SDT", textBox4.Text);
                    smd.ExecuteNonQuery();
                    FormKhashHang_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (myConnection.State == ConnectionState.Closed)
                    myConnection.Open();
                SqlCommand cmd = new SqlCommand("Delete from dbo.KhachHang where MaKH = '" + textBox1.Text + "'", myConnection);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
                FormKhashHang_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            setControl(true);
            state = 0;
            textBox1.Text = "";
            textBox1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string MaKH = dataGridView1.CurrentRow.Cells["MaKH"].Value.ToString();
            Formsach.FormCHITIETSACH fm1 = new Formsach.FormCHITIETSACH(MaKH, Quyen);
            fm1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string MaKH = dataGridView1.CurrentRow.Cells["MaKH"].Value.ToString();
            //Tao thong qua xau ket noi da mo
            //string SqlStr = "SELECT * FROM KhachHang ";
            string query = "SELECT COUNT(*) FROM PhieuMuon WHERE MaKH = @MaKH";
            using (SqlCommand command = new SqlCommand(query, myConnection))
            {
                command.Parameters.AddWithValue("@MaKH", MaKH);
                int count = (int)command.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Khách hàng này chưa mượn sách");
                }
                else
                {
                    FormPHIEUMUONKHACHHANG fm1 = new FormPHIEUMUONKHACHHANG(MaKH, Quyen);
                    fm1.Show();
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string MaKH = dataGridView1.CurrentRow.Cells["MaKH"].Value.ToString();
            string TenKH = dataGridView1.CurrentRow.Cells["TenKH"].Value.ToString();
            string SDT = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
            string Email = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
            string checkValueQuery = "IF EXISTS(SELECT 1 FROM dbo.TheKhachHang WHERE MaKH = '" + MaKH + "') SELECT 1 ELSE SELECT 0";
            SqlCommand cmd = new SqlCommand(checkValueQuery, myConnection);
            int exists = (int)cmd.ExecuteScalar();
            if(exists == 1)
            {
                MessageBox.Show("Khách hàng này đã có thẻ","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FormTHEKHACHHANGDEMO fm1 = new FormTHEKHACHHANGDEMO(MaNV, MaKH, TenKH, SDT, Email);
                fm1.Show();
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string MaKH = dataGridView1.CurrentRow.Cells["MaKH"].Value.ToString();
            string query = "SELECT COUNT(*) FROM PhieuMuon WHERE MaKH = @MaKH";
            using (SqlCommand command = new SqlCommand(query, myConnection))
            {
                command.Parameters.AddWithValue("@MaKH", MaKH);
                int count = (int)command.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Khách hàng này chưa mượn sách");
                }
                else
                {
                    FormPHIEUMUONKHACHHANG fm1 = new FormPHIEUMUONKHACHHANG(MaKH, Quyen);
                    fm1.Show();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
