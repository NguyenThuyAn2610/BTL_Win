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
    public partial class FormDoanhThu : Form
    {
        string MaNV = "";
        public FormDoanhThu()
        {
            InitializeComponent();
        }
        public FormDoanhThu(string MaNV)
        {
            this.MaNV = MaNV;
            InitializeComponent();
        }
        int currentMonth = DateTime.Now.Month;
        int currentYear = DateTime.Now.Year;
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataSet myDataSet;
        private DataTable myTable;
        public int State;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8HCDGC7\SQLEXPRESS;Initial Catalog=ThuVien;Integrated Security=True");
        private void FormDoanhThu_Load(object sender, EventArgs e)
        {
            label6.Text = currentMonth.ToString();
            label7.Text = currentYear.ToString();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string cmd = "select * from dbo.DoanhThu";
                myDataAdapter = new SqlDataAdapter(cmd, conn);
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "DoanhThu");
                myTable = myDataSet.Tables["DoanhThu"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi ket noi");
            }
        }
        public static string SoSangChu(int so)
        {
            if (so == 0) return "không";

            if (so < 0) return "âm " + SoSangChu(Math.Abs(so));

            string chuoi = "";

            if ((so / 1000000) > 0)
            {
                chuoi += SoSangChu(so / 1000000) + " triệu ";
                so %= 1000000;
            }

            if ((so / 1000) > 0)
            {
                chuoi += SoSangChu(so / 1000) + " nghìn ";
                so %= 1000;
            }

            if ((so / 100) > 0)
            {
                chuoi += SoSangChu(so / 100) + " trăm ";
                so %= 100;
            }

            if (so > 0)
            {
                if (chuoi != "") chuoi += "lẻ ";

                string[] mangDonVi = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín", "mười", "mười một", "mười hai", "mười ba", "mười bốn", "mười lăm", "mười sáu", "mười bảy", "mười tám", "mười chín" };
                string[] mangChuc = new string[] { "không", "mười", "hai mươi", "ba mươi", "bốn mươi", "năm mươi", "sáu mươi", "bảy mươi", "tám mươi", "chín mươi" };

                if (so < 20)
                    chuoi += mangDonVi[so];
                else
                {
                    chuoi += mangChuc[so / 10];
                    if ((so % 10) > 0)
                        chuoi += " " + mangDonVi[so % 10];
                }
            }

            return chuoi;
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
        private void phiếuThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new GiayTo.FormPHIEUTHU());
        }

        private void phiếuChiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new GiayTo.FormPHIEUCHI());
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                textBox3.Text = myTable.Rows[row]["SoTienThu"].ToString();
                textBox4.Text = myTable.Rows[row]["SoTienChi"].ToString();
                textBox1.Text = myTable.Rows[row]["Thang"].ToString();
                textBox2.Text = myTable.Rows[row]["Nam"].ToString();
            }
            catch
            {

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sotienthuduocchuoi = textBox3.Text;
            try
            {
                int sotienthuduoc = int.Parse(sotienthuduocchuoi);
                string bangchuthuduoc = SoSangChu(sotienthuduoc);
                string sotienchichuoi = textBox4.Text;
                int sotienchi = int.Parse(sotienchichuoi);
                string bangchuchi = SoSangChu(sotienchi);
                string Nam = dataGridView1.CurrentRow.Cells["Nam"].Value.ToString();
                string Thang = dataGridView1.CurrentRow.Cells["Thang"].Value.ToString();
                GiayTo.FormPHIEUTHUDEMO fm1 = new GiayTo.FormPHIEUTHUDEMO(MaNV, bangchuthuduoc, sotienthuduoc, Nam, Thang);
                fm1.Show();
            }catch { }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sotienchichuoi = textBox4.Text;
                int sotienchi = int.Parse(sotienchichuoi);
                string bangchuchi = SoSangChu(sotienchi);
                string Nam = dataGridView1.CurrentRow.Cells["Nam"].Value.ToString();
                string Thang = dataGridView1.CurrentRow.Cells["Thang"].Value.ToString();
                GiayTo.FormPHIEUCHIDEMO fm1 = new GiayTo.FormPHIEUCHIDEMO(MaNV, bangchuchi, sotienchi, Nam, Thang);
                fm1.Show();
            }catch { }
            
        }

        
    }
}
