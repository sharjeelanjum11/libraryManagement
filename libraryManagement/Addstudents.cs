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
    public partial class Addstudents : Form
    {
        public Addstudents()
        {
            InitializeComponent();
        }

        private void btneXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
            private void btRfresh_Click(object sender, EventArgs e)
        {
            txtsName.Clear();
            txtsRollno.Clear();
            txtDept.Clear();
            txtsem.Clear();
            txtCont.Clear();
            txtEmail.Text = "";


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtsName.Text != "" && txtsRollno.Text != "" && txtDept.Text != "" && txtsem.Text != "" && txtCont.Text != "" && txtEmail.Text != "")
            {
                string name = txtsName.Text;
                string rollno = txtsRollno.Text;
                string dept = txtDept.Text;
                string sem = txtsem.Text;
                Int64 contact = Int64.Parse(txtCont.Text);
                string email = txtEmail.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into newStudent(sname,srollno,deptm,sem,scontact,semail) values ('" + name + "','" + rollno + "','" + dept + "','" + sem + "','" + contact + "','" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("please Fill All Box", "error", MessageBoxButtons.OK);
            }
        }
    }
}
