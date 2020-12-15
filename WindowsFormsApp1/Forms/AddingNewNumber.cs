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

namespace WindowsFormsApp1
{
    public partial class AddingNewNumber : Form
    {
        public static List<string> selectedPhotos = new List<string>();
        public static string str = "";
        public static string[] sr;
        public AddingNewNumber()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Form1.admissibleTypesOfApartments);
        }
        
        private void openFileDialogButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog myFile = new OpenFileDialog();
            myFile.Filter ="Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            myFile.Multiselect = true;
            myFile.Title = "Images Browser";
            if (myFile.ShowDialog() == DialogResult.OK)
            {
                sr = myFile.FileNames;
                foreach (string i in sr)
                {
                    str += i + "|";
                }
                selectedPhotos.AddRange(str.Split('|'));
                selectedPhotos.RemoveAt(selectedPhotos.Count - 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RequestsSQLT.IsNotThereSetNumberInApartments(Form1.conn, Convert.ToInt32(textBox1.Text)) == true)
            {
                if(textBox1.Text != "" && comboBox1.Text != "" && textBox3.Text != "")
                {
                    //SqlCommand command0 = new SqlCommand();
                    //command0 = new SqlCommand($"SET IDENTITY_INSERT Apartments ON", Form1.conn);
                    //command0.ExecuteNonQuery();
                    SqlCommand command1 = new SqlCommand();
                    command1 = new SqlCommand($"INSERT INTO Apartments (number, \"type\", price) VALUES (@number, @type, @price)", Form1.conn);
                    command1.Parameters.AddWithValue("@number", Convert.ToInt32(textBox1.Text));
                    command1.Parameters.AddWithValue("@type", comboBox1.Text);
                    command1.Parameters.AddWithValue("@price", Convert.ToInt32(textBox3.Text));
                    command1.ExecuteNonQuery();
                    //command0 = new SqlCommand($"SET IDENTITY_INSERT Apartments OFF", Form1.conn);
                    //command0.ExecuteNonQuery();
                    foreach (string i in selectedPhotos)
                    {
                        SqlCommand command2 = new SqlCommand();
                        command2 = new SqlCommand($"INSERT INTO Photos (path, number) VALUES (@path, @number)", Form1.conn);
                        command2.Parameters.AddWithValue("@path", i);
                        command2.Parameters.AddWithValue("@number", Convert.ToInt32(textBox1.Text));
                        command2.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Следует заполнить все поля");
                }
            }
            else
            {
                MessageBox.Show("Номер с таким числовым обозначением уже есть в базе данных");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoLetters(textBox1, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoLetters(textBox3, e);
        }
    }
}
