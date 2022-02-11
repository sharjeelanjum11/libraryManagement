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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string uName = textusername.Text;
            string pass = textpassword.Text;
            
            
            
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=SHARJEELANJUM;database=master;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd.CommandText = "insert into loginTables(username,pass) values ('" + uName + "','" + pass + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Saved", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
           
        
        }

        private void button2(object sender, EventArgs e)
        {
            this.Hide();
            Form1 dsa = new Form1();
            dsa.Show();
        }
    }
}
