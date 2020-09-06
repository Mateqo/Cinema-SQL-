using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateuszBartkowiakHomework3
{
    public partial class Login : Form
    {
        // Deklaracja zmienne by pamietać login w każdym oknie
        public string login = ""; 


        /// <summary>
        /// Konstruktor domyślny
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Zalogowanie się 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            // Tworzenie sign i wysłanie to konstruktora danych
            SignIn sign = new SignIn(textBoxLogin.Text, textBoxPassword.Text);

            // Utworzenie nowego okna / wysłanie obecnego
            Film film= new Film(this);

            // Sprawdź czy istnieje taki użytkownik
            if (sign.SignInCinema())
            {
                // Ukryj i pokaż nowe okno
                this.Visible = false;
                film.Show();
                login = textBoxLogin.Text;

            }
            else
            {
                MessageBox.Show("Failed!");
            }
        }

        /// <summary>
        /// Rejestracja użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            // Stworzenie nowego ona/ wysyłamy obecne okno by móc się odwołać 
            Register register = new Register(this);
            register.Show();
            this.Visible = false;
        }

  
    }
}
