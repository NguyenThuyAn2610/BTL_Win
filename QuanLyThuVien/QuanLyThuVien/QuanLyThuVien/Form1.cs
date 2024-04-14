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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.Font = new Font(button3.Font, FontStyle.Underline);
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {

            button3.ForeColor = Color.Black;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Blue;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormFORGOTPASS fm2 = new FormFORGOTPASS();
            fm2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string TenDangNhap = "";
            string MatKhau = "";
            string Quyen = "";
            string Email = "";
            string MaKH = "";

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo");
            }
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Integrated Security=True");

                SqlDataAdapter da1 = new SqlDataAdapter("Select * From dbo.TaiKhoan where TenDangNhap= '" + textBox1.Text + "' and MatKhau= '" + textBox2.Text + "'", conn);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                     TenDangNhap = dt1.Rows[0]["TenDangNhap"].ToString();
                     MatKhau = dt1.Rows[0]["MatKhau"].ToString();
                     Quyen = dt1.Rows[0]["Quyen"].ToString();
                     Email = dt1.Rows[0]["Email"].ToString();
                    MessageBox.Show("Đăng nhập thành công", "Admin");
                    FormMAIN frm = new FormMAIN(TenDangNhap, MatKhau, Quyen, Email);
                    frm.Show();
                    this.Hide();
                }

                
                }

        private void button4_Click(object sender, EventArgs e)
        {

            FormREGISTER fm2 = new FormREGISTER();
            fm2.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
    }

   

        
    }

