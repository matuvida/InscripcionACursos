using System;
using System.Collections.Generic;

namespace InscripcionACursos
{
    public class Materias
    {

        public Materias(int registro, string codCarrera, int codMateria, string descMateria, string statusMateria)
        {
            CodMateria = codMateria;
            DescMateria = descMateria;
            StatusMateria = statusMateria;
            Registro = registro;
            CodCarrera = codCarrera;

        }
        
        
        public int Registro { get; }

        public string CodCarrera { get; }
        public int CodMateria { get; }
        public string DescMateria { get; }
        public string StatusMateria { get; set; }

    }
}