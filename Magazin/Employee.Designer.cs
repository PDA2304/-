namespace Magazin
{
    partial class Employee
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.text4 = new System.Windows.Forms.Label();
            this.text3 = new System.Windows.Forms.Label();
            this.test2 = new System.Windows.Forms.Label();
            this.text1 = new System.Windows.Forms.Label();
            this.Passwrod = new System.Windows.Forms.Label();
            this.Dolgnost = new System.Windows.Forms.ComboBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.TextBox();
            this.Last_name = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.TextBox();
            this.Middle_name = new System.Windows.Forms.TextBox();
            this.text = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 231);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1065, 436);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.77419F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.22581F));
            this.tableLayoutPanel1.Controls.Add(this.text4, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.text3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.test2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.text1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Passwrod, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Dolgnost, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Password, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.login, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Last_name, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Name, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Middle_name, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.text, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(372, 213);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // text4
            // 
            this.text4.AutoSize = true;
            this.text4.Location = new System.Drawing.Point(269, 175);
            this.text4.Name = "text4";
            this.text4.Size = new System.Drawing.Size(81, 17);
            this.text4.TabIndex = 12;
            this.text4.Text = "Должность";
            // 
            // text3
            // 
            this.text3.AutoSize = true;
            this.text3.Location = new System.Drawing.Point(269, 140);
            this.text3.Name = "text3";
            this.text3.Size = new System.Drawing.Size(71, 17);
            this.text3.TabIndex = 11;
            this.text3.Text = "Отчество";
            // 
            // test2
            // 
            this.test2.AutoSize = true;
            this.test2.Location = new System.Drawing.Point(269, 105);
            this.test2.Name = "test2";
            this.test2.Size = new System.Drawing.Size(35, 17);
            this.test2.TabIndex = 10;
            this.test2.Text = "Имя";
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.Location = new System.Drawing.Point(269, 70);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(70, 17);
            this.text1.TabIndex = 9;
            this.text1.Text = "Фамилия";
            // 
            // Passwrod
            // 
            this.Passwrod.AutoSize = true;
            this.Passwrod.Location = new System.Drawing.Point(269, 35);
            this.Passwrod.Name = "Passwrod";
            this.Passwrod.Size = new System.Drawing.Size(57, 17);
            this.Passwrod.TabIndex = 8;
            this.Passwrod.Text = "Пароль";
            // 
            // Dolgnost
            // 
            this.Dolgnost.FormattingEnabled = true;
            this.Dolgnost.Location = new System.Drawing.Point(3, 178);
            this.Dolgnost.Name = "Dolgnost";
            this.Dolgnost.Size = new System.Drawing.Size(260, 24);
            this.Dolgnost.TabIndex = 2;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(3, 38);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(260, 22);
            this.Password.TabIndex = 4;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(3, 3);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(260, 22);
            this.login.TabIndex = 2;
            // 
            // Last_name
            // 
            this.Last_name.Location = new System.Drawing.Point(3, 73);
            this.Last_name.Name = "Last_name";
            this.Last_name.Size = new System.Drawing.Size(260, 22);
            this.Last_name.TabIndex = 3;
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(3, 108);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(260, 22);
            this.Name.TabIndex = 5;
            // 
            // Middle_name
            // 
            this.Middle_name.Location = new System.Drawing.Point(3, 143);
            this.Middle_name.Name = "Middle_name";
            this.Middle_name.Size = new System.Drawing.Size(260, 22);
            this.Middle_name.TabIndex = 6;
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Location = new System.Drawing.Point(269, 0);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(42, 17);
            this.text.TabIndex = 7;
            this.text.Text = "Лоин";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(385, 13);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(122, 23);
            this.Add.TabIndex = 2;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(385, 84);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(122, 23);
            this.update.TabIndex = 3;
            this.update.Text = "Обновить ";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(385, 49);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(122, 23);
            this.delete.TabIndex = 4;
            this.delete.Text = "Удаление";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(385, 119);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(122, 23);
            this.clear.TabIndex = 5;
            this.clear.Text = "Очистить";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 679);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.update);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridView1);
            this.Text = "Employee";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Employee_FormClosed);
            this.Load += new System.EventHandler(this.Employee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label text4;
        private System.Windows.Forms.Label text3;
        private System.Windows.Forms.Label test2;
        private System.Windows.Forms.Label text1;
        private System.Windows.Forms.Label Passwrod;
        private System.Windows.Forms.ComboBox Dolgnost;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox Last_name;
        private System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.TextBox Middle_name;
        private System.Windows.Forms.Label text;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button clear;
    }
}