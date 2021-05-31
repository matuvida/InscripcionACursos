using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InscripcionACursos
{

    internal class Alumno
    {
        Dictionary<int, string> MateriasPend = new Dictionary<int, string>();
        public Alumno(int numregistro, string nombre, string apellido, string carrera)
        {
            NumRegistro = numregistro;
            Nombre = nombre;
            Apellido = apellido;
            Carrera = carrera;


        }

        public int NumRegistro { get; }
        public string Nombre { get; }
        public string Apellido { get; }
        public string Carrera { get; }

        public List<Materia> MateriasCursadas = new List<Materia>();


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

        }

        internal static void Inscribir(int Num)
        {

            DeclaracionJuradaUltimasMaterias();
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
                    //Alumno.VerMateriasFaltantes(Num, "A");
                }
                else if (tecla.Key == ConsoleKey.B)
                {
                    Console.WriteLine("Futuro actuario en admin");
                    //Alumno.VerMateriasFaltantes(Num, "B");
                }
                else if (tecla.Key == ConsoleKey.C)
                {
                    Console.WriteLine("Futuro lic en admin");
                    Alumno.VerMateriasFaltantes(Num, "3");
                }
                else if (tecla.Key == ConsoleKey.D)
                {
                    Console.WriteLine("Contador");
                    Alumno.VerMateriasFaltantes(Num, "2");
                }
                else if (tecla.Key == ConsoleKey.E)
                {
                    Console.WriteLine("Lic en sistemas");
                    Alumno.VerMateriasFaltantes(Num, "1");
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

        public static void VerMateriasFaltantes(int numReg, string CodCarrera)
        {
            foreach (var mate in Program.matpen)
            {
                if (mate.Registro == numReg && mate.CodCarrera == CodCarrera && mate.StatusMateria == "Pendiente")
                {
                    Console.WriteLine(mate.Registro.ToString() + mate.CodCarrera + mate.CodMateria + mate.DescMateria + mate.StatusMateria);
                }
            }
        }
        private static bool DeclaracionJuradaUltimasMaterias()
        {
            bool cuartaMateria = MiValidador.IngresoSoN("Bienvenido!\n¿Se encuentra dentro de las ultimas 4 materias? Debe ingresar S o N");
            return cuartaMateria;
        }

        internal bool BuscarMateriasPendientes()
        {
            foreach (var materiasDelAlumno in MateriasCursadas)
            {
                if (materiasDelAlumno.Estado == "Pendiente")
                {
                    return true;
                }
            }
            return false;
        }

        
    }











}