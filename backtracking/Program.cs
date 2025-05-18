using System;
using System.IO;
using System.Security.Cryptography;

namespace backtracking
{
    class Program
    {
        static void Main(string[] args)
        {
            string localSaida = "9";//local onde o percurso ira começar
            string localAlvo = "b";//local onde deve tentar chegar

            Console.Clear();

            List<Tile> listaTiles = cadastrarTiles();//lista de todos os tiles cadastrados no cadTiles.txt
            List<Tile> visitados = new List<Tile>();//tiles já visitados, inicialmente vazia

            Console.WriteLine("Caminho encontrado:");
            Console.WriteLine(encontrarCaminho(encontrarTile(listaTiles, localSaida), localAlvo, visitados));
        }

        static string encontrarCaminho(Tile tileAtual, String tileAlvo, List<Tile> tilesAnteriores)
        {
            //verifica se é o tile alvo, se for já retorna
            if (tileAtual.nome == tileAlvo)
            {
                return tileAtual.nome;
            }
            //adiciona na lista dos visitados
            tilesAnteriores.Add(tileAtual);

            //Pega a lista de todos os tiles com o qual o atual tem conexão
            List<Tile> tiles = tileAtual.getListaTiles();
            string caminhoParcial = "";


            foreach (Tile tile in tiles)
            {
                if (tilesAnteriores.Count() > 0 && tile.nome != tilesAnteriores.Last().nome && tileJaVisitado(tilesAnteriores, tile) == false)
                {
                    string resultado = encontrarCaminho(tile, tileAlvo, tilesAnteriores);
                    if (!string.IsNullOrEmpty(resultado))
                    {
                        caminhoParcial = $"{tileAtual.nome}/{resultado}";
                        break;  // Se encontrou um caminho, sai do loop
                    }
                }

            }

            tilesAnteriores.RemoveAt(tilesAnteriores.Count() - 1);
            return caminhoParcial;

        }

        //Retorno uma lista com os tiles cadastrados no cadTiles.txt
        static List<Tile> cadastrarTiles()
        {
            string caminho = "cadTiles.txt";
            List<Tile> listaTiles = new List<Tile>();

            if (File.Exists(caminho))
            {

                using (StreamReader sr = new StreamReader("cadTiles.txt"))
                {
                    string linha = sr.ReadLine();
                    string[] elementos = linha.Split(";");

                    foreach (string elemento in elementos)
                    {
                        listaTiles.Add(new Tile(elemento));
                    }

                    while ((linha = sr.ReadLine()) != null)
                    {
                        elementos = linha.Split(";");
                        string nomeElemento = elementos[0];
                        string[] vizinhos = elementos[1].Split("/");
                        Tile tileAtual = encontrarTile(listaTiles, nomeElemento);

                        foreach (string tileVizinho in vizinhos)
                        {
                            Tile aux = encontrarTile(listaTiles, tileVizinho);
                            if (aux != null)
                            {
                                tileAtual.adicionarTileAdjacente(aux);
                            }

                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }

            return listaTiles;
        }

        //Encontra um tile pelo nome dele
        static Tile encontrarTile(List<Tile> listaTiles, string tileAlvo)
        {
            foreach (Tile tile in listaTiles)
            {
                if (tile.nome == tileAlvo)
                {
                    return tile;
                }
            }

            return null;
        }

        //verifica se um tile já foi visitado
        static bool tileJaVisitado(List<Tile> listaTiles, Tile tileAtual)
        {
            foreach (Tile tile in listaTiles)
            {
                if (tile.nome == tileAtual.nome)
                {
                    return true;
                }
            }
            return false;
        }

    }

    //Tile é um termo comum para se referir a casa de tabuleiros como o de xadrez, aqui serve como "divisão" da area do problema
    public class Tile
    {
        public string nome;
        private int custoMovimento;
        public List<Tile> adjacentes;

        public Tile(string _nome)
        {
            nome = _nome;
            custoMovimento = 0;
            adjacentes = new List<Tile>();
        }

        public string getNome()
        {
            return nome;
        }

        public int getCustoMovimento()
        {
            return custoMovimento;
        }

        public void adicionarTileAdjacente(Tile novoAdjacente)
        {
            adjacentes.Add(novoAdjacente);
        }

        public List<Tile> getListaTiles()
        {
            return adjacentes;
        }
    }
}
