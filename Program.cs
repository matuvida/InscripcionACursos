using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscripcionACursos
{
    class Program
    {
        static void Main(string[] args)
        {

                Console.WriteLine("Ingrese la opcion deseada:\n" +
                       "A)Ingresar al sistema de Inscripcion de alumnos\n" +
                       "S)Salir");
                
            while (true)
                {
                    var tecla = Console.ReadKey();
                    if (tecla.Key == ConsoleKey.A)
                    {
                        Ingresar();
                        continue;

                    }
                    else if (tecla.Key == ConsoleKey.S)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un valor valido");
                        continue;
                    }
                }
        }

        private static void Ingresar()
        {
            var tecla = Console.ReadKey();

            Alumno.IniciarSesion();
            
            Console.WriteLine("Bienvenido al sistema integral de la facultad\n" + "Se encuentra en las ultimas 4 materias? S/N");
            tecla = Console.ReadKey();
            if (tecla.Key == ConsoleKey.S)
            {
                Alumno.Inscribir();
            }
            else if (tecla.Key == ConsoleKey.N)
            {
                Alumno.Inscribir();
            }
            else
            {

            }
            
            MiValidador.ValidarInicioSesion();
        }
    }
}
