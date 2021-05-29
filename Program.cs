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
            Ejecutar();
            Console.ReadKey();
        }

        public static void Ejecutar()
        {

            while (true)
            {
                Console.WriteLine("BIENVENIDO AL SISTEMA UNIVERSITARIO\nIngrese la opcion deseada:\n" +
                       "A)Ingresar al sistema de Inscripcion de alumnos\n" +
                       "S)Salir");
                var tecla = Console.ReadKey(intercept: true);
                if (tecla.Key == ConsoleKey.A)
                {
                    Ingresar();
                    break;

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
            Alumno.IniciarSesion();
            Console.WriteLine("Bienvenido al sistema de inscripcion de la facultad\n" + "Se encuentra en las ultimas 4 materias? S/N");
            var tecla = Console.ReadKey(intercept: true);
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
                Console.WriteLine("Ingrese una opcion valida");
            }
            
            //MiValidador.ValidarInicioSesion();
        }
        
        
    }
}
