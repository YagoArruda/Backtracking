using System;

class Program
{
    static void Main(string[] args)
    {
        int[] listaNumeros = { 1, 7, 4, 3, 5, 6, 9, 8, 10, 2};
        int numA = 1;
        int numB = 2;

        int compsA = 0;
        int compsB = 0;

        Console.WriteLine("Distancia sem ordenar: " + calcularDistancia(numA, numB, listaNumeros, ref compsA, ref compsB) + " | " + (compsA + compsB) + " comparações");
        compsA = 0;
        compsB = 0;
        listaNumeros = presorting(listaNumeros);
        Console.WriteLine("Distancia ordenando: " + calcularDistancia(numA, numB, listaNumeros, ref compsA, ref compsB) + " | " + (compsA + compsB) + " comparações");
    }

    public static int[] presorting(int[] listaDesordenada)
    {
        int[] copiaListaDesordenada = new int[listaDesordenada.Length];
        Array.Copy(listaDesordenada, copiaListaDesordenada, listaDesordenada.Length);

        for (int i = 0; i < copiaListaDesordenada.Length; i++)
        {
            for (int j = i + 1; j < copiaListaDesordenada.Length; j++)
            {
                if (copiaListaDesordenada[j] < copiaListaDesordenada[i])
                {
                    int aux = copiaListaDesordenada[j];
                    copiaListaDesordenada[j] = copiaListaDesordenada[i];
                    copiaListaDesordenada[i] = aux;
                }

            }
        }

        return copiaListaDesordenada;
    }

    public static int calcularDistancia(int A, int B, int[] lista, ref int compsA, ref int compsB)
    {
        int posA = encontrarPosNoVetor(A, lista, ref compsA);
        int posB = encontrarPosNoVetor(B, lista, ref compsB);

        if ((posA != -1) && (posB != -1))
        {
            if (posA > posB)
            {
                return posA - posB;
            }
            else
            {
                return posB - posA;
            }
        }
        compsA = 0;
        compsB = 0;
        return -1;
    }

    public static int encontrarPosNoVetor(int num, int[] lista, ref int comps)
    {
        int aux = 0;
        for (int i = 0; i < lista.Length; i++)
        {
            if (lista[i] == num)
            {
                return aux;
            }
            aux++;
            comps++;
        }
        return -1;
    }
}
