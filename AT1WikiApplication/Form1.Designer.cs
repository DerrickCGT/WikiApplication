﻿namespace AT1WikiApplication
{
    partial class Form1
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
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.dataStructureTextBox = new System.Windows.Forms.TextBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.definitionTextBox = new System.Windows.Forms.TextBox();
            this.linearButton = new System.Windows.Forms.RadioButton();
            this.nonLinearButton = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.listViewDisplay = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sortButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 16);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(63, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(105, 16);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(63, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(209, 16);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(63, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(28, 16);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(63, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(130, 16);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(63, 23);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // dataStructureTextBox
            // 
            this.dataStructureTextBox.Location = new System.Drawing.Point(160, 89);
            this.dataStructureTextBox.Name = "dataStructureTextBox";
            this.dataStructureTextBox.Size = new System.Drawing.Size(218, 20);
            this.dataStructureTextBox.TabIndex = 7;
            this.dataStructureTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataStructureTextBox_MouseDoubleClick);
            // 
            // searchTextBox
            // 
            this.searchTextBox.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.searchTextBox.Location = new System.Drawing.Point(6, 48);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(205, 20);
            this.searchTextBox.TabIndex = 8;
            this.searchTextBox.Text = "Search Structure Name";
            this.searchTextBox.Click += new System.EventHandler(this.searchTextBox_Click);
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            this.searchTextBox.Leave += new System.EventHandler(this.searchTextBox_Leave);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(130, 19);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(63, 23);
            this.searchButton.TabIndex = 9;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Data Structure Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Category:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Structure:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Definition:";
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(160, 123);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(218, 20);
            this.categoryTextBox.TabIndex = 14;
            // 
            // definitionTextBox
            // 
            this.definitionTextBox.Location = new System.Drawing.Point(44, 203);
            this.definitionTextBox.Multiline = true;
            this.definitionTextBox.Name = "definitionTextBox";
            this.definitionTextBox.Size = new System.Drawing.Size(334, 214);
            this.definitionTextBox.TabIndex = 16;
            // 
            // linearButton
            // 
            this.linearButton.AutoSize = true;
            this.linearButton.Location = new System.Drawing.Point(160, 155);
            this.linearButton.Name = "linearButton";
            this.linearButton.Size = new System.Drawing.Size(54, 17);
            this.linearButton.TabIndex = 17;
            this.linearButton.TabStop = true;
            this.linearButton.Text = "Linear";
            this.linearButton.UseVisualStyleBackColor = true;
            // 
            // nonLinearButton
            // 
            this.nonLinearButton.AutoSize = true;
            this.nonLinearButton.Location = new System.Drawing.Point(241, 153);
            this.nonLinearButton.Name = "nonLinearButton";
            this.nonLinearButton.Size = new System.Drawing.Size(77, 17);
            this.nonLinearButton.TabIndex = 18;
            this.nonLinearButton.TabStop = true;
            this.nonLinearButton.Text = "Non-Linear";
            this.nonLinearButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 436);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(655, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // listViewDisplay
            // 
            this.listViewDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewDisplay.HideSelection = false;
            this.listViewDisplay.Location = new System.Drawing.Point(408, 166);
            this.listViewDisplay.Name = "listViewDisplay";
            this.listViewDisplay.Size = new System.Drawing.Size(217, 251);
            this.listViewDisplay.TabIndex = 20;
            this.listViewDisplay.UseCompatibleStateImageBehavior = false;
            this.listViewDisplay.View = System.Windows.Forms.View.Details;
            this.listViewDisplay.SelectedIndexChanged += new System.EventHandler(this.listViewDisplay_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category";
            this.columnHeader2.Width = 92;
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(28, 19);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(63, 23);
            this.sortButton.TabIndex = 21;
            this.sortButton.Text = "Sort";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.loadButton);
            this.groupBox1.Location = new System.Drawing.Point(402, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 45);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.searchTextBox);
            this.groupBox2.Controls.Add(this.searchButton);
            this.groupBox2.Controls.Add(this.sortButton);
            this.groupBox2.Location = new System.Drawing.Point(402, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 71);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.addButton);
            this.groupBox3.Controls.Add(this.editButton);
            this.groupBox3.Controls.Add(this.deleteButton);
            this.groupBox3.Location = new System.Drawing.Point(46, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 45);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Action";
            // 
            // statusLabel1
            // 
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 458);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewDisplay);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.nonLinearButton);
            this.Controls.Add(this.linearButton);
            this.Controls.Add(this.definitionTextBox);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataStructureTextBox);
            this.Name = "Form1";
            this.Text = "Wiki Application";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TextBox dataStructureTextBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.TextBox definitionTextBox;
        private System.Windows.Forms.RadioButton linearButton;
        private System.Windows.Forms.RadioButton nonLinearButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView listViewDisplay;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
    }
}

