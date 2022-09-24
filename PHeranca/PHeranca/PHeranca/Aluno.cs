using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHeranca
{
    internal class Aluno : Pessoa
    {
        String Registro;
        DateTime dataMatricula;
        //construtor
        public Aluno(String nome, DateTime dataNasc, String cpf, String registro, DateTime dataMatric) 
            : base(nome, dataNasc, cpf)
        {
            Registro = registro;
            dataMatricula = dataMatric;
        }
        //métodos de acesso aos atributos
        public void setRegistro(string registro)
        {
            Registro = registro;
        }
        public void setDataMatricula(DateTime dataMatric)
        {
            dataMatricula = dataMatric;
        }
        public string getRegistroAluno()
        {
            return Registro;    
        }
        public String getDataMatric()
        {
            return dataMatricula.ToShortDateString();
        }
        public string ImprimirAluno()
        {
            return ImprimePessoa() + $"\nNumero de registro do aluno: {Registro}\nData da matrícula: {dataMatricula.ToShortDateString()}";
        }
        public override string ToString()
        {
            return base.ToString() + $"\nNumero de registro do aluno: {Registro}\nData da matrícula: {dataMatricula}";
        }
    }
}
