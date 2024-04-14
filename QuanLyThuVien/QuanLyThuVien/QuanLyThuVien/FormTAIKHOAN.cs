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
    public partial class FormTAIKHOAN : Form
    {
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        public int State;
        string Quyen = "";
        string ChucVu = "";
        string MaNV = "";
        string MaNhanVien = "";
        string CV = "";
        public FormTAIKHOAN()
        {
            InitializeComponent();
        }
        public void setControl(bool edit)
        {
            textBox1.Enabled = edit;
            textBox2.Enabled = edit;
            textBox3.Enabled = edit;
            comboBox1.Enabled = edit;
            button1.Enabled = !edit;
            button2.Enabled = !edit;
            button3.Enabled = !edit;
            button4.Enabled = edit;
        }
        public FormTAIKHOAN(string Quyen)
        {
            this.Quyen = Quyen;
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormTAIKHOAN_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (Quyen == "Admin")
                {
                    string cmd = "select * from dbo.TaiKhoan";
                    myDataAdapter = new SqlDataAdapter(cmd, conn);
                    myDataSet = new DataSet();
                    myDataAdapter.Fill(myDataSet, "TaiKhoan");
                    myTable = myDataSet.Tables["TaiKhoan"];
                    setControl(false);
                    dataGridView1.DataSource = myTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else if (Quyen == "QuanLy")
                {
                    string cmd = "select * from TaiKhoan where Quyen <> N'Admin'";
                    myDataAdapter = new SqlDataAdapter(cmd, conn);
                    myDataSet = new DataSet();
                    myDataAdapter.Fill(myDataSet, "TaiKhoan");
                    myTable = myDataSet.Tables["TaiKhoan"];
                    setControl(false);
                    dataGridView1.DataSource = myTable;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }


        private Form currentChildForm;
        private void ShowForm(Form formChild)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = formChild;
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            formChild.Dock = DockStyle.Fill;
            panel1.Controls.Add(formChild);
            panel1.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int row = e.RowIndex;

            textBox3.Text = myTable.Rows[row]["Email"].ToString();
            textBox1.Text = myTable.Rows[row]["TenDangNhap"].ToString();
            textBox2.Text = myTable.Rows[row]["MatKhau"].ToString();
            comboBox1.Text = myTable.Rows[row]["Quyen"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setControl(true);
            textBox1.Focus();
            State = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            State = 0;
            setControl(true);
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (State == 1)
            {
                try
                {
                    if (comboBox1.Text == "")
                    {
                        MessageBox.Show("Vui lòng chọn Quyền cho tài khoản");
                    }
                    else
                    {

                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        SqlCommand smd = new SqlCommand("Insert into dbo.TaiKhoan values(@Email, @MatKhau, @TenDangNhap,@Quyen)", conn);
                        smd.Parameters.AddWithValue("@Email", textBox3.Text);
                        smd.Parameters.AddWithValue("@TenDangNhap", textBox1.Text);
                        smd.Parameters.AddWithValue("@MatKhau", textBox2.Text);
                        smd.Parameters.AddWithValue("@Quyen", comboBox1.SelectedItem);
                        smd.ExecuteNonQuery();
                        FormTAIKHOAN_Load(sender, e);
                        MessageBox.Show("ok");


                    }

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
                    SqlCommand smd = new SqlCommand("Update dbo.TaiKHoan set TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, Quyen = @Quyen where Email = @Email", conn);
                    smd.Parameters.AddWithValue("@Email", textBox3.Text);
                    smd.Parameters.AddWithValue("@TenDangNhap", textBox1.Text);
                    smd.Parameters.AddWithValue("@MatKhau", textBox2.Text);
                    smd.Parameters.AddWithValue("@Quyen", comboBox1.Text);
                    smd.ExecuteNonQuery();
                    FormTAIKHOAN_Load(sender, e);
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
                SqlCommand cmd1 = new SqlCommand("Delete from dbo.TaiKhoan where Email = '" + textBox3.Text + "'", conn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                FormTAIKHOAN_Load(sender, e);

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
