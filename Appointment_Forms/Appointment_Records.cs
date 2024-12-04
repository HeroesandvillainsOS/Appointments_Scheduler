using Appointments_Scheduler.Database_Table_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Appointments_Scheduler.Appointment_Forms
{
    public partial class Appointment_Records : Form
    {
        // Properties to ensure the Data Grid View can display live updates when the Binding List values change
        public static Appointment_Records Instance { get; private set; }

        public BindingList<Appointment> AllAppointments { get; private set; }

        public DataGridView DgvAppointments => dgv_Appointments;

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

            // Converts the Data Grid View Start and End times to Local time (Binding List only)
            foreach (Appointment appointment in AllAppointments)
            {
                appointment.Start = TimeZoneInfo.ConvertTimeFromUtc(appointment.Start, TimeZoneInfo.Local);
                appointment.End = TimeZoneInfo.ConvertTimeFromUtc(appointment.End, TimeZoneInfo.Local);
            }

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
    }
}

