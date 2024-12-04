using Appointments_Scheduler.Database_Table_Classes;
using Appointments_Scheduler.Forms.Customer_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointments_Scheduler.Appointment_Forms
{
    public partial class Edit_Appointment : Form
    {

        public BindingList<Customer> AllCustomers { get; private set; }

        public BindingList<User> AllUsers { get; private set; }

        public Edit_Appointment(List<String> appointmentDetails)
        {
            InitializeComponent();
            AllCustomers = Customer.GetAllCustomers();
            AllUsers = User.GetAllUsers();

            txtBox_AppointmentID.Text = appointmentDetails[0];
            cmboBox_CustomerName.Text = Customer.GetCustomerNameFromCustomerID(Convert.ToInt32(appointmentDetails[1]));
            cmboBox_UserName.Text = User.GetUserNameFromUserID(Convert.ToInt32(appointmentDetails[2]));
            txtBox_Title.Text = appointmentDetails[3];
            txtBox_Description.Text = appointmentDetails[4];
            txtBox_Location.Text = appointmentDetails[5];
            txtBox_Type.Text = appointmentDetails[7];
            txtBox_Url.Text = appointmentDetails[8];
            txtBox_Start.Text = appointmentDetails[9];
            txtBox_End.Text = appointmentDetails[10];
            txtBox_CreateDate.Text = appointmentDetails[11];
            txtBox_CreatedBy.Text = appointmentDetails[12];
            txtBox_LastUpdate.Text = appointmentDetails[13];
            txtBox_LastUpdateBy.Text = appointmentDetails[14];

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

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            int appointmentID = Convert.ToInt32(txtBox_AppointmentID.Text);
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
            List<(DateTime, DateTime)> allAppointmentTimes = Appointment.GetAllAppointmentTimes(appointmentID);
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
                createDate = DateTime.Now.Date;  // Ensures today's date is used if the field is left blank
            }

            // Last Update cannot be left blank
            if (string.IsNullOrWhiteSpace(txtBox_LastUpdate.Text) || !DateTime.TryParse(txtBox_LastUpdate.Text, out lastUpdate))
            {
                lastUpdate = DateTime.Now.Date;  // Ensures today's date is used if the field is left blank
            }

            // Create Date and Last Update must be converted from local time to UTC time
            createDate = TimeZoneInfo.ConvertTime(createDate, TimeZoneInfo.Local, utcZone);
            lastUpdate = TimeZoneInfo.ConvertTime(lastUpdate, TimeZoneInfo.Local, utcZone);

            // Asks the user to verify they want to permanently edit this appointment
            DialogResult result = MessageBox.Show(@"Are you sure you want to edit this appointment in the database? This action cannot be undone.",
                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return;
            }

             // Creates a new appointment object
            Appointment newAppointmentWithUTC = new Appointment(appointmentID, customerID, userID, title, description, location, contact,
                type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy);

            // Updates the Database with the appointment's new values
            Appointment.EditAppointmentInDatabase(newAppointmentWithUTC);

            // Converts the UTC times to local times so they display correctly on the Data Grid View
            DateTime startLocal = TimeZoneInfo.ConvertTimeFromUtc(start, TimeZoneInfo.Local);
            DateTime endLocal = TimeZoneInfo.ConvertTimeFromUtc(end, TimeZoneInfo.Local);

            // Uses LINQ to find the first appointment in the Binding List that matches the edited appointment's appointmentID
            var appointmentToEdit = Appointment_Records.Instance.AllAppointments.FirstOrDefault(a => a.AppointmentID == appointmentID);

            if (appointmentToEdit != null)
            {
                // Updates the Binding List record for the appointment being edited
                appointmentToEdit.AppointmentID = appointmentID;
                appointmentToEdit.CustomerID = customerID;
                appointmentToEdit.UserID = userID;
                appointmentToEdit.Title = title;
                appointmentToEdit.Description = description;
                appointmentToEdit.Location = location;
                appointmentToEdit.Contact = contact;
                appointmentToEdit.Type = type;
                appointmentToEdit.Url = url;
                appointmentToEdit.Start = startLocal;
                appointmentToEdit.End = endLocal;
                appointmentToEdit.CreateDate = createDate;
                appointmentToEdit.CreatedBy = createdBy;
                appointmentToEdit.LastUpdate = lastUpdate;
                appointmentToEdit.LastUpdateBy = lastUpdateBy;
            }
            else
            {
                MessageBox.Show("The appointment you're trying to edit cannot be found.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Refreshes the Data Grid View
            Appointment_Records.Instance.DgvAppointments.Refresh();

            // Ensures the form closes after adding the customer data
            this.Close();
        }
    }
}
