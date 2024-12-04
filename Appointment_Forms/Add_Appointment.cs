using Appointments_Scheduler.Database_Table_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Appointments_Scheduler.Appointment_Forms
{
    public partial class Add_Appointment : Form
    {
        public BindingList<Customer> AllCustomers { get; private set; }

        public BindingList<User> AllUsers { get; private set; }

        public Add_Appointment()
        {
            InitializeComponent();
            AllCustomers = Customer.GetAllCustomers();
            AllUsers = User.GetAllUsers();

            // Deselects the Create Date text box which is highlighted by default
            txtBox_CreateDate.Select(0, 0);
        }

        // Ensures only current customers in the database appear in the Customer Name dropdown
        private void cmboBox_CustomerName_DropDown(object sender, EventArgs e)
        {
            cmboBox_CustomerName.DataSource = null;
            List<String> allCustomerNames = Customer.GetAllCustomerNames(AllCustomers);
            cmboBox_CustomerName.DataSource = allCustomerNames;
        }

        // Ensures only current users in the database appear in the User Name dropdown
        private void cmboBox_UserName_DropDown(object sender, EventArgs e)
        {
            cmboBox_UserName.DataSource = null;
            List<String> allUserNames = User.GetAllUserNames(AllUsers);
            cmboBox_UserName.DataSource = allUserNames;
        }

        // Handles the Add button click event
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string customerName = cmboBox_CustomerName.Text;
            int customerID = Convert.ToInt32(Customer.GetCustomerIDFromCustomerName(customerName));
            string userName = cmboBox_UserName.Text;
            int userID = Convert.ToInt32(User.GetUserIDFromUserName(userName));
            string title = txtBox_Title.Text;
            string description = txtBox_Description.Text;   
            string location = txtBox_Location.Text;
            string contact = customerName;
            string type = txtBox_Type.Text;
            string url = txtBox_Url.Text;
            DateTime start;
            DateTime end;
            DateTime createDate;
            string createdBy = txtBox_CreatedBy.Text;
            DateTime lastUpdate;
            string lastUpdateBy = txtBox_LastUpdateBy.Text;

            // Enforces formatting rules for the appointment data

            // Customer Name cannot be left blank
            if (String.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Customer Name cannot be left blank.", "Warning", MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                return;
            }

            // User Name cannot be left blank
            if (String.IsNullOrEmpty(userName))
            {
                MessageBox.Show("User Name cannot be left blank.", "Warning", MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                return;
            }

            // Appointment Type cannot be left blank
            if (String.IsNullOrEmpty(type))
            {
                MessageBox.Show("Appointment Type cannot be left blank.", "Warning", MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                return;
            }

            // Start time cannot be in an invalid DateTime format
            if (!DateTime.TryParse(txtBox_Start.Text, out start))
            {
                MessageBox.Show("Appointment Start is using an invalid date format.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            // End time cannot be in an invalid DateTime format
            if (!DateTime.TryParse(txtBox_End.Text, out end))
            {
                MessageBox.Show("Appointment End is using an invalid date format.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            // Variables for converting local time to EST time
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEst = TimeZoneInfo.ConvertTime(start, TimeZoneInfo.Local, estZone);
            DateTime endEst = TimeZoneInfo.ConvertTime(end, TimeZoneInfo.Local, estZone);
            TimeSpan startOfWorkDay = new TimeSpan(9, 0, 0);
            TimeSpan endOfWorkDay = new TimeSpan(17, 0, 0);
            TimeSpan inputStartTime = startEst.TimeOfDay;
            TimeSpan inputEndTime = endEst.TimeOfDay;

            // Variables for verifying the days of the week
            DayOfWeek startDayOfWeek = startEst.DayOfWeek;
            DayOfWeek endDayOfWeek = endEst.DayOfWeek;

            // Variable for converting local time to UTC time
            TimeZoneInfo utcZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            // Appointments cannot start before 9AM EST or after 5PM EST
            if (inputStartTime < startOfWorkDay || inputStartTime > endOfWorkDay)
            {
                MessageBox.Show("Appointments cannot start before 9AM or after 5PM EST.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Appointments cannot end before 9AM EST or after 5PM EST
            if (inputEndTime < startOfWorkDay || inputEndTime > endOfWorkDay)
            {
                MessageBox.Show("Appointments cannot end before 9AM or after 5PM EST.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Appointment end times must be after appointment start times
            if (inputStartTime >= inputEndTime)
            {
                MessageBox.Show("Appointment start time must be before end time.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            // Appointments cannot be made on Saturdays or Sundays
            if (startDayOfWeek == DayOfWeek.Saturday || startDayOfWeek == DayOfWeek.Sunday || endDayOfWeek == DayOfWeek.Saturday ||
                endDayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Appointments cannot occur on Saturdays or Sundays.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            // Appointments cannot overlap one another
            List<(DateTime, DateTime)> allAppointmentTimes = Appointment.GetAllAppointmentTimes();
            bool isAppointmentOverlappingAnyAppointments = Appointment.IsAppointmentOverlappingAnyAppointments(start, end, 
                allAppointmentTimes);

            if (isAppointmentOverlappingAnyAppointments)
            {
                MessageBox.Show("New appointments cannot overlap any existing appointments.", "Warning", MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                return;
            }

            // Appointments must be saved to the Database in UTC time
            DateTime utcStart = TimeZoneInfo.ConvertTimeToUtc(start);
            DateTime utcEnd = TimeZoneInfo.ConvertTimeToUtc(end);
            start = utcStart;
            end = utcEnd;

            // Create Date cannot be left blank
            if (string.IsNullOrWhiteSpace(txtBox_CreateDate.Text) || !DateTime.TryParse(txtBox_CreateDate.Text, out createDate))
            {
                createDate = DateTime.Now;  // Ensures today's date is used if the field is left blank
            }

            // Last Update cannot be left blank
            if (string.IsNullOrWhiteSpace(txtBox_LastUpdate.Text) || !DateTime.TryParse(txtBox_LastUpdate.Text, out lastUpdate))
            {
                lastUpdate = DateTime.Now;  // Ensures today's date is used if the field is left blank
            }

            // Create Date and Last Update must be converted from local time to UTC time
            createDate = TimeZoneInfo.ConvertTime(createDate, TimeZoneInfo.Local, utcZone);
            lastUpdate = TimeZoneInfo.ConvertTime(lastUpdate, TimeZoneInfo.Local, utcZone);

            // Asks the user to verify they want to permanently add this appointment
            DialogResult result = MessageBox.Show(@"Are you sure you want to add this appointment to the database? This action cannot be undone.",
                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Creates a new appointment object
            Appointment newAppointmentWithUTC = new Appointment(customerID, userID, title, description, location, contact,
                type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy);

            // Adds the new appointment to the Database and retrieves the auto-generated appointmentID
            newAppointmentWithUTC.AppointmentID = Appointment.AddAppointmentToDatabase(newAppointmentWithUTC);
            int newAppointmentID = newAppointmentWithUTC.AppointmentID;

            // Converts the UTC times to local times so they display correctly on the Data Grid View
            DateTime startLocal = TimeZoneInfo.ConvertTimeFromUtc(start, TimeZoneInfo.Local);
            DateTime endLocal = TimeZoneInfo.ConvertTimeFromUtc(end, TimeZoneInfo.Local);
            DateTime createDateLocal = TimeZoneInfo.ConvertTimeFromUtc(createDate, TimeZoneInfo.Local);
            DateTime lastUpdateLocal = TimeZoneInfo.ConvertTimeFromUtc(lastUpdate, TimeZoneInfo.Local);

            // Adds the new appointment to the BindingList instance with the returned appointmentID
            Appointment newAppointmentWithLocalTime = new Appointment(newAppointmentID, customerID, userID, title, description, 
                location, contact, type, url, startLocal, endLocal, createDateLocal, createdBy, lastUpdateLocal, lastUpdateBy);
            
            Appointment_Records.Instance.AllAppointments.Add(newAppointmentWithLocalTime);

            // Ensures the form closes after adding the customer data
            this.Close();
        }
    }
}
