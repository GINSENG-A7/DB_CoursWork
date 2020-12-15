
namespace WindowsFormsApp1
{
    partial class EditingAdditionalServices
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.minibarTextBox = new System.Windows.Forms.TextBox();
            this.clothesWashingTextBox = new System.Windows.Forms.TextBox();
            this.telephoneTextBox = new System.Windows.Forms.TextBox();
            this.intercityTelephoneTextBox = new System.Windows.Forms.TextBox();
            this.eatTextBox = new System.Windows.Forms.TextBox();
            this.updateDataButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Мини-бар:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Стирка одежды:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Телефон:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Междугородний телефон:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Еда:";
            // 
            // minibarTextBox
            // 
            this.minibarTextBox.Location = new System.Drawing.Point(156, 10);
            this.minibarTextBox.Name = "minibarTextBox";
            this.minibarTextBox.Size = new System.Drawing.Size(100, 20);
            this.minibarTextBox.TabIndex = 5;
            this.minibarTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minibarTextBox_KeyPress);
            // 
            // clothesWashingTextBox
            // 
            this.clothesWashingTextBox.Location = new System.Drawing.Point(156, 36);
            this.clothesWashingTextBox.Name = "clothesWashingTextBox";
            this.clothesWashingTextBox.Size = new System.Drawing.Size(100, 20);
            this.clothesWashingTextBox.TabIndex = 6;
            this.clothesWashingTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.clothesWashingTextBox_KeyPress);
            // 
            // telephoneTextBox
            // 
            this.telephoneTextBox.Location = new System.Drawing.Point(156, 62);
            this.telephoneTextBox.Name = "telephoneTextBox";
            this.telephoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.telephoneTextBox.TabIndex = 7;
            this.telephoneTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telephoneTextBox_KeyPress);
            // 
            // intercityTelephoneTextBox
            // 
            this.intercityTelephoneTextBox.Location = new System.Drawing.Point(156, 88);
            this.intercityTelephoneTextBox.Name = "intercityTelephoneTextBox";
            this.intercityTelephoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.intercityTelephoneTextBox.TabIndex = 8;
            this.intercityTelephoneTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intercityTelephoneTextBox_KeyPress);
            // 
            // eatTextBox
            // 
            this.eatTextBox.Location = new System.Drawing.Point(156, 114);
            this.eatTextBox.Name = "eatTextBox";
            this.eatTextBox.Size = new System.Drawing.Size(100, 20);
            this.eatTextBox.TabIndex = 9;
            this.eatTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.eatTextBox_KeyPress);
            // 
            // updateDataButton
            // 
            this.updateDataButton.Location = new System.Drawing.Point(136, 141);
            this.updateDataButton.Name = "updateDataButton";
            this.updateDataButton.Size = new System.Drawing.Size(119, 23);
            this.updateDataButton.TabIndex = 10;
            this.updateDataButton.Text = "Обновить";
            this.updateDataButton.UseVisualStyleBackColor = true;
            this.updateDataButton.Click += new System.EventHandler(this.updateDataButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(12, 141);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(118, 23);
            this.refreshButton.TabIndex = 11;
            this.refreshButton.Text = "Внести изменения";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // EditingAdditionalServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 176);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.updateDataButton);
            this.Controls.Add(this.eatTextBox);
            this.Controls.Add(this.intercityTelephoneTextBox);
            this.Controls.Add(this.telephoneTextBox);
            this.Controls.Add(this.clothesWashingTextBox);
            this.Controls.Add(this.minibarTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(286, 215);
            this.MinimumSize = new System.Drawing.Size(286, 215);
            this.Name = "EditingAdditionalServices";
            this.Text = "Работа с дополнительными услугами";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox minibarTextBox;
        private System.Windows.Forms.TextBox clothesWashingTextBox;
        private System.Windows.Forms.TextBox telephoneTextBox;
        private System.Windows.Forms.TextBox intercityTelephoneTextBox;
        private System.Windows.Forms.TextBox eatTextBox;
        private System.Windows.Forms.Button updateDataButton;
        private System.Windows.Forms.Button refreshButton;
    }
}