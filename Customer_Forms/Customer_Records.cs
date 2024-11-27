﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using Appointments_Scheduler.Customer_Forms;
using Appointments_Scheduler.Database_Table_Classes;
using Appointments_Scheduler.Forms.Customer_Records;

namespace Appointments_Scheduler.Forms.Customer_Forms
{
    public partial class Customer_Records : Form
    {
        public Customer_Records()
        {
            InitializeComponent();

            // Data Grid View settings
            dgv_Customers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Customers.ReadOnly = true;
            dgv_Customers.MultiSelect = false;

            // Gets all customers from the customer database table
            BindingList<Customer> allCustomers = Customer.GetAllCustomers();
            // Displays the Binding List of all customers on the Data Grid View
            dgv_Customers.DataSource = allCustomers;            
        }

        // Unselects the automatically selected first row on the Data Grid View
        private void OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Customers.ClearSelection();
        }

        // Handles the Add button click event
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Opens the Add_Customer form
            var addCustomer = new Add_Customer();
            addCustomer.Show();
        }

        // Handles the Edit Button click event
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dgv_Customers.SelectedRows.Count > 0)
            {
                // Gets the selected Data Grid View row
                DataGridViewRow selectedRow = dgv_Customers.SelectedRows[0];

                // Retrieves a string List of the selected row's customer data
                System.Collections.Generic.List<String> customerDetails = Customer.GetSelectedRowData(selectedRow);

                // Opens the Edit_Customer form, passing on the List
                var editCustomer = new Edit_Customer(customerDetails);
                editCustomer.Show();
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Handles the Delete Button click event
        private void btn_Delete_Click(object sender, EventArgs e)
        {

            // Opens the Delete_Customer form
            var deleteCustomer = new Delete_Customer();
            deleteCustomer.Show();

        }
    }
}