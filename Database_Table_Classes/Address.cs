using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments_Scheduler.Database_Table_Classes
{
    internal class Address
    {
        public static int GetAddressID(string address, string address2, string city, int postalCode, string phone,
           DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            int addressID = 0;

            // Handles what happens if the addressID already exists

            // Determines the SQL query
            string getAddressQuery = @"SELECT addressID FROM address
                                    WHERE address = @address
                                    AND address2 = @address2
                                    AND city = @city
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
                command.Parameters.AddWithValue("@city", city);
                command.Parameters.AddWithValue("@postalCode", postalCode);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@createDate", createDate);
                command.Parameters.AddWithValue("@createdBy", createdBy);
                command.Parameters.AddWithValue("@lastUpdate", lastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", lastUpdateBy);

                // Executes the SQL query on the database and returns the first column of the first row of the table
                object result = command.ExecuteScalar(); // can return null. Storing the result to "object" prevents an exception

                if (result != null)
                {
                    // Finds and return the addressID
                    addressID = Convert.ToInt32(result);
                }
            }

            // Handles what happens if the addressID doesn't already exist

            if (addressID == 0)
            {
                // Establishes a connection to the database with a querty to execute
                string insertAddressQuery = @"INSERT INTO address (address, address2, city, postalCode, phone, createDate, 
                                            createdBy, lastUpdate, lastUpdateBy) 
                                            VALUES (@address, @address2, @city, @postalCode, @phone, @createDate, @createdBy, 
                                            @lastUpdate, @lastUpdateBy);
                                            SELECT LAST_INSERT_ID();"; // Establishes a way to get the auto-generated addressID

                // Establishes a connection to the database with a querty to execute
                using (var command = new MySqlCommand(insertAddressQuery, DBConnection.connection))
                {
                    // Defines values for the @variables
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@address2", address2);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@postalCode", postalCode);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@createDate", createDate);
                    command.Parameters.AddWithValue("@createdBy", createdBy);
                    command.Parameters.AddWithValue("@lastUpdate", lastUpdate);
                    command.Parameters.AddWithValue("@lastUpdateBy", lastUpdateBy);

                    // Executes the SQL query on the database and returns the first column of the first row of the table
                    addressID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return addressID;
        }
    }
}
