using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PizzaApp {
    /// <summary>
    /// This program creates a window or dialog box that makes up the application's user interface
    /// </summary>
    /// <author>Sun Wook Kim</author>
    /// <student_id>n10370943</student_id>
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            //add sauce options to cmbSauce ComboBox
            cmbSauce.Items.AddRange(new string[] {"Tomato", "Barbeque"});
            //change DropDownStyle of cmbSauce to DropDownList
            cmbSauce.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        //Non event handler methods


        /// <summary>
        /// Gets the Text value of the selected radiobutton in a GroupBox
        /// </summary>
        /// <param name="grb">The name of the GroupBox</param>
        /// <returns>The Text value of the selected radiobutton</returns>
        private string GetSelectedRadioButtonName(GroupBox grb) {
            string radioButtonName = grb.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text;
            //recalculates total cost when user changes the option
            CostCounter();
            return radioButtonName;
        }

        /// <summary>
        /// Counts the number of checkboxes selected in a GroupBox
        /// </summary>
        /// <param name="grb">The name of the GroupBox</param>
        /// <returns>The number of selected checkboxes</returns>
        private int CountChkBox(GroupBox grb) {
            int checkedBoxes = 0;
            //loop to iterate through all topping options in grpTopping
            foreach (Control c in grpTopping.Controls) {
                if (c is CheckBox cb && cb.Checked) {
                    checkedBoxes++;
                }
            }

            return checkedBoxes;

        }

        /// <summary>
        /// Calculates the total cost of the pizza
        /// </summary>
        /// <returns>Total cost of the pizza</returns>
        private int CostCounter() {
            int totalCost = 0;
            const int GLUTEN_FREE_CRUST_PRICE = 2;

            string getRadioButton = grpCrust.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true)?.Text;
            if (getRadioButton == "Gluten free*") {
                totalCost += GLUTEN_FREE_CRUST_PRICE;
            }
            int numberOfChkBoxes = CountChkBox(grpTopping);
            if (numberOfChkBoxes > 4) {
                totalCost += numberOfChkBoxes - 4;
            }

            return totalCost + 10;
        }

        /// <summary>
        /// Reset all Controls in form including: Textbox, ComboBox, RadioButton, CheckBox
        /// </summary>
        private void ClearControl() {
            //clear order name TextBox
            txtOrderName.Clear();
            //clear sauce ComboBox
            cmbSauce.SelectedIndex = -1;
            //clear RadioButtons in crust GroupBox
            grpCrust.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Checked = false;
            //clear CheckBoxes in topping GroupBox, iterating through with a loop
            foreach (Control ctrl in grpTopping.Controls) {
                if (ctrl is CheckBox) {
                    CheckBox cb = (CheckBox)ctrl;
                    cb.Checked = false;
                }
            }
        }


        //Event handler methods


        private void txtOrderName_TextChanged(object sender, EventArgs e) {
            //enable ComboBox for sauce if Text value for Textbox is not an empty string
            cmbSauce.Enabled = txtOrderName.Text != "";
        }

        private void cmbSauce_SelectedIndexChanged(object sender, EventArgs e) {
            //enable grpCrust GroupBox and its components if ComboBox has a selected value
            grpCrust.Enabled = cmbSauce.SelectedItem != null;
        }

        private void grpCrust_CheckedChanged(object sender, EventArgs e) {
            //use LINQ to iterate through each RadioButton in grpCrust GroupBox and check whether it is checked or not
            bool isAnyRadioButtonChecked = grpCrust.Controls.OfType<RadioButton>().Any(rdo => rdo.Checked);
            //enable grpTopping GroupBox and its components if a RadioButton is selected in grpCrust
            grpTopping.Enabled = isAnyRadioButtonChecked;
        }

        private void chkToppingAlmonds_CheckedChanged(object sender, EventArgs e) {
            CheckBox chkBox = (CheckBox) sender;
            //enable btnOrder if at least 1 CheckBox is selected in grpTopping
            if (chkBox.Enabled) {
                btnOrder.Enabled = true;
            }
            //recalculate total cost of pizza when a CheckBox is selected or deselected
            CostCounter();
        }

        private void btnOrder_Click(object sender, EventArgs e) {
            //display a dialog box, which presents a message to the user. It is a modal window, blocking other actions in the application until the user closes it.
            //display inputted order name, crust, sauce, topping and total cost to user.
            DialogResult result = MessageBox.Show(string.Format(
                    "Thank you for the order, {0}.\n 1 {1} pizza base with {2} sauce and {3} toppings. \n\n Your order comes to ${4}",
                    txtOrderName.Text,
                    GetSelectedRadioButtonName(grpCrust),
                    cmbSauce.SelectedItem,
                    CountChkBox(grpTopping),
                    CostCounter()),
                "Order Complete");
            //disable order button after it is pressed
            btnOrder.Enabled = false;

            //reset window form once OK is pressed in dialog box
            if (result == DialogResult.OK) {
                ClearControl();
                }
        }
    }
}