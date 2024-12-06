using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Appointments_Scheduler.Database_Table_Classes
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        // Constructor for existing appointments (requires appointmentID)
        public Appointment(int appointmentID, int customerID, int userID, string title, string description, string location,
            string contact, string type, string url, DateTime start, DateTime end, DateTime createDate, string createdBy,
            DateTime lastUpdate, string lastUpdateBy)
        {
            AppointmentID = appointmentID;
            CustomerID = customerID;
            UserID = userID;
            Title = title;
            Description = description;
            Location = location;
            Contact = contact;
            Type = type;
            Url = url;
            Start = start;
            End = end;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }

        // Constructor for new appointments (doesn't require appointmentID)
        public Appointment(int customerID, int userID, string title, string description, string location,
            string contact, string type, string url, DateTime start, DateTime end, DateTime createDate, string createdBy,
            DateTime lastUpdate, string lastUpdateBy)
        {
            CustomerID = customerID;
            UserID = userID;
            Title = title;
            Description = description;
            Location = location;
            Contact = contact;
            Type = type;
            Url = url;
            Start = start;
            End = end;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }

        // Returns a Binding List of all appointments from the appointment database table
        public static BindingList<Appointment> GetAllAppointments()
        {
            // Establishes the SQL query
            string query = "SELECT * FROM appointment";

            // Creates a new MySQLCommand instance with the established query and database connection
            var command = new MySqlCommand(query, DBConnection.connection);

            // Creates a reader object for the MySQLCommand instance
            var reader = command.ExecuteReader();

            // Creates a Binding List to store the customer table data
            BindingList<Appointment> allAppointments = new BindingList<Appointment>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    allAppointments.Add(new Appointment(
                        reader.GetInt32("appointmentId"),
                        reader.GetInt32("customerId"),
                        reader.GetInt32("userId"),
                        reader.GetString("title"),
                        reader.GetString("description"),
                        reader.GetString("location"),
                        reader.GetString("contact"),
                        reader.GetString("type"),
                        reader.GetString("url"),
                        // Set DateTimeKind explicitly for each DateTime field
                        DateTime.SpecifyKind(reader.GetDateTime("start"), DateTimeKind.Utc),
                        DateTime.SpecifyKind(reader.GetDateTime("end"), DateTimeKind.Utc),
                        DateTime.SpecifyKind(reader.GetDateTime("createDate"), DateTimeKind.Utc),
                        reader.GetString("createdBy"),
                        DateTime.SpecifyKind(reader.GetDateTime("lastUpdate"), DateTimeKind.Utc),
                        reader.GetString("lastUpdateBy")
                    ));
                }
            }
            else
            {
                MessageBox.Show("The appointment table has no rows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reader.Close();

            // Returns a Binding List of all appointments from the appointment database table
            return allAppointments;
        }

        public static bool UserHasAppointmentWithin15Minutes(string username, DateTime currentTime)
        {
            DateTime currentTimePlus15Minutes = currentTime.AddMinutes(15);

            // Retrieves the userID from the input userName
            string user = User.GetUserIDFromUserName(username);
            int userID = Convert.ToInt32(user);

            // Establishes the SQL query
            string query = @"SELECT start 
                     FROM appointment
                     WHERE userId = @userID";

            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                // Defines the @variables values
                command.Parameters.AddWithValue("@userID", userID);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return false;

                    while (reader.Read())
                    {
                        // Converts the times from UTC to Local time
                        DateTime appointmentUtc = DateTime.SpecifyKind(reader.GetDateTime("start"), DateTimeKind.Utc);
                        DateTime appointmentLocal = TimeZoneInfo.ConvertTimeFromUtc(appointmentUtc, TimeZoneInfo.Local);

                        // Checks if the appointment is within 15 minutes
                        if (appointmentLocal >= currentTime && appointmentLocal <= currentTimePlus15Minutes)
                        {
                            return true; 
                        }
                    }
                }
            }
            return false;
        }


        // Returns a List of tuples containing appointment start and end times
        public static List<(DateTime Start, DateTime End)> GetAllAppointmentTimes()
        {
            // Establishes the SQL query
            string query = @"SELECT * FROM appointment";

            // Creates a new MySQLCommand instance with the established query and database connection
            var command = new MySqlCommand(query, DBConnection.connection);

            // Creates a reader object for the MySQLCommand instance
            var reader = command.ExecuteReader();

            // Creates a List to store the appointment start and end times as tuples
            List<(DateTime Start, DateTime End)> allAppointmentTimes = new List<(DateTime Start, DateTime End)>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // Retrieves the times as UTC time
                    DateTime start = reader.GetDateTime("start");
                    DateTime end = reader.GetDateTime("end");

                    // Converts the times from UTC to local time
                    start = TimeZoneInfo.ConvertTimeFromUtc(start, TimeZoneInfo.Local);
                    end = TimeZoneInfo.ConvertTimeFromUtc(end, TimeZoneInfo.Local);

                    // Adds the times to the List
                    allAppointmentTimes.Add((start, end));
                }
            }
            else
            {
                MessageBox.Show("The appointment table has no rows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Close the reader after use
            reader.Close();
            return allAppointmentTimes;
        }

        // Returns a List of tuples containing appointment start and end times EXCLUDING the input appointmentID
        public static List<(DateTime Start, DateTime End)> GetAllAppointmentTimes(int appointmentID)
        {
            // Establishes the SQL query
            string query = @"SELECT * FROM appointment
                             WHERE appointmentId != @appointmentID";

            // Creates a new MySQLCommand instance with the established query and database connection
            var command = new MySqlCommand(query, DBConnection.connection);

            // Defines the @variable values
            command.Parameters.AddWithValue("@appointmentID", appointmentID);

            // Creates a reader object for the MySQLCommand instance
            var reader = command.ExecuteReader();

            // Creates a List to store the appointment start and end times as tuples
            List<(DateTime Start, DateTime End)> allAppointmentTimes = new List<(DateTime Start, DateTime End)>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // Retrieves the times as UTC time
                    DateTime start = reader.GetDateTime("start");
                    DateTime end = reader.GetDateTime("end");

                    // Converts the times from UTC to local time
                    start = TimeZoneInfo.ConvertTimeFromUtc(start, TimeZoneInfo.Local);
                    end = TimeZoneInfo.ConvertTimeFromUtc(end, TimeZoneInfo.Local);

                    // Adds the times to the List
                    allAppointmentTimes.Add((start, end));
                }
            }
            else
            {
                MessageBox.Show("The appointment table has no rows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Close the reader after use
            reader.Close();
            return allAppointmentTimes;
        }

        // Returns a Binding List of appointments based on the user's Filter Appointments criteria
        public static BindingList<Appointment> GetFilteredAppointments(string month, string day, string year)
        {
            int inputMonth;

            switch (month)
            {
                case "January": inputMonth = 1; break;
                case "February": inputMonth = 2; break;
                case "March": inputMonth = 3; break;
                case "April": inputMonth = 4; break;
                case "May": inputMonth = 5; break;
                case "June": inputMonth = 6; break;
                case "July": inputMonth = 7; break;
                case "August": inputMonth = 8; break;
                case "September": inputMonth = 9; break;
                case "October": inputMonth = 10; break;
                case "November": inputMonth = 11; break;
                case "December": inputMonth = 12; break;
                default:
                    throw new ArgumentException("Invalid month provided.");
            }

            int inputDay = int.Parse(day);
            int inputYear = int.Parse(year);

            // Establishes the SQL query
            string query = @"SELECT * 
                            FROM appointment
                            WHERE MONTH(start) = @Month
                            AND DAY(start) = @Day
                            AND YEAR(start) = @Year";

            // Creates a new MySQLCommand instance with the established query and database connection
            var command = new MySqlCommand(query, DBConnection.connection);

            // Defines the @variable values
            command.Parameters.AddWithValue("@Month", inputMonth);
            command.Parameters.AddWithValue("@Day", inputDay);
            command.Parameters.AddWithValue("@Year", inputYear);

            // Creates a reader object for the MySQLCommand instance
            var reader = command.ExecuteReader();

            // Creates a Binding List to store the returned appointments
            BindingList<Appointment> filteredAppointments = new BindingList<Appointment>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    filteredAppointments.Add(new Appointment(
                         reader.GetInt32("appointmentId"),
                         reader.GetInt32("customerId"),
                         reader.GetInt32("userId"),
                         reader.GetString("title"),
                         reader.GetString("description"),
                         reader.GetString("location"),
                         reader.GetString("contact"),
                         reader.GetString("type"),
                         reader.GetString("url"),
                         // Set DateTimeKind explicitly for each DateTime field
                         DateTime.SpecifyKind(reader.GetDateTime("start"), DateTimeKind.Utc),
                         DateTime.SpecifyKind(reader.GetDateTime("end"), DateTimeKind.Utc),
                         DateTime.SpecifyKind(reader.GetDateTime("createDate"), DateTimeKind.Utc),
                         reader.GetString("createdBy"),
                         DateTime.SpecifyKind(reader.GetDateTime("lastUpdate"), DateTimeKind.Utc),
                         reader.GetString("lastUpdateBy")
                    ));
                }
            }
            else
            {
                MessageBox.Show("No appointments match this criteria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Close the reader after use and returns the Binding List
            reader.Close();
            return filteredAppointments;
        }

        // Returns a Binding List of appointments based on the user's Filter Appointments criteria
        public static BindingList<Appointment> GetFilteredAppointments(string month, string year)
        {
            int inputMonth;

            switch (month)
            {
                case "January": inputMonth = 1; break;
                case "February": inputMonth = 2; break;
                case "March": inputMonth = 3; break;
                case "April": inputMonth = 4; break;
                case "May": inputMonth = 5; break;
                case "June": inputMonth = 6; break;
                case "July": inputMonth = 7; break;
                case "August": inputMonth = 8; break;
                case "September": inputMonth = 9; break;
                case "October": inputMonth = 10; break;
                case "November": inputMonth = 11; break;
                case "December": inputMonth = 12; break;
                default:
                    throw new ArgumentException("Invalid month provided.");
            }

            int inputYear = int.Parse(year);

            // Establishes the SQL query
            string query = @"SELECT * 
                            FROM appointment
                            WHERE MONTH(start) = @Month
                            AND YEAR(start) = @Year";

            // Creates a new MySQLCommand instance with the established query and database connection
            var command = new MySqlCommand(query, DBConnection.connection);

            // Defines the @variable values
            command.Parameters.AddWithValue("@Month", inputMonth);
            command.Parameters.AddWithValue("@Year", inputYear);

            // Creates a reader object for the MySQLCommand instance
            var reader = command.ExecuteReader();

            // Creates a Binding List to store the returned appointments
            BindingList<Appointment> filteredAppointments = new BindingList<Appointment>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    filteredAppointments.Add(new Appointment(
                         reader.GetInt32("appointmentId"),
                         reader.GetInt32("customerId"),
                         reader.GetInt32("userId"),
                         reader.GetString("title"),
                         reader.GetString("description"),
                         reader.GetString("location"),
                         reader.GetString("contact"),
                         reader.GetString("type"),
                         reader.GetString("url"),
                         // Set DateTimeKind explicitly for each DateTime field
                         DateTime.SpecifyKind(reader.GetDateTime("start"), DateTimeKind.Utc),
                         DateTime.SpecifyKind(reader.GetDateTime("end"), DateTimeKind.Utc),
                         DateTime.SpecifyKind(reader.GetDateTime("createDate"), DateTimeKind.Utc),
                         reader.GetString("createdBy"),
                         DateTime.SpecifyKind(reader.GetDateTime("lastUpdate"), DateTimeKind.Utc),
                         reader.GetString("lastUpdateBy")
                    ));
                }
            }
            else
            {
                MessageBox.Show("No appointments match this criteria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Close the reader after use and returns the Binding List
            reader.Close();
            return filteredAppointments;
        }

        // Returns a bool indicating whether new or edited appointments overlap any existing appointments
        public static bool IsAppointmentOverlappingAnyAppointments(DateTime newStart, DateTime newEnd,
            List<(DateTime start, DateTime end)> allAppointments)
        {
            foreach (var appointment in allAppointments)
            {
                if ((newStart >= appointment.start && newStart <= appointment.end) ||
                    (newEnd >= appointment.start && newEnd <= appointment.end) ||
                    (newStart < appointment.start && newEnd > appointment.end))

                {
                    return true;
                }
            }
            return false;
        }

        // Returns a string List of a single appointment's data from the selected Data Grid View row
        public static List<String> GetSelectedRowData(DataGridViewRow selectedRow)
        {
            // Extracts the data from the row
            string appointmentID = selectedRow.Cells["appointmentID"].Value.ToString();
            string customerID = selectedRow.Cells["customerID"].Value.ToString();
            string userID = selectedRow.Cells["userID"].Value.ToString();
            string title = selectedRow.Cells["title"].Value.ToString();
            string description = selectedRow.Cells["description"].Value.ToString();
            string location = selectedRow.Cells["location"].Value.ToString();
            string contact = selectedRow.Cells["contact"].Value.ToString();
            string type = selectedRow.Cells["type"].Value.ToString();
            string url = selectedRow.Cells["url"].Value.ToString();
            string start = selectedRow.Cells["start"].Value.ToString();
            string end = selectedRow.Cells["end"].Value.ToString();
            string createDate = selectedRow.Cells["createDate"].Value.ToString();
            string createdBy = selectedRow.Cells["createdBy"].Value.ToString();
            string lastUpdate = selectedRow.Cells["lastUpdate"].Value.ToString();
            string lastUpdateBy = selectedRow.Cells["lastUpdateBy"].Value.ToString();

            // Creates a string List of the selected row's customer data
            List<String> appointmentDetails = new List<String>();
            appointmentDetails.Add(appointmentID);
            appointmentDetails.Add(customerID);
            appointmentDetails.Add(userID);
            appointmentDetails.Add(title);
            appointmentDetails.Add(description);
            appointmentDetails.Add(location);
            appointmentDetails.Add(contact);
            appointmentDetails.Add(type);
            appointmentDetails.Add(url);
            appointmentDetails.Add(start);
            appointmentDetails.Add(end);
            appointmentDetails.Add(createDate);
            appointmentDetails.Add(createdBy);
            appointmentDetails.Add(lastUpdate);
            appointmentDetails.Add(lastUpdateBy);

            // Returns the List
            return appointmentDetails;
        }

        // Inserts the added appointment into the appointment database table and returns the new customerID
        public static int AddAppointmentToDatabase(Appointment appointment)
        {
            // Establishes the SQL query
            string query = @"INSERT INTO appointment (appointmentId, customerId, userId, title, description, location, contact, 
                                    type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
                            VALUES (@appointmentID, @customerID, @userID, @title, @description, @location, @contact, 
                                    @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);
                            SELECT LAST_INSERT_ID();"; // Gets the auto-generated customerID

            // Opens a connection to the database and executes the query
            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                // Defines the @ variable values
                command.Parameters.AddWithValue("@appointmentID", appointment.AppointmentID);
                command.Parameters.AddWithValue("@customerID", appointment.CustomerID);
                command.Parameters.AddWithValue("@userID", appointment.UserID);
                command.Parameters.AddWithValue("@title", appointment.Title);
                command.Parameters.AddWithValue("@description", appointment.Description);
                command.Parameters.AddWithValue("@location", appointment.Location);
                command.Parameters.AddWithValue("@contact", appointment.Contact);
                command.Parameters.AddWithValue("@type", appointment.Type);
                command.Parameters.AddWithValue("@url", appointment.Url);
                command.Parameters.AddWithValue("@start", appointment.Start);
                command.Parameters.AddWithValue("@end", appointment.End);
                command.Parameters.AddWithValue("@createDate", appointment.CreateDate);
                command.Parameters.AddWithValue("@createdBy", appointment.CreatedBy);
                command.Parameters.AddWithValue("@lastUpdate", appointment.LastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", appointment.LastUpdateBy);

                // Returns the auto-generated customerID and executes the SQL command
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // Edits an appointment in the database
        public static void EditAppointmentInDatabase(Appointment appointment)
        {
            // Establishes the SQL query
            string query = @"UPDATE appointment 
                             SET customerId = @customerID, userId = @userID, title = @title, 
                                 description = @description, location = @location, contact = @contact, type = @type, url = @url, 
                                 start = @start, end = @end, createDate = @createDate, createdBy = @createdBy, 
                                 lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy
                             WHERE appointmentId = @appointmentID";

            // Opens a connection to the database and executes the query
            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                // Defines the @ variable values
                command.Parameters.AddWithValue("@appointmentID", appointment.AppointmentID);
                command.Parameters.AddWithValue("@customerID", appointment.CustomerID);
                command.Parameters.AddWithValue("@userID", appointment.UserID);
                command.Parameters.AddWithValue("@title", appointment.Title);
                command.Parameters.AddWithValue("@description", appointment.Description);
                command.Parameters.AddWithValue("@location", appointment.Location);
                command.Parameters.AddWithValue("@contact", appointment.Contact);
                command.Parameters.AddWithValue("@type", appointment.Type);
                command.Parameters.AddWithValue("@url", appointment.Url);
                command.Parameters.AddWithValue("@start", appointment.Start);
                command.Parameters.AddWithValue("@end", appointment.End);
                command.Parameters.AddWithValue("@createDate", appointment.CreateDate);
                command.Parameters.AddWithValue("@createdBy", appointment.CreatedBy);
                command.Parameters.AddWithValue("@lastUpdate", appointment.LastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", appointment.LastUpdateBy);

                // Executes the SQL command
                command.ExecuteNonQuery();
            }
        }

        // Deletes an appointment record from the Database
        public static void DeleteAppointmentFromDatabase(int appointmentID)
        {
            // Establishes the SQL query
            string query = "DELETE FROM appointment WHERE appointmentId = @appointmentID";

            // Opens a connection to the database and executes the query
            using (var command = new MySqlCommand(query, DBConnection.connection))
            {
                // Defines the @ variable values
                command.Parameters.AddWithValue("@appointmentID", appointmentID);

                // Executes the SQL command
                command.ExecuteNonQuery();
            }
        }
    }
}
