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
            minibarTextBox.Text = Form1.valuesOfAdditionalServicesCell[0].ToString();
            clothesWashingTextBox.Text = Form1.valuesOfAdditionalServicesCell[1].ToString();
            telephoneTextBox.Text = Form1.valuesOfAdditionalServicesCell[2].ToString();
            intercityTelephoneTextBox.Text = Form1.valuesOfAdditionalServicesCell[3].ToString();
            eatTextBox.Text = Form1.valuesOfAdditionalServicesCell[4].ToString();
        }

        private void updateDataButton_Click(object sender, EventArgs e)
        {
            minibarTextBox.Text = Form1.valuesOfAdditionalServicesCell[0].ToString();
            clothesWashingTextBox.Text = Form1.valuesOfAdditionalServicesCell[1].ToString();
            telephoneTextBox.Text = Form1.valuesOfAdditionalServicesCell[2].ToString();
            intercityTelephoneTextBox.Text = Form1.valuesOfAdditionalServicesCell[3].ToString();
            eatTextBox.Text = Form1.valuesOfAdditionalServicesCell[4].ToString();
        }
        private void refreshButton_Click(object sender, EventArgs e) //Изменение данных
        {
            var dResult = MessageBox.Show("Вы уверены, что хотите применить изменения в базе данных?", "", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                if (Convert.ToInt32(minibarTextBox.Text) >=0 && Convert.ToInt32(clothesWashingTextBox.Text) >=0 && Convert.ToInt32(telephoneTextBox.Text) >=0 && Convert.ToInt32(intercityTelephoneTextBox.Text) >=0 && Convert.ToInt32(eatTextBox.Text) >=0)
                {
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand($"UPDATE Additional_services SET mini_bar = {Convert.ToInt32(minibarTextBox.Text)}, clothes_washing = {Convert.ToInt32(clothesWashingTextBox.Text)}, telephone = {Convert.ToInt32(telephoneTextBox.Text)}, intercity_telephone = {Convert.ToInt32(intercityTelephoneTextBox.Text)}, food = {Convert.ToInt32(eatTextBox.Text)} WHERE as_id = {Form1.idOfChosenRowAS}", Form1.conn);
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Введены отрицательные значения");
                }
            }
        }

        private void minibarTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoLetters(minibarTextBox, e);
        }

        private void clothesWashingTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoLetters(clothesWashingTextBox, e);
        }

        private void telephoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoLetters(telephoneTextBox, e);
        }

        private void intercityTelephoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoLetters(intercityTelephoneTextBox, e);
        }

        private void eatTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ElementsSettings.RowWithNoLetters(eatTextBox, e);
        }
    }
}
