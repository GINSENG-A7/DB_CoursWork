using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddingNewNumber : Form
    {
        public static string str = "";
        public static string[] sr;
        public AddingNewNumber()
        {
            InitializeComponent();
        }
        
        private void openFileDialogButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog myFile = new OpenFileDialog();
            myFile.Filter ="Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            myFile.Multiselect = true;
            myFile.Title = "My Image Browser";
            if (myFile.ShowDialog() == DialogResult.OK)
            {
                sr = myFile.FileNames;
            }
            foreach(string i in sr)
            {
                str += i + "  ";
            }
        }
    }
}
