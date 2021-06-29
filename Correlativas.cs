namespace InscripcionACursos
{
    public class Correlativas
    {
        public Correlativas(int codMate , int codCorre)
        {
            CodMate = codMate;
            CodCorre = codCorre;
        }

        public int CodMate { get; }
        public int CodCorre { get; }
    }
}