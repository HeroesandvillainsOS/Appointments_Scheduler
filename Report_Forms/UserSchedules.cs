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

namespace Appointments_Scheduler.Report_Forms
{
    public partial class UserSchedules : Form
    {
        public static UserSchedules Instance { get; private set; }

        public BindingList<Appointment> UserFilteredAppointments { get; private set; }

        public DataGridView Dgv_UserSchedules => dgv_UserSchedules;

        string CurrentlySelectedUser { get; set; }

        string CurrentlySelectedTimeframe { get; set; }

        public UserSchedules()
        {
            InitializeComponent();

            Instance = this;

            // Data Grid View settings
            dgv_UserSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_UserSchedules.ReadOnly = true;
            dgv_UserSchedules.MultiSelect = false;
        }

        // Unselects the automatically selected first row on the Data Grid View
        private void OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_UserSchedules.ClearSelection();
        }

        // Handles the User Name dropdown event
        private void cmboBox_Users_DropDown(object sender, EventArgs e)
        {
            cmboBox_Users.Items.Clear();

            BindingList<User> allUsers = User.GetAllUsers();

            // Uses a Lambda expression to add each user's userName to the Combo Box dropdown
            allUsers.ToList().ForEach(user => cmboBox_Users.Items.Add(user.UserName));

            CurrentlySelectedUser = cmboBox_Users.Text;
        }

        // Handles the Time Frame dropdown event
        private void cmboBox_Timeframe_DropDown(object sender, EventArgs e)
        {
            cmboBox_Timeframe.Items.Clear();

            string[] timeframeChoices = new string[] { "Today", "This Week", "This Month" };

            foreach (string timeFrameChoice in timeframeChoices)
            {
                cmboBox_Timeframe.Items.Add(timeFrameChoice);
            }
        }

        // Ensures the user User Name selection is tracked live as the selection is made or changes
        private void cmboBox_Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentlySelectedUser = cmboBox_Users.SelectedItem?.ToString();
        }

        // Ensures the user Time Frame selection is tracked live as the selection is made or changes
        private void cmboBox_Timeframe_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentlySelectedTimeframe = cmboBox_Timeframe.SelectedItem?.ToString();
        }

        // Handles the Generate Report click event
        private void btn_GenerateReport_Click(object sender, EventArgs e)
        {
            string userName = cmboBox_Users.Text;
            string timeFrame = cmboBox_Timeframe.Text;
            int totalResults = 0;
            DateTime today = DateTime.Today;
            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek); // Sunday of this week
            DateTime endOfWeek = startOfWeek.AddDays(7); // Next Sunday
            DateTime firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);

            bool isTimeFrameToday = false;
            bool isTimeFrameThisWeek = false;
            bool isTimeFrameThisMonth = false;

            // a User Name and a Time Frame must be selected to generate a report
            if (userName == "--" || timeFrame == "--")
            {
                MessageBox.Show("Please select a valid User Name and Time Frame.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // Determines the currently selected Time Frame
            switch (timeFrame)
            {
                case "Today": isTimeFrameToday = true; break;
                case "This Week": isTimeFrameThisWeek = true; break;
                case "This Month": isTimeFrameThisMonth = true; break;
            }

            // Retrieves all of the selected user's appointments
            BindingList<Appointment> allUserAppointments = Appointment.GetAllAppointmentsForASpecificUser(userName);

            // Filters appointments based on the selected Time Frame
            List<Appointment> filteredAppointments = new List<Appointment>();

            // Uses Lambda expressions to add appointments to a List
            if (isTimeFrameToday)
            {
                allUserAppointments
                    .Where(appointment => appointment.Start == today)
                    .ToList()
                    .ForEach(appointment =>
                    {
                        filteredAppointments.Add(appointment);
                        totalResults++;
                    }
                 );
            }

            if (isTimeFrameThisWeek)
            {
                allUserAppointments
                   .Where(appointment => appointment.Start >= startOfWeek && appointment.Start < endOfWeek)
                   .ToList()
                    .ForEach(appointment =>
                    {
                        filteredAppointments.Add(appointment);
                        totalResults++;
                    }
                 );
            }

            if (isTimeFrameThisMonth)
            {
                allUserAppointments
                  .Where(appointment => appointment.Start >= firstDayOfMonth && appointment.Start < firstDayOfNextMonth)
                  .ToList()
                   .ForEach(appointment =>
                   {
                       filteredAppointments.Add(appointment);
                       totalResults++;
                   }
                 );
            }

            // Displays the generated report
            txtBox_TotalResults.Text = totalResults.ToString();
            UserSchedules.Instance.dgv_UserSchedules.DataSource = filteredAppointments;
        }
    }
}
