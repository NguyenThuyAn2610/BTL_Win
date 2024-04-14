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
    public partial class FormDANHSACHCHOPHIEUMUON : Form
    {
        string MaNV = "";
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        private DataTable myTablePM;
        public int state;
        public FormDANHSACHCHOPHIEUMUON()
        {
            InitializeComponent();
        }
        public FormDANHSACHCHOPHIEUMUON(string MaNV)
        {
            this.MaNV = MaNV;
            InitializeComponent();
        }
        
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        
        private void FormDANHSACHPHIEUMUON_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd1 = "select * from dbo.DanhSachChoMuonSach";
                myDataAdapter = new SqlDataAdapter(cmd1, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "DanhSachChoMuonSach");
                myTable = myDataSet.Tables["DanhSachChoMuonSach"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                dateTimePicker1.Value = DateTime.Parse(myTable.Rows[row]["NgayHetHanMuon"].ToString());
                textBox1.Text = myTable.Rows[row]["MaSach"].ToString();
                textBox2.Text = myTable.Rows[row]["MaKH"].ToString();
                textBox3.Text = myTable.Rows[row]["TenSach"].ToString();
                textBox4.Text = myTable.Rows[row]["Soluong"].ToString();
            }
            catch
            {

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            state = 1;
            button3.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (state == 1)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    // Xóa dữ liệu từ bảng DanhSachChoMuonSach
                    SqlCommand cmd = new SqlCommand("DELETE FROM dbo.DanhSachChoMuonSach WHERE MaSach = @MaSach", conn);
                    cmd.Parameters.AddWithValue("@MaSach", textBox1.Text);
                    cmd.ExecuteNonQuery();

                    // Tạo Phiếu Mượn sách
                    SqlCommand cmdGetID = new SqlCommand("SELECT dbo.AUTO_IDPM()", conn);
                    string id = cmdGetID.ExecuteScalar().ToString();

                    SqlCommand cmdInsertPhieuMuon = new SqlCommand("INSERT INTO dbo.PhieuMuon VALUES(@MaPhieuMuon, @MaSach, @MaNV, @MaKH, @TenSach, @NgayTaoPhieu, @SoLuong, @NgayHetHanMuon)", conn);
                    cmdInsertPhieuMuon.Parameters.AddWithValue("@MaPhieuMuon", id);
                    //cmdInsertPhieuMuon.Parameters.AddWithValue("@TenPhieuMuon");
                    cmdInsertPhieuMuon.Parameters.AddWithValue("@MaSach", textBox1.Text);
                    cmdInsertPhieuMuon.Parameters.AddWithValue("@MaNV", MaNV);
                    cmdInsertPhieuMuon.Parameters.AddWithValue("@SoLuong", textBox4.Text);
                    cmdInsertPhieuMuon.Parameters.AddWithValue("@TenSach", textBox3.Text);
                    cmdInsertPhieuMuon.Parameters.AddWithValue("@MaKH", textBox2.Text);
                    cmdInsertPhieuMuon.Parameters.AddWithValue("@NgayHetHanMuon", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                    cmdInsertPhieuMuon.Parameters.AddWithValue("@NgayTaoPhieu", DateTime.Now);
                    cmdInsertPhieuMuon.ExecuteNonQuery();

                    MessageBox.Show("Tạo thành công");
                    FormDANHSACHPHIEUMUON_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loi ket noi");
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from dbo.DanhSachChoMuonSach where MaSach = '" + textBox1.Text + "'", conn);
                SqlCommand cmd1 = new SqlCommand("Update dbo.Sach set SoLuongCoTheMuon += '" + textBox4.Text + "'", conn);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công", "Thông báo");
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                FormDANHSACHPHIEUMUON_Load(sender, e);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
