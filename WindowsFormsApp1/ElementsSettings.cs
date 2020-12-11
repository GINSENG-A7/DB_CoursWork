using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class ElementsSettings
    {
        static bool executed1 = false;
        static bool executed2 = false;
        public static bool RowOfPassportSeriesConsistEnoughNumbers(TextBox tb)
        {
            if (tb.TextLength != 4)
            {
                MessageBox.Show("Неверный формат ввода при указании серии паспорта");
                return false;
            }
            return true;
        }

        public static void RowOfPassportSeriesIsCorrect(TextBox tb, KeyPressEventArgs e_local)
        {
            if (tb.TextLength >= 4)
            {
                e_local.Handled = true;
                if (e_local.KeyChar == 8 || e_local.KeyChar == 46)
                {
                    e_local.Handled = false;
                }
            }
            else
            {
                e_local.Handled = false;
                if (!Char.IsDigit(e_local.KeyChar) && e_local.KeyChar != 8 && e_local.KeyChar != 20 && e_local.KeyChar != 131072 && e_local.KeyChar != 262144 && e_local.KeyChar != 16 && e_local.KeyChar != 46)
                {
                    e_local.Handled = true;
                }
            }
        }
        public static bool RowOfPassportNumberConsistEnoughNumbers(TextBox tb)
        {
            if(tb.TextLength != 6)
            {
                MessageBox.Show("Неверный формат ввода при указании номера паспорта");
                return false;
            }
            return true;
        }
        public static void RowOfPassportNumberIsCorrect(TextBox tb, KeyPressEventArgs e_local)
        {
            if (tb.TextLength >= 6)
            {
                e_local.Handled = true;
                if (e_local.KeyChar == 8 || e_local.KeyChar == 46)
                {
                    e_local.Handled = false;
                }
            }
            else
            {
                e_local.Handled = false;
                if (!Char.IsDigit(e_local.KeyChar) && e_local.KeyChar != 8 && e_local.KeyChar != 20 && e_local.KeyChar != 131072 && e_local.KeyChar != 262144 && e_local.KeyChar != 16 && e_local.KeyChar != 46)
                {
                    e_local.Handled = true;
                }
            }
        }
        public static void RowWithNoDigits(TextBox tb, KeyPressEventArgs e_local)
        {
            if (!Char.IsLetter(e_local.KeyChar) && e_local.KeyChar != 8 && e_local.KeyChar != 20 && e_local.KeyChar != 131072 && e_local.KeyChar != 262144 && e_local.KeyChar != 16 && e_local.KeyChar != 46)
            {
                e_local.Handled = true;
            }
        }
        public static void RowWithNoLetters(TextBox tb, KeyPressEventArgs e_local)
        {
            if (!Char.IsDigit(e_local.KeyChar) && e_local.KeyChar != 8 && e_local.KeyChar != 20 && e_local.KeyChar != 131072 && e_local.KeyChar != 262144 && e_local.KeyChar != 16 && e_local.KeyChar != 46)
            {
                e_local.Handled = true;
            }
        }
        public static void SmartRowOfDate(TextBox tb, KeyPressEventArgs e_local)//вставка, вырезка, копирование не работают
        {
            if (tb.TextLength >= 10)
            {
                e_local.Handled = true;
                if (e_local.KeyChar == 8 || e_local.KeyChar == 46)
                {
                    e_local.Handled = false;
                }
            }
            else
            {
                if(tb.Text == "" || tb.Text == null)
                {
                    executed1 = false;
                    executed2 = false;
                }
                e_local.Handled = false;
                if (!Char.IsDigit(e_local.KeyChar) && e_local.KeyChar != 8 && e_local.KeyChar != 20 && e_local.KeyChar != 131072 && e_local.KeyChar != 262144 && e_local.KeyChar != 16 && e_local.KeyChar != 46 && e_local.KeyChar != '-' && e_local.KeyChar != '.' && e_local.KeyChar != 67 && e_local.KeyChar != 86 && e_local.KeyChar != 88)
                {
                    e_local.Handled = true;
                }
                if (e_local.KeyChar == 8 || e_local.KeyChar == 46)
                {
                    goto point1;
                }
                if (tb.TextLength == 4 && executed1 == false)
                {
                    tb.Text += "-";
                    tb.SelectionStart = tb.Text.Length;
                    executed1 = true;
                }
                if (tb.TextLength == 7 && executed2 == false)
                {
                    tb.Text += "-";
                    tb.SelectionStart = tb.Text.Length;
                    executed2 = true;
                }
                point1:;
            }
        }
        public static void SmartRowOfTellNumber(TextBox tb, KeyPressEventArgs e_local)
        {
            if (tb.Text.Length > 0)
            {
                switch (tb.Text[0])
                {
                    case '+':
                        if (tb.TextLength >= 12)
                        {
                            e_local.Handled = true;
                            if (e_local.KeyChar == 8 || e_local.KeyChar == 46)
                            {
                                e_local.Handled = false;
                            }
                        }
                        else
                        {
                            if (!Char.IsDigit(e_local.KeyChar) && e_local.KeyChar != 8 && e_local.KeyChar != 20 && e_local.KeyChar != 131072 && e_local.KeyChar != 262144 && e_local.KeyChar != 16 && e_local.KeyChar != 46)
                            {
                                e_local.Handled = true;
                            }
                        }
                        break;
                    case '8':
                        if (tb.TextLength >= 11)
                        {
                            e_local.Handled = true;
                            if (e_local.KeyChar == 8 || e_local.KeyChar == 46)
                            {
                                e_local.Handled = false;
                            }
                            if (tb.SelectionStart == 0 && e_local.KeyChar == '+')
                            {
                                e_local.Handled = false;
                            }
                        }
                        else
                        {
                            if (!Char.IsDigit(e_local.KeyChar) && e_local.KeyChar != 8 && e_local.KeyChar != 20 && e_local.KeyChar != 131072 && e_local.KeyChar != 262144 && e_local.KeyChar != 16 && e_local.KeyChar != 46 && e_local.KeyChar != '+')
                            {
                                e_local.Handled = true;
                            }
                        }
                        break;
                }
            }
        }
        public static bool ValuesOfGuestsAndKidsAreCorrect(TextBox tbOfGuests, TextBox tbOfKids)
        {
            if((0 < Convert.ToInt32(tbOfGuests.Text) && Convert.ToInt32(tbOfGuests.Text) < 7) && (0 <= Convert.ToInt32(tbOfKids.Text) && Convert.ToInt32(tbOfKids.Text) < Convert.ToInt32(tbOfGuests.Text)))
            {
                return true;
            }
            MessageBox.Show("Неверный формат ввода при указании колличества проживающих");
            return false;
        }
        public static bool SettlingDateIsLessThenEvictionDate(DateTimePicker dtp1, DateTimePicker dtp2)
        {
            if(dtp1.Value < dtp2.Value)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Дата заезда должна быть меньше даты выезда");
                return false;
            }
        }
        public static void DefaultTextBoxSettings(TextBox tb)
        {
            tb.Text = null;
            tb.ForeColor = Color.Black;
            tb.BackColor = Color.White;
        }
        public static void SearchTextBoxSettings(TextBox tb)
        {
            tb.Text = "Поиск по фамилии";//подсказка
            tb.ForeColor = Color.DarkGray;
            tb.BackColor = Color.LightGray;
        }
        public static void DateTextBoxSettings(TextBox tb)
        {
            tb.Text = "YYYY-MM-DD";//подсказка
            tb.ForeColor = Color.DarkGray;
        }
        public static void SetDefaultSettingsToDGV(DataGridView dgv)
        {
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToOrderColumns = true;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeColumns = true;
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgv.ReadOnly = true;
        }
        public static void HideFirstXColumns(DataGridView dgv, int x)
        {
            x = x - 1;
            while(x >= 0)
            {
                dgv.Columns[x].Visible = false;
                x--;
            }
        }
        public static string[] SetDataFromCustomersDGVToTextBoxes(DataGridView dgv, DataGridViewCellEventArgs e_local)
        {
            string[] collomnsValues = new string[7];
            if (e_local.ColumnIndex == 0)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex+1].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex+2].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex+3].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex+4].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex+5].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex+6].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 1)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 1].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 2].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 3].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 4].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 5].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 2)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 2].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 1].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 2].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 3].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 4].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 3)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 3].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 2].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 1].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 2].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 3].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 4)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 4].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 3].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 2].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 1].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 2].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 5)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 5].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 4].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 3].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 2].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 1].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 6)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 6].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 5].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 4].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 3].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 2].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 7)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 7].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 6].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 5].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 4].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 3].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 2].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
            }
            return collomnsValues;
        }
        public static string[] SetDataFromLivingOrBookingDGVToTextBoxes(DataGridView dgv, DataGridViewCellEventArgs e_local)
        {
            string[] collomnsValues = new string[7];
            if (e_local.ColumnIndex == 0)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 1].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 5].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 6].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 7].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 8].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 9].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 1)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 4].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 5].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 6].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 7].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 8].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 2)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 2].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 3].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 4].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 5].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 6].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 7].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 3)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 3].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 2].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 2].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 3].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 4].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 5].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 6].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 4)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 4].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 3].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 1].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 2].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 3].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 4].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 5].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 5)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 5].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 4].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 1].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 2].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 3].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 4].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 6)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 6].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 5].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 1].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 2].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 3].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 7)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 7].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 6].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 2].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 1].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 2].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 8)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 8].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 7].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 3].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 2].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 1].FormattedValue.ToString();
            }
            if (e_local.ColumnIndex == 9)
            {
                collomnsValues[0] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 8].FormattedValue.ToString();
                collomnsValues[1] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 7].FormattedValue.ToString();
                collomnsValues[2] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 4].FormattedValue.ToString();
                collomnsValues[3] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 3].FormattedValue.ToString();
                collomnsValues[4] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 2].FormattedValue.ToString();
                collomnsValues[5] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex - 1].FormattedValue.ToString();
                collomnsValues[6] = dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue.ToString();
            }
            return collomnsValues;
        }
        public static int SelectNumberOfSelectedApartments(DataGridView dgv, DataGridViewCellEventArgs e_local)
        {
            int num = 0;
            if (e_local.ColumnIndex == 0)
            {
                num = Convert.ToInt32(dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue);
            }
            if (e_local.ColumnIndex == 1)
            {
                num = Convert.ToInt32(dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex-1].FormattedValue);
            }
            if (e_local.ColumnIndex == 2)
            {
                num = Convert.ToInt32(dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex-2].FormattedValue);
            }
            if (e_local.ColumnIndex == 3)
            {
                num = Convert.ToInt32(dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex-3].FormattedValue);
            }
            return num;
        }
        public static int SelectPriceOfSelectedApartments(DataGridView dgv, DataGridViewCellEventArgs e_local)
        {
            int prc = 0;
            if (e_local.ColumnIndex == 0)
            {
                prc = Convert.ToInt32(dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 2].FormattedValue);
            }
            if (e_local.ColumnIndex == 1)
            {
                prc = Convert.ToInt32(dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex + 1].FormattedValue);
            }
            if (e_local.ColumnIndex == 2)
            {
                prc = Convert.ToInt32(dgv.Rows[e_local.RowIndex].Cells[e_local.ColumnIndex].FormattedValue);
            }
            return prc;
        }
        public static bool NewDiscountIsInPercentage(TextBox tb)
        {
            if(Convert.ToInt32(tb.Text)>=0 && Convert.ToInt32(tb.Text) <= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}