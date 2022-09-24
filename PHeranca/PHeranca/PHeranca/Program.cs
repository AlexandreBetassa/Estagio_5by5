using System;

namespace PHeranca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //coleta de dados
            Pessoa pessoa = coletarPessoa();
            Console.Clear();
            Aluno aluno = coletarDadosAluno();
            Console.Clear();
            Funcionarios funcionario = coletarDadosFuncionario();
            Console.Clear();
            //imprime objetos
            Console.WriteLine($"Imprime Pessoa{pessoa}\n");
            Console.WriteLine();
            Console.WriteLine($"Imprime Aluno{aluno}\n");
            Console.WriteLine();
            Console.WriteLine($"Imprime Funcionário{funcionario}\n");
        }
        //funcao pára coletar dados de uma pessoa
        static Pessoa coletarPessoa()
        {
            Console.WriteLine("Coletar dados da pessoa: ");
            Console.Write("Informe o nome da pessoa: ");
            string nome = Console.ReadLine();
            Console.Write("Informe a data de nascimento: ");
            DateTime dataNasc = DateTime.Parse(Console.ReadLine());
            Console.Write("Informe o CPF: ");
            String cpf = Console.ReadLine();
            Pessoa pessoa = new Pessoa(nome, dataNasc, cpf);
            return pessoa;
        }
        //funcao para coletar dados de um aluno
        static Aluno coletarDadosAluno()
        {
            Console.WriteLine("Coletar dados do aluno: ");
            Console.WriteLine("Informe o nome do aluno: ");
            string nome = Console.ReadLine();
            Console.Write("Informe a data de nascimento do aluno: ");
            DateTime dataNasc = DateTime.Parse(Console.ReadLine());
            Console.Write("Informe o CPF do aluno: ");
            String cpf = Console.ReadLine();

            Aluno aluno = new Aluno(nome, dataNasc, cpf, "1000", DateTime.Now);
            return aluno;
        }
        //funcao para coletar dados do funcionario
        static Funcionarios coletarDadosFuncionario()
        {
            Console.WriteLine("Coletar dados do Funcionário: ");
            Console.WriteLine("Informe o nome do funcionário: ");
            string nome = Console.ReadLine();
            Console.Write("Informe a data de nascimento do funcionário: ");
            DateTime dataNasc = DateTime.Parse(Console.ReadLine());
            Console.Write("Informe o CPF do funcionário: ");
            String cpf = Console.ReadLine();
            Console.Write("Informe o número do PIS do funcionário:");
            String pis = Console.ReadLine();
            Console.Write("Informe o salário do funcionário: ");
            float salario = float.Parse(Console.ReadLine());
            Console.Write("Informe o departamento do funcionário: ");
            String setor = Console.ReadLine();

            Funcionarios funcionarios = new Funcionarios(nome, dataNasc, cpf, pis, salario, setor);
            return funcionarios;
        }
    }
}
