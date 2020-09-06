using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateuszBartkowiakHomework3
{
    public partial class Film : Form
    {
        // Opis w klasie SignIn
        private readonly Func<SqlConnection> dbConnectionHomework3 = () => new SqlConnection(ConfigurationManager.ConnectionStrings["Homework3"].ConnectionString);


        // Deklaracja okna by móc sie odwoływać
        public Login login;
        // Deklaracka zmiennej sprawdzająca czy zaznaczono under18
        bool under18=false;
        // Deklaracja zmiennej przechowująca FilmId
        public int film = 0;

        /// <summary>
        /// Konstruktor domyślny
        /// </summary>
        public Film()
        {
            InitializeComponent();
            // Pobranie danych do tabeli
            GetDataFromTable();
        }

        /// <summary>
        /// Konstruktor parametryczny
        /// </summary>
        /// <param name="login"></param>
        public Film(Login login)
        {
            InitializeComponent();
            GetDataFromTable();
            // Przypisanie okna login
            this.login = login;
        }


        /// <summary>
        /// Metoda połączy dane z datagridview
        /// </summary>
        public void GetDataFromTable()
        {
            using (var connection = dbConnectionHomework3())
            {
                //Połączenia
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Film ", connection))
                {
                    ///Wynik zapytania do tabeli.
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    /// Do datagridview dodano powyższą tabelę
                    dataGridViewFilm.DataSource = table;
                }
            }
        }

        /// <summary>
        /// Przejście do kolejnego etapu (nowe okno)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxNext_Click(object sender, EventArgs e)
        {
            // Sprawdzenie czy jesteśmy pełnoletni gdy wybierzemy te filmy
            if ((labelSelectedFilm.Text == "KacVegas" || labelSelectedFilm.Text == "Saw") && (under18 == false))
            {
                MessageBox.Show("Ten film jest dla dorosłych!");
            }
            // Sprawdzenie czy wybrano film
            else if (labelSelectedFilm.Text == "-")
            {
                MessageBox.Show("Nie wyrano filmu");
            }
            else
            {
                // Przypisanie FilmId w zależności od filmu wybranego
                string tmp = labelSelectedFilm.Text;
                switch (tmp)
                {
                    case "Hugo":
                        film = 1;
                        break;
                    case "Nemo":
                        film = 2;
                        break;
                    case "Saw":
                        film = 3;
                        break;
                    case "MammaMia":
                        film = 4;
                        break;
                    case "CowboyJack":
                        film = 5;
                        break;
                    case "LoveIsEverywhere":
                        film = 6;
                        break;
                    case "SherlockHolmes":
                        film = 7;
                        break;
                    case "StarWars":
                        film = 8;
                        break;
                    case "KacVegas":
                        film = 9;
                        break;
                    case "Spartan":
                        film = 10;
                        break;
                }
                this.Visible = false;
                Place place = new Place(this);
                place.Show();               
            }
        }

        #region Wybór filmu

        private void buttonHugo_Click(object sender, EventArgs e)
        {
            labelSelectedFilm.Text = "Hugo";
        }

        private void buttonNemo_Click(object sender, EventArgs e)
        {
            labelSelectedFilm.Text = "Nemo";
        }

        private void buttonSaw_Click(object sender, EventArgs e)
        {
            labelSelectedFilm.Text = "Saw";
        }

        private void buttonMammaMia_Click(object sender, EventArgs e)
        {
            labelSelectedFilm.Text = "MammaMia";
        }

        private void buttonCowboyJack_Click(object sender, EventArgs e)
        {
            labelSelectedFilm.Text = "CowboyJack";
        }

        private void buttonLoveIsEverywhere_Click(object sender, EventArgs e)
        {
            labelSelectedFilm.Text = "LoveIsEverywhere";
        }

        private void buttonSherlockHolmes_Click(object sender, EventArgs e)
        {
            labelSelectedFilm.Text = "SherlockHolmes";
        }

        private void buttonStarWars_Click(object sender, EventArgs e)
        {
            labelSelectedFilm.Text = "StarWars";
        }

        private void buttonKacVegas_Click(object sender, EventArgs e)
        {
            labelSelectedFilm.Text = "KacVegas";
        }

        private void buttonSpartan_Click(object sender, EventArgs e)
        {
            labelSelectedFilm.Text = "Spartan";
        }

        #endregion Wybór filmu

        /// <summary>
        /// Wylogowanie sie 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Sprawdzenie co wybrał użytkownik
            if (rezultat == DialogResult.Yes)
            {
                this.Close();
                login.Visible = true;
            }
            else
                return;           
        }

        /// <summary>
        /// Przypisanie pełnoletności
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxAge_CheckedChanged(object sender, EventArgs e)
        {
            // Jeśli zaznaczony
            if (checkBoxAge.Checked)
            {
                under18 = true;
            }
            else
            {
                under18 = false;
            }
        }

        private void PictureBoxInfo_Click(object sender, EventArgs e)
        {
            Account account = new Account(this);
            account.Show();
            this.Visible = false;
        }
    }
}
