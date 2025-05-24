using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManegment
{
    public partial class booking : Form
    {
        public booking()
        {
            InitializeComponent();
            populate();
            GetRooms();
            getCostemers();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kidus\Documents\hotel.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        { //to display the database table into the interface.
            Con.Open();
            string Query = "SELECT * FROM BookingTb1";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            bookingdgv.DataSource = ds.Tables[0];
            bookingdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in bookingdgv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            bookingdgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            Con.Close();
        }
        private void GetRooms()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from RoomTb1 where Rstatus ='Available'", Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Rnum", typeof(int));
            dt.Load(rdr);
            Con.Close();

            comboBox1.Items.Clear(); // Clear existing items in the ComboBox

            foreach (DataRow row in dt.Rows)
            {
                int rnum = (int)row["Rnum"];
                comboBox1.Items.Add(rnum);
            }
        }
        private void fetchCost()
        {
            Con.Open();
            string Query = "select cost from RoomTb1 join TYpeTbl on Rtype=num where Rnum=" + comboBox1.SelectedValue.ToString();
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                bamount.Text = dr["cost"].ToString();
            }
            Con.Close();
        }
        private void getCostemers()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from CustomerTb1", Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Load(rdr);
            Con.Close();

            coobox.Items.Clear(); // Clear existing items in the ComboBox

            foreach (DataRow row in dt.Rows)
            {
                int rnum = (int)row["id"];
                coobox.Items.Add(rnum);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            rooms Rooms = new rooms();
            Rooms.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void booking_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Types ts = new Types();
            ts.Show();
            this.Hide();
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

        private void book_Click(object sender, EventArgs e)
        {
            GetRooms();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchCost();
        }

        private void bduration_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (int.TryParse(bamount.Text, out int roomPrice) && int.TryParse(bduration.Text, out int duration))
            {
                int total = roomPrice * duration;
                bamount.Text = "Rs" + total.ToString();
            }
        }
    }
}