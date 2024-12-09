using Appointments_Scheduler.Database_Table_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Appointments_Scheduler.Appointment_Forms
{
    public partial class Appointment_Records : Form
    {
        // Properties to ensure the Data Grid View can display live updates when the Binding List values change
        public static Appointment_Records Instance { get; private set; }

        public BindingList<Appointment> AllAppointments { get; private set; }

        public BindingList<Appointment> FilteredAppointments { get; private set; }

        public DataGridView DgvAppointments => dgv_Appointments;

        public string CurrentlySelectedMonth { get; private set; }

        public string CurrentlySelectedDay { get; private set; }

        public string CurrentlySelectedYear { get; private set; }

        public bool IsLeapYear { get; private set; } = false;

        public Appointment_Records()
        {
            InitializeComponent();

            Instance = this;

            // Data Grid View settings
            dgv_Appointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Appointments.ReadOnly = true;
            dgv_Appointments.MultiSelect = false;

            // Gets all appointments from the appointment database table
            AllAppointments = Appointment.GetAllAppointments();

            // Converts the Data Grid View DateTime records to Local time (Binding List only)
            Appointment.ConvertAppointmentsToLocalTime(AllAppointments);

            // Displays the Binding List of all appointments on the Data Grid View
            dgv_Appointments.DataSource = AllAppointments;
        }

        // Unselects the automatically selected first row on the Data Grid View
        private void OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Appointments.ClearSelection();
        }

        // Handles the Add button click event
        private void btn_Add_Click(object sender, System.EventArgs e)
        {
            Add_Appointment add_Appointment = new Add_Appointment();
            add_Appointment.Show();
        }

        // Handles the Edit button click event
        private void btn_Edit_Click(object sender, System.EventArgs e)
        {
            DataGridViewRow selectedRow;

            try
            {
                // Gets the selected Data Grid View row
                selectedRow = dgv_Appointments.SelectedRows[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an appointment to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieves a string List of the selected row's appointment data
            List<String> appointmentDetails = Appointment.GetSelectedRowData(selectedRow);

            // Opens the Edit Appointment form
            Edit_Appointment edit_Appointment = new Edit_Appointment(appointmentDetails);
            edit_Appointment.Show();
        }

        // Handles the Delete button click event
        private void btn_Delete_Click(object sender, System.EventArgs e)
        {
            DataGridViewRow selectedRow;

            try
            {
                // Gets the selected Data Grid View row
                selectedRow = dgv_Appointments.SelectedRows[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an appointment to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieves a string List of the selected row's appointment data
            List<String> appointmentDetails = Appointment.GetSelectedRowData(selectedRow);

            // Opens the Delete Appointment form
            Delete_Appointment delete_Appointment = new Delete_Appointment(appointmentDetails);
            delete_Appointment.Show();
        }

        // Handles the Month dropdown event
        private void cmboBox_Month_DropDown(object sender, EventArgs e)
        {
            // Clears the dropdown values and adds the array items to the dropdown list
            cmboBox_Month.Items.Clear();

            string[] months = new string[] {"--", "January", "February", "March", "April", "May", "June", "July", "August",
                "September", "October", "November", "December"};

            for (int i = 0; i < months.Length; i++)
            {
                cmboBox_Month.Items.Add(months[i]);
            }

            CurrentlySelectedMonth = cmboBox_Month.Text;
        }

        // Handles the Day dropdown event
        private void cmboBox_Day_DropDown(object sender, EventArgs e)
        {
            // Clears the dropdown values and adds the array items to the dropdown list
            cmboBox_Day.Items.Clear();

            string[] days31 = new string[] { "--", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15",
                "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"};

            string[] days30 = new string[] { "--", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15",
                "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"};

            string[] febDays = new string[] { "--", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15",
                "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29"};

            string[] leapFebDays = new string[] { "--", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15",
                "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28"};

            // Determines if the current year is a leap year
            if (CurrentlySelectedYear != null && int.TryParse(CurrentlySelectedYear, out int currentlySelectedYearInt))
            {
                if (currentlySelectedYearInt % 4 == 0)
                {
                    IsLeapYear = true;
                }
                else
                {
                    IsLeapYear = false;
                }
            }

            // February can only contain 28 days if the Year is a leap year
            if (CurrentlySelectedMonth == "February" && IsLeapYear)
            {
                for (int i = 0; i < leapFebDays.Length; i++)
                {
                    cmboBox_Day.Items.Add(leapFebDays[i]);
                }
            }
            // February can only contain 29 days if the Year is not a leap year
            else if (CurrentlySelectedMonth == "February" && !IsLeapYear)
            {
                for (int i = 0; i < febDays.Length; i++)
                {
                    cmboBox_Day.Items.Add(febDays[i]);
                }
            }
            // Certain months can only contain 30 days
            else if (CurrentlySelectedMonth == "April" || CurrentlySelectedMonth == "June" ||
                CurrentlySelectedMonth == "September" || CurrentlySelectedMonth == "November")
            {
                for (int i = 0; i < days30.Length; i++)
                {
                    cmboBox_Day.Items.Add(days30[i]);
                }
            }
            // Certain months can only contain 31 days
            else
            {
                for (int i = 0; i < days31.Length; i++)
                {
                    cmboBox_Day.Items.Add(days31[i]);
                }
            }
        }

        // Handles the Year dropdown event
        private void cmboBox_Year_DropDown(object sender, EventArgs e)
        {
            // Clears the dropdown values and adds the array items to the dropdown list
            cmboBox_Year.Items.Clear();

            string[] years = new string[] {"--", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028",
                "2029", "2030", "2031", "2032", "2033", "2034", "2035"};

            for (int i = 0; i < years.Length; i++)
            {
                cmboBox_Year.Items.Add(years[i]);
            }

            CurrentlySelectedYear = cmboBox_Year.Text;
        }

        // Ensures the user Month selection is tracked live as the selection is made or changes
        private void cmboBox_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentlySelectedMonth = cmboBox_Month.SelectedItem?.ToString();
        }

        // Ensures the user Day selection is tracked live as the dropdown changes
        private void cmboBox_Day_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentlySelectedDay = cmboBox_Day.SelectedItem?.ToString();
        }

        // Ensures the user Year selection is tracked live as the dropdown value changes
        private void cmboBox_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentlySelectedYear = cmboBox_Year.SelectedItem?.ToString();
        }

        // Handles the Filter Appointments click event
        private void btn_FilterAppointments_Click(object sender, EventArgs e)
        {
            string month = cmboBox_Month.Text;
            string day = cmboBox_Day.Text;
            string year = cmboBox_Year.Text;

            bool isMonthEmpty = String.IsNullOrEmpty(month) || month == "--";
            bool isDayEmpty = String.IsNullOrEmpty(day) || day == "--";
            bool isYearEmpty = String.IsNullOrEmpty(year) || year == "--";

            // Show all appointments if all dropdowns are empty or contain "--"
            if (isMonthEmpty && isDayEmpty && isYearEmpty)
            {
                Appointment_Records.Instance.DgvAppointments.DataSource = AllAppointments;
                return;
            }

            // If a day is selected, both month and year must also be selected
            if (!isDayEmpty)
            {
                if (isMonthEmpty)
                {
                    MessageBox.Show("A valid month is required to filter appointments.", "Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (isYearEmpty)
                {
                    MessageBox.Show("A valid year is required to filter appointments.", "Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            // If only a month is selected, a year must also be selected
            if (!isMonthEmpty && isDayEmpty && isYearEmpty)
            {
                MessageBox.Show("A valid year is required to filter appointments.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Handles filtering by month and year (when day not selected)
            if (!isMonthEmpty && isDayEmpty && !isYearEmpty)
            {
                FilteredAppointments = Appointment.GetFilteredAppointments(month, year);

                FilteredAppointments = Appointment.ConvertAppointmentsToLocalTime(FilteredAppointments);
                Appointment_Records.Instance.DgvAppointments.DataSource = FilteredAppointments;
                return;
            }

            // Handles filtering by month, day, and year
            if (!isMonthEmpty && !isDayEmpty && !isYearEmpty)
            {
                FilteredAppointments = Appointment.GetFilteredAppointments(month, day, year);

                FilteredAppointments = Appointment.ConvertAppointmentsToLocalTime(FilteredAppointments);
                Appointment_Records.Instance.DgvAppointments.DataSource = FilteredAppointments;
            }
        }
    }
}

