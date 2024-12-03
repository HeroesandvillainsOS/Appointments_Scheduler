using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Appointments_Scheduler.Database_Table_Classes
{
    public class Customer
    {
        public int CustomerID { get; set; } // Primary Key
        public string CustomerName { get; set; }
        public int AddressID { get; set; } // Foreign Key
        public int Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        // Constructor for existing customers (requires customerID)
        public Customer(int customerID, string customerName, int addressID, int active, DateTime createDate,
            string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            AddressID = addressID;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }

        // Constructor for new customers (doesn't requre customerID)
        public Customer(string customerName, int addressID, int active, DateTime createDate,
            string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            CustomerName = customerName;
            AddressID = addressID;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }

        // Returns a Binding List of all customers from the customer database table
        public static BindingList<Customer> GetAllCustomers()
        {
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
                    allCustomers.Add(new Customer(reader.GetInt32("customerID"), reader.GetString("customerName"), 
                        reader.GetInt32("addressId"), reader.GetInt32("active"), reader.GetDateTime("createDate"), 
                        reader.GetString("createdBy"), reader.GetDateTime("lastUpdate"), reader.GetString("lastUpdateBy")));
                }
            }
            else
            {
                MessageBox.Show("The customer table has no rows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            reader.Close();

            // Returns a Binding List of all customers from the customer database table
            return allCustomers;
        }

        // Returns a string List of a single customer's data from the selected Data Grid View row
        public static List<String> GetSelectedRowData(DataGridViewRow selectedRow)
        {
            // Extracts the data from the row
            string customerID = selectedRow.Cells["customerID"].Value.ToString();
            string customerName = selectedRow.Cells["customerName"].Value.ToString();
            string addressID = selectedRow.Cells["addressID"].Value.ToString();
            string active = selectedRow.Cells["active"].Value.ToString();
            string createDate = selectedRow.Cells["createDate"].Value.ToString();
            string createdBy = selectedRow.Cells["createdBy"].Value.ToString();
            string lastUpdate = selectedRow.Cells["lastUpdate"].Value.ToString();
            string lastUpdateBy = selectedRow.Cells["lastUpdateBy"].Value.ToString();

            // Creates a string List of the selected row's customer data
            List<String> customerDetails = new List<String>();
            customerDetails.Add(customerID);
            customerDetails.Add(customerName);
            customerDetails.Add(addressID);
            customerDetails.Add(active);
            customerDetails.Add(createDate);
            customerDetails.Add(createdBy);
            customerDetails.Add(lastUpdate);
            customerDetails.Add(lastUpdateBy);

            // Returns the List
            return customerDetails;
        }

        // Returns a List<String> of additional customer data needed to pre-fill the Edit and Delete customer forms
        public static List<String> GetAdditionalCustomerData(string addressIDString)
        {
            List<String> additionalCustomerData = new List<String>();
            string address;
            string address2;
            string city;
            string country;
            string postalCode;
            string phone;

            // Gets additional details needed from the address database table
            int addressID = Convert.ToInt32(addressIDString);
            List<String> additionalAddressData = Address.GetAddressCityIDZipAndPhone(addressID);
            address = additionalAddressData[0];
            address2 = additionalAddressData[1];
            int cityID = Convert.ToInt32(additionalAddressData[2]);
            postalCode = additionalAddressData[3];
            phone = additionalAddressData[4];

            // Gets additional details needed from the city database table
            List<String> additionalCityData = City.GetCityAndCountryID(cityID);
            city = additionalCityData[0];
            int countryID = Convert.ToInt32(additionalCityData[1]);

            // Gets additional details needed from the country database table
            List<String> additionalCountryData = Country.GetCountryName(countryID);
            country = additionalCountryData[0];

            // Adds the details to the List<String>
            additionalCustomerData.Add(address);
            additionalCustomerData.Add(address2);
            additionalCustomerData.Add(city);
            additionalCustomerData.Add(country);
            additionalCustomerData.Add(postalCode);
            additionalCustomerData.Add(phone);

            // Returns the List<String>
            return additionalCustomerData;
        }

        // Inserts the added customer into the customer database table and returns the new customerID
        public static int AddCustomerToDatabase(Customer customer)
        {
            // Establishes the SQL query
            string query = @"INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
                            VALUES (@customerName, @addressID, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);
                            SELECT LAST_INSERT_ID();"; // Gets the auto-generated customerID

            // Opens a connection to the database and executes the query
            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                // Defines the @ variable values
                command.Parameters.AddWithValue("@customerName", customer.CustomerName);
                command.Parameters.AddWithValue("@addressID", customer.AddressID);
                command.Parameters.AddWithValue("@active", customer.Active);
                command.Parameters.AddWithValue("@createDate", customer.CreateDate);
                command.Parameters.AddWithValue("@createdBy", customer.CreatedBy);
                command.Parameters.AddWithValue("@lastUpdate", customer.LastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", customer.LastUpdateBy);

                // Returns the auto-generated customerID and executes the SQL command
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // Edits a customer record in the database
        public static void EditCustomerInDatabase(Customer customer)
        {
            // Establishes the SQL query
            string query = @"UPDATE customer 
                            SET customerName = @customerName, addressId = @addressID, active = @active, createDate = @createDate,
                                createdBy = @createdBy, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy
                            WHERE customerID = @customerID";

            // Opens a connection to the database and executes the query
            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                // Defines the @ variable values
                command.Parameters.AddWithValue("@customerID", customer.CustomerID);
                command.Parameters.AddWithValue("@customerName", customer.CustomerName);
                command.Parameters.AddWithValue("@addressID", customer.AddressID);
                command.Parameters.AddWithValue("@active", customer.Active);
                command.Parameters.AddWithValue("@createDate", customer.CreateDate);
                command.Parameters.AddWithValue("@createdBy", customer.CreatedBy);
                command.Parameters.AddWithValue("@lastUpdate", customer.LastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", customer.LastUpdateBy);

                // Executes the SQL command
                command.ExecuteNonQuery();
            }
        }

        // Deletes a customer record from the Database
        public static void DeleteCustomerFromDatabase(int customerID)
        {
            // Establishes the SQL query
            string query = "DELETE FROM customer WHERE customerID = @customerID";

            // Opens a connection to the database and executes the query
            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                // Defines the @ variable values
                command.Parameters.AddWithValue("@customerID", customerID);

                // Executes the SQL command
                command.ExecuteNonQuery();
            }
        }
    }
}
