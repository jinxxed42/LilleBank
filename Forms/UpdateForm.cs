using LilleBank.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LilleBank
{
    /// <summary>
    /// Form for updating a Customers details.
    /// </summary>
    internal partial class UpdateForm : Form
    {
        private string _oldCpr { get; set; } // Used to store the Old CPR number of Customer being processed.
        private Bank _bank { get; set; } // Needed for reference to Bank object so we can call it's UpdateCustomer method.

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="customer">Customer to be updated.</param>
        /// <param name="bank">The Bank object.</param>
        public UpdateForm(Customer customer, Bank bank)
        {
            InitializeComponent();
            TbUpdateCustomerName.Text = customer.Name;
            TbUpdateCustomerCPR.Text = customer.CPR;
            TbUpdateCustomerAddress.Text = customer.Address;
            TbUpdateCustomerCity.Text = customer.City;
            _oldCpr = customer.CPR;
            _bank = bank;
        }

        /// <summary>
        /// Eventhandler for clicks on the Update button. Checks all fields for input, and if input is provided then
        /// calls the UpdateCustomer method of the Bank object to attempt updating the Customer. The user is informed
        /// of the result through a MessageBox. If successful the UpdateForm will close, otherwise it will remain open 
        /// for another attempt.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnUpdateCustomer_Click(object sender, EventArgs e)
        {
            string name = TbUpdateCustomerName.Text;
            string cpr = TbUpdateCustomerCPR.Text;
            string address = TbUpdateCustomerAddress.Text;
            string city = TbUpdateCustomerCity.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(cpr)
                || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("Please provide valid input in all textboxes.");
            }
            else
            {
                Result result = _bank.UpdateCustomer(_oldCpr, name, cpr, address, city);
                if (result.Success)
                {
                    MessageBox.Show($"Success.\n\n{result.Message}");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Failure.\n\n{result.Message}\n\nYou can try again.");
                }
            }
        }

        /// <summary>
        /// Eventhandler for clicks on the Cancel button. Closes this form.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
