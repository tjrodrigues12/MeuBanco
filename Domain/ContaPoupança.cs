using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Interface;

namespace Domain
{
    class ContaPoupança : Rendimento, IConta
    {
        #region Properties

        private int NumeroAgencia { get; set; }
        private int NumeroConta { get; set; }
        private double Saldo { get; set; }
        private List<Pessoa> Titulares { get; set; }

        #endregion

        #region Methods

        public void Depositar(double valor)
        {
            this.Saldo += valor;
            RenderValor();
        }

        public override void RenderValor()
        {
            this.Saldo += this.Saldo * taxaRendimento;
        }

        public void Sacar(double valor)
        {
            this.Saldo -= valor;
        }

        #endregion
    }
}
