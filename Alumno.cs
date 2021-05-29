using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscripcionACursos
{
    
    internal class Alumno
    {
        Dictionary<int, string> MateriasPend = new Dictionary<int, string>();
        public Alumno(int numregistro,string nombre,string carrera )
        {
            NumRegistro = numregistro;
            Nombre = nombre;
            Carrera = carrera;

        }

        public int NumRegistro { get; }
        public string Nombre { get; }
        public string Carrera { get; }

        internal static void IniciarSesion()
        {
            
            Dictionary<int, string> ingreso = new Dictionary<int, string>();
            ingreso.Add(884535, "MatiPass");
            ingreso.Add(881051, "LucasPass");
            ingreso.Add(884410, "JorgePass");
            string registro = "";
            string pass = "";
            bool esCorrecto = false;
            bool esOK = false;
            do
            {
                Console.WriteLine("Para ingresar, le solicitaremos los siguientes datos de acceso:\n" +
                "Num de Registro");
                int registroValidado = MiValidador.ValidarNumero(registro);
                Console.WriteLine("La contraseña:");
                pass = Console.ReadLine();
                do
                {
                    if (!ingreso.ContainsKey(registroValidado))
                    {
                        Console.WriteLine("No se encontro al alumno");
                        break;
                    }
                    else
                    {
                        if (!ingreso.ContainsValue(pass))
                        {
                            Console.WriteLine("La contrasenia no es valida");
                            continue;

                        }
                        else
                        {
                            esCorrecto = true;
                            Alumno.Inscribir(registroValidado);
                        }
                    }


                } while (!esCorrecto);

                esOK = true;
            } while (!esOK);
            //MiValidador.ValidarInicioSesion();
        }

        internal static void Inscribir(int Num)
        {
            
            Console.WriteLine("Bienvenido al metodo de inscripcion:'\n" +
                "Seleccione la carrera:\n" +
                "A)Lic. en Economia\n" +
                "B)Actuario en Administracion\n" +
                "C)Lic. en Administracion\n" +
                "D)Contador\n" +
                "E)Lic. en Sistemas\n" +
                "F)Actuario en Economia\n" +
                "S)Salir");
            do
            {
                var tecla = Console.ReadKey(intercept: true);
                if (tecla.Key == ConsoleKey.A)
                {
                    Console.WriteLine("Futuro Economista");

                }
                else if (tecla.Key == ConsoleKey.B)
                {
                    Console.WriteLine("Futuro actuario en admin");

                }
                else if (tecla.Key == ConsoleKey.C)
                {
                    Console.WriteLine("Futuro lic en admin");

                }
                else if (tecla.Key == ConsoleKey.D)
                {
                    Console.WriteLine("Contador");

                }
                else if (tecla.Key == ConsoleKey.E)
                {
                    Console.WriteLine("Lic en sistemas");
                    Alumno.VerMateriasFaltantes(Num,"E");
                }
                else if (tecla.Key == ConsoleKey.S)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ingrese una opcion valida");
                }

            } while (false);

        }

        private static string VerMateriasFaltantes(int num, string CodCarrera)
        {
            return "Materias Faltantes...";
        }


    }

    




    



    
}