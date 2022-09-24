using System;
using System.Globalization;


namespace PPeso_ideal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Sexo;
            float Altura, Peso, IMC;
            int Opc = 1;
            do
            {
                do
                {
                    Console.Write("Informe o sexo da pessoa: (Masculino) (Feminino) ");
                    Sexo = Console.ReadLine().ToUpper();
                    if (Sexo != "Masculino" && Sexo != "Feminino")
                    {
                        Console.WriteLine("Informe somente: Masculino ou Feminino");

                    }
                } while (Sexo != "Masculino" && Sexo != "Feminino");

                do
                {
                    Console.Write("Informe a altura da pessoa: ");
                    Altura = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    if (Altura <= 0)
                    {
                        Console.WriteLine("A altura está incorreta!!!");
                    }
                } while (Altura <= 0);

                switch (Sexo)
                {
                    case "Masculino":
                        Peso = ((float)((72.7 * Altura) - 58));
                        Console.WriteLine($"O peso ideal de uma pessoa do sexo masculino com {Altura.ToString("F", CultureInfo.InvariantCulture)}mts é de {Peso.ToString("F", CultureInfo.InvariantCulture)}Kg");
                        IMC = ((float)(Peso / Math.Pow(Altura, 2)));
                        Console.WriteLine($"Seu IMC ideal é de: {IMC.ToString("F", CultureInfo.InvariantCulture)}");
                        break;

                    case "Feminino":
                        Peso = ((float)((62.1 * Altura) - 44.7));
                        Console.WriteLine($"O peso ideal de uma pessoa do sexo feminino com {Altura.ToString("F", CultureInfo.InvariantCulture)}mts é de {Peso.ToString("F", CultureInfo.InvariantCulture)}Kg");
                        IMC = ((float)(Peso / Math.Pow(Altura, 2)));
                        Console.WriteLine($"Seu IMC ideal é de: {IMC.ToString("F", CultureInfo.InvariantCulture)}");
                        break;
                }
               
                do
                {
                    Console.Write("Informe seu peso atual: ");
                    Peso = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    if (Peso <= 0)
                    {
                        Console.WriteLine("Valor do peso errado.");
                    }
                } while (Peso <= 0);

                IMC = ((float)(Peso / Math.Pow(Altura, 2)));
                Console.WriteLine($"Seu IMC é: {IMC.ToString("F", CultureInfo.InvariantCulture)}");
                if (IMC < 18.5)
                {
                    Console.WriteLine("Abaixo do peso");
                }
                else if (IMC >= 18.5 && IMC <= 24.9)
                {
                    Console.WriteLine("Peso normal");
                }
                else if (IMC >= 25 && IMC <= 29.9)
                {
                    Console.WriteLine("Acima do peso");
                }
                else if (IMC >= 30 && IMC <= 34.9)
                {
                    Console.WriteLine("Obesidade I");
                }
                else if (IMC >= 35 && IMC <= 39.9)
                {
                    Console.WriteLine("Obesidade II");
                }
                else if (IMC >= 40)
                {
                    Console.WriteLine("Obesidade III");
                }

                Console.WriteLine("Deseja efetuar nova análise? (1 - Sim) (2 - Não) ");
                Opc = int.Parse(Console.ReadLine());
            } while (Opc != 2);
            Console.WriteLine("Sair");
            Console.ReadKey();
        }
    }
}
