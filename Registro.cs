namespace InscripcionACursos
{
    internal class Registro
    {
        public int NumRegistro;
        public string Pass;


        public Registro(int numRegistro, string pass)
        {
            NumRegistro = numRegistro;
            Pass = pass;
        }

        public int numRegistro { get; }
        public string pass { get; }

    }
}