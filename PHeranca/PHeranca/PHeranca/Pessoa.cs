using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PHeranca
{
    internal class Pessoa
    {
        String Nome;
        DateTime DataNasc;
        String Cpf;

        //construtor
        public Pessoa(string nome, DateTime dataNasc, String cpf)
        {
            Nome = nome;
            DataNasc = dataNasc;
            Cpf = cpf;
        }
        //métodos de acesso aos atributos
        public void setNome(String nome)
        {
            Nome = nome;
        }
        public void setDataNasc(DateTime dataNasc)
        {
            DataNasc = dataNasc;
        }
        public void setCpf(String cpf)
        {
            Cpf = cpf;
        }
        public String getNome()
        {
            return Nome;
        }
        public String getDataNasc()
        {
            return DataNasc.ToShortDateString();
        }
        public String getCpf()
        {
            return Cpf;
        }
        public string ImprimePessoa()
        {
            return $"Nome: {Nome}\nData de Nascimento: {DataNasc.ToShortDateString()}\nCPF: {Cpf}";
        }
        public override string ToString()
        {
            return $"\nNome: {Nome}\nData de nascimento: {DataNasc.ToShortDateString()}\nCPF: {Cpf}";
        }
    }
}
