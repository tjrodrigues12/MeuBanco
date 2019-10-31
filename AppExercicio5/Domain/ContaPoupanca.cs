using System.Collections.Generic;

using AppExercicio5.Util.Enumerador;

namespace AppExercicio5.Domain
{
    public class ContaPoupanca : Conta
    {
        #region Methods
        public override TipoConta RetornarTipoConta => TipoConta.Poupanca;

        protected override void RenderSaldo()
        {
            this.Saldo += this.Saldo * taxaRendimento;
        }

        public override bool Sacar(double valor)
        {

            bool retorno = false;
            this.RenderSaldo();

            if (this.Saldo >= valor)
            {
                retorno = true;
                this.Saldo -= valor;
            }

            return retorno;
        }
        #endregion

        #region Constructor
        public ContaPoupanca(int numeroAgencia, int numeroConta, List<Cliente> titulares)
        {
            base.NumeroAgencia = numeroAgencia;
            base.NumeroConta = numeroConta;
            base.Titulares = titulares;
        }
        #endregion
    }
}
