using System;
using System.ComponentModel;
using System.Windows.Forms;
using Appointments_Scheduler.Customer_Forms;
using Appointments_Scheduler.Database_Table_Classes;
using System.Collections.Generic;

namespace Appointments_Scheduler.Forms.Customer_Forms
{
    public partial class Customer_Records : Form
    {
        // Properties to ensure the Data Grid View can display live updates when the Binding List values change
        public static Customer_Records Instance { get; private set; } 
        public BindingList<Customer> AllCustomers { get; private set; }
        public DataGridView DgvCustomers => dgv_Customers; 

        public Customer_Records()
        {
            InitializeComponent();

            Instance = this; 

            // Data Grid View settings
            dgv_Customers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Customers.ReadOnly = true;
            dgv_Customers.MultiSelect = false;

            // Gets all customers from the customer database table
            AllCustomers = Customer.GetAllCustomers();

            // Converts the Data Grid View DateTime records to Local time (Binding List only)
            foreach (Customer customer in AllCustomers)
            {
                customer.CreateDate = TimeZoneInfo.ConvertTimeFromUtc(customer.CreateDate, TimeZoneInfo.Local);
                customer.LastUpdate = TimeZoneInfo.ConvertTimeFromUtc(customer.LastUpdate, TimeZoneInfo.Local);
            }

            // Displays the Binding List of all customers on the Data Grid View
            dgv_Customers.DataSource = AllCustomers;
        }

        // Unselects the automatically selected first row on the Data Grid View
        private void OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Customers.ClearSelection();
        }

        // Handles the Add button click event
        private void btn_Add_Click(object sender, EventArgs e)
        {
            // Opens the Add_Customer form
            var addCustomer = new Add_Customer();
            addCustomer.Show();
        }

        // Handles the Edit Button click event
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;

            try
            {
                // Gets the selected Data Grid View row
                selectedRow = dgv_Customers.SelectedRows[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select a customer to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieves a string List of the selected row's customer data
            List<String> customerDetails = Customer.GetSelectedRowData(selectedRow);

            // Opens the Edit_Customer form, passing on the List
            var editCustomer = new Edit_Customer(customerDetails);
            editCustomer.Show();

        }

        // Handles the Delete Button click event
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;

            try
            {
                // Gets the selected Data Grid View row
                selectedRow = dgv_Customers.SelectedRows[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select a customer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieves a string List of the selected row's customer data
            List<String> customerDetails = Customer.GetSelectedRowData(selectedRow);

            // Opens the Delete_Customer form
            var deleteCustomer = new Delete_Customer(customerDetails);
            deleteCustomer.Show();

        }
    }
}
