using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InscripcionACursos
{
    public class Program
    {
        static List<Materia> materias = new List<Materia>();
        static List<Alumno> alumnos = new List<Alumno>();
        public static List<MateriasPendientes> matpen = new List<MateriasPendientes>();
        public static List<OfertaCursos> ofcursos = new List<OfertaCursos>();
        public static List<FormularioInscripcion> cursosElegidos = new List<FormularioInscripcion>();

        static void Main(string[] args)
        {
            cargarListaMateriasPendientes();
            cargarListaOfertaCursos();
            Ejecutar();
            Console.ReadKey();
        }

        public static void Ejecutar()
        {

            while (true)
            {
                Console.WriteLine("BIENVENIDO AL SISTEMA UNIVERSITARIO\n\nIngrese la opcion deseada:\n" +
                       "A)Ingresar al sistema de Inscripcion de alumnos\n" +
                       "S)Salir\n");
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

        }


        private static void cargarListaMateriasPendientes()
        {
            int num = 0;
            string filePath = "C:/Users/Win10/Desktop/AlumnosMaterias.txt";
            //Documentos.LeerHistorialMaterias(filePath);
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] col = line.Split('|');
                matpen.Add(new MateriasPendientes(num = Convert.ToInt32(col[0]), col[1], col[2], col[3], col[4]));
            }

        }

         private static void cargarListaOfertaCursos()
        {
            int primerCol = 0;
            int segundaCol = 0;
            string filePath = "C:/Users/Win10/Desktop/OfertaCursos.txt";
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] col = line.Split('|');
                ofcursos.Add(new OfertaCursos(primerCol = Convert.ToInt32(col[0]), segundaCol = Convert.ToInt32(col[1]), col[2], col[3], col[4]));
            }

        }

    }
}
