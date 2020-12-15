
namespace WindowsFormsApp1
{
    partial class ViewingApartmentsPhotos
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
            this.previousImageButton = new System.Windows.Forms.Button();
            this.deleteImageButton = new System.Windows.Forms.Button();
            this.addImageButton = new System.Windows.Forms.Button();
            this.nextImageButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // previousImageButton
            // 
            this.previousImageButton.Location = new System.Drawing.Point(13, 415);
            this.previousImageButton.Name = "previousImageButton";
            this.previousImageButton.Size = new System.Drawing.Size(185, 23);
            this.previousImageButton.TabIndex = 0;
            this.previousImageButton.Text = "Предыдущая";
            this.previousImageButton.UseVisualStyleBackColor = true;
            this.previousImageButton.Click += new System.EventHandler(this.previousImageButton_Click);
            // 
            // deleteImageButton
            // 
            this.deleteImageButton.Location = new System.Drawing.Point(204, 415);
            this.deleteImageButton.Name = "deleteImageButton";
            this.deleteImageButton.Size = new System.Drawing.Size(192, 23);
            this.deleteImageButton.TabIndex = 1;
            this.deleteImageButton.Text = "Удалить";
            this.deleteImageButton.UseVisualStyleBackColor = true;
            this.deleteImageButton.Click += new System.EventHandler(this.deleteImageButton_Click);
            // 
            // addImageButton
            // 
            this.addImageButton.Location = new System.Drawing.Point(402, 415);
            this.addImageButton.Name = "addImageButton";
            this.addImageButton.Size = new System.Drawing.Size(201, 23);
            this.addImageButton.TabIndex = 2;
            this.addImageButton.Text = "Добавить";
            this.addImageButton.UseVisualStyleBackColor = true;
            this.addImageButton.Click += new System.EventHandler(this.addImageButton_Click);
            // 
            // nextImageButton
            // 
            this.nextImageButton.Location = new System.Drawing.Point(609, 415);
            this.nextImageButton.Name = "nextImageButton";
            this.nextImageButton.Size = new System.Drawing.Size(179, 23);
            this.nextImageButton.TabIndex = 3;
            this.nextImageButton.Text = "Следующая";
            this.nextImageButton.UseVisualStyleBackColor = true;
            this.nextImageButton.Click += new System.EventHandler(this.nextImageButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(775, 396);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ViewingApartmentsPhotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.nextImageButton);
            this.Controls.Add(this.addImageButton);
            this.Controls.Add(this.deleteImageButton);
            this.Controls.Add(this.previousImageButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "ViewingApartmentsPhotos";
            this.Text = "Просмотр фотографий";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button previousImageButton;
        private System.Windows.Forms.Button deleteImageButton;
        private System.Windows.Forms.Button addImageButton;
        private System.Windows.Forms.Button nextImageButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}