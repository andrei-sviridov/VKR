
namespace VKR
{
    partial class OtchetForm
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
            this.SotrudnikiDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtchotDataGridView = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtchotButton = new System.Windows.Forms.Button();
            this.PDFButton = new System.Windows.Forms.Button();
            this.ExcelButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SotrudnikiDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtchotDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SotrudnikiDataGridView
            // 
            this.SotrudnikiDataGridView.AllowUserToAddRows = false;
            this.SotrudnikiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SotrudnikiDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.SotrudnikiDataGridView.Location = new System.Drawing.Point(13, 13);
            this.SotrudnikiDataGridView.Name = "SotrudnikiDataGridView";
            this.SotrudnikiDataGridView.RowHeadersVisible = false;
            this.SotrudnikiDataGridView.RowHeadersWidth = 51;
            this.SotrudnikiDataGridView.RowTemplate.Height = 24;
            this.SotrudnikiDataGridView.Size = new System.Drawing.Size(957, 99);
            this.SotrudnikiDataGridView.TabIndex = 0;
            this.SotrudnikiDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SotrudnikiDataGridView_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Выбрать";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Сотрудник";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Руководитель сотрудника";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // OtchotDataGridView
            // 
            this.OtchotDataGridView.AllowUserToAddRows = false;
            this.OtchotDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OtchotDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.OtchotDataGridView.Location = new System.Drawing.Point(13, 182);
            this.OtchotDataGridView.Name = "OtchotDataGridView";
            this.OtchotDataGridView.RowHeadersVisible = false;
            this.OtchotDataGridView.RowHeadersWidth = 51;
            this.OtchotDataGridView.RowTemplate.Height = 24;
            this.OtchotDataGridView.Size = new System.Drawing.Size(957, 451);
            this.OtchotDataGridView.TabIndex = 1;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Сотрудник";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Поступившие";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Выполненные";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "В работе";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Возвращённые";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 125;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "В срок";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 125;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Не в срок";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 125;
            // 
            // OtchotButton
            // 
            this.OtchotButton.BackColor = System.Drawing.SystemColors.Info;
            this.OtchotButton.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.OtchotButton.Location = new System.Drawing.Point(13, 130);
            this.OtchotButton.Name = "OtchotButton";
            this.OtchotButton.Size = new System.Drawing.Size(300, 46);
            this.OtchotButton.TabIndex = 2;
            this.OtchotButton.Text = "Сформировать";
            this.OtchotButton.UseVisualStyleBackColor = false;
            this.OtchotButton.Click += new System.EventHandler(this.OtchotButton_Click);
            // 
            // PDFButton
            // 
            this.PDFButton.BackColor = System.Drawing.SystemColors.Info;
            this.PDFButton.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.PDFButton.Location = new System.Drawing.Point(664, 130);
            this.PDFButton.Name = "PDFButton";
            this.PDFButton.Size = new System.Drawing.Size(150, 46);
            this.PDFButton.TabIndex = 3;
            this.PDFButton.Text = "В PDF";
            this.PDFButton.UseVisualStyleBackColor = false;
            this.PDFButton.Click += new System.EventHandler(this.PDFButton_Click);
            // 
            // ExcelButton
            // 
            this.ExcelButton.BackColor = System.Drawing.SystemColors.Info;
            this.ExcelButton.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.ExcelButton.Location = new System.Drawing.Point(820, 130);
            this.ExcelButton.Name = "ExcelButton";
            this.ExcelButton.Size = new System.Drawing.Size(150, 46);
            this.ExcelButton.TabIndex = 4;
            this.ExcelButton.Text = "В Excel";
            this.ExcelButton.UseVisualStyleBackColor = false;
            this.ExcelButton.Click += new System.EventHandler(this.ExcelButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(319, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 46);
            this.button1.TabIndex = 5;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OtchetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 645);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExcelButton);
            this.Controls.Add(this.PDFButton);
            this.Controls.Add(this.OtchotButton);
            this.Controls.Add(this.OtchotDataGridView);
            this.Controls.Add(this.SotrudnikiDataGridView);
            this.Name = "OtchetForm";
            this.Text = "OtchetForm";
            ((System.ComponentModel.ISupportInitialize)(this.SotrudnikiDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtchotDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SotrudnikiDataGridView;
        private System.Windows.Forms.DataGridView OtchotDataGridView;
        private System.Windows.Forms.Button OtchotButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Button PDFButton;
        private System.Windows.Forms.Button ExcelButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}