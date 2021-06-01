using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscripcionACursos
{
    public class OfertaCursos
    {
        public OfertaCursos(int codCurso, int codMateria, string nombreMateria, string Catedra, string horario)
        {
            CodCurso = codCurso;
            CodMateria = codMateria;
            NombreMateria = nombreMateria;
            this.Catedra = Catedra;
            Horario = horario;
        }

        public int CodCurso { get; }
        public int CodMateria { get; }
        public string NombreMateria { get; }
        public string Catedra { get; }
        public string Horario { get; }

        
    }
}
