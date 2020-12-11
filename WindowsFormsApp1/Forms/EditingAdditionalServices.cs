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
    public partial class EditingAdditionalServices : Form
    {
        public static DataTable dtLinked = new DataTable();
        public EditingAdditionalServices()
        {
            InitializeComponent();
        }

        private void updateDataButton_Click(object sender, EventArgs e)
        {
            minibarTextBox.Text = Form1.valuesOfAdditionalServicesCell[0].ToString();
            clothesWashingTextBox.Text = Form1.valuesOfAdditionalServicesCell[1].ToString();
            telephoneTextBox.Text = Form1.valuesOfAdditionalServicesCell[2].ToString();
            intercityTelephoneTextBox.Text = Form1.valuesOfAdditionalServicesCell[3].ToString();
            eatTextBox.Text = Form1.valuesOfAdditionalServicesCell[4].ToString();
        }
        private void refreshButton_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show("Вы уверены, что хотите применить изменения в базе данных?", "", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                if (Convert.ToInt32(minibarTextBox.Text) <=0 && Convert.ToInt32(clothesWashingTextBox.Text) <=0 && Convert.ToInt32(telephoneTextBox.Text) <=0 && Convert.ToInt32(intercityTelephoneTextBox.Text) <=0 && Convert.ToInt32(eatTextBox.Text) <=0)
                {
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand($"UPDATE Customer SET passport_series = {0}, passport_number = {0}, name = '{0}', surname = '{0}', patronymic = '{0}', birthday = '{0}', tel_number = '{0}' WHERE customer_id = {0}", Form1.conn);
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Введены отрицательные значения");
                }
            }
        }
    }
}
