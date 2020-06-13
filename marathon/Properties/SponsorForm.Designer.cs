namespace marathon.Properties
{
    partial class SponsorForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SponsorForm));
            this.NameBox = new System.Windows.Forms.TextBox();
            this.CardBox = new System.Windows.Forms.MaskedTextBox();
            this.NomberCardBox = new System.Windows.Forms.MaskedTextBox();
            this.CVCBox = new System.Windows.Forms.MaskedTextBox();
            this.donateField = new System.Windows.Forms.MaskedTextBox();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.RunnerBox = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Charity = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dateCard = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Ltimer = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(149, 190);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(202, 20);
            this.NameBox.TabIndex = 0;
            // 
            // CardBox
            // 
            this.errorProvider1.SetIconAlignment(this.CardBox, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.CardBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.CardBox.Location = new System.Drawing.Point(149, 270);
            this.CardBox.Name = "CardBox";
            this.CardBox.Size = new System.Drawing.Size(202, 20);
            this.CardBox.TabIndex = 1;
            // 
            // NomberCardBox
            // 
            this.NomberCardBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.NomberCardBox.Location = new System.Drawing.Point(149, 311);
            this.NomberCardBox.Mask = "0000000000000000";
            this.NomberCardBox.Name = "NomberCardBox";
            this.NomberCardBox.Size = new System.Drawing.Size(106, 20);
            this.NomberCardBox.TabIndex = 2;
            this.NomberCardBox.ValidatingType = typeof(int);
            this.NomberCardBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NomberCardBox_KeyPress);
            this.NomberCardBox.Leave += new System.EventHandler(this.NomberCardBox_Leave);
            // 
            // CVCBox
            // 
            this.CVCBox.Location = new System.Drawing.Point(149, 393);
            this.CVCBox.Mask = "000";
            this.CVCBox.Name = "CVCBox";
            this.CVCBox.Size = new System.Drawing.Size(25, 20);
            this.CVCBox.TabIndex = 5;
            this.CVCBox.ValidatingType = typeof(int);
            this.CVCBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CVCBox_KeyPress);
            this.CVCBox.Leave += new System.EventHandler(this.CVCBox_Leave);
            // 
            // donateField
            // 
            this.donateField.Location = new System.Drawing.Point(520, 335);
            this.donateField.Name = "donateField";
            this.donateField.Size = new System.Drawing.Size(66, 20);
            this.donateField.TabIndex = 6;
            this.donateField.Text = "50";
            this.donateField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.donateField_KeyPress);
            // 
            // buttonPlus
            // 
            this.buttonPlus.Location = new System.Drawing.Point(465, 327);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(45, 35);
            this.buttonPlus.TabIndex = 7;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Location = new System.Drawing.Point(598, 327);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(45, 35);
            this.buttonMinus.TabIndex = 8;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(439, 372);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 35);
            this.button3.TabIndex = 9;
            this.button3.Text = "Заплатить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(570, 372);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 35);
            this.button4.TabIndex = 10;
            this.button4.Text = "Отмена";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // RunnerBox
            // 
            this.RunnerBox.FormattingEnabled = true;
            this.RunnerBox.Location = new System.Drawing.Point(149, 232);
            this.RunnerBox.Name = "RunnerBox";
            this.RunnerBox.Size = new System.Drawing.Size(202, 21);
            this.RunnerBox.TabIndex = 11;
            this.RunnerBox.Leave += new System.EventHandler(this.RunnerBox_Leave);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Назад";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 40);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(261, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "MARATHON SKILLS 2020";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(71, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ваше имя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(82, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Бегун:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(81, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Карта:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(46, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Номер карты#:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(36, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Срок действия:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(90, 394);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "CVC:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(299, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 24);
            this.label8.TabIndex = 20;
            this.label8.Text = "Спонсор бегуна";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(462, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 18);
            this.label9.TabIndex = 21;
            this.label9.Text = "Сумма пожертвования";
            // 
            // Charity
            // 
            this.Charity.AutoSize = true;
            this.Charity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Charity.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Charity.Location = new System.Drawing.Point(462, 153);
            this.Charity.Name = "Charity";
            this.Charity.Size = new System.Drawing.Size(181, 18);
            this.Charity.TabIndex = 22;
            this.Charity.Text = "Благотворительность";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(147, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(204, 18);
            this.label11.TabIndex = 23;
            this.label11.Text = "Информация о спонсоре";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(46, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(698, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "Пожалуйста выберите бегуна, которого вы хотели бы проспонсировать и сумму, котору" +
    "ю вы хотели бы спонсировать.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(156, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(445, 15);
            this.label13.TabIndex = 26;
            this.label13.Text = "Спасибо за вашу поддержку бегунов и их благотворительных учереждений!";
            // 
            // dateCard
            // 
            this.dateCard.Location = new System.Drawing.Point(149, 355);
            this.dateCard.Name = "dateCard";
            this.dateCard.Size = new System.Drawing.Size(127, 20);
            this.dateCard.TabIndex = 30;
            this.dateCard.Value = new System.DateTime(2020, 6, 10, 0, 0, 0, 0);
            this.dateCard.Leave += new System.EventHandler(this.dateCard_Leave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // errorProvider2
            // 
            this.errorProvider2.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider2.Icon")));
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(465, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.Ltimer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 446);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 40);
            this.panel2.TabIndex = 32;
            // 
            // Ltimer
            // 
            this.Ltimer.AutoSize = true;
            this.Ltimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ltimer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Ltimer.Location = new System.Drawing.Point(206, 15);
            this.Ltimer.Name = "Ltimer";
            this.Ltimer.Size = new System.Drawing.Size(158, 16);
            this.Ltimer.TabIndex = 0;
            this.Ltimer.Text = "Вы видите 25-й кадр";
            // 
            // SponsorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 486);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dateCard);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Charity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RunnerBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.donateField);
            this.Controls.Add(this.CVCBox);
            this.Controls.Add(this.NomberCardBox);
            this.Controls.Add(this.CardBox);
            this.Controls.Add(this.NameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SponsorForm";
            this.Text = "MARATHONE SKILLS 2020";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SponsorForm_FormClosed);
            this.Load += new System.EventHandler(this.SponsorForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.MaskedTextBox CardBox;
        private System.Windows.Forms.MaskedTextBox NomberCardBox;
        private System.Windows.Forms.MaskedTextBox CVCBox;
        private System.Windows.Forms.MaskedTextBox donateField;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox RunnerBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Charity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateCard;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Ltimer;
    }
}