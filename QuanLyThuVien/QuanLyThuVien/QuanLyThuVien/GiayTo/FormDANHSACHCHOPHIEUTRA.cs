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
    public partial class FormDANHSACHCHOPHIEUTRA : Form
    {
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        private DataTable myTablePM;
        string MaNV = "";
        public FormDANHSACHCHOPHIEUTRA()
        {
            InitializeComponent();
        }
        public FormDANHSACHCHOPHIEUTRA(string MaNV)
        {
            this.MaNV = MaNV;
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormDANHSACHCHOPHIEUTRA_Load(object sender, EventArgs e)
        {

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd1 = "select * from dbo.DanhSachChoPhieuTraSach";
                myDataAdapter = new SqlDataAdapter(cmd1, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "DanhSachChoPhieuTraSach");
                myTable = myDataSet.Tables["DanhSachChoPhieuTraSach"];
                dataGridView1.DataSource = myTable;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                dateTimePicker1.Value = DateTime.Parse(myTable.Rows[row]["NgayTraSach"].ToString());
                dateTimePicker2.Value = DateTime.Parse(myTable.Rows[row]["NgayHetHanMuon"].ToString());
                textBox1.Text = myTable.Rows[row]["MaSach"].ToString();
                textBox2.Text = myTable.Rows[row]["MaKH"].ToString();
                textBox3.Text = myTable.Rows[row]["TenSach"].ToString();
                textBox4.Text = myTable.Rows[row]["Soluong"].ToString();
                textBox5.Text = myTable.Rows[row]["MaPhieuTra"].ToString();
                textBox6.Text = myTable.Rows[row]["TinhTrangSach"].ToString();
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string MaSach = dataGridView1.CurrentRow.Cells["MaSach"].Value.ToString();
            string MaKH = dataGridView1.CurrentRow.Cells["MaKH"].Value.ToString();
            string TenSach = dataGridView1.CurrentRow.Cells["TenSach"].Value.ToString();
            string SoLuong = dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString();
            string TinhTrang = dataGridView1.CurrentRow.Cells["TinhTrangSach"].Value.ToString();
            DateTime NgayTraSach = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["NgayTraSach"].Value);
            DateTime NgayHetHanMuon = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["NgayHetHanMuon"].Value);
            DateTime NgayTaoSach = DateTime.Now;
            string STT = dataGridView1.CurrentRow.Cells["STT"].Value.ToString();
            string manv = MaNV;
            //GiayTo.FormPHIEUTRADEMO fm1 = new GiayTo.FormPHIEUTRADEMO(MaSach, TenSach, SoLuong, MaKH, NgayTraSach, NgayTaoSach, manv, TinhTrang, NgayHetHanMuon);
            //fm1.Show();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand smd = new SqlCommand("delete DanhSachChoPhieuTraSach where STT = '"+ STT +"'", conn);
                smd.ExecuteNonQuery();
                SqlCommand smd1 = new SqlCommand("insert into dbo.PhieuTraSach(MaSach, MaKH, MaNV, TenSach, NgayTaoPhieu, TinhTrangSach, SoLuong, NgayTraSach, NgayHetHanMuon) values(@MaSach, @MaKH, @MaNV, @TenSach, @NgayTaoPhieu, @TinhTrangSach, @SoLuong, @NgayTraSach, @NgayHetHanMuon)", conn);
                smd1.Parameters.Add("@MaSach", MaSach);
                smd1.Parameters.Add("@MaKH", MaKH);
                smd1.Parameters.Add("@MaNV", manv);
                smd1.Parameters.Add("@TenSach", TenSach);
                smd1.Parameters.Add("@NgayTaoPhieu", NgayTaoSach);
                smd1.Parameters.Add("@TinhTrangSach", TinhTrang);
                smd1.Parameters.Add("@SoLuong", SoLuong);
                smd1.Parameters.Add("@NgayTraSach", NgayTraSach);
                smd1.Parameters.Add("@NgayHetHanMuon", NgayHetHanMuon);
                smd1.ExecuteNonQuery();
                FormDANHSACHCHOPHIEUTRA_Load(sender, e);
                MessageBox.Show("Tạo phiếu trả thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand smd = new SqlCommand("Update dbo.DanhSachChoPhieuTraSach set TinhTrangSach = '" + textBox6.Text +"' where MaSach = '"+ textBox1.Text +"'", conn);

                smd.ExecuteNonQuery();
                FormDANHSACHCHOPHIEUTRA_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string STT = dataGridView1.CurrentRow.Cells["STT"].Value.ToString();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand smd = new SqlCommand("DELETE dbo.DanhSachChoPhieuTraSach where STT = '"+ STT +"'",conn);
                MessageBox.Show("Xóa thành công");
                FormDANHSACHCHOPHIEUTRA_Load(sender, e);
                smd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
