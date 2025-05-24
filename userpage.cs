using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManegment
{
    public partial class userpage : Form
    {
        public userpage()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kidus\Documents\hotel.mdf;Integrated Security=True;Connect Timeout=30");
        int Key = 0;
        private void InsertUser()
        {
            if (username.Text == "" || phone.Text == "" || sex.SelectedIndex == -1 || password.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO UserTBl (UName, UPhone, UGender, UPassword) VALUES (@TN, @TC, @TR, @TP)", Con);
                    cmd.Parameters.AddWithValue("@TN", username.Text);
                    cmd.Parameters.AddWithValue("@TC", phone.Text);
                    cmd.Parameters.AddWithValue("@TR", sex.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TP", password.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Information is accepted!");
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void username_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertUser();
        }

        private void userpage_Load(object sender, EventArgs e)
        {

        }
    }
}
