using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HotelManegment
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kidus\Documents\hotel.mdf;Integrated Security=True;Connect Timeout=30");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (user.Text == "" || password.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [dbo].[UserTbl] WHERE UName = @username AND UPassword = @password", Con);
                    command.Parameters.AddWithValue("@username", user.Text);
                    command.Parameters.AddWithValue("@password", password.Text);
                    int count = (int)command.ExecuteScalar();
                    Con.Close();

                    if (count == 1)
                    {
                        userpage kidus = new userpage();
                        kidus.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CountinueLbl_Click(object sender, EventArgs e)
        {
            admin kidus = new admin();
            kidus.Show();
            this.Hide();
        }
    }
}