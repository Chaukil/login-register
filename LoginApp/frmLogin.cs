using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        SqlConnection sqlcon = new SqlConnection(@"Data Source = DEV-CHAUKIL\CHAUKIL;Initial Catalog = login; Integrated Security = True");

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill in the missing fields.");
            }
            else
            {
                string query = "Select * from Account Where UserName = '" + txtUsername.Text.Trim() + "' and PassWord = '" + txtPassword.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    frmMain objFrmMain = new frmMain();
                    this.Hide();
                    objFrmMain.Show();
                }
                else
                {
                    MessageBox.Show("Check your account and password.");
                }
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (dkname.Text =="" || dkuser.Text == "" || dkpass.Text == "")
            {
                MessageBox.Show("Please fill in the missing fields.");
            }
            else
            {
                sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO Account VALUES (@UserName,@DisplayName,@PassWord,@Type)", sqlcon);
                sqlCmd.Parameters.AddWithValue("@UserName", dkuser.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@DisplayName", dkname.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@PassWord", dkpass.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Type", dktype.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("Sign Up Success!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                label4.ForeColor = Color.White;
                label4.BackColor = Color.MediumPurple;
                label5.ForeColor = Color.OrangeRed;
                label5.BackColor = Color.White;     
            } 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            label4.ForeColor = Color.White;
            label4.BackColor = Color.MediumPurple;
            label5.ForeColor = Color.OrangeRed;
            label5.BackColor = Color.White;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            label4.ForeColor = Color.MediumPurple;
            label4.BackColor = Color.White;
            label5.ForeColor = Color.White;
            label5.BackColor = Color.OrangeRed;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            label4.ForeColor = Color.White;
            label4.BackColor = Color.MediumPurple;
            label5.ForeColor = Color.OrangeRed;
            label5.BackColor = Color.White;
        }
    }
}
