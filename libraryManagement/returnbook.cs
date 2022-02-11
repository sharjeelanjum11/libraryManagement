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

namespace libraryManagement
{
    public partial class returnbook : Form
    {
        public returnbook()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from IRbook where std_roll ='" + textrollnosearch.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count!=0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid Book Id Or no book issue");
            }
        
        }
        String bname;
        String bdate;
        Int64 rowid;


        private void btnreturn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update IRbook set book_return_date ='" + dateTimePicker1.Text + "'where std_roll='" + textrollnosearch.Text + "'and id =" + rowid + "";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Return succesfuly", "succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            returnbook_Load(this, null);

        
        }

        private void returnbook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            textrollnosearch.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate= dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            textbookname.Text = bname;
            textbookdate.Text = bdate;
        }
    }
}
