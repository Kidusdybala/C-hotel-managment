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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HotelManegment
{
public partial class customers : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kidus\Documents\hotel.mdf;Integrated Security=True;Connect Timeout=30");
        int Key = 0;

        public customers()
        {
            InitializeComponent();
            cdgv.CellContentClick += cdgv_CellContentClick;
            cdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            populate();
        }
        private void cdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = cdgv.Rows[e.RowIndex];
                cname.Text = row.Cells["CusName"].Value.ToString();
                cphone.Text = row.Cells["CusPhone"].Value.ToString();
                csex.SelectedItem = row.Cells["CusGender"].Value.ToString();
                Key = Convert.ToInt32(row.Cells["Id"].Value);
            }
        }

        private void populate()
        {
            {
                Con.Open();
                string Query = "SELECT * FROM CustomerTb1";
                SqlDataAdapter adapter = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                var ds = new DataSet();
                adapter.Fill(ds);
                cdgv.DataSource = ds.Tables[0];
                cdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                foreach (DataGridViewColumn column in cdgv.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                cdgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                Con.Close();
            }
        }
            private void DeleteCustomer()
            {
                if (Key == 0)
                {
                    MessageBox.Show("Select a Customer!");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM CustomerTb1 WHERE Id = @Ckey", Con);
                        cmd.Parameters.AddWithValue("@Ckey", Key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer is deleted!");
                        Con.Close();
                        populate();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
            private void InsertCustomer()
            {
                if (cname.Text == "" || cphone.Text == "" || csex.Text == "" )
                {
                    MessageBox.Show("Missing Information!");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO CustomerTb1 (CusName, CusPhone, CusGender) VALUES (@CN, @CC, @CR)", Con);
                        cmd.Parameters.AddWithValue("@CN", cname.Text);
                        cmd.Parameters.AddWithValue("@CC", cphone.Text);
                        cmd.Parameters.AddWithValue("@CR", csex.SelectedItem.ToString());
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
            private void EditCustomer()
            {
            if (cname.Text == "" || cphone.Text == "" || csex.Text == "") 
                {
                    MessageBox.Show("Missing Information!");
                }
                else
                {
                    try
                    {
                        Con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE CustomerTb1 SET CusName = @CN, CusPhone = @CT, CusGender = @CG WHERE Id = @Tkey", Con);
                    cmd.Parameters.AddWithValue("@CN", cname.Text);
                        cmd.Parameters.AddWithValue("@CT", cphone.Text);
                        cmd.Parameters.AddWithValue("@CG", csex.SelectedItem.ToString());
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            booking Booking = new booking();
            Booking.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            rooms Rooms = new rooms();
            Rooms.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Users kidus = new Users();
            kidus.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Types ts = new Types();
            ts.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertCustomer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditCustomer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            login kidus = new login();
            kidus.Show();
            this.Hide();   
        }
    }
}
