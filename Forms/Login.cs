using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
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
            /*try
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

        // Handles the Submit button Mouse Enter event
        private void btn_Submit_MouseEnter(object sender, EventArgs e)
        {
            // Sets the cursor to the Hand icon when hovering over the Submit button 
            Cursor = Cursors.Hand;   
        }

        // Handles the Submit button Mouse Leave Event
        private void btn_Submit_MouseLeave(object sender, EventArgs e)
        {
            // Sets the cursor back to the default icon when exiting the Submit button area
            Cursor = Cursors.Default;
        }

        // Handles the Submit button Click event
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            // Gets and trims the currently entered username and password
            string currentUsername = txtBox_Username.Text.Trim();
            string currentPassword = txtBox_Password.Text.Trim();

            // Creates a new User object and a List to store the user database information
            User myUser = new User();
            List<User> users = myUser.GetUsers();

            // Iterates through the database list to find a username match
            foreach (User user in users)
            {
                if (currentUsername == user.UserName)
                {
                    int currentIndex = users.IndexOf(user);

                    // Verifies the password is correct for a username match
                    if (users[currentIndex].Password == currentPassword)
                    {
                        MessageBox.Show("Success!");
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
