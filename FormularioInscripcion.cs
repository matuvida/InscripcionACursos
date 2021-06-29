using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InscripcionACursos
{
    public class FormularioInscripcion
    {
        public FormularioInscripcion(int numRegistro,int codCurso, int codMateria, string nombreMateria, string catedra, string horario)
        {
            NumRegistro = numRegistro;
            CodCurso = codCurso;
            CodMateria = codMateria;
            NombreMateria = nombreMateria;
            Catedra = catedra;
            Horario = horario;
        }

        public int NumRegistro { get; }
        public int CodCurso { get; }
        public int CodMateria { get; }
        public string NombreMateria { get; }
        public string Catedra { get; }
        public string Horario { get; }



    }
}
