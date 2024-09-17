using System;

class SalariosVendedores
{
    static void Main()
    {
        // Arreglo para contar cuántos vendedores están en cada rango de salarios
        int[] rangosSalarios = new int[9]; // 9 rangos de salarios

        // Bucle para ingresar ventas brutas de cada vendedor
        while (true)
        {
            Console.Write("Ingrese las ventas brutas del vendedor (o -1 para terminar): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal ventasBrutas) || ventasBrutas == -1) break;

            // Calcular el salario del vendedor
            decimal salario = 200 + (ventasBrutas * 0.09m); // 200 es el salario base, 9% de comisión
            int salarioEntero = (int)Math.Floor(salario);   // Truncar a la parte entera

            // Determinar el rango en el que cae el salario
            int indice = salarioEntero >= 1000 ? 8 : (salarioEntero - 200) / 100;
            rangosSalarios[indice]++;
        }

        // Imprimir el número de vendedores en cada rango de salarios
        Console.WriteLine("\nDistribución de salarios:");
        string[] rangos = { "$200-$299", "$300-$399", "$400-$499", "$500-$599", "$600-$699", "$700-$799", "$800-$899", "$900-$999", "$1000 o más" };
        for (int i = 0; i < rangos.Length; i++)
        {
            Console.WriteLine($"{rangos[i]}: {rangosSalarios[i]} vendedores");
        }
    }
}
