using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateuszBartkowiakHomework3
{
    class SignIn
    {
        /// <summary>
        /// 1. Delegat pozwalający zalogować się do aplikacji. Trzeba użycć dwóch bibliotek: 
        /// System.Data.SqlClient oraz System.Configuration ( w tym ,że do biblioteki trzeba dodać
        /// referencje PP na REFERENCES W Solution Explorer, ADD REFERENCE..., Assemblies( po lewej stronie),
        /// wybieramy bibliotekę System.Configuration i akceptujemy
        /// 2.  ConfigurationManager.ConnectionStrings["Warehouse"]   wskazuje na znacznik <ConnectionString></ConnectionString>
        /// i zagnieżdżony <ADD> </ADD>  i tam znajduję się Connection string.
        /// w DataSource Podajemy nazwę naszego serwera, a w database nazwę naszej bazy danych.
        /// </summary>
        private readonly Func<SqlConnection> dbConnectionHomework3 = () => new SqlConnection(ConfigurationManager.ConnectionStrings["Homework3"].ConnectionString);


        public SqlCommand QuerySql { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Konstruktor Parametryczny
        /// </summary>
        public SignIn(string username, string password)
        {
            Username = username;
            Password = password;
        }

        /// <summary>
        /// Metoda sprawdzająca czy dany użytkownik znajduje się w bazie danych w celu zalogowania się do aplikacji.
        /// </summary>
        /// <returns></returns>
        public bool SignInCinema()
        {
            int valueResault;
            bool isTrue = false;
            // Zapytanie w SQL
            string query = "SELECT COUNT(UserLogin.UserName) From UserLogin WHERE UserName = @Username AND Password = @Password";
            using (var connection = dbConnectionHomework3())
            {
                // Połączenie
                connection.Open();
                QuerySql = new SqlCommand(query, connection);
                QuerySql.Parameters.Add(new SqlParameter("@Username", Username));
                QuerySql.Parameters.Add(new SqlParameter("@Password", Password));
                valueResault = (int)QuerySql.ExecuteScalar();

                // Jeśli wystepuje więcej niż jeden wynik
                if (valueResault >= 1)
                {
                    isTrue = true;
                }

            }
            return isTrue;
        }
        
    }
}
