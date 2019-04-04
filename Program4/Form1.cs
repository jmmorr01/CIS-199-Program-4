// By: Joseph Morrison, Grading ID C9865
// Program 4
// Due: April 25th, 2017
// Section 75
// Description: This program allows you to enter information in about a package and it will calculate the cost of shipping the package based on the information entered.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program4
{
    public partial class Form1 : Form
    {
        List<GroundPackage> packageList = new List<GroundPackage>();
        const int uoflZipCode = 40292; // Zip Code for UofL

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int originZip; // Origin Zip
            int destinationZip; // Destination Zip
            double length; // Length of package
            double width; // Width of package
            double height; // Height of package
            double weight; // Weight of package
            double cost; // Cost of package

            if (int.TryParse(originZipInput.Text, out originZip) && (int.TryParse(destZipInput.Text, out destinationZip)))// Parses Origin Zip and Destination Zip.
            {

                if (double.TryParse(lengthInput.Text, out length) && (double.TryParse(widthInput.Text, out width)) && (double.TryParse(heightInput.Text, out height)) && (double.TryParse(weightInput.Text, out weight)))// Parses Length, width, height, and weight.
                {

                    GroundPackage package = new GroundPackage(originZip, destinationZip, length, width, height, weight); // Creates a Package object

                    cost = package.CalcCost(); // Calculates Cost of the package 

                    packageList.Add(package); // adds the package to the list

                    packagesList.Items.Add(cost.ToString("c")); // adds the cost of the package to the list.
                }
                else
                {
                    MessageBox.Show("Enter valid package dimensions"); // Package dimensions are invalid
                }
                
            }
            else
            {
                MessageBox.Show("Enter valid zip"); // zip is invalid.
            }
        }

        private void sendToButton_Click(object sender, EventArgs e)
        {
            int index = packagesList.SelectedIndex;
            // Precondition: An item is selected on the List Box.
            // Postcondition: Sets the destination zip code of selected package to zip code of UofL.
            if (index <= -1)
                MessageBox.Show("select a valid package");
            else
            {
                packageList[index].DestinationZip = uoflZipCode; // Sets the package zip code to 40292
                packagesList.Items[index] = packageList[index].CalcCost().ToString("C"); // Recalculates the cost of the package.
                MessageBox.Show("Package has been reset");
            }
        }

        private void sendFromButton_Click(object sender, EventArgs e)
        {
            int index = packagesList.SelectedIndex;
            // Precondition: An item is selected on the List Box.
            // Postcondition: sets the origin zip code of the package to the zip code of UofL.
            if (index <= -1)
                MessageBox.Show("select a valid package");
            else
            {
                packageList[index].OriginZip = uoflZipCode; // Sets the package origin zip code to 40292.
                packagesList.Items[index] = packageList[index].CalcCost().ToString("C"); // Recalculates the cost of the package.
                MessageBox.Show("Package has been reset");
            }
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            int index = packagesList.SelectedIndex; // Index of the selected item
            // Precondition: An item is selected on the list box
            // Postcondition: The details of the item appear in a messagebox.
            if (index <= -1)
            {
                MessageBox.Show("select a valid package");
            }
            else
            {
                MessageBox.Show(packageList[index].ToString());
            }
        }
    }
}
