using Appointments_Scheduler.Forms;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Appointments_Scheduler
{
    public partial class Login : Form
    {
        // Creates a new instance of the Culture class
        Culture myCulture = new Culture();

        public Login()
        {
            InitializeComponent();


            // Stores the system's current culture info
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;

            // UNCOMMENT THIS BLOCK TO TEST THE PROGRAM IN SPANISH
            /* try
            {
                // Sets the system's current culture to Spanish
                CultureInfo spanishCulture = new CultureInfo("es-ES");
                myCulture.SetCulture(spanishCulture, spanishCulture);
                myCulture.PrintCurrentCulture();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } */ 

            // UNCOMMENT THIS BLOCK TO PUT THE PROGRAM BACK INTO ENGLISH AFTER BEING FORCED INTO SPANISH
            /*finally
            {
                // Sets the system's current culture back to the original culture (English)
                myCulture.SetCulture(currentCulture, currentUICulture); // Comment out to keep Culture Spanish
                myCulture.PrintCurrentCulture();
            }*/

            // Changes the login page language to Spanish if a Spanish culture is detected
            if (myCulture.GetCultureName() == "es-ES")
            {
                lbl_Location.Text = "Ubicación - España";
                lbl_Username.Text = "Nombre de usuario:";
                lbl_Password.Text = "Contraseña:";
                btn_Submit.Text = "Enviar";
            }
            // Ensures the default login page language is English if any culture other than Spanish is detected
            else
            {
                lbl_Username.Text = "Username:";
                lbl_Password.Text = "Password:";
                btn_Submit.Text = "Submit";
            } 
        }

        // Handles the Submit button Click event
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            // Gets and trims the currently entered username and password
            string currentUsername = txtBox_Username.Text.Trim();
            string currentPassword = txtBox_Password.Text.Trim();

            BindingList<User> allUsers = User.GetAllUsers();

            // Iterates through the Binding List to find a username match
            foreach (User user in allUsers)
            {
                if (currentUsername == user.UserName)
                {
                    int currentIndex = allUsers.IndexOf(user);

                    // Verifies the password is correct for a username match
                    if (allUsers[currentIndex].Password == currentPassword)
                    {
                        // Opens the Main Menu form
                        var mainMenu = new Main_Menu(user.UserName); // Passes the currently logged in user into the main program
                        mainMenu.Show();
                        // Closes the Login form
                        this.Hide();
                    }
                    // Handles an incorrect password for a valid username
                    else
                    {
                        if (myCulture.GetCultureName() == "es-ES")
                        {
                            MessageBox.Show("La contraseña introducida es incorrecta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("The entered password is incorrect.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                // Handles the submission of an invalid username
                else
                {
                    if (myCulture.GetCultureName() == "es-ES")
                    {
                        MessageBox.Show("No se pudo encontrar el nombre de usuario ingresado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("The entered username could not be found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
