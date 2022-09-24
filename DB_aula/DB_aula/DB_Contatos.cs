using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB_aula
{
    internal class DB_Contatos
    {
        string Conexao = "Data Source=DESKTOP-49RHHLK\\MSSQL;Initial Catalog=agenda;Persist Security Info=True;User ID=sa;Password=834500";
        public SqlConnection connection { get; set; }


        public DB_Contatos()
        {
            connection = new SqlConnection(Conexao);
        }

        public SqlConnection AbrirConexao()
        {
            connection.Open();
            return connection;
        }

        public void FecharConexao()
        {
            connection.Close();
        }
    }
}
