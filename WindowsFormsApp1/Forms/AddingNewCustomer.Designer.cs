
namespace WindowsFormsApp1
{
    partial class AddingNewCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewANC = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.applyFiltresButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.typeOfApartmentsComboBox = new System.Windows.Forms.ComboBox();
            this.topPriceTextBox = new System.Windows.Forms.TextBox();
            this.bottomPriceTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.searchebleEvictionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.searchebleSettlingDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ancBirthdayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ancEvictionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ancSettlingDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CheckAndAddCustomerData = new System.Windows.Forms.Button();
            this.CheckAndAddВookingData = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.resultPriceTextBox = new System.Windows.Forms.TextBox();
            this.discountTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewANC)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewANC
            // 
            this.dataGridViewANC.AllowUserToAddRows = false;
            this.dataGridViewANC.AllowUserToDeleteRows = false;
            this.dataGridViewANC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewANC.Location = new System.Drawing.Point(13, 12);
            this.dataGridViewANC.Name = "dataGridViewANC";
            this.dataGridViewANC.ReadOnly = true;
            this.dataGridViewANC.Size = new System.Drawing.Size(683, 301);
            this.dataGridViewANC.TabIndex = 23;
            this.dataGridViewANC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewANC_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.applyFiltresButton);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.typeOfApartmentsComboBox);
            this.groupBox3.Controls.Add(this.topPriceTextBox);
            this.groupBox3.Controls.Add(this.bottomPriceTextBox);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.searchebleEvictionDateTimePicker);
            this.groupBox3.Controls.Add(this.searchebleSettlingDateTimePicker);
            this.groupBox3.Location = new System.Drawing.Point(13, 320);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(501, 88);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Фильтры";
            // 
            // applyFiltresButton
            // 
            this.applyFiltresButton.Location = new System.Drawing.Point(304, 59);
            this.applyFiltresButton.Name = "applyFiltresButton";
            this.applyFiltresButton.Size = new System.Drawing.Size(191, 23);
            this.applyFiltresButton.TabIndex = 41;
            this.applyFiltresButton.Text = "Применить фильтры";
            this.applyFiltresButton.UseVisualStyleBackColor = true;
            this.applyFiltresButton.Click += new System.EventHandler(this.applyFiltresButton_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(301, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "Тип номера";
            // 
            // typeOfApartmentsComboBox
            // 
            this.typeOfApartmentsComboBox.FormattingEnabled = true;
            this.typeOfApartmentsComboBox.Location = new System.Drawing.Point(374, 19);
            this.typeOfApartmentsComboBox.Name = "typeOfApartmentsComboBox";
            this.typeOfApartmentsComboBox.Size = new System.Drawing.Size(121, 21);
            this.typeOfApartmentsComboBox.TabIndex = 39;
            // 
            // topPriceTextBox
            // 
            this.topPriceTextBox.Location = new System.Drawing.Point(176, 61);
            this.topPriceTextBox.Name = "topPriceTextBox";
            this.topPriceTextBox.Size = new System.Drawing.Size(119, 20);
            this.topPriceTextBox.TabIndex = 38;
            // 
            // bottomPriceTextBox
            // 
            this.bottomPriceTextBox.Location = new System.Drawing.Point(26, 61);
            this.bottomPriceTextBox.Name = "bottomPriceTextBox";
            this.bottomPriceTextBox.Size = new System.Drawing.Size(119, 20);
            this.bottomPriceTextBox.TabIndex = 37;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(151, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "до";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "От";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(151, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "до";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "C";
            // 
            // searchebleEvictionDateTimePicker
            // 
            this.searchebleEvictionDateTimePicker.Location = new System.Drawing.Point(176, 19);
            this.searchebleEvictionDateTimePicker.Name = "searchebleEvictionDateTimePicker";
            this.searchebleEvictionDateTimePicker.Size = new System.Drawing.Size(119, 20);
            this.searchebleEvictionDateTimePicker.TabIndex = 1;
            // 
            // searchebleSettlingDateTimePicker
            // 
            this.searchebleSettlingDateTimePicker.Location = new System.Drawing.Point(26, 19);
            this.searchebleSettlingDateTimePicker.Name = "searchebleSettlingDateTimePicker";
            this.searchebleSettlingDateTimePicker.Size = new System.Drawing.Size(119, 20);
            this.searchebleSettlingDateTimePicker.TabIndex = 0;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(115, 175);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(132, 20);
            this.textBox7.TabIndex = 6;
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Номер паспорта";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(115, 123);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(132, 20);
            this.textBox5.TabIndex = 4;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Имя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Фамилия";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(115, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Отчество";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(115, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Дата рождения";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(115, 97);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(132, 20);
            this.textBox4.TabIndex = 5;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Номер телефона";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Серия паспорта";
            // 
            // ancBirthdayDateTimePicker
            // 
            this.ancBirthdayDateTimePicker.Location = new System.Drawing.Point(115, 149);
            this.ancBirthdayDateTimePicker.Name = "ancBirthdayDateTimePicker";
            this.ancBirthdayDateTimePicker.Size = new System.Drawing.Size(132, 20);
            this.ancBirthdayDateTimePicker.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ancBirthdayDateTimePicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Location = new System.Drawing.Point(702, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 208);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные о клиенте";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Дата выезда";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Количество гостей";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Количество детей";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Дата заезда";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(115, 71);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(132, 20);
            this.textBox13.TabIndex = 24;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(115, 97);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(132, 20);
            this.textBox14.TabIndex = 29;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ancEvictionDateTimePicker);
            this.groupBox2.Controls.Add(this.ancSettlingDateTimePicker);
            this.groupBox2.Controls.Add(this.textBox14);
            this.groupBox2.Controls.Add(this.textBox13);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(702, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 129);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные о проживании";
            // 
            // ancEvictionDateTimePicker
            // 
            this.ancEvictionDateTimePicker.Location = new System.Drawing.Point(115, 45);
            this.ancEvictionDateTimePicker.Name = "ancEvictionDateTimePicker";
            this.ancEvictionDateTimePicker.Size = new System.Drawing.Size(132, 20);
            this.ancEvictionDateTimePicker.TabIndex = 36;
            // 
            // ancSettlingDateTimePicker
            // 
            this.ancSettlingDateTimePicker.Location = new System.Drawing.Point(115, 19);
            this.ancSettlingDateTimePicker.Name = "ancSettlingDateTimePicker";
            this.ancSettlingDateTimePicker.Size = new System.Drawing.Size(132, 20);
            this.ancSettlingDateTimePicker.TabIndex = 35;
            // 
            // CheckAndAddCustomerData
            // 
            this.CheckAndAddCustomerData.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CheckAndAddCustomerData.Location = new System.Drawing.Point(702, 385);
            this.CheckAndAddCustomerData.Name = "CheckAndAddCustomerData";
            this.CheckAndAddCustomerData.Size = new System.Drawing.Size(145, 23);
            this.CheckAndAddCustomerData.TabIndex = 22;
            this.CheckAndAddCustomerData.Text = "Регистрация проживания";
            this.CheckAndAddCustomerData.UseVisualStyleBackColor = true;
            this.CheckAndAddCustomerData.Click += new System.EventHandler(this.CheckAndAddCustomerData_Click);
            // 
            // CheckAndAddВookingData
            // 
            this.CheckAndAddВookingData.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CheckAndAddВookingData.Location = new System.Drawing.Point(853, 385);
            this.CheckAndAddВookingData.Name = "CheckAndAddВookingData";
            this.CheckAndAddВookingData.Size = new System.Drawing.Size(102, 23);
            this.CheckAndAddВookingData.TabIndex = 25;
            this.CheckAndAddВookingData.Text = "Забронировать";
            this.CheckAndAddВookingData.UseVisualStyleBackColor = true;
            this.CheckAndAddВookingData.Click += new System.EventHandler(this.CheckAndAddВookingData_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.resultPriceTextBox);
            this.groupBox4.Controls.Add(this.discountTextBox);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Location = new System.Drawing.Point(520, 320);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(176, 89);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Итоговая стоимость";
            // 
            // resultPriceTextBox
            // 
            this.resultPriceTextBox.Location = new System.Drawing.Point(52, 61);
            this.resultPriceTextBox.Name = "resultPriceTextBox";
            this.resultPriceTextBox.Size = new System.Drawing.Size(118, 20);
            this.resultPriceTextBox.TabIndex = 3;
            // 
            // discountTextBox
            // 
            this.discountTextBox.Location = new System.Drawing.Point(139, 19);
            this.discountTextBox.Name = "discountTextBox";
            this.discountTextBox.Size = new System.Drawing.Size(31, 20);
            this.discountTextBox.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Итого:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(127, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Скидка для ребёнка (%)";
            // 
            // AddingNewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 418);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.CheckAndAddВookingData);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridViewANC);
            this.Controls.Add(this.CheckAndAddCustomerData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(985, 457);
            this.MinimumSize = new System.Drawing.Size(985, 457);
            this.Name = "AddingNewCustomer";
            this.Text = "Регистрация клиента";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewANC)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewANC;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker searchebleSettlingDateTimePicker;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ancBirthdayDateTimePicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button CheckAndAddCustomerData;
        private System.Windows.Forms.DateTimePicker ancEvictionDateTimePicker;
        private System.Windows.Forms.DateTimePicker ancSettlingDateTimePicker;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox typeOfApartmentsComboBox;
        private System.Windows.Forms.TextBox topPriceTextBox;
        private System.Windows.Forms.TextBox bottomPriceTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker searchebleEvictionDateTimePicker;
        private System.Windows.Forms.Button applyFiltresButton;
        private System.Windows.Forms.Button CheckAndAddВookingData;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox resultPriceTextBox;
        private System.Windows.Forms.TextBox discountTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
    }
}