using System;
using System.Collections.Generic;

namespace InscripcionACursos
{
    public class Materias
    {

        public Materias(int registro, string codCarrera, int codMateria, string descMateria, string statusMateria, string []Correlativas)
        {
            CodMateria = codMateria;
            DescMateria = descMateria;
            StatusMateria = statusMateria;
            this.Correlativas = Correlativas;
            Registro = registro;
            CodCarrera = codCarrera;

        }
        
        
        public int Registro { get; }

        public string CodCarrera { get; }
        public int CodMateria { get; }
        public string DescMateria { get; }
        public string StatusMateria { get; set; }
        public string [] Correlativas { get; }
    }
}