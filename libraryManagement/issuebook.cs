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
    public partial class issuebook : Form
    {
        public issuebook()
        {
            InitializeComponent();
        }

        private void issuebook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand("select bName from NewBooks", con);
            SqlDataReader Sdr = cmd.ExecuteReader();
            while(Sdr.Read())
            {
                for(int i=0;i<Sdr.FieldCount;i++)
                {
                    comboBoxbook.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
            con.Close();
        }
        int count;
        private void searchbtnroll_Click(object sender, EventArgs e)
        {
                if(txtrollnosearch.Text!="")
            {
                String eid = txtrollnosearch.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText=("select * from newStudent where srollno ='" + eid + "'");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                

                cmd.CommandText = ("select count (std_roll) from IRbook where std_roll ='" + eid + "' and book_return_date is NULL ");
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                
                
                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());



                
                if (ds.Tables[0].Rows.Count!=0)
                {
                    txtname.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtdept.Text= ds.Tables[0].Rows[0][3].ToString();
                    txtsem.Text= ds.Tables[0].Rows[0][4].ToString();
                    txtcontact.Text= ds.Tables[0].Rows[0][5].ToString();
                    txtemail.Text= ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    txtname.Clear();
                    txtdept.Clear();
                    txtsem.Clear();
                    txtcontact.Clear();
                    txtemail.Clear();
                    MessageBox.Show("Invalid Roll no", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void issuebtn_Click(object sender, EventArgs e)
        {
            if(txtname.Text!="")
            {
                if(comboBoxbook.SelectedIndex!=-1 && count <= 2)
                {
                    String rollno = txtrollnosearch.Text;
                    String sname = txtname.Text;
                    String sdep = txtdept.Text;
                    String sem = txtsem.Text;
                    Int64 contact = Int64.Parse(txtcontact.Text);
                    String semail = txtemail.Text;
                    String bookname = comboBoxbook.Text;
                    String bookissuedate = dateTimePicker.Text;
                    String returndate = returndatePicker.Text;
                   
                    
                    String eid = txtrollnosearch.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into IRbook (std_roll,std_name,std_dept,std_sem,std_contact,std_email,book_name,book_issue_date,book_return_date) values ('" + rollno + "','" + sname + "','" + sdep + "','" + sem + "'," + contact + ",'" + semail + "','" +bookname + "','" + bookissuedate + "','"+returndate+"') ";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("BookISued sucessfuly", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("Select Book OR. maximum nuber of book has been issued", "No book selected", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
              
            }
            else
            {
                MessageBox.Show("Please enter valid enrolment id","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtrollnosearch.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
