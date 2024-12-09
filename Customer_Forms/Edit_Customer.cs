using Appointments_Scheduler.Database_Table_Classes;
using Appointments_Scheduler.Forms.Customer_Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine(customer[3]);
            if (Convert.ToInt32(customer[3]) == 0)
                chkBox_Active.Checked = false;
            else
                chkBox_Active.Checked = true;
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

        // Edits a customer's data in the customer, address, city, and country database tables and updates the Binding List
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            // Gets the user input customer values
            int customerID = Convert.ToInt32(txtBox_CustomerID.Text.Trim());
            string customerName = txtBox_CustomerName.Text.Trim();
            string address = txtBox_Address.Text.Trim();
            string address2 = txtBox_Address2.Text.Trim();
            string city = txtBox_City.Text.Trim();
            string country = txtBox_Country.Text.Trim();
            int postalCode;
            string phoneNumber = txtBox_Phone.Text.Trim();
            int active;
            if (chkBox_Active.Checked)
                active = 1;
            else
                active = 0;
            DateTime createDate;
            string createdBy = txtBox_CreatedBy.Text.Trim();
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
            if (!String.IsNullOrEmpty(txtBox_PostalCode.Text) && !postalCodeIsValid)
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
                createDate = DateTime.Now;  // Ensures today's date is used if the field is left blank
            }

            // Last Update cannot be left blank
            if (string.IsNullOrWhiteSpace(txtBox_LastUpdate.Text) || !DateTime.TryParse(txtBox_LastUpdate.Text, out lastUpdate))
            {
                lastUpdate = DateTime.Now;  // Ensures today's date is used if the field is left blank
            }

            // Variable for converting local time to UTC time
            TimeZoneInfo utcZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            // Create Date and Last Update must be converted from local time to UTC time
            createDate = TimeZoneInfo.ConvertTime(createDate, TimeZoneInfo.Local, utcZone);
            lastUpdate = TimeZoneInfo.ConvertTime(lastUpdate, TimeZoneInfo.Local, utcZone);

            // Asks the user to verify they want to permanently edit this customer
            DialogResult result = MessageBox.Show(@"Are you sure you want to edit this customer in the database? This action cannot be undone.", 
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

            // Creates a new customer object based on the user input customer values
            Customer editCustomerWithUTC = new Customer(customerID, customerName, addressID, active, createDate, createdBy, lastUpdate, 
                lastUpdateBy);

            // Updates the database with the customer's new information
            Customer.EditCustomerInDatabase(editCustomerWithUTC);

            // Converts the UTC times to local times so they display correctly on the Data Grid View
            DateTime createDateLocal = TimeZoneInfo.ConvertTimeFromUtc(createDate, TimeZoneInfo.Local);
            DateTime lastUpdateLocal = TimeZoneInfo.ConvertTimeFromUtc(lastUpdate, TimeZoneInfo.Local);

            // Uses LINQ to find the first customer in the Binding List that matches the edited customer's customerID
            var customerToEdit = Customer_Records.Instance.AllCustomers.FirstOrDefault(c => c.CustomerID == customerID);

            if (customerToEdit != null)
            {
                // Updates the Binding List record for customer being edited
                customerToEdit.CustomerID = customerID;
                customerToEdit.CustomerName = customerName;
                customerToEdit.AddressID = addressID;
                customerToEdit.Active = active;
                customerToEdit.CreateDate = createDateLocal;
                customerToEdit.CreatedBy = createdBy;
                customerToEdit.LastUpdate = lastUpdateLocal;
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
