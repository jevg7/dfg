using System;

public class LanzarDados
{
    public static void Main()
    {
        Random rand = new Random();
        int[] sumas = new int[11]; // Arreglo para contar las sumas posibles (2 a 12)
        int totalTiradas = 36000;

        // Simular 36,000 lanzamientos de dos dados
        for (int i = 0; i < totalTiradas; i++)
        {
            int suma = rand.Next(1, 7) + rand.Next(1, 7); // Suma de dos dados
            sumas[suma - 2]++; // Ajustar índice para el arreglo
        }

        // Imprimir los resultados en formato tabular
        Console.WriteLine("Suma\tFrecuencia\tPorcentaje");
        for (int i = 0; i < sumas.Length; i++)
        {
            int suma = i + 2;
            double porcentaje = (double)sumas[i] / totalTiradas * 100;
            Console.WriteLine($"{suma}\t{sumas[i]}\t\t{porcentaje:F2}%");
        }

        // Verificar si los resultados son razonables
        Console.WriteLine("\nVerificación: Aproximadamente 1/6 de las tiradas deberían ser 7.");
        Console.WriteLine($"Frecuencia de 7: {sumas[5]}"); // Índice 5 corresponde a la suma 7
        double esperado = totalTiradas / 6.0;
        Console.WriteLine($"Esperado (aprox): {esperado:F0}");
    }
}
