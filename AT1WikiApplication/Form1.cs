using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private int rowRef = 0;

        private void displayListView()
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

        private void clearDisplay()
        {
            dataStructureTextBox.Clear();
            categoryTextBox.Clear();
            linearButton.Checked = false;
            nonLinearButton.Checked = false;
            definitionTextBox.Clear();
            searchTextBox.Clear();  
        }
    

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(dataStructureTextBox.Text))
                {
                    WikiTable[rowRef, 0] = dataStructureTextBox.Text;
                    if (!string.IsNullOrEmpty(categoryTextBox.Text))
                    {
                        WikiTable[rowRef, 1] = categoryTextBox.Text;
                    }
                    if (linearButton.Checked)
                    {
                        WikiTable[rowRef, 2] = linearButton.Text;
                    }
                    if (nonLinearButton.Checked)
                    {
                        WikiTable[rowRef, 2] = nonLinearButton.Text;
                    }
                    if (!string.IsNullOrEmpty(definitionTextBox.Text))
                    {
                        WikiTable[rowRef, 3] = definitionTextBox.Text;
                    }
                    rowRef++;

                }
                displayListView();
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry! WikiTable is full and no new data added.");
            }
            
        }

        private void listViewDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linearButton_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "txt files (*.txt)|*.txt";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string fileName = savefile.FileName;
                using (BinaryWriter bw = new BinaryWriter(new FileStream(fileName, FileMode.Append)))
                {
                    // Writing the dimensions of the array to the file
                    bw.Write(WikiTable.GetLength(0));
                    bw.Write(WikiTable.GetLength(1));

                    // Writing the data of the array to the file
                    for (int i = 0; i < WikiTable.GetLength(0); i++)
                    {
                        for (int j = 0; j < WikiTable.GetLength(1); j++)
                        {
                            bw.Write(WikiTable[i, j]);
                        }
                    }
                };
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {


            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.InitialDirectory = "C:\\temp\\";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string openFileName = openFile.FileName;
                    BinaryReader br = new BinaryReader(new FileStream(openFileName, FileMode.Open));

                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            WikiTable[i, j] = br.ReadString();
                        }
                    }
                    br.Close();
                }
            }
        }


    }
}
