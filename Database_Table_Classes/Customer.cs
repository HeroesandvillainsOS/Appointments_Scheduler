using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments_Scheduler.Database_Table_Classes
{
    internal class Customer
    {
        public int CustomerID {  get; set; } // Primary Key
        public string CustomerName { get; set; }
        public int AddressID { get; set; } // Foreign Key
        public int Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate {  get; set; }
        public string LastUpdateBy { get; set; }

        public List<Customer> GetCustomers()
        {
            // Creates the List
            var customers = new List<Customer>();
            // Establishes the SQL query
            string query = "SELECT customerID, customerName, addressID, active, createDate, createdBy, lastUpdate, lastUpdateBy FROM customer";

            // Creates a new MySQLCommand instance with the established query and connection
            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                // Creates a reader object for the MySQLCommand instance
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Iterates through the database table
                        var customer = new Customer
                        {
                            CustomerID = reader.GetInt32("customerID"),
                            CustomerName = reader.GetString("customerName"),
                            AddressID = reader.GetInt32("addressId"),
                            Active = reader.GetInt32("active"),
                            CreateDate = reader.GetDateTime("createDate"),
                            CreatedBy = reader.GetString("createdBy"),
                            LastUpdate = reader.GetDateTime("lastUpdate"),
                            LastUpdateBy = reader.GetString("lastUpdateBy")
                        };
                        // Adds a new user to the List
                        customers.Add(customer);
                    }
                    // Returns the List
                    return customers;
                }

            }

        }
    }
}
