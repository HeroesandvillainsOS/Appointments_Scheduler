using Appointments_Scheduler.Database_Table_Classes;
using Appointments_Scheduler.Forms.Customer_Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Appointments_Scheduler.Customer_Forms
{
    public partial class Delete_Customer : Form
    {
        public Delete_Customer(List<String> customer)
        {
            InitializeComponent();

            // Fills the form with the selected customer's data
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
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            // Retrieves the selected customer's customerID
            int customerID = Convert.ToInt32(txtBox_CustomerID.Text);

            // Executes the SQL query and deletes the customer from the database
            Customer.DeleteCustomerFromDatabase(customerID);

            // Deletes the customer entry from the Binding List'
            foreach (Customer customer in Customer_Records.Instance.AllCustomers.ToList())
            {
                if (customer.CustomerID == customerID)
                {
                    Customer_Records.Instance.AllCustomers.Remove(customer);
                }
            }

            // Refreshes the Data Grid view's data
            Customer_Records.Instance.DgvCustomers.Refresh();

            // Closes the form once a customer has been deleted
            this.Close();
        }
    }
}
