public class ReservacionAereo
{
    public static void Main()
    {
        bool[] asientos = new bool[10]; // Un arreglo de 10 asientos donde "false" indica asiento libre y "true" que está ocupado.
        while (true)
        {
            Console.WriteLine("Por favor seleccione una opción:");
            Console.WriteLine("1. Fumar");
            Console.WriteLine("2. No fumar");
            int seleccion = int.Parse(Console.ReadLine()); // El usuario elige la sección: fumar o no fumar.

            if (seleccion == 1) // Si elige la sección de fumar
            {
                bool asignado = false; // Variable para rastrear si se asigna un asiento.
                for (int i = 0; i <= 4; i++) // Recorre los primeros 5 asientos (sección de fumar).
                {
                    if (!asientos[i]) // Si encuentra un asiento libre...
                    {
                        asientos[i] = true; // Lo marca como ocupado.
                        Console.WriteLine($"Su asiento es el número {i + 1} en la sección de fumar."); // Informa el número de asiento asignado.
                        asignado = true; // Indica que ya se asignó un asiento.
                        break; // Sale del bucle una vez asignado.
                    }
                }

                if (!asignado) // Si no se asignó asiento porque la sección está llena...
                {
                    Console.WriteLine("La sección de fumar está llena. ¿Desea ser asignado a la sección de no fumar? (s/n)");
                    if (Console.ReadLine().ToLower() == "s") // Si elige ser asignado a la sección de no fumar...
                    {
                        for (int i = 5; i <= 9; i++) // Recorre los asientos de la sección de no fumar.
                        {
                            if (!asientos[i])
                            {
                                asientos[i] = true;
                                Console.WriteLine($"Su asiento es el número {i + 1} en la sección de no fumar.");
                                asignado = true;
                                break;
                            }
                        }
                        if (!asignado) Console.WriteLine("El siguiente vuelo sale en 3 horas"); // Si no hay asientos libres en la otra sección.
                    }
                    else
                    {
                        Console.WriteLine("El siguiente vuelo sale en 3 horas"); // Si no acepta cambiar de sección, debe esperar el próximo vuelo.
                    }
                }
            }
            else if (seleccion == 2) // Si elige la sección de no fumar
            {
                bool asignado = false;
                for (int i = 5; i <= 9; i++) // Recorre los asientos de la sección de no fumar.
                {
                    if (!asientos[i])
                    {
                        asientos[i] = true;
                        Console.WriteLine($"Su asiento es el número {i + 1} en la sección de no fumar.");
                        asignado = true;
                        break;
                    }
                }

                if (!asignado) // Si la sección de no fumar está llena...
                {
                    Console.WriteLine("La sección de no fumar está llena. ¿Desea ser asignado a la sección de fumar? (s/n)");
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        for (int i = 0; i <= 4; i++) // Busca en la sección de fumar.
                        {
                            if (!asientos[i])
                            {
                                asientos[i] = true;
                                Console.WriteLine($"Su asiento es el número {i + 1} en la sección de fumar.");
                                asignado = true;
                                break;
                            }
                        }
                        if (!asignado) Console.WriteLine("El siguiente vuelo sale en 3 horas"); // Si no hay asientos en ninguna sección.
                    }
                    else
                    {
                        Console.WriteLine("El siguiente vuelo sale en 3 horas"); // Si no acepta cambiar de sección.
                    }
                }
            }
            else
            {
                Console.WriteLine("Selección inválida, intente de nuevo."); // Mensaje de error si el usuario ingresa una opción inválida.
            }

            // Verifica si el vuelo está lleno.
            bool vueloLleno = true;
            foreach (bool asiento in asientos)
            {
                if (!asiento) // Si encuentra un asiento libre, el vuelo no está lleno.
                {
                    vueloLleno = false;
                    break;
                }
            }

            if (vueloLleno) // Si todos los asientos están ocupados...
            {
                Console.WriteLine("El avión está lleno. El siguiente vuelo sale en 3 horas");
                break; // Termina el ciclo porque ya no hay más asientos disponibles.
            }
        }
    }
}
