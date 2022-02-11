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
    public partial class Addbook : Form
    {
        public Addbook()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtBName.Text != "" && txtAutorN.Text != "" && txtPublic.Text != "" && txtPrice.Text != "" && txtBQuantity.Text != "")

            {
                string bNme = txtBName.Text;
                string bAuthor = txtAutorN.Text;
                string publication = txtPublic.Text;
                string pDate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quan = Int64.Parse(txtBQuantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewBooks(bName,bAuthor,bPubl,bPdate,bPrice,bQuant) values ('" + bNme + "','" + bAuthor + "','" + publication + "','" + pDate + "','" + price + "','" + quan + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBName.Clear();
                txtAutorN.Clear();
                txtPublic.Clear();
                txtPrice.Clear();
                txtBQuantity.Clear();
            }
            else
            {
                MessageBox.Show("please Fill All Box","error", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
