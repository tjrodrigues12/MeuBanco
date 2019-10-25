namespace AppExercicio5.Domain
{
    public class Cliente
    {
        #region Properties        
        public string CPF { get; set; }
        public string Nome { get; set; }
        #endregion

        #region Constructors
        public Cliente()
        {

        }

        public Cliente(string CPF, string Nome, string Telefone)
        {
            this.CPF = CPF;
            this.Nome = Nome;             
        }
        #endregion

    }
}
