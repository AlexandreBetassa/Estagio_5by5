using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_aula
{
    internal class Contato
    {
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String Apelido { get; set; }
        public String Email { get; set; }

        public Contato()
        { }

        public Contato(String nome, String tel, String apelido, String email)
        {
            Nome = nome;
            Telefone = tel;
            Apelido = apelido;
            Email = email;
        }

        public void CadastrarContato()
        {
            Console.Write("Nome: ");
            Nome = Console.ReadLine();

            Console.Write("Informe o telefone: ");
            Telefone = Console.ReadLine();

            Console.Write("Apelido: ");
            Apelido = Console.ReadLine();

            Console.Write("Email: ");
            Email = Console.ReadLine();
        }

        public void EditarContato()
        {
            Console.Write("Informe o campo que deseja alterar 1 - Nome / 2 - Telefone / 3 - Apelido / 4 - Email ");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    Console.Write("Informe o novo nome: ");
                    Nome = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Informe o novo telefone: ");
                    Telefone = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Informe o novo apelido: ");
                    Apelido = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Informe o novo email: ");
                    Email = Console.ReadLine();
                    break;
            }
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\tTel: {Telefone}\tApelido: {Apelido}\tEmail: {Email}".ToString();
        }
    }
}
