using System.Collections.Generic;

using AppExercicio5.Interface;
using AppExercicio5.Util.Enumerador;

namespace AppExercicio5.Domain
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

        protected string EmitirExtrato()
        {
            return "Extrato";
        }

        public abstract TipoConta RetornarTipoConta { get; }

        protected virtual void RenderSaldo()
        {

        }

        public virtual bool Sacar(double valor)
        {
            bool retorno = false;

            if (this.Saldo >= valor)
            {
                this.Saldo -= valor;
                retorno = true;
            }

            return retorno;
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }

        #endregion
    }
}
