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

        public static List<Materias> matAlum = new List<Materias>();
        public static List<AlumnoRegistrado> alumnosRegistrados = new List<AlumnoRegistrado>();
        public static List<Cursos> ofcursos = new List<Cursos>();
        public static Dictionary<int,string> registros = new Dictionary<int, string>();
        public static List<Correlativas> correlativas = new List<Correlativas>();
        public static List<FormularioInscripcion> cursosElegidos = new List<FormularioInscripcion>();
        public static List<int> MateriasDisponiblesPorAlumno = new List<int>();

        static void Main(string[] args)
        {
            cargarMaestroAlumnos();
            cargarListaMaterias();
            cargarListaOfertaCursos();
            cargarCorrelativas();
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


        private static void cargarListaMaterias()
        {
            int num = 0;
            int tercerNum = 0;
            string filePath = "AlumnosMaterias.txt";
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] col = line.Split('|');
               
                matAlum.Add(new Materias(num = Convert.ToInt32(col[0]), col[1], tercerNum = Convert.ToInt32(col[2]), col[3], col[4]));

            }
            

        }

         private static void cargarListaOfertaCursos()
        {
            int primerCol = 0;
            int segundaCol = 0;
            string filePath = "OfertaCursos.txt";
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] col = line.Split('|');
                ofcursos.Add(new Cursos(primerCol = Convert.ToInt32(col[0]), segundaCol = Convert.ToInt32(col[1]), col[2], col[3], col[4]));
            }

        }

        private static void cargarMaestroAlumnos()
        {
            int primerCol = 0;
            string filePath = "MaestroAlumnos.txt";
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] col = line.Split('|');
                registros.Add(primerCol = Convert.ToInt32(col[0]), col[1]);
            }

        }

        private static void cargarCorrelativas()
        {
            int primerCol = 0;
            int segundaCol = 0;
            string filePath = "Correlativas.txt";
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] col = line.Split('|');
                correlativas.Add(new Correlativas(primerCol = Convert.ToInt32(col[0]), segundaCol = Convert.ToInt32(col[1])));
            }

        }

        
    }
}
