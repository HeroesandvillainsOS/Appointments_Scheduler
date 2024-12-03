using Appointments_Scheduler.Database_Table_Classes;
using System.ComponentModel;
using System.Windows.Forms;

namespace Appointments_Scheduler.Appointment_Forms
{
    public partial class Appointment_Records : Form
    {
        // Properties to ensure the Data Grid View can display live updates when the Binding List values change
        public static Appointment_Records instance { get; private set; }

        public BindingList<Appointment> AllAppointments { get; private set; }

        public DataGridView DgvAppointments => dgv_Appointments;

        public Appointment_Records()
        {
            InitializeComponent();

            instance = this;

            // Data Grid View settings
            dgv_Appointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Appointments.ReadOnly = true;
            dgv_Appointments.MultiSelect = false;

            // Gets all appointments from the appointment database table
            AllAppointments = Appointment.GetAllAppointments();

            // Displays the Binding List of all appointments on the Data Grid View
            dgv_Appointments.DataSource = AllAppointments;
        }

        // Unselects the automatically selected first row on the Data Grid View
        private void OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Appointments.ClearSelection();
        }
    }
}

