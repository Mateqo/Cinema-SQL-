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
    public partial class Ticket : Form
    {
        // Opis w klasie SignIn
        private readonly Func<SqlConnection> dbConnectionHomework3 = () => new SqlConnection(ConfigurationManager.ConnectionStrings["Homework3"].ConnectionString);

        public SqlCommand QuerySql;

        #region Zmienne

        // Deklaracja okna place by móc się odwoływać
        public Place place;
        // Deklaracja zmiennej Imienia
        public string name="";
        // Deklaracja zmiennej Nazwisko
        public string surname="";
        // Typ biletu (normalny/ulgowy)
        public int typeOfTicket = 0;
        // Cena biletu
        public int price = 0;
        // Czy opcja Vip
        public bool vip = false;
        // Data
        public DateTime day;
        // Godzina
        public DateTime time;

        #endregion Zmienne

        /// <summary>
        /// Konstruktor domyślny
        /// </summary>
        public Ticket()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor paremetryczny
        /// </summary>
        /// <param name="place"></param>
        public Ticket(Place place)
        {
            InitializeComponent();
            // Przypisanie place by móc się odwoływać 
            this.place = place;
        }

        /// <summary>
        /// Wybór daty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonthCalendarDay_DateSelected(object sender, DateRangeEventArgs e)
        {
            labelDay.Text =monthCalendarDay.SelectionRange.Start.ToShortDateString();
        }

        /// <summary>
        /// Poprzednie okno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxPevious_Click(object sender, EventArgs e)
        {
            this.Close();
            place.Visible = true;
        }

        /// <summary>
        /// Następne okno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxNext_Click(object sender, EventArgs e)
        {
            // SPrawdzamy czy uzupełniono wszystko
            if (textBoxName.Text == "" || textBoxSurname.Text == "" || labelDay.Text == "-"||labelTime.Text=="-")
            {
                MessageBox.Show("Nie wybrano wszystkich opcji");
            }
            else
            {
                // Przypisanie wszystkich parametrów
                this.Visible = false;
                name = textBoxName.Text;
                surname = textBoxSurname.Text;

                if(comboBoxTypeOfTicket.SelectedItem.ToString() == "Normal")
                {
                    typeOfTicket = 2;
                    price = 30;
                }

                if (comboBoxTypeOfTicket.SelectedItem.ToString() == "Student")
                {
                    typeOfTicket = 1;
                    price = 15;
                }

                day = DateTime.Parse(labelDay.Text);
                time = dateTimerPicker.Value;
                time.ToString("HH:mm");


                if (checkBoxVip.Checked)
                {
                    vip = true;
                }
                else
                {
                    vip = false;
                }

                // Wywołanie fuknkcji dodający rekordy do tabel
                AddClient();
                AddOrder();
                Result result = new Result(this);
                result.Show();
            }

        }

        /// <summary>
        /// Wylogowanie się
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxExit_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rezultat == DialogResult.Yes)
            {
                this.Close();
                place.film.login.Visible = true;
            }
            else
                return;
        }

        /// <summary>
        /// WYbór biletu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxTypeOfTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTypeOfTicket.SelectedItem.ToString() == "Normal")
                labelPrice.Text = "30";
            else if (comboBoxTypeOfTicket.SelectedItem.ToString() == "Student")
                labelPrice.Text = "15";
        }

        /// <summary>
        /// Liczenie liczby klientów
        /// </summary>
        /// <returns></returns>
        public int CountClients()
        {
            int valueResault = 0;
            // Zapytanie w SQL
            string query = "SELECT COUNT(Client.Name) From Client";
            using (var connection = dbConnectionHomework3())
            {
                // Łączenie
                connection.Open();
                QuerySql = new SqlCommand(query, connection);
                
                // Przypisanie zmiennej wynik zapytania w int
                valueResault = (int)QuerySql.ExecuteScalar();
            }

            return valueResault;
        }

        /// <summary>
        /// Dodanie klienta
        /// </summary>
        public void AddClient()
        {
            string query;
            // Zapytanie w SQL
            query = string.Format("INSERT INTO Client (Name,Surname) VALUES ('{0}','{1}')", name, surname);


            using (var connection = dbConnectionHomework3())
            {
                // Połączenia
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.InsertCommand = new SqlCommand(query, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                }
            }

        }

        /// <summary>
        /// Dodanie zamówienia
        /// </summary>
        public void AddOrder()
        {

            string query;
            // Zapytanie  SQL +996 by się zgadzał indeks
            query = string.Format("INSERT INTO OrderTicket (ClientId,FilmId,TicketId,Day,Place,Vip,Row,Time) VALUES ('{0}','{1}','{2}','{3:yyy-MM-dd}','{4}','{5}','{6}','{7}')",CountClients()+996,place.film.film ,typeOfTicket,day, place.place, vip, place.row,time);


            using (var connection = dbConnectionHomework3())
            {
                // Połączenia
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.InsertCommand = new SqlCommand(query, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                }
            }

        }

        /// <summary>
        /// Wybór dnia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            labelDay.Text += dateTimerPicker.Value;
        }

        /// <summary>
        /// Wybór godziny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimerPicker_ValueChanged(object sender, EventArgs e)
        {
            labelTime.Text = dateTimerPicker.Text;
        }

        /// <summary>
        /// Uruchomienie okna info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxInfo_Click(object sender, EventArgs e)
        {
            Account account = new Account(this);
            account.Show();
            this.Visible = false;
               
        }
    }
}
