using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Name: Derrick Choong
// Application: Wiki form to provide data structure definitions and categories.
// version 1.0.1
// Remarks: still struggling on add button and seem to have duplication

namespace AT1WikiApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int row = 12;
        static int col = 4;
        private string[,] WikiTable = new string[row, col];

        private void DisplayListView()
        {
            listViewDisplay.Items.Clear();
            for (int x = 0; x < row ; x++)
            {
                ListViewItem lvi = new ListViewItem(WikiTable[x, 0]);
                lvi.SubItems.Add(WikiTable[x, 1]);
                lvi.SubItems.Add(WikiTable[x, 2]);
                lvi.SubItems.Add(WikiTable[x, 3]);
                listViewDisplay.Items.Add(lvi);
            }
        }
    

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dataStructureTextBox.Text))
            {
                for (int x = 0; x < row; x++)
                {
                    if (WikiTable[x, 0] == null)
                    {
                        if (WikiTable[x, 0] != dataStructureTextBox.Text) // duplicate
                        {
                            WikiTable[x, 0] = dataStructureTextBox.Text;
                            if (!string.IsNullOrEmpty(categoryTextBox.Text))
                            {
                                WikiTable[x, 1] = categoryTextBox.Text;
                            }
                            if (linearButton.Checked)
                            {
                                WikiTable[x, 2] = linearButton.Text;
                            }
                            if (nonLinearButton.Checked)
                            {
                                WikiTable[x, 2] = nonLinearButton.Text;
                            }
                            if (!string.IsNullOrEmpty(definitionTextBox.Text))
                            {
                                WikiTable[x, 3] = definitionTextBox.Text;
                            }

                            break;
                        }
                    }
                        
                    
                }
            }
            DisplayListView();
        }

        private void listViewDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linearButton_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
