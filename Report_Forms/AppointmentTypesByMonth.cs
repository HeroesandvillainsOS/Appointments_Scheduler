using Appointments_Scheduler.Appointment_Forms;
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
    public partial class AppointmentTypesByMonth : Form
    {
        // Properties to ensure the Data Grid View can display live updates when the Binding List values change
        public static AppointmentTypesByMonth Instance { get; private set; }

        public BindingList<Appointment> FilteredAppointments { get; private set; }

        public DataGridView DgvAppointmentTypesByMonth => dgv_AppointmentTypesByMonth;

        public string CurrentlySelectedMonth { get; private set; }

        public string CurrentlySelectedYear { get; private set; }

        public string CurrentlySelectedType { get; private set; }

        public AppointmentTypesByMonth()
        {
            InitializeComponent();

            Instance = this;

            // Data Grid View settings
            dgv_AppointmentTypesByMonth.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_AppointmentTypesByMonth.ReadOnly = true;
            dgv_AppointmentTypesByMonth.MultiSelect = false;
        }

        // Unselects the automatically selected first row on the Data Grid View
        private void OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_AppointmentTypesByMonth.ClearSelection();
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

        // Handles the Type dropdown event
        private void cmboBox_Type_DropDown(object sender, EventArgs e)
        {
            // Clears the dropdown values and adds the array items to the dropdown list
            cmboBox_Type.Items.Clear();

            BindingList<String> allUniqueAppointmentTypes = Appointment.GetAllUniqueAppointmentTypes();

            // Uses a lambda to add items to the Type dropdown
            allUniqueAppointmentTypes.ToList().ForEach(type => cmboBox_Type.Items.Add(type));

            CurrentlySelectedType = cmboBox_Year.Text;
        }

        // Ensures the user Month selection is tracked live as the selection is made or changes
        private void cmboBox_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentlySelectedMonth = cmboBox_Month.SelectedItem?.ToString();
        }

        // Ensures the user Year selection is tracked live as the dropdown value changes
        private void cmboBox_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentlySelectedYear = cmboBox_Year.SelectedItem?.ToString();
        }

        // Ensures the appointment type selection is tracked live as the dropdown changes
        private void cmboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentlySelectedType = cmboBox_Type.SelectedItem?.ToString();
        }

        // Handles the Generate Report button click event
        private void btn_GenerateReport_Click(object sender, EventArgs e)
        {
            string month = cmboBox_Month.Text;
            int monthInt;

            switch (month)
            {
                case "January": monthInt = 1; break;
                case "February": monthInt = 2; break;
                case "March": monthInt = 3; break;
                case "April": monthInt = 4; break;
                case "May": monthInt = 5; break;
                case "June": monthInt = 6; break;
                case "July": monthInt = 7; break;
                case "August": monthInt = 8; break;
                case "September": monthInt = 9; break;
                case "October": monthInt = 10; break;
                case "November": monthInt = 11; break;
                case "December": monthInt = 12; break;
                default: monthInt = 0; break;
            }

            string year = cmboBox_Year.Text;
            int yearInt;
            bool isValidYear = int.TryParse(year, out yearInt);
            string type = cmboBox_Type.Text;
            int totalResults = 0;

            // a month, year, and type must be selected to generate a report
            if (month == "--" || monthInt == 0 || year == "--" || !isValidYear || type == "--")
            {
                MessageBox.Show("Please select a vaild month, year, and appointment type.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            BindingList<Appointment> allAppointments = Appointment.GetAllAppointments();
            BindingList<Appointment> filteredAppointments = new BindingList<Appointment>();

            // Uses a Lamda expression to add appointments meeting the search criteria to a Binding List
            allAppointments
                .Where(appointment => appointment.Start.Month == monthInt &&
                        appointment.Start.Year == yearInt && appointment.Type == type)
                .ToList()
                .ForEach(appointment => 
                {
                    filteredAppointments.Add(appointment);
                    totalResults++;
                });

            // Shows the total number of appointments returned 
            txtBox_TotalResults.Text = totalResults.ToString();

            // Converts displayed appointments to Local Time
            filteredAppointments = Appointment.ConvertAppointmentsToLocalTime(filteredAppointments);

            // Displays the results in the Data Grid View
            AppointmentTypesByMonth.Instance.DgvAppointmentTypesByMonth.DataSource = filteredAppointments;
        }
    }
}

