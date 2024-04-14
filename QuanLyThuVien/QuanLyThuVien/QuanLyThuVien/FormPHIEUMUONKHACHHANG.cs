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
    public partial class FormPHIEUMUONKHACHHANG : Form
    {
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        string MaKH = "";
        string Quyen = "";
        public FormPHIEUMUONKHACHHANG()
        {
            InitializeComponent();
        }
        public FormPHIEUMUONKHACHHANG(string MaKH, string Quyen)
        {
            this.MaKH = MaKH;
            this.Quyen = Quyen;
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormPHIEUMUONKHACHHANG_Load(object sender, EventArgs e)
        {
            if(Quyen == "KhachHang")
            {
                button4.Visible = false;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = "select MaPhieuMuon, MaSach, TenSach, MaKH, MaNV AS 'Mã nhân viên tạo', NgayHetHanMuon, NgayTaoPhieu, SoLuong  from PhieuMuon where MaKH = '" + MaKH + "'";
                myDataAdapter = new SqlDataAdapter(cmd, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "PhieuMuon");
                myTable = myDataSet.Tables["PhieuMuon"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else if(Quyen == "NhanVien")
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = "select MaPhieuMuon, MaSach, TenSach, MaKH, MaNV AS 'Mã nhân viên tạo', NgayHetHanMuon, NgayTaoPhieu, SoLuong  from PhieuMuon where MaKH = '" + MaKH + "'";
                myDataAdapter = new SqlDataAdapter(cmd, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "PhieuMuon");
                myTable = myDataSet.Tables["PhieuMuon"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            
               
            
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString());
                // Lấy row hiện tại đang được chọn
               
                
                // Lấy giá trị của cell trong row
                string maSach = dataGridView1.CurrentRow.Cells["MaSach"].Value.ToString();
                string tenSach = dataGridView1.CurrentRow.Cells["TenSach"].Value.ToString();
                string maKH = dataGridView1.CurrentRow.Cells["MaKH"].Value.ToString();
                DateTime NgayHetHanMuon = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["NgayHetHanMuon"].Value);
            string SoLuong = dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString();

                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                //SqlCommand smd2 = new SqlCommand("Update dbo.Sach set SoLuongCoTheMuon += '" + textBox2.Text + "' where MaSach = '" + textBox1.Text + "'", conn);
                //smd2.ExecuteNonQuery();

                SqlCommand smd = new SqlCommand("INSERT INTO dbo.DanhSachChoPhieuTraSach (MaSach, MaKH, TenSach,TinhTrangSach, SoLuong, NgayTraSach, NgayHetHanMuon) VALUES('"+ maSach +"', '"+ maKH +"', '"+ tenSach +"', N'', '"+ SoLuong +"', '"+ DateTime.Now +"', '"+ NgayHetHanMuon +"')", conn);
                    SqlCommand smd1 = new SqlCommand("delete PhieuMuon where MaSach ='" + maSach +"'",conn);
                    smd1.ExecuteNonQuery();
                    MessageBox.Show("Trả thành công", "Thông báo");
                    smd.ExecuteNonQuery();
                    FormPHIEUMUONKHACHHANG_Load(sender , e);
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }

        }
        public void Ketnoi()
        {
            try
            {
                if (conn.State == 0)
                {
                    conn.ConnectionString = @"Data Source=DESKTOP-8HCDGC7\\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True";
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable XemDL(string sql)
        {
            Ketnoi();

            SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            return dt;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Thông báo", "Bạn chưa nhập thông tin tìm kiếm");
                    textBox1.Focus();
                }
                else
                {
                    dataGridView1.DataSource = XemDL("select MaSach, TenSach, MaKH, NgayHetHanMuon, NgayTaoPhieu, SoLuong  from PhieuMuon TenSach like '%" + textBox1.Text + "%' ");
                }
            }
            else if (checkBox2.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Thông báo", "Bạn chưa nhập thông tin tìm kiếm");
                    textBox1.Focus();
                }
                else
                {
                    dataGridView1.DataSource = XemDL("select MaSach, TenSach, MaKH, NgayHetHanMuon, NgayTaoPhieu, SoLuong  from PhieuMuon where MaSach like '%" + textBox1.Text + "%' ");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = "select MaSach, TenSach, MaKH, NgayHetHanMuon, NgayTaoPhieu, SoLuong  from PhieuMuon where MaKH = '" + MaKH + "'";
                myDataAdapter = new SqlDataAdapter(cmd, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "PhieuMuon");
                myTable = myDataSet.Tables["PhieuMuon"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string maSach = dataGridView1.CurrentRow.Cells["MaSach"].Value.ToString();
            string tenSach = dataGridView1.CurrentRow.Cells["TenSach"].Value.ToString();
            string maKH = dataGridView1.CurrentRow.Cells["MaKH"].Value.ToString();
            string manv = dataGridView1.CurrentRow.Cells["Mã nhân viên tạo"].Value.ToString();
            string maphieumuon = dataGridView1.CurrentRow.Cells["MaPhieuMuon"].Value.ToString();
            string soluong = dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString();

            GiayTo.FormNGAYGIAHAN fm1 = new GiayTo.FormNGAYGIAHAN(maSach, tenSach, maKH, manv, maphieumuon, soluong);
            fm1.Show();
        }
    }
}
