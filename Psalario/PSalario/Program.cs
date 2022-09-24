using System;
using System.Globalization;

namespace PSalario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Opc;
            float salario;
            do
            {
                do
                {
                    Console.Write("Informe o salário: ");
                    salario = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    if (salario < 1000)
                    {
                        Console.WriteLine("O salario informado deve ser maior que 1000,00");
                    }
                } while (salario < 1000);

                if (salario < 2000)
                {
                    Console.WriteLine($"O salario atual de R${salario} será de R$" + (salario * 1.1).ToString("F"));
                }
                else if (salario >= 2000 && salario < 3000)
                {
                    Console.WriteLine($"O salario atual de R${salario} será de R$" + (salario * 1.05).ToString("F"));
                }
                else
                {
                    Console.WriteLine("Salarios acima de R$3000,00 não terão aumento!!!");
                }

                do
                {
                    Console.Write("Deseja efetuar novo calculo? 1 - Sim 2 - Nao \n>");
                    Opc = int.Parse(Console.ReadLine());
                    if (Opc != 1 && Opc != 2)
                    {
                        Console.WriteLine("Opção Incorreta\nEscreva exatamente igual as opções");
                    }
                } while (Opc != 1 && Opc != 2);
            } while (Opc != 2);
            Console.WriteLine("Sair");
            Console.ReadKey();
        }
    }
}
