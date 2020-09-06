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
    class RegisterAccount
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

        public SqlCommand QuerySql;


        public string setLogin;
        public string setPassword;

        /// <summary>
        /// Konstruktor parametryczny
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public RegisterAccount(TextBox login,TextBox password)
        {
            this.setLogin = login.Text;
            this.setPassword = password.Text;
        }

        /// <summary>
        /// Sprawdzanie czy jest taki użytkownik
        /// </summary>
        /// <returns></returns>
        public bool CheckUser()
        {
            int valueResault;
            bool isTrue = false;
    
            // Zapytanie w SQL
            string query = "SELECT COUNT(UserLogin.UserName) From UserLogin WHERE UserName = @Username";
            using (var connection = dbConnectionHomework3())
            {
                // Połączenie
                connection.Open();
                QuerySql = new SqlCommand(query, connection);
                QuerySql.Parameters.Add(new SqlParameter("@Username", setLogin));

                // Przypisz wynik
                valueResault = (int)QuerySql.ExecuteScalar();

                if (valueResault >= 1)
                {
                    isTrue = true;
                }

            }

            return isTrue;
        }

        /// <summary>
        /// Rejestracja użytkownika
        /// </summary>
        public void Register()
        {
            string query;
            // Zapytanie w SQL
            query = string.Format("INSERT INTO UserLogin (UserName,Password) VALUES ('{0}','{1}')", setLogin, setPassword);
                

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
        
    }
}
