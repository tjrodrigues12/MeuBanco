namespace AppExercicio5.Domain
{
    public static class Banco
    {
        #region Fields        

        private static string NomeBanco = "Banco .NET";

        private static int NumeracaoConta = 0;

        #endregion

        #region Methods

        public static string ObterNomeBanco()
        {
            return NomeBanco;
        }

        public static int NovoNumeroConta()
        {
            return NumeracaoConta += 1;
        }
        
        #endregion
    }
}
