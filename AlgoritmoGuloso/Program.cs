using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int[] S = { 1, 5, 10, 25, 50, 100 };
        int C = 147;

        int resultado = calcularTroco(S, ref C);
        Console.WriteLine("Valor: 147 /// Moedas: 1, 5, 10, 25, 50, 100");
        Console.WriteLine("Menor quantidade de moeda: " + resultado);
    }

    public static int calcularTroco(int[] moedas, ref int valor)
    {
        int moedasUsadas = 0;

        while (valor > 0)
        {
            foreach (int i in moedas.Reverse())
            {
                if (i <= valor)
                {
                    valor -= i;
                    moedasUsadas++;
                    break;
                }
            }
        }

        return moedasUsadas;

    }
}