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
    public partial class viewstudents : Form
    {
        public viewstudents()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void viewstudents_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from newStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textRollnoSerach_TextChanged(object sender, EventArgs e)
        {
            if(textRollnoSerach.Text!="")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from newStudent where srollno like'"+textRollnoSerach.Text+"'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from newStudent where stuid="+bid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtStdname.Text = ds.Tables[0].Rows[0][1].ToString();
            txtstdRolln.Text= ds.Tables[0].Rows[0][2].ToString();
            txtDept.Text= ds.Tables[0].Rows[0][3].ToString();
            txtSem.Text= ds.Tables[0].Rows[0][4].ToString();
            textcontact.Text= ds.Tables[0].Rows[0][5].ToString();
            txtemail.Text= ds.Tables[0].Rows[0][6].ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtStdname.Text;
            string rollno = txtstdRolln.Text;
            string dept = txtDept.Text;
            string sem = txtSem.Text;
            Int64 contact = Int64.Parse(textcontact.Text);
            string email = txtemail.Text;
            if (MessageBox.Show("Data will be Updated.confirm", "Succes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //sname,srollno,deptm,sem,scontact,semail
                cmd.CommandText = "update newStudent set sname='" + name + "',srollno='" + rollno + "',deptm='" + dept + "',sem='" + sem + "',scontact='" + contact + "',semail='" + email + "'where stuid=" + rowid + " ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = txtStdname.Text;
            string rollno = txtstdRolln.Text;
            string dept = txtDept.Text;
            string sem = txtSem.Text;
            Int64 contact = Int64.Parse(textcontact.Text);
            string email = txtemail.Text;
            if (MessageBox.Show("Data will be Deleted.confirm", "Succes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //sname,srollno,deptm,sem,scontact,semail
                cmd.CommandText = "delete from newStudent where stuid=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }
    }
}
