using System;
using System.ComponentModel;
using System.Windows.Forms;
using Appointments_Scheduler.Customer_Forms;
using Appointments_Scheduler.Database;
using Appointments_Scheduler.Database_Table_Classes;
using Appointments_Scheduler.Forms.Customer_Records;
using MySql.Data.MySqlClient;


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

            // Establishes the SQL query
            string query = "SELECT * FROM customer";

            // Creates a new MySQLCommand instance with the established query and database connection
            MySqlCommand command = new MySqlCommand(query, DBConnection.connection);

            // Creates a reader object for the MySQLCommand instance
            var reader = command.ExecuteReader();

            // Creates a Binding List to store the customer table data
            BindingList<Customer> allCustomers = new BindingList<Customer>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // Adds the customer table data to the Binding List
                    allCustomers.Add(new Customer(reader.GetInt32("customerID"), reader.GetString("customerName"), reader.GetInt32("addressId"),
                        reader.GetInt32("active"), reader.GetDateTime("createDate"), reader.GetString("createdBy"), reader.GetDateTime("lastUpdate"),
                        reader.GetString("lastUpdateBy")));
                }
            }
            else
            {
                MessageBox.Show("The customer table has no rows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            reader.Close();
            // Displays the Binding List on the Data Grid View
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

                // Extracts the data from the row
                string customerID = selectedRow.Cells["customerID"].Value.ToString();
                string customerName = selectedRow.Cells["customerName"].Value.ToString();
                string addressID = selectedRow.Cells["addressID"].Value.ToString();
                int active = Convert.ToInt32(selectedRow.Cells["active"].Value);
                string createDate = selectedRow.Cells["createDate"].Value.ToString();
                string createdBy = selectedRow.Cells["createdBy"].Value.ToString();
                string lastUpdate = selectedRow.Cells["lastUpdate"].Value.ToString();
                string lastUpdateBy = selectedRow.Cells["lastUpdateBy"].Value.ToString();

                // Opens the Edit_Customer form
                var editCustomer = new Edit_Customer(customerID, customerName, addressID, active, createDate, createdBy,
                    lastUpdate, lastUpdateBy);
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
