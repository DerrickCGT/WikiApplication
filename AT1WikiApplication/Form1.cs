using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
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
        int rowRef = 0;

        #region "Display ListView"
        private void displayListView()
        {
            listViewDisplay.Items.Clear();

            for (int x = 0; x < row; x++)
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
        #endregion 

        #region "Sort"
        private void sortButton_Click(object sender, EventArgs e)
        {
            bubbleSort();
            displayListView();
        }
        private void bubbleSort()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = i + 1; j < row; j++)
                {

                    if (compareSpecialString(WikiTable[i, 0], WikiTable[j, 0]) > 0)
                    {
                        swap(i, j);
                    }
                }
            }
        }

        private void swap(int i, int j)
        {

            for (int k = 0; k < col; k++)
            {
                string temp = WikiTable[i, k];
                WikiTable[i, k] = WikiTable[j, k];
                WikiTable[j, k] = temp;

            }
        }

        private int compareSpecialString(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
            {
                return 1;
            }
            else if (string.IsNullOrEmpty(b))
            {
                return -1;
            }
            else
            {
                return string.CompareOrdinal(a, b);
            }
        }
        #endregion

        #region "Add Button"
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
                clearDisplay();
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry! WikiTable is full and no new data added.");
            }

        }
        #endregion

        #region "Save File"
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = @"C:\\temp\\";
            savefile.Filter = "Binary File (*.bin)|*.bin";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string fileName = savefile.FileName;
                using (BinaryWriter bw = new BinaryWriter(new FileStream(fileName, FileMode.Append)))
                {
                    // Writing the dimensions of the array to the file
                    //bw.Write(WikiTable.GetLength(0));
                    //bw.Write(WikiTable.GetLength(1));

                    // Writing the data of the array to the file
                    for (int i = 0; i < rowRef; i++)
                    {

                        for (int j = 0; j < col; j++)
                        {

                            if (string.IsNullOrEmpty(WikiTable[i, j]))
                            {
                                bw.Write("");
                            }
                            else
                            {
                                bw.Write(WikiTable[i, j]);
                            }
                        }

                    }
                }
            }
        }
        #endregion

        #region "Load File"
        private void loadButton_Click(object sender, EventArgs e)
        {
            rowRef = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    WikiTable[i, j] = "";
                }
            }

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.InitialDirectory = @"C:\\temp\\";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string openFileName = openFile.FileName;
                    BinaryReader br = new BinaryReader(new FileStream(openFileName, FileMode.Open));



                    for (int i = 0; i < row; i++)
                    {
                        try
                        {
                            for (int j = 0; j < col; j++)
                            {
                                WikiTable[i, j] = br.ReadString();
                            }
                            rowRef++;
                        }
                        catch (Exception)
                        {
                            break;
                        }

                    }
                    br.Close();
                    displayListView();
                }
            }
        }
        #endregion

        #region "Edit Button"
        private void editButton_Click(object sender, EventArgs e)
        {
            if (listViewDisplay.SelectedIndices.Count > 0)
            {
                int selectedIndex = listViewDisplay.SelectedIndices[0];
                var confirmResult = MessageBox.Show("Do you want to edit this record?", "Confirm Edit!", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    if (selectedIndex > -1)
                    {

                        WikiTable[selectedIndex, 0] = dataStructureTextBox.Text;
                        WikiTable[selectedIndex, 1] = categoryTextBox.Text;
                        if (linearButton.Checked == true)
                        {
                            WikiTable[selectedIndex, 2] = linearButton.Text;
                        }
                        if (nonLinearButton.Checked == true)
                        {
                            WikiTable[selectedIndex, 2] = nonLinearButton.Text;
                        }
                        WikiTable[selectedIndex, 3] = definitionTextBox.Text;

                    }
                    displayListView();
                }
            }                        
        }
        #endregion

        #region "Delete Button"
        private void deleteButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = listViewDisplay.SelectedIndices[0];
            var confirmResult = MessageBox.Show("Do you want to edit this record?", "Confirm Edit!", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                if (selectedIndex > -1)
                {

                    WikiTable[selectedIndex, 0] = "";
                    WikiTable[selectedIndex, 1] = "";
                    WikiTable[selectedIndex, 2] = "";
                    WikiTable[selectedIndex, 3] = "";
                    rowRef--;

                }
                displayListView();
            }
        }
        #endregion

        #region "Binary Search Button"
        private void searchButton_Click(object sender, EventArgs e)
        {
            listViewDisplay.SelectedIndices.Clear();
            int low = 0;
            int high = row -1;
            int mid = 0;
            string target = searchTextBox.Text.ToLower();

            while (low <= high)
            {
                mid = (high + low) / 2;

                if (target == WikiTable[mid, 0].ToLower())
                {
                    listViewDisplay.Focus();
                    listViewDisplay.Items[mid].Selected = true;
                    focusTextBox(mid);
                    MessageBox.Show("\"" + searchTextBox.Text + "\" is found.");
                    return;                    
                }
                else if (string.CompareOrdinal(WikiTable[mid, 0].ToLower(), target) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            MessageBox.Show("\"" + target + "\" is not found. Please try again!");
            searchTextBox.Clear();

            //Linear Search
            //bool isFound = false;
            //string target = searchTextBox.Text.ToLower();

            //for (int i = 0; i < row; i++)
            //{
            //    if (target == WikiTable[i, 0].ToLower())
            //    {
            //listViewDisplay.Focus();
            //listViewDisplay.Items[i].Selected = true;
            //focusTextBox(i);
            //isFound = true;
            //MessageBox.Show("\"" + searchTextBox.Text + "\" is found.");
            //return;
            //    }
            //}
            //if (!isFound)
            //{
            //    MessageBox.Show("\""+ searchTextBox.Text + "\" is not found. Please try again!");     
            //}
        }
        #endregion

        #region "Common Method"
        private void focusTextBox(int indexI)
        {
            dataStructureTextBox.Text = WikiTable[indexI, 0];
            categoryTextBox.Text = WikiTable[indexI, 1];
            if (WikiTable[indexI, 2] == "Linear")
            {
                linearButton.Checked = true;
            }
            if (WikiTable[indexI, 2] == "Non-Linear")
            {
                nonLinearButton.Checked = true;
            }
            definitionTextBox.Text = WikiTable[indexI, 3];
        }


        #endregion

        #region "Event"
        private void dataStructureTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clearDisplay();
            dataStructureTextBox.Focus();
        }

        private void listViewDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearDisplay();
            if (listViewDisplay.SelectedIndices.Count > 0) //ensure the selected indices will not turn to null for second click
            {
                int currentItem = listViewDisplay.SelectedIndices[0];

                focusTextBox(currentItem);
            }
        }
        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "Search Structure Name")
            {
                searchTextBox.Text = "";

                searchTextBox.ForeColor = Color.Black;
            }
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "")
            {
                searchTextBox.Text = "Search Structure Name";

                searchTextBox.ForeColor = Color.Silver;
            }
        }
        #endregion
    }
}
