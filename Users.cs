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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            usersDGV.CellContentClick += TypesDGV_CellContentClick;
            //  GetCatagories();

            // Set the selection mode to FullRowSelect
            usersDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            populate();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kidus\Documents\hotel.mdf;Integrated Security=True;Connect Timeout=30");
        int Key=0;
        private void populate()
        {
            Con.Open();
            string Query = "SELECT * FROM UserTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            usersDGV.DataSource = ds.Tables[0];
            usersDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in usersDGV.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            usersDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            Con.Close();
        }
        private void DeleteUser()
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a user!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM UserTbl WHERE UNum = @Ukey", Con);
                    cmd.Parameters.AddWithValue("@Ukey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("user is deleted!");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
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
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void EditUser()
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

                    SqlCommand cmd = new SqlCommand("UPDATE UserTbl SET UName = @UN, UPhone = @UT, UGender=@UG, UPassword =@UP where UNum=@Tkey", Con);
                    cmd.Parameters.AddWithValue("@UN", username.Text);
                    cmd.Parameters.AddWithValue("@UT", phone.Text);
                    cmd.Parameters.AddWithValue("@UG", sex.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UP", password.Text);
                    cmd.Parameters.AddWithValue("@Tkey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Catagory is updated!");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertUser();
        }

        private void TypesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            username.Text = usersDGV.SelectedRows[0].Cells[1].Value.ToString();
            phone.Text = usersDGV.SelectedRows[0].Cells[2].Value.ToString();
            sex.Text = usersDGV.SelectedRows[0].Cells[3].Value.ToString();
            password.Text = usersDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (string.IsNullOrEmpty(username.Text))
            {
                // Set Key to a non-zero value when username.Text is empty
                Key = -1; // or any other non-zero value you prefer
            }
            else
            {
                if (int.TryParse(usersDGV.SelectedRows[0].Cells[0].Value.ToString(), out int keyValue))
                {
                    Key = keyValue;
                }
                else
                {
                    // Handle the conversion error
                    // For example, display an error message or set a default value
                    Key = 0;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            rooms catagories = new rooms();
            catagories.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Types ts = new Types();
            ts.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
            customers catagories = new customers();
            catagories.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            booking Booking = new booking();
            Booking.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertUser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void sex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            login kidus = new login();
            kidus.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void username_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {

        }
    }
}
