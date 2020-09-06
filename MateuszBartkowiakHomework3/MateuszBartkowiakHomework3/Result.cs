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
    public partial class Result : Form
    {
        // Opis w klasie SignIn
        private readonly Func<SqlConnection> dbConnectionHomework3 = () => new SqlConnection(ConfigurationManager.ConnectionStrings["Homework3"].ConnectionString);
        public SqlCommand QuerySql;

        // Zmienna czy wciśnięto Delete
        bool clickButton = false;
        // Zmienna okna ticket
        public Ticket ticket;

        /// <summary>
        /// Konstruktor domyślny
        /// </summary>
        public Result()
        {
            InitializeComponent();
            // Wywołanie funkcji pobrania danych do tabeli
            GetDataFromTable();
            // Pokazuje jakie masz Id
            labelActiveId.Text = (CountOrder()).ToString();
        }

        /// <summary>
        /// Konstruktor parametryczny
        /// </summary>
        /// <param name="ticket"></param>
        public Result(Ticket ticket)
        {
            InitializeComponent();
            GetDataFromTable();
            // Przypisanie okna 
            this.ticket = ticket;
            labelActiveId.Text = (CountOrder()).ToString();
            MessageBox.Show("Zamówienie przyjęte");
        }

        /// <summary>
        /// Liczy ilość zamówień
        /// </summary>
        /// <returns></returns>
        public int CountOrder()
        {
            int valueResault = 0;
            // Zapytanie w SQL
            string query = "SELECT TOP 1 * FROM OrderTicket ORDER BY OrderTicketId DESC";
            using (var connection = dbConnectionHomework3())
            {
                // Połączenie
                connection.Open();
                QuerySql = new SqlCommand(query, connection);

                valueResault = (int)QuerySql.ExecuteScalar();
            }

            return valueResault;
        }

        /// <summary>
        /// Połączenie tabeli z bazą danych
        /// </summary>
        public void GetDataFromTable()
        {
            using (var connection = dbConnectionHomework3())
            {
                //Połączenia
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM OrderTicket ", connection))
                {
                    ///Wynik zapytania do tabeli.
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    /// Do datagridview dodano powyższą tabelę
                    dataGridViewOrder.DataSource = table;
                }
            }
        }

        /// <summary>
        /// Pokaż aktualne zamówienie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFiltr_Click(object sender, EventArgs e)
        {
            if (clickButton == true)
            {
                MessageBox.Show("Twoje zamówienie zostało już usunięte");
            }
            else
            {
                using (var connection = dbConnectionHomework3())
                {
                    //Połączenia
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 1 * FROM OrderTicket ORDER BY OrderTicketId DESC", connection))
                    {
                        ///Wynik zapytania do tabeli.
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        /// Do datagridview dodano powyższą tabelę
                        dataGridViewOrder.DataSource = table;
                    }
                }
            }
            
            
        }

        /// <summary>
        /// Usuń bieżące zamówienie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (clickButton == true)
            {
                MessageBox.Show("Twoje zamówienie zostało już usunięte");
            }
            else
            {
                string query;
                // Zapytanie w SQL
                query = string.Format("DELETE FROM OrderTicket WHERE OrderTicketId=(SELECT TOP 1 OrderTicketId FROM OrderTicket ORDER BY OrderTicketId DESC)");


                using (var connection = dbConnectionHomework3())
                {
                    //Połączenia
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.InsertCommand = new SqlCommand(query, connection);
                        adapter.InsertCommand.ExecuteNonQuery();
                    }
                }
                // Odświeżenie
                GetDataFromTable();
                clickButton = true;
            }
        }

        /// <summary>
        /// Poptwierdzenie/Wylogowanie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = MessageBox.Show("Czy chcesz się wylogować?", "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Jeśli zaznaczymy tak wyloguj
            if (rezultat == DialogResult.Yes)
            {
                this.Close();
                ticket.place.film.login.Visible = true;
            }
            else
                return;
        }

        /// <summary>
        /// Otworzenie okna informacji
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
