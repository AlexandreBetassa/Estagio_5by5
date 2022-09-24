using System;
using Microsoft.VisualBasic.FileIO;

namespace PLista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaAluno listaAluno = new ListaAluno();
            int op;
            bool aux;
            do
            {
                Console.Write("Informe a operação que deseja fazer: 0 - SAIR / 1 - CADASTRAR / 2 - LISTAR / 3 - REMOVER / 4 - BUSCAR ALUNO / 5 - QUANTIDADE DE ALUNOS NA LISTA: ");
                do
                {
                    aux = int.TryParse(Console.ReadLine(), out op);
                    if (aux == false) Console.WriteLine("Informe um valor válido");
                } while (aux == false);
                Console.Clear();
                switch (op)
                {
                    case 0:
                        Console.WriteLine("###  SAIR ###");
                        break;
                    case 1:
                        Push(listaAluno);
                        break;
                    case 2:
                        Print(listaAluno);
                        break;
                    case 3:
                        Remove(listaAluno);
                        break;
                    case 4:
                        Search(listaAluno);
                        break;
                    case 5:
                        Length(listaAluno);
                        break;
                    default:
                        Console.WriteLine("### OPERAÇÃO INVÁLIDA ###");
                        Console.ReadKey();
                        break;
                }
            } while (op != 0);
        }

        static void Length(ListaAluno listaAluno)
        {
            Console.WriteLine($"Quantidade de alunos: {listaAluno.Length()}");
            Console.WriteLine("### PRESSIONE ENTER PARA CONTINUAR ###");
            Console.ReadKey();
            Console.Clear();
        }

        static void Search(ListaAluno listaAluno)
        {
            Console.Write("Informe o nome que deseja localizar: ");
            string nome = Console.ReadLine();
            Aluno aluno = listaAluno.Search(nome);
            if (aluno == null) Console.WriteLine("Aluno não localizado!!!");
            else Console.WriteLine("\nAluno Localizado\n" + aluno);
            Console.WriteLine("### PRESSIONE ENTER PARA CONTINUAR ###");
            Console.ReadKey();
            Console.Clear();
        }

        static void Push(ListaAluno listaAluno)
        {
            string nome, curso;
            int ra, idade;
            bool aux;

            Console.Write("Informe seu nome: ");
            nome = Console.ReadLine();
            Console.Write("Informe sua idade: ");
            do
            {
                aux = int.TryParse(Console.ReadLine(), out idade);
                if (aux == false) Console.WriteLine("Informe opção válida"); ;
            } while (aux == false);
            Console.Write("Informe o curso: ");
            curso = Console.ReadLine();
            Console.WriteLine("Informe o RA: ");
            do
            {
                aux = int.TryParse(Console.ReadLine(), out ra);
                if (aux == false) Console.WriteLine("Informe opção válida"); ;
            } while (aux == false);

            listaAluno.Push(new Aluno(ra, nome, idade, curso));
            Console.WriteLine("### USUÁRIO CADASTRADO COM SUCESSO ###");
            Console.ReadKey();
        }

        static void Print(ListaAluno listaAluno)
        {
            listaAluno.Print();
            Console.WriteLine("### PRESSIONE ENTER PARA CONTINUAR ###");
            Console.ReadKey();
            Console.Clear();
        }

        static void Remove(ListaAluno listaAluno)
        {
            Console.Write("Informe o nome do aluno que deseja remover: ");
            string nome = Console.ReadLine();
            Aluno aluno = listaAluno.Search(nome);
            if (aluno == null) Console.WriteLine("Aluno não localizado!!!");
            else
            {
                listaAluno.Remove(aluno);
                Console.WriteLine("### REMOVIDO COM SUCESSO ###");
            }
            Console.WriteLine("### PRESSIONE ENTER PARA CONTINUAR ###");
            Console.ReadKey();
            Console.Clear();

        }

    }
}
