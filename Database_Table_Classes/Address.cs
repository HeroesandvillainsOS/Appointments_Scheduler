using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;

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
                                    AND phone = @phone
                                    AND createDate = @createDate
                                    AND createdBy = @createdBy
                                    AND lastUpdate = @lastUpdate
                                    AND lastUpdateBY = @lastUpdateBy;";

            // Establishes a connection to the database with a querty to execute
            using (var command = new MySqlCommand(getAddressQuery, DBConnection.connection)) 
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
    }
}
