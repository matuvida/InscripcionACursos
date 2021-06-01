using System;

namespace InscripcionACursos
{
    public class MateriasPendientes
    {
        
        public MateriasPendientes(int registro, string codCarrera, string codMateria, string descMateria, string statusMateria)
        {

            this.Registro = registro;
            CodCarrera = codCarrera;
            CodMateria = codMateria;
            DescMateria = descMateria;
            StatusMateria = statusMateria;
        }
        
        public string DevolverUnalinea()
        {
            return "this.registro, CodCarrera, CodMateria, DescMateria, StatusMateria";
        }

        public int Registro { get; }

        public string CodCarrera { get; }
        public string CodMateria { get; }
        public string DescMateria { get; }
        public string StatusMateria { get; }


    }
}