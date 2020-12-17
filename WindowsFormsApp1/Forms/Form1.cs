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
        public static bool cb = new bool();
        public static string[] bookingS = new string[9];
        public static int[] valuesOfAdditionalServicesCell = new int[5];
        public static int idOfChosenRow1 = -1;
        public static int idOfChosenRow2 = -1;
        public static int idOfChosenRow3 = -1;
        public static int idOfChosenRowAS = -1;
        public static int idOfChosenRowLiving = -1;
        public static int idOfChosenRowBooking = -1;
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
        public void SetButtonsInactive0()
        {
            deleteCustomerButton.Enabled = false;
            changeCustomerDataButton.Enabled = false;
            moveToLivingsButton.Enabled = false;
            moveToBookingsBotton.Enabled = false;
        }
        public void SetButtonsActive0()
        {
            deleteCustomerButton.Enabled = true;
            changeCustomerDataButton.Enabled = true;
            moveToLivingsButton.Enabled = true;
            moveToBookingsBotton.Enabled = true;
        }
        public void SetButtonsInactive1()
        {
            deleteLivingDataButton.Enabled = false;
            changeLivingDataButton.Enabled = false;
            checkAddititonalServicesButton.Enabled = false;
            moveToCustomerFromLivingButton.Enabled = false;
        }
        public void SetButtonsActive1()
        {
            deleteLivingDataButton.Enabled = true;
            changeLivingDataButton.Enabled = true;
            checkAddititonalServicesButton.Enabled = true;
            moveToCustomerFromLivingButton.Enabled = true;
        }
        public void SetButtonsInactive2()
        {
            deleteBookingDataButton.Enabled = false;
            changeBookingDataButton.Enabled = false;
            moveToCustomerFromBookingButton.Enabled = false;
        }
        public void SetButtonsActive2()
        {
            deleteBookingDataButton.Enabled = true;
            changeBookingDataButton.Enabled = true;
            moveToCustomerFromBookingButton.Enabled = true;
        }
        public void SetButtonsInactive3()
        {
            deleteApartmentsButton.Enabled = false;
            changeApartmentsButton.Enabled = false;
            editImagesOfApartmentButton.Enabled = false;
        }
        public void SetButtonsActive3()
        {
            deleteApartmentsButton.Enabled = true;
            changeApartmentsButton.Enabled = true;
            editImagesOfApartmentButton.Enabled = true;
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
            typeComboBox.Items.AddRange(admissibleTypesOfApartments);
            SetButtonsInactive0();
            SetButtonsInactive1();
            SetButtonsInactive2();
            SetButtonsInactive3();
        }
        public void Refresh1()
        {
            OpenConnectionCorrect(conn);
            dataGridView1.DataSource = RequestsSQLT.SelectAllFromCustomer(conn);
            ElementsSettings.SetDefaultSettingsToDGV(dataGridView1);
            ElementsSettings.RenameCustomerDGV(dataGridView1);
        }
        public void Refresh2()
        {
            OpenConnectionCorrect(conn);
            dataGridView2.DataSource = RequestsSQLT.SelectAllFromLiving(conn);
            ElementsSettings.SetDefaultSettingsToDGV(dataGridView2);
            ElementsSettings.HideFirstXColumns(dataGridView2, 2);
            ElementsSettings.HideLastXColumns(dataGridView2, 2);
            ElementsSettings.RenameLivingOrBookingDGV(dataGridView2);
        }
        public void Refresh3()
        {
            OpenConnectionCorrect(conn);
            dataGridView3.DataSource = RequestsSQLT.SelectAllFromBooking(conn);
            ElementsSettings.SetDefaultSettingsToDGV(dataGridView3);
            ElementsSettings.HideFirstXColumns(dataGridView3, 2);
            ElementsSettings.HideLastXColumns(dataGridView3, 2);
            ElementsSettings.RenameLivingOrBookingDGV(dataGridView3);
        }
        public void Refresh4()
        {
            OpenConnectionCorrect(conn);
            dataGridView4.DataSource = RequestsSQLT.SelectAllFromApartments(conn);
            ElementsSettings.SetDefaultSettingsToDGV(dataGridView4);
            ElementsSettings.RenameApartmentsDGV(dataGridView4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh1();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Refresh2();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Refresh3();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Refresh4();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            cb = checkBox1.Checked;
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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetButtonsActive0();
            try
            {
                string[] s = ElementsSettings.SetDataFromCustomersDGVToTextBoxes(dataGridView1, e);
                idOfChosenRow1 = Convert.ToInt32(RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(conn, Convert.ToInt32(s[0]), Convert.ToInt32(s[1])));
                textBox2.Text = s[0];
                textBox3.Text = s[1];
                textBox4.Text = s[2];
                textBox5.Text = s[3];
                textBox6.Text = s[4];
                dateTimePicker1.Value = Convert.ToDateTime(s[5]);
                //textBox7.Text = s[6];
                textBox8.Text = s[6];
            } catch { }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetButtonsActive1();
            try
            {
                string[] s = ElementsSettings.SetDataFromLivingOrBookingDGVToTextBoxes(dataGridView2, e);
                idOfChosenRow2 = Convert.ToInt32(RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(conn, Convert.ToInt32(s[0]), Convert.ToInt32(s[1])));
                textBox12.Text = s[5];
                textBox11.Text = s[6];
                if (s[7] != "")
                {
                    idOfChosenRowAS = Convert.ToInt32(s[7]);
                }
                if (s[8] != "")
                {
                    idOfChosenRowLiving = Convert.ToInt32(s[8]);
                }
            } catch { }
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetButtonsActive2();
            try
            {
                bookingS = ElementsSettings.SetDataFromLivingOrBookingDGVToTextBoxes(dataGridView3, e);
                idOfChosenRow3 = Convert.ToInt32(RequestsSQLT.SelectNthIdFromCustomerWherePassportDataDefinedToString(conn, Convert.ToInt32(bookingS[0]), Convert.ToInt32(bookingS[1])));
                textBox17.Text = bookingS[5];
                textBox16.Text = bookingS[6];
                if (bookingS[7] != "")
                {
                    idOfChosenRowBooking = Convert.ToInt32(bookingS[8]);
                }
            } catch { }
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetButtonsActive3();
            try
            {
                bookingS = ElementsSettings.SetDataFromApartmentsDGVToTextBoxes(dataGridView4, e);
                numberOfChosenRow = Convert.ToInt32(bookingS[0]);
                numberTextBox.Text = bookingS[0];
                typeComboBox.Text = bookingS[1];
                priceTextBox.Text = bookingS[2];
            } catch { }
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
                    Refresh1();
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
                Refresh1();
                Refresh2();
                Refresh3();
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
            ElementsSettings.SetDefaultSettingsToDGV(dataGridView2);
            ElementsSettings.HideFirstXColumns(dataGridView2, 2);
            ElementsSettings.HideLastXColumns(dataGridView2, 2);
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
            EditingAdditionalServices eas = new EditingAdditionalServices();
            eas.ShowDialog();
            eas.Focus();
        }

        private void changeLivingDataButton_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show("Вы уверены, что хотите применить изменения в базе данных?", "", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                if (ElementsSettings.ValuesOfGuestsAndKidsAreCorrect(textBox12, textBox11) == true) //Проверяем все ограничения ввода для таблицы клиетов
                {
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand($"UPDATE Living SET value_of_guests = {Convert.ToInt32(textBox12.Text)}, value_of_kids = {Convert.ToInt32(textBox11.Text)} WHERE living_id = {idOfChosenRowLiving}", conn);
                    command.ExecuteNonQuery();
                    Refresh2();
                }
                else
                {
                    MessageBox.Show("Введены недопустимые значения");
                }
            }
        }

        private void deleteLivingDataButton_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand($"DELETE FROM Living WHERE living_id = {idOfChosenRowLiving}", conn);
                command.ExecuteNonQuery();
                Refresh2();
            }
            if (RequestsSQLT.DoesCustomerHasNoLivivngsAndBookings(conn, idOfChosenRow2) == true)
            {
                var dr = MessageBox.Show("У клиента не осталось ни проживаний, ни броней. Хотите удалить его из базы данных?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SqlCommand command0 = new SqlCommand();
                    command0 = new SqlCommand($"DELETE FROM Customer WHERE customer_id = {idOfChosenRow2}", conn);
                    command0.ExecuteNonQuery();
                    Refresh1();
                }
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoLetters(textBox12, e);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoLetters(textBox11, e);
        }

        private void moveToCustomerFromBookingButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = RequestsSQLT.SelectAllFromCustomerByCustomerId(conn, idOfChosenRow3);
            tabControl1.SelectedIndex = 0;
        }

        private void changeBookingDataButton_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show("Вы уверены, что хотите применить изменения в базе данных?", "", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                if (ElementsSettings.ValuesOfGuestsAndKidsAreCorrect(textBox12, textBox11) == true) //Проверяем все ограничения ввода для таблицы клиентов
                {
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand($"UPDATE Booking SET value_of_guests = {Convert.ToInt32(textBox12.Text)}, value_of_kids = {Convert.ToInt32(textBox11.Text)} WHERE booking_id = {idOfChosenRowBooking}", conn);
                    command.ExecuteNonQuery();
                    Refresh3();
                }
                else
                {
                    MessageBox.Show("Введены недопустимые значения");
                }
            }
        }

        private void deleteBookingDataButton_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand();
                command = new SqlCommand($"DELETE FROM Booking WHERE booking_id = {idOfChosenRowBooking}", conn);
                command.ExecuteNonQuery();
                Refresh3();
            }
            if (RequestsSQLT.DoesCustomerHasNoLivivngsAndBookings(conn, idOfChosenRow3) == true)
            {
                var dr = MessageBox.Show("У клиента не осталось ни проживаний, ни броней. Хотите удалить его из базы данных?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SqlCommand command0 = new SqlCommand();
                    command0 = new SqlCommand($"DELETE FROM Customer WHERE customer_id = {idOfChosenRow3}", conn);
                    command0.ExecuteNonQuery();
                    Refresh1();
                }
            }
        }

        private void changeApartmentsButton_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show("Вы уверены, что хотите применить изменения в базе данных?", "", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                if (RequestsSQLT.NumberOfApartmentsIsFree(conn, numberOfChosenRow) == true) //Проверяем все ограничения ввода для таблицы клиентов
                {
                    if(RequestsSQLT.SelectSetValueOfNumberFromApartments(numberTextBox, conn) == true)
                    {
                        if(RequestsSQLT.TypeOfApartmentsIsCorrect(typeComboBox, conn) == true)
                        {
                            SqlCommand command = new SqlCommand();
                            command = new SqlCommand($"UPDATE Apartments SET number = {Convert.ToInt32(numberTextBox.Text)}, \"type\" = '{typeComboBox.Text}', price = {Convert.ToInt32(priceTextBox.Text)} WHERE number = {Convert.ToInt32(numberTextBox.Text)}", conn);
                            command.ExecuteNonQuery();
                            Refresh4();
                        }
                        else
                        {
                            MessageBox.Show("Введён некорректный тип номера");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Редактирование данной записи недоступно. На номер зарегистрированно неоконченное проживание или оформлена бронь.");
                }
            }
        }

        private void deleteApartmentsButton_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                if (RequestsSQLT.NumberOfApartmentsIsFree(conn, numberOfChosenRow) == true) //Проверяем все ограничения ввода для таблицы клиентов
                {
                    SqlCommand command1 = new SqlCommand();
                    command1 = new SqlCommand($"DELETE FROM Apartments WHERE number = {Convert.ToInt32(numberTextBox.Text)}", conn);
                    command1.ExecuteNonQuery();
                    SqlCommand command2 = new SqlCommand();
                    command2 = new SqlCommand($"DELETE FROM Photos WHERE number = {Convert.ToInt32(numberTextBox.Text)}", conn);
                    command2.ExecuteNonQuery();
                    Refresh4();
                }
                else
                {
                    MessageBox.Show("Редактирование данной записи недоступно. На номер зарегистрированно неоконченное проживание или оформлена бронь.");
                }
            }
        }

        private void editImagesOfApartmentButton_Click(object sender, EventArgs e)
        {
            RequestsSQLT.CollectImagesOfNthNumber(conn, numberOfChosenRow, RequestsSQLT.photosList);
            ViewingApartmentsPhotos vap = new ViewingApartmentsPhotos();
            vap.ShowDialog();
            vap.Focus();
        }


        public void Form1_Load(object sender, EventArgs e)
        {
            Refresh1();
            Refresh2();
            Refresh3();
            Refresh4();
        }
    }
}
