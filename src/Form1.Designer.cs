using System.Windows.Forms;
using System.Drawing;

namespace tubes3stima
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(63, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(274, 327);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(521, 67);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(274, 327);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(164, 489);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 2;
            label1.Text = "PicBox1";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(640, 489);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 3;
            label2.Text = "PicBox2";
            // 
            // button1
            // 
            button1.Location = new Point(143, 429);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Pilih Citra!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(629, 429);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = "Search!";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkBox1
            // 
            checkBox1.Appearance = Appearance.Button;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(367, 429);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(138, 30);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Metode Pencarian";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(996, 439);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 7;
            label3.Text = "Search Time: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(996, 489);
            label4.Name = "label4";
            label4.Size = new Size(134, 20);
            label4.TabIndex = 8;
            label4.Text = "Match Percentage: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(367, 9);
            label5.Name = "label5";
            label5.Size = new Size(527, 46);
            label5.TabIndex = 9;
            label5.Text = "Finger Print Detection App Kel. 57";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(987, 87);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 10;
            label6.Text = "Nama:\r\nTempat Lahir:\r\nTanggal Lahir:\r\nJenis Kelamin:\r\nGol. Darah:\r\nAlamat:\r\nAgama:\r\nStatus Kawin:\r\nPekerjaan:\r\nKewarganegaraan:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1301, 617);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
