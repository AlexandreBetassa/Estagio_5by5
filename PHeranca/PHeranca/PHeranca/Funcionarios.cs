using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHeranca
{
    internal class Funcionarios : Pessoa
    {
        String Pis;
        float Salario;
        String Setor;

        //metodo construtor
        public Funcionarios(String nome, DateTime dataNasc, String cpf, String pis, float salario, String setor)
            : base(nome, dataNasc, cpf)
        {
            Pis = pis;
            Salario = salario;
            Setor = setor;
        }
        //metodos de acesso aos atributos
        public void setPis(string pis)
        {
            Pis = pis;
        }
        public void setSalario(float salario)
        {
            float Salario = salario;
        }
        public void setSetor(string setor)
        {
            Setor = setor;
        }
        public String getPis()
        {
            return Pis;
        }
        public float getSalario()
        {
            return Salario;
        }
        public String getSetor()
        {
            return Setor;
        }
        public String ImprimeFuncionario()
        {
            return ImprimePessoa() + $"\nPIS: {Pis}\nSalario: {Salario}\nSetor: {Setor}";
        }
        public override string ToString()
        {
            return base.ToString() + $"\nPIS: {Pis}\nSalario: {Salario}\nSetor: {Setor}";
        }
    }
}
