using Appointments_Scheduler.Database_Table_Classes;
using Appointments_Scheduler.Forms.Customer_Forms;
using System;
using System.Windows.Forms;

namespace Appointments_Scheduler.Customer_Forms
{
    public partial class Add_Customer : Form
    {
        public Add_Customer()
        {
            InitializeComponent();
        }

        // Adds a customer to the customer database table, to the Binding List, and to the Data Grid View
        private void btn_Add_Click(object sender, System.EventArgs e)
        {
            // Retrieves the input customer data
            string customerName = txtBox_CustomerName.Text;
            int addressID = Convert.ToInt32(txtBox_AddressID.Text);
            int active;
            if (radioBtn_Active.Checked)
                active = 1;
            else
                active = 0;
            DateTime createDate = DateTime.Parse(txtBox_CreateDate.Text);
            string createdBy = txtBox_CreateDate.Text; 
            DateTime lastUpdate = DateTime.Parse(txtBox_LastUpdate.Text);
            string lastUpdateBy = txtBox_LastUpdateBy.Text;

            // Creates a new customer object
            Customer newCustomer = new Customer(customerName, addressID, active, createDate, createdBy, lastUpdate, lastUpdateBy);

            // Adds the customer to the database and retrieves the generated customerID
            newCustomer.CustomerID = Customer.AddCustomerToDatabase(newCustomer);

            // Adds the new customer to the BindingList instance
            Customer_Records.Instance.AllCustomers.Add(newCustomer);

            // Ensures the form closes after adding the customer data
            this.Close();
        }
    }
}
