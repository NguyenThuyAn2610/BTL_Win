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
    public partial class FormREGISTER : Form
    {
        public FormREGISTER()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormREGISTER_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Nhập tên tài khoản";
            textBox2.Text = "Nhập mật khẩu";
            textBox3.Text = "Nhập Email";
            textBox4.Text = "Nhập lại mật khẩu";
            textBox5.Text = "Nhập tên của bạn";
            textBox6.Text = "Nhập số điện thoại";
        }
       
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nhập tên tài khoản")
            {
                textBox1.Text = "";
                
            }
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định nếu TextBox rỗng
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Nhập tên tài khoản";
            }
        }

        
        

        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = "Nhập mật khẩu";
            }
        }

        private void textBox2_Enter_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "Nhập mật khẩu")
            {
                textBox2.Text = "";

            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Nhập Email")
            {
                textBox3.Text = "";

            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Text = "Nhập Email";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Text = "Nhập lại mật khẩu";
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {

            if (textBox4.Text == "Nhập lại mật khẩu")
            {
                textBox4.Text = "";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(100000); // tạo số nguyên ngẫu nhiên từ 0 đến 99999
            string randomID = randomNumber.ToString("D5");
            if (textBox1.Text == "Nhập tên tài khoản" || textBox2.Text == "Nhập mật khẩu" || textBox3.Text == "Nhập Email" || textBox4.Text == "Nhập lại mật khẩu" || textBox5.Text == "Nhập tên của bạn" || textBox6.Text == "Nhập số điện thoại")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin");
            }
            else 
            {
                if(textBox4.Text != textBox2.Text)
                {
                    MessageBox.Show("Mật khẩu không khớp");
                }
                else
                {
                    try
                    {

                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        SqlCommand cmd = new SqlCommand("SELECT dbo.AUTO_IDKH()", conn);
                        string id = cmd.ExecuteScalar().ToString();
                        SqlCommand smd = new SqlCommand("Insert into dbo.TaiKhoan values(@Email, @MatKhau, @TenDangNhap,@Quyen)", conn);
                        smd.Parameters.AddWithValue("@TenDangNhap", textBox1.Text);
                        smd.Parameters.AddWithValue("@MatKhau", textBox2.Text);
                        smd.Parameters.AddWithValue("@Email", textBox3.Text);
                        smd.Parameters.AddWithValue("@Quyen", "KhachHang");
                        

                        SqlCommand smd1 = new SqlCommand("Insert into dbo.KhachHang values(@MaKH, @TenKH, @Email,@SDT)", conn);
                        smd1.Parameters.AddWithValue("@TenKH", textBox5.Text);
                        smd1.Parameters.AddWithValue("@SDT", textBox6.Text);
                        smd1.Parameters.AddWithValue("@Email", textBox3.Text);
                        smd1.Parameters.AddWithValue("@MaKH", id);


                        smd.ExecuteNonQuery();
                        smd1.ExecuteNonQuery();


                        FormREGISTER_Load(sender, e);
                        MessageBox.Show("Đăng kí thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Loi ket noi");
                    }
                }
                
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                textBox5.Text = "Nhập tên của bạn";
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Nhập tên của bạn")
            {
                textBox5.Text = "";

            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                textBox6.Text = "Nhập số điện thoại";
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Nhập số điện thoại")
            {
                textBox6.Text = "";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm1 = new Form1();
            fm1.Show();
        }
    }
}
