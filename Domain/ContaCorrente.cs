using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Interface;
using Domain.Util;

namespace Domain
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
