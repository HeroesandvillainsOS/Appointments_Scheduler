using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Appointments_Scheduler.Database_Table_Classes
{
    internal class Address
    {
        // Returns the addressID and adds the address to the database
        public static int GetAddressIDAndAddAddressToDatabase(string address, string address2, int cityID, int postalCode, string phone,
           DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            int addressID = 0;

            // Handles what happens if the addressID already exists

            // Determines the SQL query
            string getAddressQuery = @"SELECT addressID FROM address
                                       WHERE address = @address
                                       AND address2 = @address2
                                       AND cityID = @cityID
                                       AND postalCode = @postalCode
                                       AND phone = @phone";

            // Establishes a connection to the database with a querty to execute
            using (var command = new MySqlCommand(getAddressQuery, DBConnection.connection)) 
            {
                // Defines values for the @variables
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@address2", address2);
                command.Parameters.AddWithValue("@cityID", cityID);
                command.Parameters.AddWithValue("@postalCode", postalCode);
                command.Parameters.AddWithValue("@phone", phone);

                // Executes the SQL query on the database and returns the already established addressID
                object result = command.ExecuteScalar(); // can return null. Storing the result to "object" prevents an exception

                if (result != null)
                {
                    addressID = Convert.ToInt32(result);
                }
            }

            // Handles what happens if the addressID doesn't already exist

            if (addressID == 0)
            {
                // Establishes a connection to the database with a querty to execute
                string insertAddressQuery = @"INSERT INTO address (address, address2, cityID, postalCode, phone, createDate, 
                                              createdBy, lastUpdate, lastUpdateBy) 
                                              VALUES (@address, @address2, @cityID, @postalCode, @phone, @createDate, @createdBy, 
                                              @lastUpdate, @lastUpdateBy);
                                              SELECT LAST_INSERT_ID();"; // Establishes a way to get the auto-generated addressID

                // Establishes a connection to the database with a querty to execute
                using (var command = new MySqlCommand(insertAddressQuery, DBConnection.connection))
                {
                    // Defines values for the @variables
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@address2", address2);
                    command.Parameters.AddWithValue("@cityID", cityID);
                    command.Parameters.AddWithValue("@postalCode", postalCode);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@createDate", createDate);
                    command.Parameters.AddWithValue("@createdBy", createdBy);
                    command.Parameters.AddWithValue("@lastUpdate", lastUpdate);
                    command.Parameters.AddWithValue("@lastUpdateBy", lastUpdateBy);

                    // Executes the SQL query on the database and returns the first column of the first new row of the table
                    addressID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return addressID;
        }

        // Returns a List<String> containing a customer's address, address2, cityId, postalCode, and phone.
        public static List<String> GetAddressCityIDZipAndPhone(int addressID)
        {
            var addressData = new List<String>();

            string query = @"SELECT address, address2, cityId, postalCode, phone
                             FROM address
                             WHERE addressId = @addressID;";

            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                command.Parameters.AddWithValue("@addressID", addressID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addressData.Add(reader["address"].ToString());
                        addressData.Add(reader["address2"].ToString());
                        addressData.Add(reader["cityId"].ToString());
                        addressData.Add(reader["postalCode"].ToString());
                        addressData.Add(reader["phone"].ToString());
                    }
                }
            }
            return addressData;
        }
    }
}
