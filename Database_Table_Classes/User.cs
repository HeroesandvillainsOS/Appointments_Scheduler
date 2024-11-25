using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments_Scheduler
{
    internal class User
    {
        // Stores the values of the user database table
        public int UserId { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate {  get; set; }
        public string LastUpdateBy { get; set; }

        // Returns a List<User> of all records in the user database table
        public List<User> GetUsers()
        {
            // Creates the List
            var users = new List<User>();
            // Establishes the SQL query
            string query = "SELECT userID, userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy FROM user";

            // Creates a new MySQLCommand instance with the established query and connection
            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                // Creates a reader object for the MySQLCommand instance
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Iterates through the database table
                        var user = new User
                        {
                            UserId = reader.GetInt32("userId"),
                            UserName = reader.GetString("username"),
                            Password = reader.GetString("password"),
                            Active = reader.GetInt32("active"),
                            CreateDate = reader.GetDateTime("createDate"),
                            CreatedBy = reader.GetString("createdBy"),
                            LastUpdate = reader.GetDateTime("lastUpdate"),
                            LastUpdateBy = reader.GetString("lastUpdateBy")
                        };
                        // Adds a new user to the List
                        users.Add(user);
                    }
                }
            }
            // Returns the List
            return users;
        }

    }
}
