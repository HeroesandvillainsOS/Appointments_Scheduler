using Appointments_Scheduler.Database_Table_Classes;
using Appointments_Scheduler.Forms.Customer_Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Appointments_Scheduler.Customer_Forms
{
    public partial class Edit_Customer : Form
    {
        public Edit_Customer(List<String> customer)
        {
            InitializeComponent();

            // Fills the form with the selected customer's data from the customer table's Binding List
            txtBox_CustomerID.Text = customer[0];
            txtBox_CustomerName.Text = customer[1];
            if (Convert.ToInt32(customer[3]) == 0)
                radioBtn_Active.Checked = false;
            else
                radioBtn_Active.Checked = true;
            txtBox_CreateDate.Text = customer[4];
            txtBox_CreatedBy.Text = customer[5];
            txtBox_LastUpdate.Text = customer[6];
            txtBox_LastUpdateBy.Text = customer[7];

            // Gets the customer's address, address2, city, country, postalCode, and phone
            List<string> additionalCustomerData = Customer.GetAdditionalCustomerData(customer[2]);

            // Fills the form with this additional customer data
            txtBox_Address.Text = additionalCustomerData[0];
            txtBox_Address2.Text = additionalCustomerData[1];
            txtBox_City.Text = additionalCustomerData[2];
            txtBox_Country.Text = additionalCustomerData[3];
            txtBox_PostalCode.Text = additionalCustomerData[4];
            txtBox_Phone.Text = additionalCustomerData[5];

            // Deselects the customerName text box which is selected by default
            txtBox_CustomerName.Select(0, 0);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            // Gets the user input customer values
            int customerID = Convert.ToInt32(txtBox_CustomerID.Text);
            string customerName = txtBox_CustomerName.Text;
            int addressID = Convert.ToInt32(txtBox_Address.Text);
            int active;
            if (radioBtn_Active.Checked)
                active = 1;
            else
                active = 0;
            DateTime createDate = Convert.ToDateTime(txtBox_CreateDate.Text);
            string createdBy = txtBox_CreatedBy.Text;
            DateTime lastUpdate = Convert.ToDateTime(txtBox_LastUpdate.Text);
            string lastUpdateBy = txtBox_LastUpdateBy.Text;

            // Creates a new customer object based on the user input customer values
            Customer editCustomer = new Customer(customerID, customerName, addressID, active, createDate, createdBy, lastUpdate, 
                lastUpdateBy);

            // Updates the database with the customer's new information
            Customer.EditCustomerInDatabase(editCustomer);

            // Uses LINQ to find the first customer in the Binding List that matches the edited customer's customerID
            var customerToEdit = Customer_Records.Instance.AllCustomers.FirstOrDefault(c => c.CustomerID == customerID);

            if (customerToEdit != null)
            {
                // Updates the Binding List record for customer being edited
                customerToEdit.CustomerID = customerID;
                customerToEdit.CustomerName = customerName;
                customerToEdit.AddressID = addressID;
                customerToEdit.Active = active;
                customerToEdit.CreateDate = createDate;
                customerToEdit.CreatedBy = createdBy;
                customerToEdit.LastUpdate = lastUpdate;
                customerToEdit.LastUpdateBy = lastUpdateBy;
            }
            else
            {
                MessageBox.Show("The customer you're trying to edit cannot be found.", "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }

            // Refreshes the Data Grid View
            Customer_Records.Instance.DgvCustomers.Refresh();

            this.Close();
        }
    }
}
