using System;
using System.Collections.Generic;
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

            Customer customer = new Customer();
            List<Customer> customerList = customer.GetCustomers();

            // Loads the customer database table into the Data Grid View
            dgv_Customers.DataSource = customerList;

            // Data Grid View settings
            dgv_Customers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Customers.ReadOnly = true;  
            dgv_Customers.MultiSelect = false;
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
            // Opens the Edit_Customer form
            var editCustomer = new Edit_Customer();
            editCustomer.Show();

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
