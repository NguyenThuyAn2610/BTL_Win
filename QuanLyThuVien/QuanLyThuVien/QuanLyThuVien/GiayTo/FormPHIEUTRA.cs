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
    public partial class FormPHIEUTRA : Form
    {
        string MaNV = "";
        public FormPHIEUTRA(string MaNV)
        {
            this.MaNV = MaNV;
            InitializeComponent();
        }

        public FormPHIEUTRA()
        {
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormPHIEUTRA_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd1 = "select * from dbo.PhieuTraSach";
                myDataAdapter = new SqlDataAdapter(cmd1, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "PhieuTraSach");
                myTable = myDataSet.Tables["PhieuTraSach"];
                dataGridView1.DataSource = myTable;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                

            string cmd1 = "select * from dbo.PhieuTraSach where NgayTraSach > NgayHetHanMuon";
            myDataAdapter = new SqlDataAdapter(cmd1, conn);
            myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "PhieuTraSach");
            myTable = myDataSet.Tables["PhieuTraSach"];
            dataGridView1.DataSource = myTable;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cmd1 = "select * from dbo.PhieuTraSach ";
            myDataAdapter = new SqlDataAdapter(cmd1, conn);
            myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "PhieuTraSach");
            myTable = myDataSet.Tables["PhieuTraSach"];
            dataGridView1.DataSource = myTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                string MaSach = dataGridView1.CurrentRow.Cells["MaSach"].Value.ToString();
                string MaKH = dataGridView1.CurrentRow.Cells["MaKH"].Value.ToString();
                string TenSach = dataGridView1.CurrentRow.Cells["TenSach"].Value.ToString();
                DateTime NgayTaoPhieu = DateTime.Now;
                GiayTo.FormPHIEUPHATDEMO fm1 = new FormPHIEUPHATDEMO(MaSach, MaNV, MaKH, TenSach);
                fm1.Show();
            }
            catch
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string MaPhieuTra = dataGridView1.CurrentRow.Cells["MaPhieuTra"].Value.ToString();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from dbo.PhieuTraSach where MaPhieuTra = '" + MaPhieuTra + "'", conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                FormPHIEUTRA_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
