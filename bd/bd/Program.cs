using System;
using System.Data;
using System.Data.SqlClient;

namespace bd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string datasource = @"DESKTOP-49RHHLK\MSSQL";
                string database = "controle_academico";
                string username;
                string password;

                Console.Write("Usuario: ");
                username = Console.ReadLine().ToLower();
                Console.Write("Senha: ");
                password = Console.ReadLine().ToLower();

                string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

                SqlConnection connection = new SqlConnection(connString);
                ListarBD(connection);

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nFIM\n\nPressone qualquer tecla para finalizar");
            Console.ReadLine();
        }


        public static void ListarBD(SqlConnection connection)
        {
            Console.WriteLine("Listagem de banco de dados");

            connection.Open();

            String sql = "SELECT ra nome nota1 nota2 FROM dbo.aluno, dbo.matricula";

            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetFloat(2)} {reader.GetFloat(3)}");
                    }
                }
            }
            connection.Close();
        }
    }
}
