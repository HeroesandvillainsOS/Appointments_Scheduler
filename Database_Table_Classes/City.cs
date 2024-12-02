using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Appointments_Scheduler.Database_Table_Classes
{
    internal class City
    {
        // Returns the cityID and adds the city to the database
        public static int GetCityIDAndAddCityToDatabase(string city, int countryID, DateTime createDate, string createdBy,
            DateTime lastUpdate, string lastUpdateBy)
        {
            int cityID = 0;

            // Handles what happens if the cityID already exists

            // Determines the SQL query
            string getCityQuery = @"SELECT cityID FROM city
                                    WHERE city = @city
                                    AND countryID = @countryID";

            // Establishes a connection to the database with a querty to execute
            using (var command = new MySqlCommand(getCityQuery, DBConnection.connection))
            {
                // Defines values for the @variables
                command.Parameters.AddWithValue("@city", city);
                command.Parameters.AddWithValue("@countryID", countryID);

                // Executes the SQL query on the database and returns the already established countryID
                object result = command.ExecuteScalar(); // can return null. Storing the result to "object" prevents an exception

                if (result != null)
                {
                    cityID = Convert.ToInt32(result);
                }
            }

            // Handles what happens if the cityID doesn't already exist

            if (cityID == 0)
            {
                // Determines the SQL query
                string insertCountryQuery = @"INSERT INTO city(city, countryID, createDate, createdBy, lastUpdate, lastUpdateBy)
                                              VALUES(@city, @countryID, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);
                                              SELECT LAST_INSERT_ID();";

                // Establishes a connection to the database with a querty to execute
                using (var command = new MySqlCommand(insertCountryQuery, DBConnection.connection))
                {
                    // Defines values for the @variables
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@countryID", countryID);
                    command.Parameters.AddWithValue("@createDate", createDate);
                    command.Parameters.AddWithValue("@createdBy", createdBy);
                    command.Parameters.AddWithValue("@lastUpdate", lastUpdate);
                    command.Parameters.AddWithValue("@lastUpdateBy", lastUpdateBy);

                    // Executes the SQL query on the database and returns the first column of the first new row of the table
                    cityID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return cityID;
        }

        public static List<String> GetCityAndCountryID(int cityID)
        {
            var cityData = new List<String>();

            string query = @"SELECT city, countryId
                             FROM city
                             WHERE cityId = @cityID;";

            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                command.Parameters.AddWithValue("@cityID", cityID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cityData.Add(reader["city"].ToString());
                        cityData.Add(reader["countryId"].ToString());
                    }
                }
            }
            return cityData;
        }
    }
}
