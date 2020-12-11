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

namespace WindowsFormsApp1
{
    public partial class AddingNewBooking : Form
    {
        public static DataTable dtLinked = new DataTable();
        public AddingNewBooking()
        {
            InitializeComponent();
        }

        private void CheckAndAddBookingData_Click(object sender, EventArgs e)
        {
            Form1.OpenConnectionCorrect(Form1.conn);
            SqlCommand command = new SqlCommand("INSERT INTO Booking (settling, eviction, number, value_of_guests, value_of_kids) VALUES (@settling, @eviction, @number, @value_of_guests, @value_of_kids)", Form1.conn);
            command.Parameters.AddWithValue("@settling", textBox10.Text);
            command.Parameters.AddWithValue("@eviction", textBox11.Text);
            command.Parameters.AddWithValue("@value_of_guests", textBox12.Text);
            command.Parameters.AddWithValue("@value_of_kids", textBox13.Text);
            command.Parameters.AddWithValue("@number", Convert.ToInt32(textBox14.Text));

            command.ExecuteNonQuery();
        }
    }
}
