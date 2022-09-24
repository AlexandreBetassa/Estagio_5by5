using System;
using System.Drawing;
using System.Globalization;
using System.Net.WebSockets;

namespace Pjogo_da_velha
{
    internal class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.ResetColor();
                Console.Clear();
                if (!VerificarUsuarioDaltonico())
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                Console.Clear();
                ExecutarJogo();
            } while (JogarNovamente());
            Console.WriteLine("SAIR");
        }

        //função solicitar nome dos jogadores
        static string SolicitarNomeJogador(int Jogador, string marcaJogador)
        {
            string nome;
            do
            {
                Console.Write($"Informe o nome do Jogador {Jogador}, que usará {marcaJogador}: ");
                nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome)) Console.WriteLine("Informe um nome!!!");
            } while (string.IsNullOrWhiteSpace(nome));
            return nome;
        }

        //impressão do tabuleiro
        static void ImpressaoTabuleiro(string[,] Tabuleiro)
        {
            for (int coluna = 0; coluna < 3; coluna++)
            {
                for (int linha = 0; linha < 3; linha++)
                {
                    Console.Write($" {Tabuleiro[coluna, linha]} | ");
                }
                Console.WriteLine();
            }
        }

        //adicionar valores das posições nos tabuleiros
        static void AdicionarPosicoesTabuleiro(string[,] Tabuleiro, string[,] TabuleiroPosicoes)
        {
            int Posicao = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Tabuleiro[i, x] = Posicao.ToString();
                    TabuleiroPosicoes[i, x] = Posicao.ToString();
                    Posicao += 1;
                }
            }
        }

        //solicitar movimento de jogador
        static int SolicitarMovimento(string Jogador)
        {
            int Posicao = 0;
            do
            {
                Console.Write($"Jogador {Jogador} Insira a posição que deseja marcar: ");
                if (!int.TryParse(Console.ReadLine(), out Posicao) || Posicao < 1 || Posicao > 9) Console.WriteLine("Informe um valor válido entre 1 e 9");
            } while (Posicao < 1 || Posicao > 9);
            return Posicao;
        }

        //Marcar posição do tabuleiro
        static void MarcarPosicao(int posicao, string[,] tabuleiro, string marcaJogador)
        {
            for (int coluna = 0; coluna < 3; coluna++)
            {
                for (int linha = 0; linha < 3; linha++)
                {
                    if (tabuleiro[coluna, linha] == posicao.ToString())
                    {
                        tabuleiro[coluna, linha] = marcaJogador;
                    }
                }
            }
        }

        //verificar posição ocupada
        static bool VerificarOcupado(string[,] tabuleiro, string[,] referencia, int posicao)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (tabuleiro[i, x] == posicao.ToString())
                    {
                        return false;
                    }
                }
            }
            Console.WriteLine("Posição ja ocupada");
            return true;
        }

        //verificar sequencia
        static bool VerificarSequencia(string[,] tabuleiro, string marcaJogador)
        {
            //igualdade linhas
            if (tabuleiro[0, 0] == marcaJogador && tabuleiro[0, 1] == marcaJogador && tabuleiro[0, 2] == marcaJogador) return true;
            else if (tabuleiro[1, 0] == marcaJogador && tabuleiro[1, 1] == marcaJogador && tabuleiro[1, 2] == marcaJogador) return true;
            else if (tabuleiro[2, 0] == marcaJogador && tabuleiro[2, 1] == marcaJogador && tabuleiro[2, 2] == marcaJogador) return true;
            //verificar colunas
            else if (tabuleiro[0, 0] == marcaJogador && tabuleiro[1, 0] == marcaJogador && tabuleiro[2, 0] == marcaJogador) return true;
            else if (tabuleiro[0, 1] == marcaJogador && tabuleiro[1, 1] == marcaJogador && tabuleiro[2, 1] == marcaJogador) return true;
            else if (tabuleiro[0, 2] == marcaJogador && tabuleiro[1, 2] == marcaJogador && tabuleiro[2, 2] == marcaJogador) return true;
            //verificar diagonais
            else if (tabuleiro[0, 0] == marcaJogador && tabuleiro[1, 1] == marcaJogador && tabuleiro[2, 2] == marcaJogador) return true;
            else if (tabuleiro[2, 0] == marcaJogador && tabuleiro[1, 1] == marcaJogador && tabuleiro[0, 2] == marcaJogador) return true;
            return false;
        }

        //verificar usuario daltonico
        static bool VerificarUsuarioDaltonico()
        {
            string daltonico = "";
            do
            {
                Console.Write("Algum jogador é daltônico? Informe se sim ou nao: ");
                try
                {
                    daltonico = Console.ReadLine().ToLower();
                }
                catch
                {
                    Console.WriteLine("Informe opção válida");
                }
                if (daltonico != "sim" && daltonico != "nao")
                {
                    Console.WriteLine("Informe opção válida (Sim ou Nao)\nPressione Enter para tentar novamente!!!");
                    Console.ReadKey();
                    Console.Clear();

                }
            } while (daltonico != "sim" && daltonico != "nao" || string.IsNullOrWhiteSpace(daltonico));
            if (daltonico == "sim") return true;
            else return false;
        }

        //executar jogo
        static void ExecutarJogo()
        {
            Console.WriteLine("\t***JOGO DA VELHA***");

            int posicao, velha = 0;
            string Jogador1 = SolicitarNomeJogador(1, "X");
            string Jogador2 = SolicitarNomeJogador(2, "O");
            string[,] TabuleiroJogo = new string[3, 3];
            string[,] TabuleiroJogoPosicoes = new string[3, 3];
            AdicionarPosicoesTabuleiro(TabuleiroJogo, TabuleiroJogoPosicoes);

            do
            {
                Console.Clear();
                //jogador 1
                Console.WriteLine($"Jogador 1: {Jogador1} marca: X\nJogador 2: {Jogador2} marca: O");
                ImpressaoTabuleiro(TabuleiroJogo);
                do
                {
                    posicao = SolicitarMovimento(Jogador1);
                } while (VerificarOcupado(TabuleiroJogo, TabuleiroJogoPosicoes, posicao));

                MarcarPosicao(posicao, TabuleiroJogo, "X");

                Console.Clear();
                if (VerificarSequencia(TabuleiroJogo, "X"))
                {
                    Console.WriteLine("Jogador 1 Venceu");
                    ImpressaoTabuleiro(TabuleiroJogo);
                    break;
                }
                velha += 1;
                //jogador 2
                Console.WriteLine($"Jogador 1: {Jogador1} marca: X\nJogador 2: {Jogador2} marca: O");
                ImpressaoTabuleiro(TabuleiroJogo);

                do
                {
                    posicao = SolicitarMovimento(Jogador2);
                } while (VerificarOcupado(TabuleiroJogo, TabuleiroJogoPosicoes, posicao));

                MarcarPosicao(posicao, TabuleiroJogo, "O");

                if (VerificarSequencia(TabuleiroJogo, "O"))
                {
                    Console.Clear();
                    Console.WriteLine("Jogador 2 Venceu");
                    ImpressaoTabuleiro(TabuleiroJogo);
                    break;
                }
                velha += 1;
                if (velha > 6)
                {
                    ImpressaoTabuleiro(TabuleiroJogo);
                    Console.WriteLine("Velha");
                    break;
                }
            } while (true);
        }

        //perguntar se deseja jogar novamente
        static bool JogarNovamente()
        {
            string opcao = "s";
            do
            {
                Console.Write("Deseja jogar novamente? Informe sim ou nao: ");
                try
                {
                    opcao = Console.ReadLine().ToLower();
                }
                catch (Exception)
                {
                    Console.WriteLine("Informe se SIM ou NAO");
                }
                if (opcao != "sim" && opcao != "nao") Console.WriteLine("Informe opção válida\n\"Informe se SIM ou NAO\"");
            } while (opcao != "sim" && opcao != "nao");
            if (opcao == "sim") return true;
            else return false;
        }
    }
}
