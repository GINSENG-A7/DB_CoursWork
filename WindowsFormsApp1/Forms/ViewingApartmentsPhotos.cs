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
    public partial class ViewingApartmentsPhotos : Form
    {
        PictureData pd = new PictureData();
        SqlCommand command = new SqlCommand();
        int intdexOfPicture = 0;
        public ViewingApartmentsPhotos()
        {
            InitializeComponent();
            pictureBox1.Load(RequestsSQLT.photosList[intdexOfPicture].path);
        }

        private void addImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);

                    command = new SqlCommand("INSERT INTO Photos (path, number) VALUES (@path, @number)", Form1.conn);
                    command.Parameters.AddWithValue("@path", ofd.FileName);
                    command.Parameters.AddWithValue("@number", Form1.numberOfChosenRow);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл");
                }
            }
        }

        private void deleteImageButton_Click(object sender, EventArgs e)
        {
            var dResult = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "", MessageBoxButtons.YesNo);
            if (dResult == DialogResult.Yes)
            {
                command = new SqlCommand($"DELETE FROM Photos WHERE number = {RequestsSQLT.photosList[intdexOfPicture].id}", Form1.conn);
                command.ExecuteNonQuery();
            }
        }

        private void previousImageButton_Click(object sender, EventArgs e)
        {
            if(intdexOfPicture  > 0 )
            {
                intdexOfPicture--;
                pictureBox1.Load(RequestsSQLT.photosList[intdexOfPicture].path);
            }
        }

        private void nextImageButton_Click(object sender, EventArgs e)
        {
            if (intdexOfPicture + 1 < RequestsSQLT.photosList.Count)
            {
                intdexOfPicture++;
                pictureBox1.Load(RequestsSQLT.photosList[intdexOfPicture].path);
            }
        }
    }
}
