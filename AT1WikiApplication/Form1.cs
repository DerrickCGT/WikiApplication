﻿using System;
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
// Student ID: 30066568
// Application: Wiki form to provide data structure definitions and categories.
// Final Version

namespace AT1WikiApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Define the size of two dimensional string array: WikiTable of 12 rows and 4 columns
        //9.1	Create a global 2D string array, use static variables for the
        //dimensions (row = 4, column = 12),
        static int row = 12;
        static int col = 4;
        private string[,] WikiTable = new string[row, col];
        //Reference pointer to current row index
        int rowRef = 0;

        #region "Display Method"
        //Method to display data in Listview
        //9.8	Create a display method that will show the following information
        //in a ListView: Name and Category,
        private void displayListView()
        {
            listViewDisplay.Items.Clear();

            for (int x = 0; x < row; x++)
            {
                ListViewItem lvi = new ListViewItem(WikiTable[x, 0]);
                lvi.SubItems.Add(WikiTable[x, 1]);

                listViewDisplay.Items.Add(lvi);
            }

        }

        //Method to clear data in all textboxes and radiobuttons
        //9.5	Create a CLEAR method to clear the four text boxes so a new definition can be added,
        private void clearDisplay()
        {
            dataStructureTextBox.Clear();
            categoryTextBox.Clear();
            linearButton.Checked = false;
            nonLinearButton.Checked = false;
            definitionTextBox.Clear();
            searchTextBox.Clear();
        }

        //Method to display all text in the textboxes and radiobutton when record index is selected
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

        //Method to clear status strip
        private void clearStatusStrip()
        {
            statusLabel1.Text = "";
            statusLabel1.BackColor = Color.White;
        }
        #endregion 

        #region "Sort"
        //Bubble sort algorithm to sort WikiTable by name ascending
        //9.6	Write the code for a Bubble Sort method to sort the 2D array by Name ascending,
        //ensure you use a separate swap method that passes the array element to be swapped
        //(do not use any built-in array methods)
        private void sortButton_Click(object sender, EventArgs e)
        {
            clearStatusStrip();
            bubbleSort();
            displayListView();
            statusLabel1.Text = "Data Sorted";
            statusLabel1.BackColor = Color.Green;
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

        //Method to swap row i and j to perform bubble sort
        private void swap(int i, int j)
        {

            for (int k = 0; k < col; k++)
            {
                string temp = WikiTable[i, k];
                WikiTable[i, k] = WikiTable[j, k];
                WikiTable[j, k] = temp;

            }
        }

        //Method to compare and sort null or empty row, ensure NullorEmpty row sorted to bottom
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
                return string.CompareOrdinal(a.ToLower(), b.ToLower());
            }
        }
        #endregion

        #region "Add Button"
        //Add record to WikiTable
        //9.2	Create an ADD button that will store the information from the 4 text boxes into the 2D array,
        private void addButton_Click(object sender, EventArgs e)
        {
            clearStatusStrip();
            //If the WikiTable is full with rowRef as row indexes < 12
            try
            {
                //If an input is given
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
                bubbleSort();
                displayListView();
                clearDisplay();
                statusLabel1.Text = "Record Added";
                statusLabel1.BackColor = Color.Green;
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry! WikiTable is full and no new data added.");
                statusLabel1.Text = "Error! Record Full";
                statusLabel1.BackColor = Color.Red;
            }

        }
        #endregion

        #region "Edit Button"
        //Modifies a record with user input
        //9.3	Create an EDIT button that will allow the user to modify
        //any information from the 4 text boxes into the 2D array,
        private void editButton_Click(object sender, EventArgs e)
        {
            clearStatusStrip();
            //Event based trigger and ensure the selected indices is always more than 0
            //ensure the selected indices will not turn to null for second click
            if (listViewDisplay.SelectedIndices.Count > 0)
            {
                int selectedIndex = listViewDisplay.SelectedIndices[0];
                var confirmResult = MessageBox.Show("Do you want to edit this record?", "Confirmation of Edit", MessageBoxButtons.YesNo);

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
                    bubbleSort();
                    displayListView();
                    statusLabel1.Text = "Record Edited";
                    statusLabel1.BackColor = Color.Green;
                }
            }
        }
        #endregion

        #region "Delete Button"
        //Delete selected record from WikiTable
        //9.4	Create a DELETE button that removes all the information from
        //a single entry of the array; the user must be prompted before the final deletion occurs, 
        private void deleteButton_Click(object sender, EventArgs e)
        {
            clearStatusStrip();
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
                bubbleSort();
                displayListView();
                statusLabel1.Text = "Record Deleted";
                statusLabel1.BackColor = Color.Green;
            }
        }
        #endregion

        #region "Save File"
        //Save all records to binary file
        //9.10	Create a SAVE button so the information from the 2D array
        //can be written into a binary file called definitions.dat which
        //is sorted by Name, ensure the user has the option to select an
        //alternative file. Use a file stream and BinaryWriter to create the file.
        private void saveButton_Click(object sender, EventArgs e)
        {
            clearStatusStrip();
            SaveFileDialog savefile = new SaveFileDialog();
            //savefile.InitialDirectory = "C:\\temp\\";
            savefile.Filter = "Binary File (*.bin)|*.bin";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string fileName = savefile.FileName;
                using (BinaryWriter bw = new BinaryWriter(new FileStream(fileName, FileMode.Append)))
                {

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
                    statusLabel1.Text = "File Saved";
                    statusLabel1.BackColor = Color.Green;
                }
            }
        }
        #endregion

        #region "Load File"
        //Load file to add all records to WikiTable
        //9.11	Create a LOAD button that will read the information from
        //a binary file called definitions.dat into the 2D array, ensure
        //the user has the option to select an alternative file. Use a file
        //stream and BinaryReader to complete this task.
        private void loadButton_Click(object sender, EventArgs e)
        {
            clearStatusStrip();
            //Renew rowRef as new file is initiated and empty WikiTable
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
                //openFile.InitialDirectory = "C:\\temp\\";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string openFileName = openFile.FileName;
                    BinaryReader br = new BinaryReader(new FileStream(openFileName, FileMode.Open));



                    for (int i = 0; i < row; i++)
                    {
                        //If WikiTable is full, rowRef less than 12
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
                    statusLabel1.Text = "File Loaded";
                    statusLabel1.BackColor = Color.Green;
                    br.Close();
                    bubbleSort();
                    displayListView();
                }
            }
        }
        #endregion

        #region "Binary Search Button"
        //Searches for a given target name within the array using binary search algorithm
        //9.7	Write the code for a Binary Search for the Name in the 2D array and
        //display the information in the other textboxes when found, add suitable
        //feedback if the search in not successful and clear the search textbox
        //(do not use any built-in array methods)
        private void searchButton_Click(object sender, EventArgs e)
        {
            clearStatusStrip();
            //Upper and lower bound for binary search
            int low = 0;
            int high = rowRef - 1;
            int mid = 0;
            string target = searchTextBox.Text.ToLower();
            bool isFound = false;

            //Perform binary search
            if (!string.IsNullOrEmpty(searchTextBox.Text) && searchTextBox.Text != "Search Structure Name")
            {
                while (low <= high)
                {
                    mid = (high + low) / 2;

                    //Target found
                    if (target == WikiTable[mid, 0].ToLower())
                    {
                        isFound = true;
                        statusLabel1.Text = "Record Found";
                        statusLabel1.BackColor = Color.Green;
                        break;
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
                if (isFound)
                {
                    listViewDisplay.Focus();
                    listViewDisplay.Items[mid].Selected = true;
                    focusTextBox(mid);
                    searchTextBox.Clear();
                    MessageBox.Show("\"" + WikiTable[mid, 0] + "\" is found.");
                }
                else
                {
                    MessageBox.Show("\"" + target + "\" is not found. Please try again!");
                    statusLabel1.Text = "Record Not Found";
                    statusLabel1.BackColor = Color.Red;
                    searchTextBox.Clear();
                }

            }
            else
            {
                MessageBox.Show("Null Input. Please try again!");
                statusLabel1.Text = "Error!";
                statusLabel1.BackColor = Color.Red;
                searchTextBox.Clear();
            }

        }
        #endregion

        #region "Utility Method"
        //Event based method
        //Clear all display when data structure text box is double mouse clicked
        private void dataStructureTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            clearDisplay();
            dataStructureTextBox.Focus();
            statusLabel1.Text = "Display Clear";
            statusLabel1.BackColor = Color.Green;
        }

        //Display data when a record is selected on ListView
        //9.9	Create a method so the user can select a definition (Name)
        //from the ListView and all the information is displayed in the appropriate Textboxes,
        private void listViewDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataStructureTextBox.Clear();
            categoryTextBox.Clear();
            linearButton.Checked = false;
            nonLinearButton.Checked = false;
            definitionTextBox.Clear();
            //ensure the selected indices will not turn to null for second click
            if (listViewDisplay.SelectedIndices.Count > 0)
            {
                int currentItem = listViewDisplay.SelectedIndices[0];

                focusTextBox(currentItem);
            }
        }

        //Set PlaceHolder text in searchTextBox
        //Clear the text in searchTextBox when user tries to input
        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "Search Structure Name")
            {
                searchTextBox.Text = "";
                searchTextBox.ForeColor = Color.Black;
            }
        }

        //Set PlaceHolder text in searchTextBox
        //Input PlaceHolder text searchTextBox when user exits
        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "")
            {
                searchTextBox.Text = "Search Structure Name";

                searchTextBox.ForeColor = Color.Silver;
            }
        }

        //Clear listview indices everytime search textbox is clicked
        private void searchTextBox_Click(object sender, EventArgs e)
        {
            listViewDisplay.SelectedIndices.Clear();
            searchTextBox.ForeColor = Color.Black;
        }
        #endregion
    }
}
