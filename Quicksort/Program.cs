using System;

class Program
{
    static void Main(string[] args)
    {
        //Texto original
        char[] exemplo = { 'E', 'X', 'E', 'M', 'P', 'L', 'O' };
        Console.WriteLine("Original: " + new string(exemplo));

        //Chamada inicial quicksort
        quicksort(exemplo, 0, exemplo.Length - 1);

        //Texto Ordenado
        Console.WriteLine("Resultado: " + new string(exemplo));
    }

    public static void quicksort(char[] vetor, int inicio, int fim)
    {
        if (inicio < fim)
        {
            int pivoIndex = Ordenar(vetor, inicio, fim);

            quicksort(vetor, inicio, pivoIndex - 1);
            quicksort(vetor, pivoIndex + 1, fim);
        }
    }

    public static int Ordenar(char[] vetor, int inicio, int fim)
    {
        char pivo = vetor[fim];
        int i = inicio - 1;

        for (int j = inicio; j < fim; j++)
        {
            if (vetor[j] <= pivo)
            {
                i++;
                char aux = vetor[i];
                vetor[i] = vetor[j];
                vetor[j] = aux;
            }
        }

        char aux2 = vetor[i + 1];
        vetor[i + 1] = vetor[fim];
        vetor[fim] = aux2;
        return i + 1;
    }

}
