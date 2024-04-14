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
    
    public partial class FormPHIEUMUONDEMO : Form
    {
        string MaSach = "";
        string TenSach = "";
        string SoLuongCoTheMuon = "";
        string MaKH = "";
        string SoLuongMuon = "";
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        public FormPHIEUMUONDEMO()
        {
            InitializeComponent();
        }
        public FormPHIEUMUONDEMO(string MaSach, string TenSach, string SoLuongCoTheMuon, string MaKH, string SoLuongMuon)
        {
            this.MaSach = MaSach;
            this.TenSach = TenSach;
            this.SoLuongCoTheMuon = SoLuongCoTheMuon;
            this.MaKH = MaKH;
            this.SoLuongMuon = SoLuongMuon;
            InitializeComponent();
        }

        private void FormPHIEUMUON_Load(object sender, EventArgs e)
        {
            textBox2.Text = SoLuongMuon;
            textBox1.Text = MaSach;
            textBox3.Text = TenSach;
            textBox4.Text = MaKH;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Kiểm tra số lượng sách có thể mượn so với số lượng hiện có
                int soLuongMuon = int.Parse(textBox2.Text); // Số lượng sách muốn mượn
                string maSach = textBox1.Text; // Mã sách cần mượn

                // Lấy số lượng hiện có từ cơ sở dữ liệu
                SqlCommand cmd = new SqlCommand("SELECT SoLuongCoTheMuon FROM dbo.Sach WHERE MaSach = @MaSach", conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                int soLuongHienTai = Convert.ToInt32(cmd.ExecuteScalar());

                if (soLuongMuon <= soLuongHienTai)
                {
                    // Nếu số lượng sách muốn mượn không vượt quá số lượng hiện có
                    SqlCommand updateCmd = new SqlCommand("Update dbo.Sach set SoLuongCoTheMuon -= @SoLuongMuon where MaSach = @MaSach", conn);
                    updateCmd.Parameters.AddWithValue("@SoLuongMuon", soLuongMuon);
                    updateCmd.Parameters.AddWithValue("@MaSach", maSach);
                    updateCmd.ExecuteNonQuery();

                    // Thêm thông tin mượn sách vào bảng DanhSachChoMuonSach
                    SqlCommand insertCmd = new SqlCommand("Insert into dbo.DanhSachChoMuonSach values(@MaSach,@MaKH, @TenSach,@NgayTaoPhieu, @SoLuong, @NgayHetHanMuon)", conn);
                    insertCmd.Parameters.AddWithValue("@MaSach", textBox1.Text);
                    insertCmd.Parameters.AddWithValue("@SoLuong", textBox2.Text);
                    insertCmd.Parameters.AddWithValue("@TenSach", textBox3.Text);
                    insertCmd.Parameters.AddWithValue("@MaKH", textBox4.Text);
                    insertCmd.Parameters.AddWithValue("@NgayHetHanMuon", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                    insertCmd.Parameters.AddWithValue("@NgayTaoPhieu", DateTime.Now);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Đăng ký thành công", "Thông báo");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Số lượng sách muốn mượn vượt quá số lượng hiện có", "Thông báo");
                }
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
}
