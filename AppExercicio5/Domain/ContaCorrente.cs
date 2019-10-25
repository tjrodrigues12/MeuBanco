using AppExercicio5.Util;
using System.Collections.Generic;

namespace AppExercicio5.Domain
{
    public class ContaCorrente : Conta
    {  

        #region methods        

        public override TipoConta RetornarTipoConta()
        {
            return TipoConta.ContaCorrente;
        }

        #endregion

        #region constructors
        public ContaCorrente()
        {

        }

        public ContaCorrente(string CPF, string NomeDoTitular, string Telefone, int NumeroAgencia)
        { 
            Cliente pessoa = new Cliente(CPF, NomeDoTitular, Telefone);
            this.Titulares.Add(pessoa);
            this.NumeroAgencia = NumeroAgencia;            
            this.Saldo = 0;
        }

        public ContaCorrente(List<Cliente> Titulares, int NumeroAgencia)
        {
            this.Titulares = Titulares;
        }

        #endregion
    }
}
