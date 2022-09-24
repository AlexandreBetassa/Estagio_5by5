using System;

namespace ProjOrientacaoObjetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa();

            Console.WriteLine("Informe o nome: ");
            pessoa.setNome(Console.ReadLine());
            Console.WriteLine("Informe sua idade: ");
            pessoa.setIdade(int.Parse(Console.ReadLine()));
            //imprimindo
            Console.WriteLine("Nome: " + pessoa.getNome());
            Console.WriteLine("Idade: " + pessoa.getIdade());
        }
    }
}

