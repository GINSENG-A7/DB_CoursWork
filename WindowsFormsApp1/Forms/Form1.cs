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
    public partial class Form1 : Form
    {
        public static int[] valuesOfAdditionalServicesCell = new int[5];
        public static int idOfChosenRow1 = -1;
        public static int idOfChosenRow2 = -1;
        public static int idOfChosenRowAS = -1;
        public static int numberOfChosenRow = -1;
        public static int discount = 0;
        public static string[] admissibleTypesOfApartments = new string[] {"Люкс", "Полулюкс", "Одноместный", "Двуместный", "Трёхместный", "Четырёхместный", "Пятиместный", "Шестиместный"};
        public static string textBox2StaticValue = "";
        public static string textBox3StaticValue = "";
        public static string textBox4StaticValue = "";
        public static string textBox5StaticValue = "";
        public static string textBox6StaticValue = "";
        public static DateTimePicker dateTimePicker1StaticValue = new DateTimePicker();
        public static string textBox8StaticValue = "";
        public static SqlConnection conn = DBUtils.GetDBConnection();
        public static SqlTransaction transaction; 
        //static SqlTransaction transaction = conn.BeginTransaction();

        public static void OpenConnectionCorrect(SqlConnection c)
        {
            if (c.State == ConnectionState.Closed)
            {
                c.Open();
            }
        }
        public Form1()
        {
            InitializeComponent();
            try
            {
                conn.Open();
                MessageBox.Show("Connection successful!");
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            ElementsSettings.SearchTextBoxSettings(searchTextBox);
            //ElementsSettings.DateTextBoxSettings(textBox7);
            OpenConnectionCorrect(conn);
            RequestsSQLT.GetTypesOfApartments(RequestsSQLT.comboElements, conn); // Получаем все реально имеющиеся типы номеров для данной гостинницы для последующего использоваия в ComboBox
            discount = RequestsSQLT.GetCurrentDiscount(conn);
            label19.Text = discount.ToString() + " %";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenConnectionCorrect(conn);
            dataGridView1.DataSource = RequestsSQLT.SelectAllFromCustomer(conn);
            ElementsSettings.SetDefaultSettingsToDGV(dataGridView1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenConnectionCorrect(conn);
            dataGridView2.DataSource = RequestsSQLT.SelectAllFromLiving(conn);
            ElementsSettings.SetDefaultSettingsToDGV(dataGridView2);
            ElementsSettings.HideFirstXColumns(dataGridView2, 2);
            ElementsSettings.HideLastXColumns(dataGridView2, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenConnectionCorrect(conn);
            dataGridView3.DataSource = RequestsSQLT.SelectAllFromBooking(conn);
            ElementsSettings.SetDefaultSettingsToDGV(dataGridView3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenConnectionCorrect(conn);
            dataGridView4.DataSource = RequestsSQLT.SelectAllFromApartments(conn);
            ElementsSettings.SetDefaultSettingsToDGV(dataGridView4);
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            dateTimePicker1StaticValue.Value = dateTimePicker1.Value;
            AddingNewCustomer anc = new AddingNewCustomer();
            anc.ShowDialog();
            anc.Focus();
            if(anc.DialogResult == DialogResult.OK)
            {
                dataGridView1.DataSource = AddingNewCustomer.dtLinked;
            }
        }

        private void addBookingButton_Click(object sender, EventArgs e)
        {

        }

        private void newNumber_Click(object sender, EventArgs e)
        {
            AddingNewNumber ann = new AddingNewNumber();
            ann.ShowDialog();
            ann.Focus();
            if (ann.DialogResult == DialogResult.OK)
            {
                textBox1.Text = AddingNewNumber.str;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] s = ElementsSettings.SetDataFromCustomersDGVToTextBoxes(dataGridView1, e);
            idOfChosenRow1 = Convert.ToInt32(RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(conn, Convert.ToInt32(s[0]), Convert.ToInt32(s[1])));
            textBox1.Text = s[0] + "  " + s[1] + "  " + s[2] + "  " + s[3] + "  " + s[4] + "  " + s[5] + "  " + s[6];
            textBox2.Text = s[0];
            textBox3.Text = s[1];
            textBox4.Text = s[2];
            textBox5.Text = s[3];
            textBox6.Text = s[4];
            dateTimePicker1.Value = Convert.ToDateTime(s[5]);
            //textBox7.Text = s[6];
            textBox8.Text = s[6];
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] s = ElementsSettings.SetDataFromLivingOrBookingDGVToTextBoxes(dataGridView2, e);
            idOfChosenRow2 = Convert.ToInt32(RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(conn, Convert.ToInt32(s[0]), Convert.ToInt32(s[1])));
            textBox9.Text = s[0] + "  " + s[1] + "  " + s[2] + "  " + s[3] + "  " + s[4];
            livingSettlingDateTimePicker.Value = Convert.ToDateTime(s[2]);
            livingEvictionDateTimePicker.Value = Convert.ToDateTime(s[3]);
            textBox15.Text = s[4];
            textBox12.Text = s[5];
            textBox11.Text = s[6];
            idOfChosenRowAS = Convert.ToInt32(s[7]);
        }
        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            ElementsSettings.DefaultTextBoxSettings(searchTextBox);
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if((searchTextBox.Text == "")||(searchTextBox.Text == null))
            {
                ElementsSettings.SearchTextBoxSettings(searchTextBox);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = ElementsSettings.RowOfPassportSeriesIsCorrect(textBox2, e);
            ElementsSettings.RowOfPassportSeriesIsCorrect(textBox2, e);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2StaticValue = textBox2.Text;
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowOfPassportNumberIsCorrect(textBox3, e);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3StaticValue = textBox3.Text;
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoDigits(textBox4, e);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4StaticValue = textBox4.Text;
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoDigits(textBox5, e);
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5StaticValue = textBox5.Text;
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoDigits(textBox6, e);
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6StaticValue = textBox6.Text;
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoLetters(textBox8, e);
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox8StaticValue = textBox8.Text;
        }

        private void changeCustomerDataButton_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show("Вы уверены, что хотите применить изменения в базе данных?", "", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                if (ElementsSettings.RowOfPassportSeriesConsistEnoughNumbers(textBox2) == true && ElementsSettings.RowOfPassportNumberConsistEnoughNumbers(textBox3) == true) //Проверяем все ограничения ввода для таблицы клиетов
                {
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand($"UPDATE Customer SET passport_series = {Convert.ToInt32(textBox2.Text)}, passport_number = {Convert.ToInt32(textBox3.Text)}, name = '{textBox4.Text}', surname = '{textBox5.Text}', patronymic = '{textBox6.Text}', birthday = '{dateTimePicker1.Value}', tel_number = '{textBox8.Text}' WHERE customer_id = {idOfChosenRow1}", conn);
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Серия или номер паспорта заданы некорректно");
                }
            }
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show("Вы уверены, что хотите удалить ВСЮ информацию об этом клиенте?", "", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                SqlCommand command1 = new SqlCommand(); 
                SqlCommand command2 = new SqlCommand();
                SqlCommand command3 = new SqlCommand();
                command1 = new SqlCommand($"DELETE FROM Customer WHERE customer_id = {idOfChosenRow1}", conn);
                command2 = new SqlCommand($"DELETE FROM Living WHERE customer_id = {idOfChosenRow1}", conn);
                command3 = new SqlCommand($"DELETE FROM Booking WHERE customer_id = {idOfChosenRow1}", conn);
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
            }
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox.Text != "Поиск по фамилии")
            {
                dataGridView1.DataSource = RequestsSQLT.SelectAllFromCustomerWithSetSurname(conn, searchTextBox);
            }
        }
        private void moveToLivingsButton_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = RequestsSQLT.SelectAllFromLivingByCustomerId(conn, idOfChosenRow1);
            tabControl1.SelectedIndex = 1;
        }
        private void moveToBookingsBotton_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = RequestsSQLT.SelectAllFromBookingByCustomerId(conn, idOfChosenRow1);
            tabControl1.SelectedIndex = 2;
        }

        private void moveToCustomerFromLivingButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = RequestsSQLT.SelectAllFromCustomerByCustomerId(conn, idOfChosenRow2);
            tabControl1.SelectedIndex = 0;
        }

        private void changeDiscountButton_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show("Вы уверены, что хотите обновить значение скидки?", "", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                if (ElementsSettings.NewDiscountIsInPercentage(newDiscountTextBox) == true)
                {
                    RequestsSQLT.SetNewDiscount(conn, Convert.ToInt32(newDiscountTextBox.Text));
                }
                else
                {
                    MessageBox.Show("Введено недопустимое значение.");
                }
            }
            newDiscountTextBox.Clear();
            discount = RequestsSQLT.GetCurrentDiscount(conn);
            label19.Text = discount.ToString() + " %";
        }

        private void checkAddititonalServicesButton_Click(object sender, EventArgs e)
        {
            valuesOfAdditionalServicesCell = RequestsSQLT.SelectAllFromAdditionalServicesWhereIsSetLivingID(conn, idOfChosenRowAS);
            AddingNewCustomer eas = new AddingNewCustomer();
            eas.ShowDialog();
            eas.Focus();
        }
    }
}
