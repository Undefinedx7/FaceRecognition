
namespace FaceRecognition
{
    partial class FacialRecognitionForm
    {
    
        private System.ComponentModel.IContainer components = null;


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
            this.capturePictureBox = new System.Windows.Forms.PictureBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.detectButton = new System.Windows.Forms.Button();
            this.addPersonButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.trainButton = new System.Windows.Forms.Button();
            this.facePictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.capturePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // capturePictureBox
            // 
            this.capturePictureBox.Location = new System.Drawing.Point(12, 12);
            this.capturePictureBox.Name = "capturePictureBox";
            this.capturePictureBox.Size = new System.Drawing.Size(598, 426);
            this.capturePictureBox.TabIndex = 0;
            this.capturePictureBox.TabStop = false;
            // 
            // captureButton
            // 
            this.captureButton.Location = new System.Drawing.Point(616, 13);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(132, 23);
            this.captureButton.TabIndex = 1;
            this.captureButton.Text = "Capturer";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // detectButton
            // 
            this.detectButton.Location = new System.Drawing.Point(616, 51);
            this.detectButton.Name = "detectButton";
            this.detectButton.Size = new System.Drawing.Size(132, 25);
            this.detectButton.TabIndex = 2;
            this.detectButton.Text = "Detection du visage";
            this.detectButton.UseVisualStyleBackColor = true;
            this.detectButton.Click += new System.EventHandler(this.detectButton_Click);
            // 
            // addPersonButton
            // 
            this.addPersonButton.Location = new System.Drawing.Point(617, 332);
            this.addPersonButton.Name = "addPersonButton";
            this.addPersonButton.Size = new System.Drawing.Size(132, 25);
            this.addPersonButton.TabIndex = 3;
            this.addPersonButton.Text = "Ajouter une personne";
            this.addPersonButton.UseVisualStyleBackColor = true;
            this.addPersonButton.Click += new System.EventHandler(this.addPersonButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(619, 306);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(129, 20);
            this.nameTextBox.TabIndex = 4;
            // 
            // trainButton
            // 
            this.trainButton.Location = new System.Drawing.Point(617, 373);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(132, 26);
            this.trainButton.TabIndex = 5;
            this.trainButton.Text = "entrainer";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // facePictureBox
            // 
            this.facePictureBox.Location = new System.Drawing.Point(617, 106);
            this.facePictureBox.Name = "facePictureBox";
            this.facePictureBox.Size = new System.Drawing.Size(131, 156);
            this.facePictureBox.TabIndex = 7;
            this.facePictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(776, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(776, 230);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(127, 142);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(617, 271);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(128, 22);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Enregistrer";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FacialRecognitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.facePictureBox);
            this.Controls.Add(this.trainButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.addPersonButton);
            this.Controls.Add(this.detectButton);
            this.Controls.Add(this.captureButton);
            this.Controls.Add(this.capturePictureBox);
            this.Name = "FacialRecognitionForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.capturePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox capturePictureBox;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.Button detectButton;
        private System.Windows.Forms.Button addPersonButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.PictureBox facePictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button saveButton;
    }
}

