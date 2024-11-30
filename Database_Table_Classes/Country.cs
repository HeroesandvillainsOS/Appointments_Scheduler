using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;

namespace Appointments_Scheduler.Database_Table_Classes
{
    internal class Country
    {
        // Returns the countryID and adds the country to the database
        public static int GetCountryIDAndAddCountryToDatabase(string country, DateTime createDate, string createdBy, DateTime lastUpdate, 
            string lastUpdateBy)
        {
            int countryID = 0;

            // Handles what happens if the countryID already exists

            // Determines the SQL query
            string getCountryQuery = @"SELECT countryID FROM country
                                     WHERE country = @country
                                     AND createDate = @createDate
                                     AND createdBy = @createdBy
                                     AND lastUpdate = @lastUpdate
                                     AND lastUpdateBY = @lastUpdateBy";

            // Establishes a connection to the database with a querty to execute
            using (var command = new MySqlCommand(getCountryQuery, DBConnection.connection))
            {
                // Defines values for the @variables
                command.Parameters.AddWithValue("@country", country);
                command.Parameters.AddWithValue("@createDate", createDate);
                command.Parameters.AddWithValue("@createdBy", createdBy);
                command.Parameters.AddWithValue("@lastUpdate", lastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", lastUpdateBy);

                // Executes the SQL query on the database and returns the already established countryID
                object result = command.ExecuteScalar();  // can return null. Storing the result to "object" prevents an exception

                if (result != null)
                {
                    countryID = Convert.ToInt32(result);
                }
            }

            // Handles what happens if the countryID doesn't already exist
            if (countryID == 0)
            {
                // Determines the SQL query
                string insertCountryQuery = @"INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy)
                                            VALUES(@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);
                                            SELECT LAST_INSERT_ID();";

                // Establishes a connection to the database with a querty to execute
                using (var command = new MySqlCommand(insertCountryQuery, DBConnection.connection))
                {
                    // Defines values for the @variables
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@createDate", createDate);
                    command.Parameters.AddWithValue("@createdBy", createdBy);
                    command.Parameters.AddWithValue("@lastUpdate", lastUpdate);
                    command.Parameters.AddWithValue("@lastUpdateBy", lastUpdateBy);

                    // Executes the SQL query on the database and returns the first column of the first new row of the table
                    countryID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return countryID;
        }
    }
}
