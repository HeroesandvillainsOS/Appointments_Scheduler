using Appointments_Scheduler.Database_Table_Classes;
using Appointments_Scheduler.Forms.Customer_Forms;
using System;
using System.Windows.Forms;
using System.Linq;

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
            // Gets the user input customer values
            string customerName = txtBox_CustomerName.Text.Trim();
            string address = txtBox_Address.Text.Trim();
            string address2 = txtBox_Address2.Text.Trim();
            string city = txtBox_City.Text.Trim();
            string country = txtBox_Country.Text.Trim();
            int postalCode;
            string phoneNumber = txtBox_Phone.Text.Trim();
            int active;
            if (radioBtn_Active.Checked)
                active = 1;
            else
                active = 0;
            DateTime createDate;
            string createdBy = txtBox_CreateDate.Text.Trim();
            DateTime lastUpdate;
            string lastUpdateBy = txtBox_LastUpdateBy.Text.Trim();

            // Enforces formatting rules for the customer data

            // Customer Name cannot be left blank
            if (String.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Customer Name cannot be left empty.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            // Customer Name cannot contain numbers
            bool customerNameHasNumbers = customerName.Any(x => char.IsDigit(x));
            if (customerNameHasNumbers)
            {
                MessageBox.Show("Customer Name cannot contain numbers.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            // Address cannot be left blank
            if (String.IsNullOrEmpty(address))
            {
                MessageBox.Show("Address cannot be left empty.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            // City cannot contain numbers
            bool cityHasNumbers = city.Any(x => char.IsDigit(x));
            if (cityHasNumbers)
            {
                MessageBox.Show("City cannot contain numbers.", "Warning", MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                return;
            }

            // Country cannot contain numbers
            bool countryHasNumbers = country.Any(x => char.IsDigit(x));
            if (countryHasNumbers)
            {
                MessageBox.Show("Country cannot contain numbers.", "Warning", MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                return;
            }

            // Postal Code cannot contain letters
            bool postalCodeIsValid = int.TryParse(txtBox_PostalCode.Text.Trim(), out postalCode);
            if (!postalCodeIsValid)
            {
                MessageBox.Show("Postal Code cannot contain letters.", "Warning", MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                return;
            }

            // Phone Number cannot be left blank
            if (String.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Phone Number cannot be left empty.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            // A Phone Number can only contain digits and dashes
            string phoneNumberAsString = phoneNumber.ToString();
            bool invalidPhoneNumber = phoneNumberAsString.Any(x => x != '-' && !char.IsDigit(x));
            if (invalidPhoneNumber)
            {
                MessageBox.Show("Phone numbers can only contain digits and dashes.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Create Date cannot be left blank
            if (string.IsNullOrWhiteSpace(txtBox_CreateDate.Text) || !DateTime.TryParse(txtBox_CreateDate.Text, out createDate))
            {
                createDate = DateTime.Now.Date;  // Ensures today's date is used if the field is left blank
            }

            // Last Update cannot be left blank
            if (string.IsNullOrWhiteSpace(txtBox_LastUpdate.Text) || !DateTime.TryParse(txtBox_LastUpdate.Text, out lastUpdate))
            {
                lastUpdate = DateTime.Now.Date;  // Ensures today's date is used if the field is left blank
            }

            // Asks the user to verify they want to permanently add this customer
            DialogResult result = MessageBox.Show(@"Are you sure you want to add this customer to the database? This action cannot be undone.",
                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Gets countryID, cityID, and addressID, and sets the Address, City, and Country database tables when applicable
            int countryID = Country.GetCountryIDAndAddCountryToDatabase(country, createDate, createdBy, lastUpdate, lastUpdateBy);
            int cityID = City.GetCityIDAndAddCityToDatabase(city, countryID, createDate, createdBy, lastUpdate, lastUpdateBy);
            int addressID = Address.GetAddressIDAndAddAddressToDatabase(address, address2, cityID, postalCode, phoneNumber, 
                createDate, createdBy, lastUpdate, lastUpdateBy);

            // Creates a new customer object
            Customer newCustomer = new Customer(customerName, addressID, active, createDate, createdBy, lastUpdate, lastUpdateBy);

            // Adds the customer to the database and retrieves the generated customerID
            newCustomer.CustomerID = Customer.AddCustomerToDatabase(newCustomer);

            // Adds the new customer to the BindingList instance with the returned customerID
            Customer_Records.Instance.AllCustomers.Add(newCustomer);

            // Ensures the form closes after adding the customer data
            this.Close();
        }
    }
}
