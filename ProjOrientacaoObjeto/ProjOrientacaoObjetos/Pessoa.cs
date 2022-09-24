using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjOrientacaoObjetos
{
    internal class Pessoa
    {
        String nome;
        int idade;
        public String cidade;

        //metodo construtor
        public Pessoa()
        {
            nome = "Alexandre";
            idade = 0;
            cidade = "Taquaritinga";
            Console.WriteLine("Objeto construído com sucesso");
        }

        //metodo construtor
        public Pessoa(string nome, int idade, string cidade)
        {
            this.nome = nome;
            this.idade = idade;
            this.cidade = cidade;
        }

        //metodos de acesso
        public void setNome(String nome)
        {
            this.nome = nome;
        }

        public String getNome()
        {
            return nome;
        }

        public void setIdade(int idade)
        {
            this.idade = idade;
        }

        public int getIdade()
        {
            return this.idade;
        }
    }
}
