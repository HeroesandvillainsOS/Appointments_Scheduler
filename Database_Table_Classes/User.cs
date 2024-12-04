using Appointments_Scheduler.Database;
using Appointments_Scheduler.Database_Table_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Appointments_Scheduler
{
    public class User
    {
        // Stores the values of the user database table
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        public User(int userId, string userName, string password, int active, DateTime createDate, string createdBy,
            DateTime lastUpdate, string lastUpdateBy)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }

        // Returns a Binding List of all users from the user database table
        public static BindingList<User> GetAllUsers()
        {
            // Establishes the user database table SQL query
            string query = "SELECT * FROM user";

            // Creates a new MySQLCommand instance with the established query and database connection
            MySqlCommand command = new MySqlCommand(query, DBConnection.connection);

            // Creates a reader object for the MySQLCommand instance
            var reader = command.ExecuteReader();

            // Creates a Binding List to store the user table data
            BindingList<User> allUsers = new BindingList<User>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // Adds the user table data to the Binding List
                    allUsers.Add(new User(reader.GetInt32("userId"), reader.GetString("username"), reader.GetString("password"),
                            reader.GetInt32("active"), reader.GetDateTime("createDate"), reader.GetString("createdBy"),
                            reader.GetDateTime("lastUpdate"), reader.GetString("lastUpdateBy")));
                }
            }
            else
            {
                MessageBox.Show("The user table has no rows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            reader.Close();

            // Returns a Binding List of all users from the user database table
            return allUsers;
        }

        // Returns a List<String> of all user names from a BindingList<User>
        public static List<String> GetAllUserNames(BindingList<User> allUsers)
        {
            List<String> allUserNames = new List<String>();

            foreach (User user in allUsers)
            {
                allUserNames.Add(user.UserName);
            }

            return allUserNames;
        }

        // Returns a customer's name from a customerID
        public static string GetUserNameFromUserID(int userID)
        {
            string userName = null;

            // Establishes the SQL Query
            string query = @"SELECT userName
                             FROM user
                             WHERE userId = @userID";

            // Creates a new MySQL Command object and opens a connection to the database
            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                // Assigns the @variable's value
                command.Parameters.AddWithValue("@userID", userID);

                // Executes the query
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    userName = result.ToString();
                }
            }
            // Returns the result
            return userName;
        }

        // Returns a customerID as a string from a customer's name
        public static string GetUserIDFromUserName(string userName)
        {
            string userID = null;

            // Establishes the SQL Query
            string query = @"SELECT userID
                             FROM user
                             WHERE userName = @userName";

            // Creates a new MySQL Command object and opens a connection to the database
            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                // Assigns the @variable's value
                command.Parameters.AddWithValue("@userName", userName);

                // Executes the query
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    userID = result.ToString();
                }
            }
            // Returns the result
            return userID;
        }

        // Returns a string List of customer data from the selected Data Grid View row
        public static List<String> GetSelectedRowData(DataGridViewRow selectedRow)
        {
            // Extracts the data from the row
            string userID = selectedRow.Cells["userID"].Value.ToString();
            string userName = selectedRow.Cells["userName"].Value.ToString();
            string password = selectedRow.Cells["password"].Value.ToString();
            string active = selectedRow.Cells["active"].Value.ToString();
            string createDate = selectedRow.Cells["createDate"].Value.ToString();
            string createdBy = selectedRow.Cells["createdBy"].Value.ToString();
            string lastUpdate = selectedRow.Cells["lastUpdate"].Value.ToString();
            string lastUpdateBy = selectedRow.Cells["lastUpdateBy"].Value.ToString();

            // Creates a string List of the selected row's customer data
            List<String> userDetails = new List<String>();
            userDetails.Add(userID);
            userDetails.Add(userName);
            userDetails.Add(password);
            userDetails.Add(active);
            userDetails.Add(createDate);
            userDetails.Add(createdBy);
            userDetails.Add(lastUpdate);
            userDetails.Add(lastUpdateBy);

            // Returns the List
            return userDetails;
        }
    }
}
