using System;

public class VentasEmpresa
{
    public static void Main()
    {
        // Declaramos una matriz de dos dimensiones para almacenar las ventas de 5 productos por 4 vendedores.
        // Las filas representan productos (1 a 5) y las columnas representan vendedores (1 a 4).
        decimal[,] ventas = new decimal[5, 4]; // 5 productos y 4 vendedores

        // El programa solicita la entrada de datos de ventas del mes anterior.
        Console.WriteLine("Ingrese los datos de ventas del mes anterior:");
        while (true)
        {
            // Solicita el número del vendedor (1 a 4). Si se ingresa 0, el bucle se termina.
            Console.Write("Número de vendedor (1-4, o 0 para terminar): ");
            int vendedor = int.Parse(Console.ReadLine());
            if (vendedor == 0) break; // Si se ingresa 0, el programa sale del bucle y termina la entrada de datos.

            // Solicita el número del producto vendido (1 a 5).
            Console.Write("Número de producto (1-5): ");
            int producto = int.Parse(Console.ReadLine());

            // Solicita el valor total de la venta en dólares y lo convierte a decimal.
            Console.Write("Valor total de la venta en dólares: ");
            decimal valorVenta = decimal.Parse(Console.ReadLine());

            // Se almacena la venta en la matriz `ventas`. Se ajustan los índices restando 1 para
            // que coincidan con el rango de la matriz (0 a 4 para productos y 0 a 3 para vendedores).
            ventas[producto - 1, vendedor - 1] += valorVenta;
        }

        // Después de que se ingresen todas las ventas, el programa imprime el resumen en formato tabular.
        Console.WriteLine("\nResumen de ventas del mes anterior:");
        Console.WriteLine("Producto\\Vendedor\tV1\tV2\tV3\tV4\tTotal Producto");

        // Inicializamos un arreglo para almacenar los totales por cada vendedor.
        decimal[] totalVendedor = new decimal[4];
        decimal totalGeneral = 0; // Variable para almacenar el total general de ventas.

        // Recorremos la matriz para calcular y mostrar los totales por producto y por vendedor.
        for (int i = 0; i < 5; i++) // Itera sobre los productos (filas).
        {
            decimal totalProducto = 0; // Variable para almacenar el total de ventas por producto.
            Console.Write($"Producto {i + 1}\t\t");

            for (int j = 0; j < 4; j++) // Itera sobre los vendedores (columnas).
            {
                // Imprime las ventas de cada vendedor para el producto actual.
                Console.Write($"{ventas[i, j]:F2}\t");

                // Suma las ventas de cada vendedor para el producto actual.
                totalProducto += ventas[i, j];

                // Suma las ventas del producto actual al total del vendedor.
                totalVendedor[j] += ventas[i, j];
            }

            // Suma las ventas del producto actual al total general de ventas.
            totalGeneral += totalProducto;

            // Imprime el total de ventas del producto actual.
            Console.WriteLine($"{totalProducto:F2}");
        }

        // Imprime los totales por vendedor (columnas).
        Console.Write("Total por vendedor\t");
        for (int j = 0; j < 4; j++) // Itera sobre los vendedores para imprimir los totales.
        {
            Console.Write($"{totalVendedor[j]:F2}\t"); // Imprime el total de cada vendedor.
        }

        // Imprime el total general de ventas sumando todas las ventas de todos los vendedores y productos.
        Console.WriteLine($"{totalGeneral:F2}");
    }
}
