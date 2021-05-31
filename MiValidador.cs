using System;

namespace InscripcionACursos
{
    internal class MiValidador
    {
        internal static void ValidarInicioSesion()
        {
            throw new NotImplementedException();
        }

        internal static int ValidarNumero(string numero)
        {
            numero = Console.ReadLine();
            int numeroD;                
                if (!int.TryParse(numero, out numeroD))
                {
                    Console.WriteLine("No es un número válido.");
                }
                else if (numeroD < 1)
                {
                        Console.WriteLine("El numero debe ser mayor a 0");
                    }
                else
                {
                    return numeroD;
                }
            return numeroD;
        }

        internal static bool IngresoSoN(string v)
        {
            Console.WriteLine(v);
            bool esTrue = false;
            var tecla = Console.ReadKey(intercept: true);
            if (tecla.Key == ConsoleKey.S)
            {
                esTrue = true;

            }
            else if (tecla.Key == ConsoleKey.N)
            {
                esTrue = false;
            }
            else
            {
                Console.WriteLine("Debe ingresar S o N");
            }
            return esTrue;
        }

        /*internal static void ValidarPass(string pass)
        {
            pass = Console.ReadLine();
            int numeroD;
            do
            {

                if (!int.TryParse(pass, out numeroD))
                {
                    Console.WriteLine("No es un número válido.");
                }
                else
                {
                    if (numeroD < 10000000 || numeroD > 99999999)
                    {
                        Console.WriteLine("Debe tener 8 cifras.");
                    }
                }
            } while (true);
        }*/
    }
}