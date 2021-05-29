using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscripcionACursos
{
    
    internal class Alumno
    {
        
        public Alumno(int numregistro,string nombre,string carrera)
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
                        continue;
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
                            Console.WriteLine("OK!!");
                        }
                    }

                } while (!esCorrecto);

                esOK = true;
            } while (!esOK);
            //MiValidador.ValidarInicioSesion();

        }

        internal static void Inscribir()
        {
            Console.WriteLine("Desarrollando metodo de inscripcion...");
        }



    }

    




    



    
}