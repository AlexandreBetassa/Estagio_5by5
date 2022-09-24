using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.SqlServer.Server;

namespace DB_aula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("### CADASTRAR CONTATO ###");
                Console.WriteLine("Informe a Operação: 0- Sair / 1 - Cadastrar / 2 - Listar / 3 - Deletarr contato / 4 - Editar contato");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        CadastrarContato();
                        break;
                    case "2":
                        ListarContatos();
                        break;
                    case "3":
                        DeletarContato();
                        break;
                    case "4":
                        EditarContato();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalido");
                        break;
                }
            } while (true);
        }

        static void CadastrarContato()
        {
            Console.Clear();
            Console.WriteLine("### CADASTRAR CONTATO ###");
            Contato contato = new Contato();
            contato.CadastrarContato();
            InsertContato(contato);
        }

        static void ListarContatos()
        {
            Console.Clear();
            Console.WriteLine("### LISTAR CONTATOS ###");
            DB_Contatos conn = new DB_Contatos();
            string sql = "select id, nome,tel,apelido,email from contatos;";
            SqlCommand cmd = new SqlCommand(sql, conn.AbrirConexao());
            Console.Clear();
            Console.WriteLine("### LISTAGEM ###");
            using (SqlDataReader r = cmd.ExecuteReader())
                while (r.Read()) Console.Write($"ID do usúario: {r.GetInt32(0)}\tNome: {r.GetString(1)}\tTelefone: {r.GetString(2)}\tApelido: {r.GetString(3)}\tEmail: {r.GetString(4)}\n\n");
            conn.FecharConexao();
            Console.ReadKey();
        }
        static void DeletarContato()
        {
            Console.Clear();
            Console.WriteLine("### DELETAR CONTATOS ###");
            Console.Write("Informe o ID que deseja deletar: ");
            int id = int.Parse(Console.ReadLine());
            DB_Contatos conn = new DB_Contatos();
            string sql = "delete from contatos where id = @id;";
            SqlCommand cmd = new SqlCommand(sql, conn.AbrirConexao());
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.ExecuteNonQuery();
            conn.FecharConexao();
        }

        static void EditarContato()
        {
            Console.Clear();
            Console.WriteLine("### EDITAR CONTATOS ###");
            Console.Write("Informe o ID que deseja editar: ");
            int id = int.Parse(Console.ReadLine());
            DB_Contatos conn = new DB_Contatos();
            string sql = "select id, nome, tel, apelido, email from contatos where id = @id";
            SqlConnection conection = conn.AbrirConexao();
            SqlCommand cmd = new SqlCommand(sql, conection);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            Contato contato = new Contato(r.GetString(1), r.GetString(2), r.GetString(3), r.GetString(4));
            conection.Close();
            Console.WriteLine(contato);
            contato.EditarContato();
            Console.WriteLine(contato);
            UpdateContato(conn.AbrirConexao(), contato, id);
        }

        static void UpdateContato(SqlConnection connection, Contato contato, int id)
        {
            string sql = "update contatos set nome = @nome, tel = @tel, apelido = @apelido, email = @email where id = @id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@nome", contato.Nome));
            cmd.Parameters.Add(new SqlParameter("@tel", contato.Telefone));
            cmd.Parameters.Add(new SqlParameter("@apelido", contato.Apelido));
            cmd.Parameters.Add(new SqlParameter("@email", contato.Email));
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        static void InsertContato(Contato contato)
        {
            DB_Contatos conn = new DB_Contatos();
            string sql = "insert into dbo.contatos (nome,tel,apelido,email) values (@nome, @tel,@apelido, @email);";
            SqlCommand cmd = new SqlCommand(sql, conn.AbrirConexao());
            cmd.Parameters.Add(new SqlParameter("@nome", contato.Nome));
            cmd.Parameters.Add(new SqlParameter("@tel", contato.Telefone));
            cmd.Parameters.Add(new SqlParameter("@apelido", contato.Apelido));
            cmd.Parameters.Add(new SqlParameter("@email", contato.Email));
            cmd.ExecuteNonQuery();
            conn.FecharConexao();
        }
    }
}
