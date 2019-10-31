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

        public ContaCorrente(int numeroAgencia, int numeroConta, List<Cliente> Titulares)
        {
            base.NumeroAgencia = numeroAgencia;
            base.NumeroConta = numeroConta;
            base.Titulares = Titulares;
        }

        #endregion
    }
}
