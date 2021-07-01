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


        public Alumno(int numregistro, string nombre, string apellido, string carrera, bool ultimas4Materias)
        {
            NumRegistro = numregistro;
            Nombre = nombre;
            Apellido = apellido;
            Carrera = carrera;
            UltimasMaterias = ultimas4Materias;
        }

        public Alumno(int numregistro)
        {
            NumRegistro = numregistro;
        }

        public int NumRegistro { get; }
        public string Nombre { get; }
        public string Apellido { get; }
        public string Carrera { get; }
        public bool UltimasMaterias { get; set; }



        //public List<MateriasPorAlumno> MateriasCursadas = new List<MateriasPorAlumno>();
        public const int MaximoMaterias = 4;
        private static bool Habilitado;
        
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
                            Console.WriteLine("\nLa contraseña no es valida. Por favor vuelva a ingresarla:");
                            esCorrecto = false;
                        }
                        else
                        {
                            string AlumnosRegistrados = ValidarRegistro(registroValidado);
                            if (AlumnosRegistrados == "")
                            {
                                Alumno.Inscribir(registroValidado);
                            }
                            else
                            {
                                Console.WriteLine(AlumnosRegistrados);
                            }
                        }

                    } while (esCorrecto == false);

                }
            } while (esOK == false);


        }

        private static string ValidarRegistro(int registroValidado)
        {
            string valor = "";
            foreach (var alumReg in Program.alumnosRegistrados)
            {
                if (alumReg.NumReg != registroValidado)
                {
                    valor = "";

                }
                else
                {
                    valor = "Ya se encuentra registrado anteriormente";
                }
            }

            return valor;
        }

        internal static void Inscribir(int Num)
        {

            bool confirmacion = false;
            bool salir = false;
            //string texto = "";
            bool Declaracion = DeclaracionJuradaUltimasMaterias();
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
                        Alumno.ElegirCursos(Num, "4", Declaracion);
                        Console.WriteLine("\nLos cursos elegidos son:\n");
                        Alumno.MostrarCursosElegidos(Num);
                        confirmacion = MiValidador.IngresoSoN("Desea confirmar la inscripcion? S|N ");
                        if (confirmacion == true)
                        {
                            Console.WriteLine("\n\nGracias! Tu solicitud de inscripcion ha sido confirmada");
                            Program.alumnosRegistrados.Add(new AlumnoRegistrado(Num));
                            bool terminar = MiValidador.IngresoSoN("Desea realizar otra inscripción? S | N");
                            if (terminar == true)
                            {
                                IniciarSesion();
                            }
                            else
                            {
                                Console.WriteLine("\n\nMuchas gracias! Presione ENTER para salir.");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            foreach (var curso in Program.cursosElegidos)
                            {
                                foreach (var mate in Program.matAlum)
                                {
                                    if (curso.CodMateria == mate.CodMateria && mate.Registro == Num)
                                    {
                                        mate.StatusMateria = "Pendiente";
                                    }

                                }
                            }
                            Program.cursosElegidos.Clear();
                            salir = MiValidador.IngresoSoN("\nDesea volver a inscribirse? S|N\n");
                            if (salir == true)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("\n\nMuchas gracias! Presione ENTER para salir.");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }

                        }

                    } while (confirmacion == false);
                }
                else if (tecla.Key == ConsoleKey.B)
                {
                    do
                    {
                        Console.WriteLine("\nA continuacion detallaremos las materias en las cuales te puedes anotar:\n");
                        Alumno.ElegirCursos(Num, "5", Declaracion);
                        Console.WriteLine("\nLos cursos elegidos son:\n");
                        Alumno.MostrarCursosElegidos(Num);
                        confirmacion = MiValidador.IngresoSoN("Desea confirmar la inscripcion? S|N ");
                        if (confirmacion == true)
                        {
                            Console.WriteLine("\n\nGracias! Tu solicitud de inscripcion ha sido confirmada");
                            Program.alumnosRegistrados.Add(new AlumnoRegistrado(Num));
                            bool terminar = MiValidador.IngresoSoN("Desea realizar otra inscripción? S | N");
                            if (terminar == true)
                            {
                                IniciarSesion();
                            }
                            else
                            {
                                GrabarInscripcion();
                                Console.WriteLine("\n\nMuchas gracias! Presione ENTER para salir.");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            foreach (var curso in Program.cursosElegidos)
                            {
                                foreach (var mate in Program.matAlum)
                                {
                                    if (curso.CodMateria == mate.CodMateria && mate.Registro == Num)
                                    {
                                        mate.StatusMateria = "Pendiente";
                                    }

                                }
                            }

                            Program.cursosElegidos.Clear();
                            salir = MiValidador.IngresoSoN("\nDesea volver a inscribirse? S|N\n");
                            if (salir == true)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("\n\nMuchas gracias! Presione ENTER para salir.");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }

                    } while (confirmacion == false);
                }
                else if (tecla.Key == ConsoleKey.C)
                {
                    do
                    {
                        Console.WriteLine("\nA continuacion detallaremos las materias en las cuales te puedes anotar:\n");
                        ElegirCursos(Num, "3", Declaracion);
                        Console.WriteLine("\nLos cursos elegidos son:\n");
                        MostrarCursosElegidos(Num);
                        confirmacion = MiValidador.IngresoSoN("Desea confirmar la inscripcion? S|N ");
                        if (confirmacion == true)
                        {
                            Console.WriteLine("\n\nGracias! Tu solicitud de inscripcion ha sido confirmada");
                            Program.alumnosRegistrados.Add(new AlumnoRegistrado(Num));
                            bool terminar = MiValidador.IngresoSoN("Desea realizar otra inscripción? S | N");
                            if (terminar == true)
                            {
                                IniciarSesion();
                            }
                            else
                            {
                                Console.WriteLine("\n\nMuchas gracias! Presione ENTER para salir.");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            foreach (var curso in Program.cursosElegidos)
                            {
                                foreach (var mate in Program.matAlum)
                                {
                                    if (curso.CodMateria == mate.CodMateria && mate.Registro == Num)
                                    {
                                        mate.StatusMateria = "Pendiente";
                                    }

                                }
                            }

                            Program.cursosElegidos.Clear();
                            salir = MiValidador.IngresoSoN("\nDesea volver a inscribirse? S|N\n");
                            if (salir == true)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("\n\nMuchas gracias! Presione ENTER para salir.");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }

                        }

                    } while (confirmacion == false);

                }
                else if (tecla.Key == ConsoleKey.D)
                {
                    do
                    {
                        Console.WriteLine("\nA continuacion detallaremos las materias en las cuales te puedes anotar:\n");
                        Alumno.ElegirCursos(Num, "2", Declaracion);
                        Console.WriteLine("\nLos cursos elegidos son:\n");
                        Alumno.MostrarCursosElegidos(Num);
                        confirmacion = MiValidador.IngresoSoN("Desea confirmar la inscripcion? S|N ");
                        if (confirmacion == true)
                        {
                            Console.WriteLine("\n\nGracias! Tu solicitud de inscripcion ha sido confirmada");
                            Program.alumnosRegistrados.Add(new AlumnoRegistrado(Num));
                            bool terminar = MiValidador.IngresoSoN("Desea realizar otra inscripción? S | N");
                            if (terminar == true)
                            {
                                IniciarSesion();
                            }
                            else
                            {
                                Console.WriteLine("\n\nMuchas gracias! Presione ENTER para salir.");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }

                        }
                        else
                        {
                            foreach (var curso in Program.cursosElegidos)
                            {
                                foreach (var mate in Program.matAlum)
                                {
                                    if (curso.CodMateria == mate.CodMateria && mate.Registro == Num)
                                    {
                                        mate.StatusMateria = "Pendiente";
                                    }

                                }
                            }

                            Program.cursosElegidos.Clear();
                            salir = MiValidador.IngresoSoN("\nDesea volver a inscribirse? S|N\n");
                            if (salir == true)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("\n\nMuchas gracias! Presione ENTER para salir.");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }

                    } while (confirmacion == false);
                }
                else if (tecla.Key == ConsoleKey.E)
                {
                    do
                    {
                        Console.WriteLine("\nA continuacion detallaremos las materias en las cuales te puedes anotar:\n");
                        Alumno.ElegirCursos(Num, "1", Declaracion);
                        Console.WriteLine("\nLos cursos elegidos son:\n");
                        Alumno.MostrarCursosElegidos(Num);
                        confirmacion = MiValidador.IngresoSoN("Desea confirmar la inscripcion? S|N ");
                        if (confirmacion == true)
                        {
                            Console.WriteLine("\n\nGracias! Tu solicitud de inscripcion ha sido confirmada");
                            Program.alumnosRegistrados.Add(new AlumnoRegistrado(Num));
                            bool terminar = MiValidador.IngresoSoN("\nDesea realizar otra inscripción? S | N");

                            if (terminar == true)
                            {
                                IniciarSesion();
                            }
                            else
                            {
                                GrabarInscripcion();
                                Console.WriteLine("\n\nMuchas gracias! Presione ENTER para salir.");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            foreach (var curso in Program.cursosElegidos)
                            {
                                foreach (var mate in Program.matAlum)
                                {
                                    if (curso.CodMateria == mate.CodMateria && mate.Registro == Num)
                                    {
                                        mate.StatusMateria = "Pendiente";
                                    }

                                }
                            }

                            Program.cursosElegidos.Clear();
                            salir = MiValidador.IngresoSoN("\nDesea volver a inscribirse? S|N\n");
                            if (salir == true)
                            {
                                continue;
                            }
                            else
                            {
                                GrabarInscripcion();
                                Console.WriteLine("\n\nMuchas gracias! Presione ENTER para salir.");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
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

        private static void GrabarInscripcion()
        {
            string NombreDeArchivo = "Inscripciones.txt";
            string texto = "";
            using (var Writer = new StreamWriter(NombreDeArchivo, append: true))
            {
                foreach (var item in Program.cursosElegidos)
                {
                    texto += string.Format(
                    "Num de Registro: {0} | - Código Curso:{1} | - Código Materia:{2} | - Nombre Materia: {3} | - Catedra: {4} | - Horario: {5} | \n",
                    item.NumRegistro,
                    item.CodCurso,
                    item.CodMateria,
                    item.NombreMateria,
                    item.Catedra,
                    item.Horario
);
                }
                Writer.WriteLine(texto);

            }
        }


        private static void MostrarCursosElegidos(int NumReg)
        {

            foreach (var cur in Program.cursosElegidos)
            {
                if (cur.NumRegistro == NumReg)
                {
                    Console.WriteLine("Num Registro: " + cur.NumRegistro + "\t | Num Curso: " + cur.CodCurso + "\t|Cod Materia: " + cur.CodMateria + "\t|Materia: " + cur.NombreMateria + "\t|Catedra: " + cur.Catedra + "\t|Horario: " + cur.Horario);
                }
            }
        }

        private static void ElegirCursos(int NumRegistro, string codCarrera, bool ultimasCuatro)
        {
            int codMateriaElegida = 0;
            string MateriaElegida = "";
            string CursoElegido = "";
            int codCursoElegido = 0;
            bool CursoInscripto = false;
            bool MateriaInscripta = false;
            bool MateriaDispo = false;
            bool respuesta = false;
            bool flag = false;
            for (int i = 0; i < MaximoMaterias; i++)
            {


                do
                {
                    VerMateriasFaltantes(NumRegistro, codCarrera, ultimasCuatro);
                    Console.WriteLine("\n\nEscriba el numero de materia a la cual se quiera anotar:\n");
                    codMateriaElegida = MiValidador.ValidarNumero(MateriaElegida);
                    MateriaInscripta = MiValidador.ValidarInscripcionMateria(NumRegistro, codMateriaElegida);
                    MateriaDispo = MiValidador.ValidarCorrelativas(codMateriaElegida, ultimasCuatro);
                    if (!MateriaInscripta && MateriaDispo)
                    {
                        BuscarOfertaCurso(codMateriaElegida);
                        do
                        {

                            Console.WriteLine("Elija el codigo del curso:\n");
                            codCursoElegido = MiValidador.ValidarNumero(CursoElegido);
                            CursoInscripto = MiValidador.ValidarInscripcionCurso(NumRegistro, codCursoElegido);
                            if (!CursoInscripto)
                            {
                                RegistrarCurso(NumRegistro, codMateriaElegida, codCursoElegido);
                                flag = false;
                            }
                            else
                            {
                                Console.WriteLine("\nUsted ya se encuentra inscripto en este curso, por favor vuelva a seleccionar otro curso:");
                                flag = true;
                            }

                        } while (flag == true);
                    }
                    else
                    {
                        Console.WriteLine("\nUsted no puede anotarse en esta materia, por favor vuelva a seleccionar otra materia:\n\n");
                        MateriaInscripta = true;
                        
                    }
                    respuesta = MiValidador.IngresoSoN("\nDesea elegir otra materia? S|N \n");
                    if (respuesta == false)
                    {
                        MateriaInscripta = true;
                    }
                    else
                    {
                        MateriaInscripta = false;
                    }

                } while (!MateriaInscripta);
                if (MateriaInscripta == true)
                {
                    break;
                }
            }

        }
        private static void RegistrarCurso(int NumReg, int codMateria, int codCurso)
        {
            foreach (var opciones in Program.ofcursos)
            {
                if (opciones.CodCurso == codCurso)
                {
                    Program.cursosElegidos.Add(new FormularioInscripcion(NumReg, opciones.CodCurso, opciones.CodMateria, opciones.NombreMateria, opciones.Catedra, opciones.Horario));
                    foreach (var mates in Program.matAlum)
                    {
                        if (mates.CodMateria == codMateria && mates.Registro == NumReg)
                        {
                            mates.StatusMateria = "Inscripto";
                        }
                    }
                }
            }
        }

        private static void BuscarOfertaCurso(int codMateriaElegida)
        {
            foreach (var ofertas in Program.ofcursos)
            {
                if (ofertas.CodMateria == codMateriaElegida)
                {
                    Console.WriteLine("Num Curso: " + ofertas.CodCurso + "\t|Catedra: " + ofertas.Catedra + "\t|Horario: " + ofertas.Horario);
                }
            }
        }

        public static void VerMateriasFaltantes(int numReg, string CodCarrera, bool ultimasCuatro)
        {
            List<int> CorrelativasPorMateria = new List<int>();
            List<int> MateriasPendientesPorAlumno = new List<int>();
            List<int> MateriasAprobadasPorAlumno = new List<int>();
            //List<int> MateriasDisponiblesPorAlumno = new List<int>();


            Console.WriteLine("Cod. Materia | Desc. Materia");
            if (ultimasCuatro)
            {
                foreach (var mate in Program.matAlum)
                {
                    if (mate.Registro == numReg && mate.CodCarrera == CodCarrera && mate.StatusMateria == "Pendiente")
                    {
                        Console.WriteLine(mate.CodMateria + "|" + mate.DescMateria);
                    }
                }
            }
            else
            {
                
                int contador = 0;
                MateriasPendientesPorAlumno = TraerMatPenPorAlumno(numReg, CodCarrera);
                foreach (var matPenPorAlum in MateriasPendientesPorAlumno)
                {
                    CorrelativasPorMateria = TraerCorrelativas(matPenPorAlum);
                    bool puedoAnotarmeEnPendiente = false;
                    foreach (var corrPorMat in CorrelativasPorMateria)
                    {
                        MateriasAprobadasPorAlumno = TraerMateriasAprobadas(numReg, CodCarrera);
                        puedoAnotarmeEnPendiente = MateriasAprobadasPorAlumno.Contains(corrPorMat);
                        if (puedoAnotarmeEnPendiente)
                        {
                            contador++;
                        }
                        
                    }
                    string nombreMat = traerDescripcionMateria(matPenPorAlum);
                    if (contador == CorrelativasPorMateria.Count())
                    {
                        Console.WriteLine(matPenPorAlum + "|" + nombreMat);
                        Program.MateriasDisponiblesPorAlumno.Add(matPenPorAlum);
                    }
                    
                    contador =0; 
                }
            } 
            
        }

        private static string traerDescripcionMateria(int mate)
        {
            string valor = "";
            foreach (var item in Program.matAlum)
            {
                if (item.CodMateria == mate) 
                {
                    valor = item.DescMateria;
                }
            } 
            return valor;
        }

        private static List<int> TraerMatPenPorAlumno(int numReg, string codCarrera)
        {
            List<int> MateriasPen = new List<int>();
            foreach (var matePen in Program.matAlum)
            {
                if (matePen.Registro == numReg && matePen.CodCarrera == codCarrera && matePen.StatusMateria == "Pendiente")
                {
                    MateriasPen.Add(matePen.CodMateria);
                }
            }
            return MateriasPen;
        }
        private static bool DeclaracionJuradaUltimasMaterias()
        {
            bool cuartaMateria = MiValidador.IngresoSoN("\nBIENVENIDO!\n¿Se encuentra dentro de las ultimas 4 materias? Debe ingresar S o N");
            return cuartaMateria;
        }


        private static List<int> TraerMateriasAprobadas(int numReg, string codCarre)
        {

            List<int> matApro = new List<int>();
            foreach (var aprobadas in Program.matAlum)
            {
                if (aprobadas.Registro == numReg && aprobadas.CodCarrera == codCarre && aprobadas.StatusMateria == "Aprobado")
                {
                    matApro.Add(aprobadas.CodMateria);
                }
            }
            return matApro;
        }

        private static List<int> TraerCorrelativas(int codMate)
        {

            List<int> corPorMat = new List<int>();
            foreach (var corre in Program.correlativas)
            {
                if (corre.CodMate == codMate)
                {
                    corPorMat.Add(corre.CodCorre);
                }
            }
            return corPorMat;
        }
        

    }











}