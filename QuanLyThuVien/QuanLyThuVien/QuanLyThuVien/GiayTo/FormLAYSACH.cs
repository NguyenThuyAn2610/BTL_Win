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
    public partial class FormLAYSACH : Form
    {
        string MaSach = "";
        string TenSach = "";
        string TacGia = "";
        int SoLuong = 0;
        public FormLAYSACH()
        {
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        public int State;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        public FormLAYSACH(string MaSach, string TenSach, string TacGia, int SoLuong)
        {
            this.MaSach = MaSach;
            this.TenSach = TenSach;
            this.TacGia = TacGia;
            this.SoLuong = SoLuong;
            InitializeComponent();
        }
        List<int> soluong = new List<int>();
        private void FormLAYSACH_Load(object sender, EventArgs e)
        {
           
            for(int i = 0; i<= SoLuong; i++)
            {
                soluong.Add(i);
            }
            


            comboBox2.DataSource = soluong;
            textBox1.Text = MaSach;
            textBox2.Text = TenSach;
            textBox4.Text = TacGia;
            

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT COUNT(MaSach) FROM Sach WHERE TenSach=@TenSach", conn);
                cmd.Parameters.AddWithValue("@TenSach", textBox2.Text);
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {

                    SqlCommand smd1 = new SqlCommand("Update dbo.KhoSach set SoLuong -= '" + comboBox2.Text + "' where MaSach = '" + MaSach + "'", conn);
                    smd1.ExecuteNonQuery();
                    SqlCommand smd = new SqlCommand("Insert into dbo.Sach values(@MaSach, @TenSach, @TacGia,@TinhTrangMuon,@NamXB,@SoLuongCoTheMuon,@ChuDe, @SoTien)", conn);
                    smd.Parameters.AddWithValue("@MaSach", textBox1.Text);
                    smd.Parameters.AddWithValue("@TenSach", textBox2.Text);
                    smd.Parameters.AddWithValue("@TacGia", textBox4.Text);
                    smd.Parameters.AddWithValue("@TinhTrangMuon", comboBox1.SelectedItem.ToString());
                    smd.Parameters.AddWithValue("@NamXB", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                    smd.Parameters.AddWithValue("@SoLuongCoTheMuon", comboBox2.Text);
                    smd.Parameters.AddWithValue("@ChuDe", textBox8.Text);
                    smd.Parameters.AddWithValue("@SoTien", textBox7.Text);
                    MessageBox.Show("Lấy thành công");
                    smd.ExecuteNonQuery();
                }
                else 
                {
                    
                    SqlCommand smd1 = new SqlCommand("Update dbo.KhoSach set SoLuong -= '" + comboBox2.Text + "' where MaSach = '" + MaSach + "'", conn);
                    smd1.ExecuteNonQuery();
                    SqlCommand smd2 = new SqlCommand("Update dbo.Sach set SoLuongCoTheMuon += '" + comboBox2.Text + "' where MaSach = '" + MaSach + "'", conn);
                    smd2.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã lấy thêm " + comboBox2.Text + " quyển sách");
                }
            }
            catch
            {

            }
            
           
        }
    }
}
