using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace PLista
{
    internal class ListaAluno
    {
        public Aluno HEAD { get; set; }
        public Aluno TAIL { get; set; }

        public ListaAluno()
        {
            HEAD = TAIL = null;
        }

        public int Length()
        {
            if (Vazia()) return 0;
            else
            {
                Aluno aux = HEAD;
                int cont = 0;
                do
                {
                    cont++;
                    aux = aux.Proximo;
                } while (aux != null);
                return cont;
            }
        }

        private bool Vazia()
        {
            if (HEAD == null) return true;
            else return false;
        }

        public void Print()
        {
            if (Vazia()) Console.WriteLine("Lista Vazia!!!");
            else
            {
                for (Aluno aux = HEAD; aux != null; aux = aux.Proximo)
                {
                    Console.WriteLine(aux + "\n");
                }
            }
        }

        public void Push(Aluno aux)
        {
            if (Vazia()) HEAD = TAIL = aux;
            else
            {
                //ordenação por ordem alfabética
                if (aux.Nome.ToUpper().CompareTo(TAIL.Nome.ToUpper()) >= 0) //inserir fim da lista
                {
                    TAIL.Proximo = aux;
                    TAIL = aux;
                }
                else
                {
                    if (aux.Nome.ToUpper().CompareTo(HEAD.Nome.ToUpper()) < 0) //inserir começo da lista
                    {
                        aux.Proximo = HEAD;
                        HEAD = aux;
                    }
                    else //inserir meio da lista
                    {
                        Aluno aux1, aux2 = aux;
                        aux1 = HEAD;
                        do
                        {
                            if (aux.Nome.ToUpper().CompareTo(aux1.Nome.ToUpper()) >= 0)
                            {//percorrer para analisar local de inserção
                                aux2 = aux1;
                                aux1 = aux1.Proximo;
                            }
                            else
                            {//inserção
                                aux2.Proximo = aux;
                                aux.Proximo = aux1;
                                break;
                            }
                        } while (true);
                    }
                }
            }
        }

        public Aluno Search(string nome)
        {
            if (!Vazia())
            {
                Aluno aux = HEAD, aux1 = aux;
                do
                {
                    if (aux.Nome == nome) return aux;
                    else
                    {
                        aux1 = aux;
                        aux = aux.Proximo;
                    }
                } while (aux != null);
            }
            return null;
        }

        //metodo remove usando o Length
        public void Remove(Aluno aluno)
        {
            if (Length() == 0) Console.WriteLine("Não há elementos na lista!!!");
            if (Length() == 1 && HEAD == aluno)
            {
                HEAD = TAIL = null;
                return;
            }
            else
            {
                Aluno aux = HEAD, aux1 = aux;
                do
                {
                    if (aux != aluno)
                    {
                        aux1 = aux;
                        aux = aux.Proximo;
                    }
                    else
                    {
                        aux1.Proximo = aux.Proximo;
                        if (Length() == 1)
                        {
                            TAIL = aux1;
                            return;
                        }
                        return;
                    }
                } while (true);

            }
        }
        //metodo remove sem usar o Length
        /*public void Remove(Aluno aluno)
        {
            if (Vazia()) Console.WriteLine("Não existem alunos para remover!!!");
            else
            {
                if (aluno == HEAD && HEAD.Proximo != null)
                {
                    HEAD = HEAD.Proximo;
                    if (HEAD.Proximo == null)
                    {
                        TAIL = HEAD;
                        return;
                    }
                    return;
                }
                else if (aluno == HEAD && aluno == TAIL)
                {
                    HEAD = TAIL = null;
                    return;
                }
                else
                {
                    Aluno aux = HEAD, aux1 = aux;
                    do
                    {
                        if (aluno != aux)
                        {
                            aux1 = aux;
                            aux = aux.Proximo;
                        }
                        else
                        {
                            aux1.Proximo = aux.Proximo;
                            if (aux == TAIL) TAIL = aux1;
                            return;
                        }
                    } while (true);
                }
            }
        }*/
    }
}
