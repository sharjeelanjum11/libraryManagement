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
    public partial class viewbooks : Form
    {
        public viewbooks()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void viewbooks_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewBooks";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewBooks where bid=" + bid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtBname.Text = ds.Tables[0].Rows[0][1].ToString();
            txtAuth.Text = ds.Tables[0].Rows[0][2].ToString();
            txtpublicat.Text = ds.Tables[0].Rows[0][3].ToString();
            textPdate.Text = ds.Tables[0].Rows[0][4].ToString();
            textPrice.Text = ds.Tables[0].Rows[0][5].ToString();
            textQuantity.Text = ds.Tables[0].Rows[0][6].ToString();


        }

        private void cnclbtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBookName.Text))
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from NewBooks where bName Like'" + txtBookName.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from NewBooks";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            panel2.Visible = false;
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated.confirm", "Succes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string bname = txtBname.Text;
                string bauth = txtAuth.Text;
                string publica = txtpublicat.Text;
                string pdate = textPdate.Text;
                Int64 price = Int64.Parse(textPrice.Text);
                Int64 quant = Int64.Parse(textQuantity.Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //(bName, bAuthor, bPubl, bPdate, bPrice, bQuant
                cmd.CommandText = "update NewBooks set bName ='" + bname + "',bAuthor='" + bauth + "',bPubl='" + publica + "',bPdate='" + pdate + "',bPrice='" + price + "',bQuant='" + quant + "'where bid =" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

            }
        }

        private void Delbtn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Data will be Deleted.confirm", "Succes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string bname = txtBname.Text;
                string bauth = txtAuth.Text;
                string publica = txtpublicat.Text;
                string pdate = textPdate.Text;
                Int64 price = Int64.Parse(textPrice.Text);
                Int64 quant = Int64.Parse(textQuantity.Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=SHARJEELANJUM;database=libraryz;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //(bName, bAuthor, bPubl, bPdate, bPrice, bQuant
                cmd.CommandText = "delete from NewBooks where bid =" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }
    }
}
