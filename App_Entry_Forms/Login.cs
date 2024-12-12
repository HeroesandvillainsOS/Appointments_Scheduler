using Appointments_Scheduler.Forms;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Appointments_Scheduler
{
    public partial class Login : Form
    {
        // Creates a new instance of the Culture class
        private readonly Culture myCulture = new Culture();

        // Sets a test culture for testing purposes (uncomment it for testing only)
        // CultureInfo myCurrentCulture = new CultureInfo("es-GT"); // For testing (Spanish for Guatemala)

        // Uses the CurrentCulture that's detected at runtime
        public static CultureInfo myCurrentCulture = CultureInfo.CurrentCulture;

        string cultureName { get; set; }   

        public Login()
        {
            InitializeComponent();

            // Set the culture for the Culture class
            myCulture.SetCulture(myCurrentCulture);
            myCulture.PrintCurrentCulture();  // This will print the current culture to Debug output

            // Update the UI labels based on the current culture
            UpdateCulture();
        }

        private void UpdateCulture()
        {
            cultureName = myCulture.GetCultureName(myCurrentCulture);

            // Changes the login page language to Spanish if a Spanish culture is detected
            if (cultureName.StartsWith("es-"))
            {
                lbl_Location.Text = "Idioma Preferido - Español";
                lbl_Username.Text = "Nombre de usuario:";
                lbl_Password.Text = "Contraseña:";
                btn_Submit.Text = "Enviar";
            }
            else
            {
                lbl_Location.Text = "Preferred Language - English";
                lbl_Username.Text = "Username:";
                lbl_Password.Text = "Password:";
                btn_Submit.Text = "Submit";
            }

            // Force the form to refresh and update the UI
            this.Refresh();  // Force the form to repaint and update the controls
        }


        private void btn_Submit_Click(object sender, EventArgs e)
        {
            // Gets and trims the currently entered username and password
            string currentUsername = txtBox_Username.Text.Trim();
            string currentPassword = txtBox_Password.Text.Trim();

            BindingList<User> allUsers = User.GetAllUsers();
            bool isUserFound = false;

            // Iterates through the Binding List to find a username match
            foreach (User user in allUsers)
            {
                if (currentUsername == user.UserName)
                {
                    isUserFound = true;

                    if (user.Password == currentPassword)
                    {
                        // Opens the Main Menu form
                        var mainMenu = new Main_Menu(user.UserName); // Passes the currently logged in user into the main program
                        mainMenu.Show();

                        // Closes the Login form
                        this.Hide();
                        return; 
                    }
                    else
                    {
                        string passwordErrorMessage = cultureName == "es-ES"
                            ? "La contraseña introducida es incorrecta."
                            : "The entered password is incorrect.";

                        MessageBox.Show(passwordErrorMessage, cultureName == "es-ES" ? "Advertencia" : "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                    }
                }
            }

            // Handles the submission of an invalid username after the loop finishes
            if (!isUserFound)
            {
                string usernameErrorMessage = cultureName == "es-ES"
                    ? "No se pudo encontrar el nombre de usuario ingresado."
                    : "The entered username could not be found.";

                MessageBox.Show(usernameErrorMessage, cultureName == "es-ES" ? "Advertencia" : "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
