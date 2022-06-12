namespace VKR
{
    partial class Form8
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
            this.KompetentComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NazvanieKompetentTextBox = new System.Windows.Forms.TextBox();
            this.OpisanieTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.InsertButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.GroupKompetentComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // KompetentComboBox
            // 
            this.KompetentComboBox.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KompetentComboBox.FormattingEnabled = true;
            this.KompetentComboBox.Items.AddRange(new object[] {
            "Знание основ документооборота",
            "Понимание принципов разроботки",
            "Умение доносить информацию",
            "Грамоная речь",
            "Знание алгоритмов",
            "Владение языком программирования"});
            this.KompetentComboBox.Location = new System.Drawing.Point(209, 10);
            this.KompetentComboBox.Name = "KompetentComboBox";
            this.KompetentComboBox.Size = new System.Drawing.Size(363, 40);
            this.KompetentComboBox.TabIndex = 0;
            this.KompetentComboBox.SelectedIndexChanged += new System.EventHandler(this.KompetentComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Компетенция";
            // 
            // NazvanieKompetentTextBox
            // 
            this.NazvanieKompetentTextBox.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NazvanieKompetentTextBox.Location = new System.Drawing.Point(19, 99);
            this.NazvanieKompetentTextBox.Multiline = true;
            this.NazvanieKompetentTextBox.Name = "NazvanieKompetentTextBox";
            this.NazvanieKompetentTextBox.Size = new System.Drawing.Size(546, 39);
            this.NazvanieKompetentTextBox.TabIndex = 2;
            // 
            // OpisanieTextBox
            // 
            this.OpisanieTextBox.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpisanieTextBox.Location = new System.Drawing.Point(19, 278);
            this.OpisanieTextBox.Multiline = true;
            this.OpisanieTextBox.Name = "OpisanieTextBox";
            this.OpisanieTextBox.Size = new System.Drawing.Size(546, 197);
            this.OpisanieTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(20, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "Название";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(20, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = "Описание";
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.SystemColors.Info;
            this.UpdateButton.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateButton.Location = new System.Drawing.Point(630, 120);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(340, 74);
            this.UpdateButton.TabIndex = 6;
            this.UpdateButton.Text = "Изменить";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // InsertButton
            // 
            this.InsertButton.BackColor = System.Drawing.SystemColors.Info;
            this.InsertButton.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InsertButton.Location = new System.Drawing.Point(630, 10);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(340, 74);
            this.InsertButton.TabIndex = 7;
            this.InsertButton.Text = "Добавить";
            this.InsertButton.UseVisualStyleBackColor = false;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.SystemColors.Info;
            this.DeleteButton.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteButton.Location = new System.Drawing.Point(630, 226);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(340, 74);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.SystemColors.Info;
            this.RefreshButton.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshButton.Location = new System.Drawing.Point(810, 367);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(160, 74);
            this.RefreshButton.TabIndex = 9;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.Info;
            this.BackButton.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.Location = new System.Drawing.Point(630, 367);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(160, 74);
            this.BackButton.TabIndex = 10;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(20, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 35);
            this.label4.TabIndex = 11;
            this.label4.Text = "Группа компетенций";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // GroupKompetentComboBox
            // 
            this.GroupKompetentComboBox.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupKompetentComboBox.FormattingEnabled = true;
            this.GroupKompetentComboBox.Items.AddRange(new object[] {
            "Знание основ документооборота",
            "Понимание принципов разроботки",
            "Умение доносить информацию",
            "Грамоная речь",
            "Знание алгоритмов",
            "Владение языком программирования"});
            this.GroupKompetentComboBox.Location = new System.Drawing.Point(26, 179);
            this.GroupKompetentComboBox.Name = "GroupKompetentComboBox";
            this.GroupKompetentComboBox.Size = new System.Drawing.Size(539, 40);
            this.GroupKompetentComboBox.TabIndex = 12;
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 487);
            this.Controls.Add(this.GroupKompetentComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OpisanieTextBox);
            this.Controls.Add(this.NazvanieKompetentTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KompetentComboBox);
            this.Name = "Form8";
            this.Text = "Изменение списка компетенций";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox KompetentComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NazvanieKompetentTextBox;
        private System.Windows.Forms.TextBox OpisanieTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox GroupKompetentComboBox;
    }
}