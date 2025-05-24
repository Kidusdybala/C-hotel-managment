using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManegment
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kidus\Documents\hotel.mdf;Integrated Security=True;Connect Timeout=30");

        private void CountinueLbl_Click(object sender, EventArgs e)
        {
            login kidus = new login();
            kidus.Show();
            this.Hide();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                MessageBox.Show("Missing password");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [dbo].[admin] WHERE password = @password", Con);
                    command.Parameters.AddWithValue("@password", password.Text);
                    int count = (int)command.ExecuteScalar();
                    Con.Close();

                    if (count == 1)
                    {
                        rooms kidus = new rooms();
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
        private void password_TextChanged(object sender, EventArgs e)
        {
        }
    }
}