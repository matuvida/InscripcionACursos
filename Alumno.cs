using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscripcionACursos
{
    internal class Alumno
    {
        Dictionary<int, string> registro = new Dictionary<int, string>();
        
        internal static void IniciarSesion()
        {
            string usuario = "";
            string pass = "";
            MiValidador.ValidarInicioSesion();

        }

        internal static void Inscribir()
        {
            throw new NotImplementedException();
        }

        //registro.Add(884535,"matutepass");
        //registro.Add(881051,"lucaspass");
        //registro.Add(882034,"jorgepass");

    }

    




    



    
}