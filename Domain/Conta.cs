using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Interface;
using Domain.Util;

namespace Domain
{
    public abstract class Conta : IConta
    {
        #region fields
        protected readonly double taxaRendimento = 0.03;
        #endregion

        #region properties

        public int NumeroAgencia { get; set; }
        public int NumeroConta { get; set; }
        public double Saldo { get; set; }
        public List<Cliente> Titulares { get; set; }

        #endregion

        #region methods
        public void Depositar(double valor)
        {
            Saldo += valor;
        }        
        #endregion

        #region abstract methods
        public abstract TipoConta RetornarTipoConta();
        #endregion

        #region virtual methods
        protected virtual void RenderSaldo()
        {

        }

        public virtual bool Sacar(double valor)
        {
            bool retorno = false;

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
