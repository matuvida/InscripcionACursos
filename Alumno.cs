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

        public Alumno(int numregistro)
        {
            NumRegistro = numregistro;
        }

        public int NumRegistro { get; }
        public string Nombre { get; }
        public string Apellido { get; }
        public string Carrera { get; }

        public List<Materia> MateriasCursadas = new List<Materia>();
        public const int MaximoMaterias = 4;

        internal static void IniciarSesion()
        {

            string registro = "";
            string pass = "";
            bool esCorrecto = true;
            bool esOK = true;

            do
            {
                Console.WriteLine("Para ingresar, le solicitaremos los siguientes datos de acceso:\n" +
                "Num de Registro:");
                int registroValidado = MiValidador.ValidarNumero(registro);
                if (!Program.registros.ContainsKey(registroValidado))
                {
                    Console.WriteLine("No se encontro al alumno. Vuelva a ingresarlo:\n");
                    esOK = false;
                }

                else
                {
                    
                    esOK = true;
                    do
                    {
                        Console.WriteLine("La contraseña:");
                        pass = Console.ReadLine();
                        if (!Program.registros.ContainsValue(pass))
                        {
                            Console.WriteLine("\nLa contrasenia no es valida. Por favor vuelva a ingresarla:");
                            esCorrecto = false;
                        }
                        else
                        {
                            esCorrecto = true;
                            Alumno.Inscribir(registroValidado);
                        }

                    } while (esCorrecto == false);

                }
             } while (esOK == false) ;

            
        }
        internal static void Inscribir(int Num)
        {
            
            bool confirmacion = false;

            DeclaracionJuradaUltimasMaterias();
            Console.WriteLine("\nBienvenido al metodo de inscripcion:\n" +
                "Seleccione la carrera:\n" +
                "A)Lic. en Economia\n" +
                "B)Actuario\n" +
                "C)Lic. en Administracion\n" +
                "D)Contador\n" +
                "E)Lic. en Sistemas\n" +
                "S)Salir");
            do
            {
                var tecla = Console.ReadKey(intercept: true);
                if (tecla.Key == ConsoleKey.A)
                {
                    do
                    {
                        Console.WriteLine("\nA continuacion detallaremos las materias en las cuales te podes anotar:\n");
                        Alumno.VerMateriasFaltantes(Num, "4");
                        Alumno.ElegirCursos(Num);
                        Console.WriteLine("\nLos cursos elegidos son:\n");
                        Alumno.MostrarCursosElegidos();
                        confirmacion = MiValidador.IngresoSoN("Desea confirmar la inscripcion? S|N ");
                        if (confirmacion == true)
                        {
                            Console.WriteLine("\n\nGracias! Tu solicitud de inscripcion ha sido confirmada");
                            break;
                        }
                        else
                        {
                            confirmacion = false;
                        }

                    } while (confirmacion == false);
                }
                else if (tecla.Key == ConsoleKey.B)
                {
                    do
                    {
                        Console.WriteLine("\nA continuacion detallaremos las materias en las cuales te puedes anotar:\n");
                        Alumno.VerMateriasFaltantes(Num, "5");
                        Alumno.ElegirCursos(Num);
                        Console.WriteLine("\nLos cursos elegidos son:\n");
                        Alumno.MostrarCursosElegidos();
                        confirmacion = MiValidador.IngresoSoN("Desea confirmar la inscripcion? S|N ");
                        if (confirmacion == true)
                        {
                            Console.WriteLine("\n\nGracias! Tu solicitud de inscripcion ha sido confirmada");
                            //Program.alumnosRegistrados.Add(new Alumno(Num));
                            break;
                        }
                        else
                        {
                            confirmacion = false;
                        }

                    } while (confirmacion == false);
                }
                else if (tecla.Key == ConsoleKey.C)
                {
                    do
                    {
                        Console.WriteLine("\nA continuacion detallaremos las materias en las cuales te puedes anotar:\n");
                        Alumno.VerMateriasFaltantes(Num, "3");
                        Alumno.ElegirCursos(Num);
                        Console.WriteLine("\nLos cursos elegidos son:\n");
                        Alumno.MostrarCursosElegidos();
                        confirmacion = MiValidador.IngresoSoN("Desea confirmar la inscripcion? S|N ");
                        if (confirmacion == true)
                        {
                            Console.WriteLine("\n\nGracias! Tu solicitud de inscripcion ha sido confirmada");
                            break;
                        }
                        else
                        {
                            confirmacion = false;
                        }

                    } while (confirmacion == false);

                }
                else if (tecla.Key == ConsoleKey.D)
                {
                    do
                    {
                        Console.WriteLine("\nA continuacion detallaremos las materias en las cuales te puedes anotar:\n");
                        Alumno.VerMateriasFaltantes(Num, "2");
                        Alumno.ElegirCursos(Num);
                        Console.WriteLine("\nLos cursos elegidos son:\n");
                        Alumno.MostrarCursosElegidos();
                        confirmacion = MiValidador.IngresoSoN("Desea confirmar la inscripcion? S|N ");
                        if (confirmacion == true)
                        {
                            Console.WriteLine("\n\nGracias! Tu solicitud de inscripcion ha sido confirmada");
                            break;
                        }
                        else
                        {
                            confirmacion = false;
                        }

                    } while (confirmacion == false);
                }
                else if (tecla.Key == ConsoleKey.E)
                {
                    do
                    {
                        Console.WriteLine("\nA continuacion detallaremos las materias en las cuales te puedes anotar:\n");
                        Alumno.VerMateriasFaltantes(Num, "1");
                        Alumno.ElegirCursos(Num);
                        Console.WriteLine("\nLos cursos elegidos son:\n");
                        Alumno.MostrarCursosElegidos();
                        confirmacion = MiValidador.IngresoSoN("Desea confirmar la inscripcion? S|N ");
                        if (confirmacion == true)
                        {
                            Console.WriteLine("\n\nGracias! Tu solicitud de inscripcion ha sido confirmada");
                            break;
                        }
                        else
                        {
                            confirmacion = false;
                        }
                       
                    } while (confirmacion == false);
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

        private static void MostrarCursosElegidos()
        {

            foreach (var cur in Program.cursosElegidos)
            {
                Console.WriteLine("Num Curso: " + cur.CodCurso + "\t|Cod Materia: " + cur.CodMateria + "\t|Materia: " + cur.NombreMateria + "\t|Catedra: " + cur.Catedra + "\t|Horario: " + cur.Horario);
            }
        }

        private static void ElegirCursos(int NumRegistro)
        {
            int codMateriaElegida = 0;
            string MateriaElegida = "";
            string CursoElegido = "";
            int codCursoElegido = 0;
            bool respuesta = false;
            bool MateriaInscripta = false;
            for (int i = 0; i < MaximoMaterias; i++)
            {
                
                    Console.WriteLine("\n\nEscriba el numero de materia a la cual se quiera anotar:\n");
                    codMateriaElegida = MiValidador.ValidarNumero(MateriaElegida);
                    MateriaInscripta = Alumno.ValidarInscripcion(NumRegistro, codMateriaElegida);
                if (MateriaInscripta == true)
                {
                    Console.WriteLine("Usted ya esta inscripto en esta materia");
                }
                else
                {
                    BuscarOfertaCurso(codMateriaElegida);
                    Console.WriteLine("Elija el codigo del curso:\n");
                    codCursoElegido = MiValidador.ValidarNumero(CursoElegido);
                    RegistrarCurso(NumRegistro,codMateriaElegida, codCursoElegido);
                    respuesta = MiValidador.IngresoSoN("Desea elegir otro curso? S|N ");
                    if (respuesta == false)
                    {
                        break;
                    }
                }
                    
            }            

        }

        private static bool ValidarInscripcion(int numRegistro, int codMateriaElegida)
        {
            bool EstaInscripto = false;
            foreach (var mate in Program.matpen)
            {
                if (mate.Registro == numRegistro && mate.CodMateria == codMateriaElegida && mate.StatusMateria == "Pendiente")
                {
                    EstaInscripto = true;
                }
                else
                {
                    EstaInscripto = false;
                }
            }
            return EstaInscripto;
        }


        private static void RegistrarCurso(int NumReg,  int codMateria, int codCurso)
        {
            foreach (var opciones in Program.ofcursos)
            {
                if (opciones.CodCurso == codCurso)
                {
                    Program.cursosElegidos.Add(new FormularioInscripcion(opciones.CodCurso, opciones.CodMateria, opciones.NombreMateria, opciones.Catedra, opciones.Horario));
                    foreach (var mate in Program.matpen)
                    {
                        if (mate.Registro == NumReg && mate.CodMateria == codMateria)
                        {
                            mate.StatusMateria = "Inscripto";
                        }
                    }
                }
            }
        }

        private static void BuscarOfertaCurso(int codMateriaElegida)
        {
            foreach (var ofertas in Program.ofcursos)
            {
                if (ofertas.CodMateria ==  codMateriaElegida)
                {
                    Console.WriteLine("Num Curso: " + ofertas.CodCurso + "\t|Catedra: " + ofertas.Catedra + "\t|Horario: " + ofertas.Horario);
                }
            }
        }

        public static void VerMateriasFaltantes(int numReg, string CodCarrera)
        {
            Console.WriteLine("Cod. Materia|Desc. Materia");
            foreach (var mate in Program.matpen)
            {
                if (mate.Registro == numReg && mate.CodCarrera == CodCarrera && mate.StatusMateria == "Pendiente")
                {
                    Console.WriteLine(mate.CodMateria + "|" + mate.DescMateria );
                }
            }
        }
        private static bool DeclaracionJuradaUltimasMaterias()
        {
            bool cuartaMateria = MiValidador.IngresoSoN("\nBIENVENIDO!\n¿Se encuentra dentro de las ultimas 4 materias? Debe ingresar S o N");
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