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
                else if (numeroD < 1 )
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

        internal static bool ValidarInscripcionCurso(int numeroReg, int codCursoElegido)
        {
            bool valor = false;
            foreach (var cursosInscriptos in Program.cursosElegidos)
            {
                if (cursosInscriptos.CodCurso == codCursoElegido && cursosInscriptos.NumRegistro == numeroReg)
                {
                    return valor = true;
                }
                else
                {
                    return valor = false;
                }
            }
            return valor;
        }

        internal static bool ValidarInscripcionMateria(int numReg, int codMateriaElegida)
        {
            bool valor = false;
            foreach (var materiasInscriptas in Program.cursosElegidos)
            {
                if (materiasInscriptas.CodMateria == codMateriaElegida && materiasInscriptas.NumRegistro == numReg)
                {
                    return valor = true;
                }
                else
                {
                    return valor = false;
                }
            }
            return valor;
        }

        public static bool ValidarCorrelativas(int codMate, bool ultimasCuatro)
        {
            bool valor = false;
            if (!ultimasCuatro)
            {
               if (Program.MateriasDisponiblesPorAlumno.Contains(codMate))
               {
                    valor = true;
                }
                else
                {
                    valor = false;
                }   
            }
            else
            {
                valor = true;
            }
            return valor;
        }
    }
}