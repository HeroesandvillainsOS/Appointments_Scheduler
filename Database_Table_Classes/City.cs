using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments_Scheduler.Database_Table_Classes
{
    internal class City
    {
        public static void SetCityIDInDatabase(string city, string country)
        {
            // Handles what happens if the cityID already exists

            int cityID = 0;
            int countryID = 0;

            // Determines the SQL query
            string getCityQuery = @"SELECT cityID FROM city
                                    WHERE city = @city";

            // Establishes a connection to the database with a querty to execute
            using (var cityCommand = new MySqlCommand(getCityQuery, DBConnection.connection))
            {
                // Defines values for the @variables
                cityCommand.Parameters.AddWithValue("@city", city);

                // Executes the SQL query on the database and returns the first column of the first row of the table
                object cityResult = cityCommand.ExecuteScalar(); // can return null. Storing the result to "object" prevents an exception

                // If city already exists in the database, verify the country already exists in the database
                if (cityResult != null)
                {
                    cityID = Convert.ToInt32(cityResult);

                    // Determines the SQL query
                    string getCountryQuery = @"SELECT countryID FROM country
                                             WHERE country = @country";

                    // Establishes a connection to the database with a querty to execute
                    using (var countryCommand = new MySqlCommand(getCountryQuery, DBConnection.connection))
                    {
                        // Defines values for the @variables
                        countryCommand.Parameters.AddWithValue("@country", country);

                        // Executes the SQL query on the database and returns the first column of the first row of the table
                        object countryResult = countryCommand.ExecuteScalar();

                        if (countryResult != null)
                        {
                            countryID = Convert.ToInt32(countryResult);
                        }
                    }
                }

            }
        }
    }
}
