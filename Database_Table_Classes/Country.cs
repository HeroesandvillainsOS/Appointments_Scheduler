using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Appointments_Scheduler.Database_Table_Classes
{
    public class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        public Country(int countryID, string countryName, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            CountryID = countryID;
            CountryName = countryName;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }

        // Returns a BindingList<Country> of all countries from the database
        public static BindingList<Country> GetAllCountries()
        {
            BindingList<Country> allCountries = new BindingList<Country>();

            string query = @"SELECT *
                             FROM country";

            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        allCountries.Add(new Country(
                            reader.GetInt32("countryId"),
                            reader.GetString("country"),
                            reader.GetDateTime("createDate"),
                            reader.GetString("createdBy"),
                            reader.GetDateTime("lastUpdate"),
                            reader.GetString("lastUpdateBy")
                        ));
                    }
                }
                reader.Close();
            }
            return allCountries;
        }

        // Returns a BindingList<String> of all unique countries in the database
        public static BindingList<String> GetAllCountryNamesAsString()
        {
            BindingList<Country> allCountries = GetAllCountries();
            BindingList<String> allUniqueCountries = new BindingList<String>();

            foreach (var country in allCountries)
            {
                // Ensures the List only contains a single reference to each country in the database
                if (!allUniqueCountries.Contains(country.CountryName))
                {
                    allUniqueCountries.Add(country.CountryName);
                } 
            }
            return allUniqueCountries;
        }

        // Returns the countryID and adds the country to the database
        public static int GetCountryIDAndAddCountryToDatabase(string country, DateTime createDate, string createdBy,
            DateTime lastUpdate, string lastUpdateBy)
        {
            int countryID = 0;

            // Handles what happens if the countryID already exists

            // Determines the SQL query
            string getCountryQuery = @"SELECT countryID FROM country
                                       WHERE country = @country";

            // Establishes a connection to the database with a querty to execute
            using (var command = new MySqlCommand(getCountryQuery, DBConnection.connection))
            {
                // Defines values for the @variables
                command.Parameters.AddWithValue("@country", country);

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

        // Returns a List<String> of all a single country name when passed a countryID
        public static List<String> GetCountryName(int countryID)
        {
            List<String> country = new List<String>();
            string query = @"SELECT country
                             FROM country
                             WHERE countryId = @countryID;";

            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                command.Parameters.AddWithValue("@countryID", countryID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        country.Add(reader["country"].ToString());
                    }
                }
            }
            return country;
        }
    }
}
