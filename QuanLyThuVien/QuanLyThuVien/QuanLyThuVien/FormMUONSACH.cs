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
    public partial class FormMUONSACH : Form
    {
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        string masach = "";
        string makhachhang = "";
        string tensach = "";
        string datetime = "";
        string soluong = "";
        
        public FormMUONSACH()
        {
            InitializeComponent();
        }
        public FormMUONSACH(string masach, string makhachhang, string tensach, string datetime, string soluong)
        {
            this.masach = masach;
            this.makhachhang = makhachhang;
            this.tensach = tensach;
            this.datetime = datetime;
            this.soluong = soluong;
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormMUONSACH_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = "select * from dbo.DanhSachChoMuonSach";
                myDataAdapter = new SqlDataAdapter(cmd, conn);
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(masach);
            MessageBox.Show(makhachhang);
            MessageBox.Show(tensach);
            MessageBox.Show(datetime);
            MessageBox.Show(soluong);
        }
    }
}
