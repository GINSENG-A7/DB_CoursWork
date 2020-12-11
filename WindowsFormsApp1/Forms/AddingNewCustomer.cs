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
    public partial class AddingNewCustomer : Form
    {
        public static int selectedNumberOfApartments = -1;
        public static int smallestPrice = 0;
        public static int biggestPrice = 100000;
        public static DataTable dtLinked = new DataTable();
        public AddingNewCustomer()
        {
            InitializeComponent();
            textBox1.Text = Form1.textBox2StaticValue;
            textBox2.Text = Form1.textBox3StaticValue;
            textBox3.Text = Form1.textBox4StaticValue;
            textBox4.Text = Form1.textBox5StaticValue;
            textBox5.Text = Form1.textBox6StaticValue;
            ancBirthdayDateTimePicker.Value = Form1.dateTimePicker1StaticValue.Value;
            textBox7.Text = Form1.textBox8StaticValue;
            Form1.OpenConnectionCorrect(Form1.conn);
            ElementsSettings.SetDefaultSettingsToDGV(dataGridViewANC);
            dataGridViewANC.DataSource = RequestsSQLT.SelectAllFromApartments(Form1.conn);
            for (int i = 0; i < RequestsSQLT.comboElements.Count; i++)
            {
                typeOfApartmentsComboBox.Items.Add(RequestsSQLT.comboElements[i]);
            }
            discountTextBox.Text = Form1.discount.ToString();
        }

        public void CheckAndAddCustomerData_Click(object sender, EventArgs e) //Регистрация проживания
        {
            SqlCommand command1 = new SqlCommand();
            SqlCommand command2 = new SqlCommand();
            Form1.OpenConnectionCorrect(Form1.conn);
            int idOfCurrentCustomer = 0;
            if (ElementsSettings.RowOfPassportSeriesConsistEnoughNumbers(textBox1) == true && ElementsSettings.RowOfPassportNumberConsistEnoughNumbers(textBox2) == true && ElementsSettings.ValuesOfGuestsAndKidsAreCorrect(textBox13, textBox14) == true && ElementsSettings.SettlingDateIsLessThenEvictionDate(ancSettlingDateTimePicker, ancEvictionDateTimePicker) == true) //Проверяем все ограничения ввода
            {
                //SqlCommand command = new SqlCommand("INSERT INTO Customer (passport_series, passport_number, name, surname, patronymic, birthday, tel_number) values('"+textBox1.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"', '"+textBox4.Text+"', '"+textBox5.Text+"', '"+textBox6.Text+"', '"+textBox7.Text+"')", Form1.conn);
                if (RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(Form1.conn, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)) != "null") //Если клиент уже был постояльцем, то реистрируем проживание по его ID
                {
                    idOfCurrentCustomer = Convert.ToInt32(RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(Form1.conn, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));
                    if(RequestsSQLT.ValueOfCustomerLivingsAndBookingsForToday(Form1.conn, idOfCurrentCustomer) < 5)
                    {
                        command2 = new SqlCommand("INSERT INTO Living (number, settling, eviction, value_of_guests, value_of_kids, customer_id) VALUES (@number, @settling, @eviction, @value_of_guests, @value_of_kids, @customer_id)", Form1.conn);
                        command2.Parameters.AddWithValue("@number", selectedNumberOfApartments);
                        command2.Parameters.AddWithValue("@settling", ancSettlingDateTimePicker.Value);
                        command2.Parameters.AddWithValue("@eviction", ancEvictionDateTimePicker.Value);
                        command2.Parameters.AddWithValue("@value_of_guests", textBox13.Text);
                        command2.Parameters.AddWithValue("@value_of_kids", textBox14.Text);
                        command2.Parameters.AddWithValue("@customer_id", idOfCurrentCustomer);
                        command2.ExecuteNonQuery();
                        //Тут можно потом поставить MessageBox, предупреждающий о том, что ткоей клинет уже есть в базе данных
                        //Tyт потом дописать каскадное создание записи в Additional_services!!!!
                    }
                }
                else //Если клиент ещё не был постояльцем в отеле, то добавляем его запись в таблицу клиентов и сразу регистрируем новое проживание
                {
                    if (RequestsSQLT.ComapreCustomerFIOforOneID(Form1.conn, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), textBox3.Text, textBox4.Text, textBox5.Text) == true)
                    {
                        command1 = new SqlCommand("INSERT INTO Customer (passport_series, passport_number, name, surname, patronymic, birthday, tel_number) VALUES (@passport_series, @passport_number, @name, @surname, @patronymic, @birthday, @tel_number)", Form1.conn);
                        command1.Parameters.AddWithValue("@passport_series", textBox1.Text);
                        command1.Parameters.AddWithValue("@passport_number", textBox2.Text);
                        command1.Parameters.AddWithValue("@name", textBox3.Text);
                        command1.Parameters.AddWithValue("@surname", textBox4.Text);
                        command1.Parameters.AddWithValue("@patronymic", textBox5.Text);
                        command1.Parameters.AddWithValue("@birthday", ancBirthdayDateTimePicker.Value);
                        command1.Parameters.AddWithValue("@tel_number", textBox7.Text);
                        command1.ExecuteNonQuery();

                        string check = RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(Form1.conn, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        idOfCurrentCustomer = Convert.ToInt32(RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(Form1.conn, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));//Заного определяем ID только что добавленного клиента

                        command2 = new SqlCommand("INSERT INTO Living (number, settling, eviction, value_of_guests, value_of_kids, customer_id) VALUES (@number, @settling, @eviction, @value_of_guests, @value_of_kids, @customer_id)", Form1.conn);
                        command2.Parameters.AddWithValue("@number", selectedNumberOfApartments);
                        command2.Parameters.AddWithValue("@settling", ancSettlingDateTimePicker.Value);
                        command2.Parameters.AddWithValue("@eviction", ancEvictionDateTimePicker);
                        command2.Parameters.AddWithValue("@value_of_guests", textBox13.Text);
                        command2.Parameters.AddWithValue("@value_of_kids", textBox14.Text);
                        command2.Parameters.AddWithValue("@customer_id", idOfCurrentCustomer);
                        command2.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Клиент с такими серией и номером паспорта уже зарегистрирован.");
                    }
                }
            }
        }

        private void CheckAndAddВookingData_Click(object sender, EventArgs e) //Регистрация бронирования
        {
            SqlCommand command1 = new SqlCommand();
            SqlCommand command2 = new SqlCommand();
            Form1.OpenConnectionCorrect(Form1.conn);
            int idOfCurrentCustomer = 0;
            if (ElementsSettings.RowOfPassportSeriesConsistEnoughNumbers(textBox1) == true && ElementsSettings.RowOfPassportNumberConsistEnoughNumbers(textBox2) == true && ElementsSettings.ValuesOfGuestsAndKidsAreCorrect(textBox13, textBox14) == true && ElementsSettings.SettlingDateIsLessThenEvictionDate(ancSettlingDateTimePicker, ancEvictionDateTimePicker) == true) //Проверяем все ограничения ввода
            {            
                //SqlCommand command = new SqlCommand("INSERT INTO Customer (passport_series, passport_number, name, surname, patronymic, birthday, tel_number) values('"+textBox1.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"', '"+textBox4.Text+"', '"+textBox5.Text+"', '"+textBox6.Text+"', '"+textBox7.Text+"')", Form1.conn);
                if (RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(Form1.conn, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)) != "null") //Если клиент уже был постояльцем, то реистрируем проживание по его ID
                {
                    idOfCurrentCustomer = Convert.ToInt32(RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(Form1.conn, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));
                    if (RequestsSQLT.ValueOfCustomerLivingsAndBookingsForToday(Form1.conn, idOfCurrentCustomer) < 5)
                    {
                        command2 = new SqlCommand("INSERT INTO Booking (number, settling, eviction, value_of_guests, value_of_kids, customer_id) VALUES (@number, @settling, @eviction, @value_of_guests, @value_of_kids, @customer_id)", Form1.conn);
                        command2.Parameters.AddWithValue("@number", selectedNumberOfApartments);
                        command2.Parameters.AddWithValue("@settling", ancSettlingDateTimePicker.Value);
                        command2.Parameters.AddWithValue("@eviction", ancEvictionDateTimePicker.Value);
                        command2.Parameters.AddWithValue("@value_of_guests", textBox13.Text);
                        command2.Parameters.AddWithValue("@value_of_kids", textBox14.Text);
                        command2.Parameters.AddWithValue("@customer_id", idOfCurrentCustomer);
                        command2.ExecuteNonQuery();
                        //Тут можно потом поставить MessageBox, предупреждающий о том, что ткоей клинет уже есть в базе данных
                    }
                }
                else //Если клиент ещё не был постояльцем в отеле, то добавляем его запись в таблицу клиентов и сразу регистрируем новое проживание
                {
                    if (RequestsSQLT.ComapreCustomerFIOforOneID(Form1.conn, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), textBox3.Text, textBox4.Text, textBox5.Text) == true)
                    {
                        command1 = new SqlCommand("INSERT INTO Customer (passport_series, passport_number, name, surname, patronymic, birthday, tel_number) VALUES (@passport_series, @passport_number, @name, @surname, @patronymic, @birthday, @tel_number)", Form1.conn);
                        command1.Parameters.AddWithValue("@passport_series", textBox1.Text);
                        command1.Parameters.AddWithValue("@passport_number", textBox2.Text);
                        command1.Parameters.AddWithValue("@name", textBox3.Text);
                        command1.Parameters.AddWithValue("@surname", textBox4.Text);
                        command1.Parameters.AddWithValue("@patronymic", textBox5.Text);
                        command1.Parameters.AddWithValue("@birthday", ancBirthdayDateTimePicker.Value);
                        command1.Parameters.AddWithValue("@tel_number", textBox7.Text);
                        command1.ExecuteNonQuery();

                        string check = RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(Form1.conn, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        idOfCurrentCustomer = Convert.ToInt32(RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(Form1.conn, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));//Заного определяем ID только что добавленного клиента

                        command2 = new SqlCommand("INSERT INTO Booking (number, settling, eviction, value_of_guests, value_of_kids, customer_id) VALUES (@number, @settling, @eviction, @value_of_guests, @value_of_kids, @customer_id)", Form1.conn);
                        command2.Parameters.AddWithValue("@number", selectedNumberOfApartments);
                        command2.Parameters.AddWithValue("@settling", ancSettlingDateTimePicker.Value);
                        command2.Parameters.AddWithValue("@eviction", ancEvictionDateTimePicker);
                        command2.Parameters.AddWithValue("@value_of_guests", textBox13.Text);
                        command2.Parameters.AddWithValue("@value_of_kids", textBox14.Text);
                        command2.Parameters.AddWithValue("@customer_id", idOfCurrentCustomer);
                        command2.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Клиент с такими серией и номером паспорта уже зарегистрирован.");
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowOfPassportSeriesIsCorrect(textBox1, e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowOfPassportNumberIsCorrect(textBox2, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoDigits(textBox3, e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoDigits(textBox4, e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoDigits(textBox5, e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoLetters(textBox7, e);
        }

        private void applyFiltresButton_Click(object sender, EventArgs e)
        {
            if (bottomPriceTextBox.Text != "")
            {
                smallestPrice = Convert.ToInt32(bottomPriceTextBox.Text);
            }
            else
            {
                smallestPrice = 0;
            }
            if (topPriceTextBox.Text != "")
            {
                biggestPrice = Convert.ToInt32(topPriceTextBox.Text);
            }
            else
            {
                biggestPrice = 100000;
            }
            if (typeOfApartmentsComboBox.SelectedItem == null)
            {
                dataGridViewANC.DataSource = RequestsSQLT.ApplyTargetFiltres(Form1.conn, null, searchebleSettlingDateTimePicker.Value, searchebleEvictionDateTimePicker.Value, smallestPrice, biggestPrice);
            }
            else
            {
                dataGridViewANC.DataSource = RequestsSQLT.ApplyTargetFiltres(Form1.conn, typeOfApartmentsComboBox.SelectedItem.ToString(), searchebleSettlingDateTimePicker.Value, searchebleEvictionDateTimePicker.Value, smallestPrice, biggestPrice);
            }
            ancSettlingDateTimePicker.Value = searchebleSettlingDateTimePicker.Value;
            ancEvictionDateTimePicker.Value = searchebleEvictionDateTimePicker.Value;
        }

        private void dataGridViewANC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedNumberOfApartments = ElementsSettings.SelectNumberOfSelectedApartments(dataGridViewANC, e);
            if (textBox13.Text != "" && textBox14.Text != "" && ancSettlingDateTimePicker.Value < ancEvictionDateTimePicker.Value)
            {
                TimeSpan ts = ancEvictionDateTimePicker.Value - ancSettlingDateTimePicker.Value;
                resultPriceTextBox.Text = ((ts.Days + 1) * ElementsSettings.SelectPriceOfSelectedApartments(dataGridViewANC, e) * (Convert.ToInt32(textBox13.Text) - Convert.ToInt32(textBox14.Text)) + (ts.Days + 1) * Convert.ToInt32(textBox14.Text) * (ElementsSettings.SelectPriceOfSelectedApartments(dataGridViewANC, e) - (ElementsSettings.SelectPriceOfSelectedApartments(dataGridViewANC, e) / 100 * Convert.ToInt32(discountTextBox.Text)))).ToString();
            }
            else
            {
                resultPriceTextBox.Text = "<некорректные данные>";
            }
        }
    }
}
