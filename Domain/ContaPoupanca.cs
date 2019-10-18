using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Interface;
using Domain.Util;

namespace Domain
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
