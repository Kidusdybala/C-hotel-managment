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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManegment
{
    public partial class Types : Form
    {
        public Types()
        {
            InitializeComponent();
            TypesDGV.CellContentClick += TypesDGV_CellContentClick;
          //  GetCatagories();

            // Set the selection mode to FullRowSelect
            TypesDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            populate();
        }
        int Key = 0;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kidus\Documents\hotel.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string Query = "SELECT * FROM TYpeTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            TypesDGV.DataSource = ds.Tables[0];
            TypesDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in TypesDGV.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            TypesDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            Con.Close();
        }
        private void DeleteCategories()
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Categories!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from TYpeTbl where num = @key", Con);
                    cmd.Parameters.AddWithValue("@key", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Categories is deleted!");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void InsertCatagories()
        {
            if (TypeName.Text == "" || Cost.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO TYpeTbl (name, cost) VALUES (@TN, @TC)", Con);
                    cmd.Parameters.AddWithValue("@TN", TypeName.Text);
                    cmd.Parameters.AddWithValue("@TC", Cost.Text);
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
       
        private void EditCatagory()
        {
            if (TypeName.Text == "" || Cost.Text == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE TYpeTbl SET name = @RN, cost = @RT where num=@Tkey", Con);
                    cmd.Parameters.AddWithValue("@RN", TypeName.Text);
                    cmd.Parameters.AddWithValue("@RT", Cost.Text);
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
            InsertCatagories();
        }
      
        private void TypesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TypeName.Text = TypesDGV.SelectedRows[0].Cells[1].Value.ToString();
            Cost.Text = TypesDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (TypeName.Text =="")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(TypesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Types_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
           rooms Rooms = new rooms();
           Rooms.Show();   
           this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Users kidus = new Users();
            kidus.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            booking Booking = new booking();
            Booking.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            customers catagories = new customers();
            catagories.Show();
            this.Hide();
        }

        private void Cost_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditCatagory();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteCategories();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            login kidus = new login();
            kidus.Show();
            this.Hide();
        }
    }
}