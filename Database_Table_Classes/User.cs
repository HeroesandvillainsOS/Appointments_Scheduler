using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

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
