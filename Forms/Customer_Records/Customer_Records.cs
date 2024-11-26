using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Appointments_Scheduler.Database_Table_Classes;

namespace Appointments_Scheduler.Forms
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

        private void lbl_AllCustomerRecords_Click(object sender, EventArgs e)
        {

        }
    }
}
