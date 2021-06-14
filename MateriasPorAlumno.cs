using System;

namespace InscripcionACursos
{
    public class MateriasPorAlumno
    {
        
        public MateriasPorAlumno(int registro, string codCarrera, int codMateria, string descMateria, string statusMateria)
        {

            Registro = registro;
            CodCarrera = codCarrera;
            CodMateria = codMateria;
            DescMateria = descMateria;
            StatusMateria = statusMateria;
        }
        
        
        public int Registro { get; }

        public string CodCarrera { get; }
        public int CodMateria { get; }
        public string DescMateria { get; }
        public string StatusMateria { get; set; }


    }
}