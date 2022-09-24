using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLista
{
    internal class Aluno
    {
        public int RA { get; set; }
        public String Nome { get; set; }
        public int Idade { get; set; }
        public String Curso { get; set; }
        public Aluno Proximo { get; set; }

        public Aluno(int ra, string nome, int idade, string curso)
        {
            RA = ra;
            Nome = nome;
            Idade = idade;
            Curso = curso;
            Proximo = null;
        }

        public override string ToString()
        {
            return $"### DADOS DO ALUNO ###\nRA: {RA}\nNome: {Nome}\nIdade: {Idade}\nCurso: {Curso}".ToString();
        }
    }
}
