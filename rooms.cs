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
using System.Data.SqlClient;

namespace HotelManegment
{
    public partial class rooms : Form
    {
        public rooms()
        {
            InitializeComponent();
            RoomDGV.CellContentClick += RoomDGV_CellContentClick;
            GetCatagories();

            // Set the selection mode to FullRowSelect
            RoomDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            populate();

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kidus\Documents\hotel.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        { //to display the database table into the interface.
            Con.Open();
            string Query = "SELECT * FROM RoomTb1";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            RoomDGV.DataSource = ds.Tables[0];
            RoomDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in RoomDGV.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            RoomDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            Con.Close();
        }
        int key = 0;
        private void EditRooms()
        {
            if (RnameTb.Text == "" || RType.SelectedIndex == -1 || Status.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE RoomTb1 SET RName = @RN, Rtype = @RT, RStatus = @RS WHERE RNum = @key", Con);
                    cmd.Parameters.AddWithValue("@RN", RnameTb.Text);
                    cmd.Parameters.AddWithValue("@RT", RType.SelectedIndex.ToString());
                    cmd.Parameters.AddWithValue("@RS", Status.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@key", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room is updated!");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void DeleteRooms()

        {
            if (key == 0)
            {
                MessageBox.Show("Select a Room!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from RoomTb1 where Rnum = @key", Con);
                    cmd.Parameters.AddWithValue("@key", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room is deleted!");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void InsertRooms()

        {
            if (RnameTb.Text == "" || RType.SelectedIndex == -1 || Status.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    Con.Open();
                    int Room_index = RType.SelectedIndex;
                    Room_index = Room_index + 1;

                    SqlCommand cmd = new SqlCommand("INSERT INTO RoomTb1 (RName, Rtype, RStatus) VALUES (@RN, @RT, @RS)", Con);
                    cmd.Parameters.AddWithValue("@RN", RnameTb.Text);
                    cmd.Parameters.AddWithValue("@RT", Room_index);
                    cmd.Parameters.AddWithValue("@RS", Status.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room is added!");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }


        }
        private void GetCatagories()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from TYpeTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeNum", typeof(int));
            dt.Load(rdr);
            RType.ValueMember = "TypeNum";
            RType.DataSource = dt;
            Con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Types ts = new Types();
            ts.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertRooms();
        }

        private void Status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RoomDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                RnameTb.Text = RoomDGV.SelectedRows[0].Cells[1].Value.ToString();
                RType.Text = RoomDGV.SelectedRows[0].Cells[2].Value.ToString();
                Status.Text = RoomDGV.SelectedRows[0].Cells[3].Value.ToString();

                if (string.IsNullOrEmpty(RnameTb.Text))
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(RoomDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            
        }

        private void Editbtn_click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditRooms();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteRooms();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Users kidus = new Users();
            kidus.Show();
            this.Hide();
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

        private void label8_Click(object sender, EventArgs e)
        {
            rooms Dashboard = new rooms();
            Dashboard.Show();
            this.Hide();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            login kidus = new login();
            kidus.Show();
            this.Hide();
        }
    }
}
