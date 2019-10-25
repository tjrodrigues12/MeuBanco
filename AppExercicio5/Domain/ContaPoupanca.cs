using AppExercicio5.Util;

namespace AppExercicio5.Domain
{
    public class ContaPoupanca : Conta
    {
        #region Methods
        public override TipoConta RetornarTipoConta()
        {
            return TipoConta.Poupanca;
        }

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
    }
}
