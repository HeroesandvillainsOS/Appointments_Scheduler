using Appointments_Scheduler.Database_Table_Classes;
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

        private void btn_Add_Click(object sender, EventArgs e)
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
            DateTime lastUpdate = Convert.ToDateTime(txtBox_LastUpdate.Text);
            string lastUpdateBy = txtBox_LastUpdateBy.Text;

            // Enforces formatting rules for the appointment data

            // Start cannot be in an invalid DateTime format
            if (!DateTime.TryParse(txtBox_Start.Text, out start))
            {
                MessageBox.Show("Appointment Start is using an invalid date format.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            // End cannot be in an invalid DateTime format
            if (!DateTime.TryParse(txtBox_End.Text, out end))
            {
                MessageBox.Show("Appointment End is using an invalid date format.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }

            // Variables for enforcing Appointment Start and End DateTime rules
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEst = TimeZoneInfo.ConvertTimeFromUtc(start, estZone);
            DateTime endEst = TimeZoneInfo.ConvertTimeFromUtc(end, estZone);
            TimeSpan startOfWorkDay = new TimeSpan(9, 0, 0);
            TimeSpan endOfWorkDay = new TimeSpan(17, 0, 0);
            TimeSpan inputStartTime = startEst.TimeOfDay;
            TimeSpan inputEndTime = endEst.TimeOfDay;
            DayOfWeek startDayOfWeek = startEst.DayOfWeek;
            DayOfWeek endDayOfWeek = endEst.DayOfWeek;

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

            // Create Date cannot be left blank
            if (string.IsNullOrWhiteSpace(txtBox_CreateDate.Text) || !DateTime.TryParse(txtBox_CreateDate.Text, out createDate))
            {
                createDate = DateTime.UtcNow;  // Ensures today's date is used if the field is left blank
            }

            // Last Update cannot be left blank
            if (string.IsNullOrWhiteSpace(txtBox_LastUpdate.Text) || !DateTime.TryParse(txtBox_LastUpdate.Text, out lastUpdate))
            {
                lastUpdate = DateTime.UtcNow;  // Ensures today's date is used if the field is left blank
            }

            //DateTime utcStart = TimeZoneInfo.ConvertTimeToUtc(start);
            //DateTime utcEnd = TimeZoneInfo.ConvertTimeToUtc(end);

        }
    }
}
