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
    public partial class Register : Form
    {
        // Zmienna by móc się odwoływać do okna login
        Login login;

        /// <summary>
        /// Konstruktor domyślny
        /// </summary>
        public Register()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor parametryczny
        /// </summary>
        /// <param name="login"></param>
        public Register(Login login)
        {
            InitializeComponent();
            // Przpisanie okna
            this.login = login;
        }

        /// <summary>
        /// Czyszczenie zawartości label
        /// </summary>
        public void Clear()
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }

        /// <summary>
        /// Rejestracja, sprawdza czy można dodać takiego użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            RegisterAccount registerAccount = new RegisterAccount(textBoxLogin, textBoxPassword);

            // Sprawdzenie czy istnieje już taki login
            if (!registerAccount.CheckUser())
            {
                registerAccount.Register();
                MessageBox.Show("Succes registration");
                Clear();
            }
            else
            {
                MessageBox.Show("The name is already taken!");
            }
        }

        /// <summary>
        /// Powrót
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxPrevious_Click(object sender, EventArgs e)
        {
            // Ukryj bieżące okno, pokaż okno login
            this.Visible = false;
            login.Visible = true;
        }
    }
}
