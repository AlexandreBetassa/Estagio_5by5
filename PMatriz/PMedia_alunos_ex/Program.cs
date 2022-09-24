using System;

namespace PMedia_alunos_ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int QtdAlunos = 1;
            Console.WriteLine("Qtd de alunos:");
            QtdAlunos = int.Parse(Console.ReadLine());
            string[,] Alunos = new string[QtdAlunos, 3];


            for (int i = 0; i < QtdAlunos; i++)
            {
                Alunos[i, 0] = "Teste";
                Alunos[i, 1] = "Teste";
                Alunos[i, 2] = "Teste";
            }

            for (int i = 0; i < QtdAlunos; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Console.Write(Alunos[i,x] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
