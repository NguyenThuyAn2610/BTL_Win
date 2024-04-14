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
    public partial class FormMAIN : Form
    {
        string TenDangNhap = "";
        string MatKhau = "";
        string Quyen = "";
        string Email = "";
        string MaKH = "";
        string MaNV = "";
        string ChucVu = "";
        public FormMAIN()
        {
            InitializeComponent();
        }

        public FormMAIN(string TenDangNhap, string MatKhau, string Quyen, string Email)
        {
            this.TenDangNhap = TenDangNhap;
            this.MatKhau = MatKhau;
            this.Quyen = Quyen;
            this.Email = Email;
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormMAIN_Load(object sender, EventArgs e)
        {
            if(Quyen == "Admin")
            {
                button3.Visible = true;
                button4.Visible = true;
                label2.Text = Quyen;
            }
            
            if(Quyen == "KhachHang")
            {
                button8.Visible = false;
                button4.Visible = false;
                button6.Visible = false;
                button3.Visible = false;
                button7.Visible = false;
                }
            if(Quyen == "KhachHang")
            {
                SqlDataAdapter da1 = new SqlDataAdapter("Select * From dbo.KhachHang where Email= '" + Email + "' ", conn);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    MaKH = dt1.Rows[0]["MaKH"].ToString();
                }
                label2.Text = Quyen;
            }
            else if(Quyen == "NhanVien")
            {
                SqlDataAdapter da1 = new SqlDataAdapter("Select * From dbo.NhanVienThuVien where Email= '" + Email + "' ", conn);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    MaNV = dt1.Rows[0]["MaNV"].ToString();
                    ChucVu = dt1.Rows[0]["ChucVu"].ToString();
                    label2.Text = ChucVu;
                }
                if(ChucVu == "NhanVienKho")
                {
                    button6.Visible = false;
                    button8.Visible = false;
                    button4.Visible = false;
                    button3.Visible = false;
                }
                else if(ChucVu == "ThuThu")
                {
                    button8.Visible = false;
                    
                }
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
            panel3.Controls.Add(formChild);
            panel3.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();

        }
        int clickCount2 = 0;
        int clickCount3 = 0;
        int clickCount4 = 0;
        int clickCount5 = 0;
        int clickCount6 = 0;
        int clickCount7 = 0;
        int clickCount8 = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            clickCount2++;
            if (clickCount2 % 2 == 0)
            {
                button2.BackColor = Color.Transparent;
            }
            else
            {
                button3.BackColor = Color.Transparent;
                button4.BackColor = Color.Transparent;
                button5.BackColor = Color.Transparent;
                button6.BackColor = Color.Transparent;
                
                button8.BackColor = Color.Transparent;

                 clickCount3 = 0;
                 clickCount4 = 0;
                 clickCount5 = 0;
                 clickCount6 = 0;
                 clickCount7 = 0;
                 clickCount8 = 0;
                button2.BackColor = SystemColors.Control;
            }
            ShowForm(new FormSACH(Quyen, TenDangNhap, Email, MaKH));
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            clickCount8++;
            if (clickCount8 % 2 == 0)
            {
                button8.BackColor = Color.Transparent;
            }
            else
            {
                button3.BackColor = Color.Transparent;
                button4.BackColor = Color.Transparent;
                button5.BackColor = Color.Transparent;
                button6.BackColor = Color.Transparent;
                
                button2.BackColor = Color.Transparent;

                 clickCount3 = 0;
                 clickCount4 = 0;
                 clickCount5 = 0;
                 clickCount6 = 0;
                 clickCount7 = 0;
                 clickCount2 = 0;
                button8.BackColor = SystemColors.Control;
            }
            ShowForm(new FormADMINtaikhoan(Quyen, ChucVu, MaNV));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clickCount5++;
            if (clickCount5 % 2 == 0)
            {
                button5.BackColor = Color.Transparent;
            }
            else
            {
                button3.BackColor = Color.Transparent;
                button4.BackColor = Color.Transparent;
                button2.BackColor = Color.Transparent;
                button6.BackColor = Color.Transparent;
                
                button8.BackColor = Color.Transparent;

                 clickCount3 = 0;
                 clickCount4 = 0;
                 clickCount2 = 0;
                 clickCount6 = 0;
                 clickCount7 = 0;
                 clickCount8 = 0;
                button5.BackColor = SystemColors.Control;
            }
            ShowForm(new GiayTo.FormGIAYTO(Quyen, MaKH, MaNV, ChucVu));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clickCount4++;
            if (clickCount4 % 2 == 0)
            {
                button4.BackColor = Color.Transparent;
            }
            else
            {
                button3.BackColor = Color.Transparent;
                button2.BackColor = Color.Transparent;
                button5.BackColor = Color.Transparent;
                button6.BackColor = Color.Transparent;
                
                button8.BackColor = Color.Transparent;

                 clickCount3 = 0;
                 clickCount2 = 0;
                 clickCount5 = 0;
                 clickCount6 = 0;
                 clickCount7 = 0;
                 clickCount8 = 0;
                button4.BackColor = SystemColors.Control;
            }
            ShowForm(new FormKhachHang(MaNV, Quyen));
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm1 = new Form1();
            fm1.Show();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            clickCount3++;
            if (clickCount3 % 2 == 0)
            {
                button3.BackColor = Color.Transparent;
            }
            else
            {
                button2.BackColor = Color.Transparent;
                button4.BackColor = Color.Transparent;
                button5.BackColor = Color.Transparent;
                button6.BackColor = Color.Transparent;
                
                button8.BackColor = Color.Transparent;

                 clickCount2 = 0;
                 clickCount4 = 0;
                 clickCount5 = 0;
                 clickCount6 = 0;
                 clickCount7 = 0;
                 clickCount8 = 0;
                button3.BackColor = SystemColors.Control;
            }
            ShowForm(new FormTHEKHACHHANG(MaNV));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clickCount6++;
            if (clickCount6 % 2 == 0)
            {
                button6.BackColor = Color.Transparent;
            }
            else
            {
                button3.BackColor = Color.Transparent;
                button4.BackColor = Color.Transparent;
                button5.BackColor = Color.Transparent;
                button2.BackColor = Color.Transparent;
                
                button8.BackColor = Color.Transparent;

                 clickCount3 = 0;
                 clickCount4 = 0;
                 clickCount5 = 0;
                 clickCount2 = 0;
                 clickCount7 = 0;
                 clickCount8 = 0;
                button6.BackColor = SystemColors.Control;
            }
            ShowForm(new FormDoanhThu(MaNV));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShowForm(new GiayTo.FormKHOSACH(ChucVu, Quyen));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
