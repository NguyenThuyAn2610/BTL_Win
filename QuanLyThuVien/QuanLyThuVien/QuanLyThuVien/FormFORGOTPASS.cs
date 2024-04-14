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
    public partial class FormFORGOTPASS : Form
    {
        string Quyen = "";
        string Email = "";
        string MatKhau = "";
        string TenDangNhap = "";
        public FormFORGOTPASS()
        {
            InitializeComponent();
        }
        public FormFORGOTPASS(string TenDangNhap, string MatKhau, string Quyen, string Email)
        {
            this.TenDangNhap = TenDangNhap;
            this.MatKhau = MatKhau;
            this.Quyen = Quyen;
            this.Email = Email;
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

            SqlDataAdapter da1 = new SqlDataAdapter("Select * From dbo.TaiKhoan where  Email= '" + textBox2.Text + "'", conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                TenDangNhap = dt1.Rows[0]["TenDangNhap"].ToString();
                Email = dt1.Rows[0]["Email"].ToString();
            }

            if (Email != textBox2.Text)
            {
                MessageBox.Show("Email không đúng", "Thông báo");
            }
            else if(TenDangNhap != textBox1.Text)
            {
                MessageBox.Show("Tên đăng nhập không đúng", "Thông báo");
            }
            else
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand smd = new SqlCommand("Update dbo.TaiKhoan set MatKhau = @MatKhau, TenDangNhap = @TenDangNhap where Email = @Email", conn);
                    smd.Parameters.AddWithValue("@MatKhau", textBox4.Text);
                    smd.Parameters.AddWithValue("@TenDangNhap", textBox1.Text);
                    smd.Parameters.AddWithValue("@Email", textBox2.Text);

                    smd.ExecuteNonQuery();
                    MessageBox.Show("Thay đổi mật khẩu thành công","Thông báo");
                    FormSETTING_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
            }
        }

        private void FormSETTING_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm1 = new Form1();
            fm1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Email);
        }
    }
}
