using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Interface;

namespace Domain
{
    public class ContaCorrente : IConta
    {
        #region properties

        private int NumeroAgencia { get; set; }
        private int NumeroConta { get; set; }
        private double Saldo { get; set; }
        private char TipoConta { get; set; }
        private List<Pessoa> Titulares { get; set; }

        #endregion

        #region methods

        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }

        public bool PodeSacar(double valor)
        {
            return (this.Saldo > valor);
        }       

        public void Sacar(double valor)
        {
            this.Saldo -= valor;
        }        

        #endregion

        #region constructors
        public ContaCorrente()
        {

        }

        public ContaCorrente(string CPF, string NomeDoTitular, string Telefone, int NumeroAgencia)
        { 
            Pessoa pessoa = new Pessoa(CPF, NomeDoTitular, Telefone);
            this.Titulares.Add(pessoa);
            this.NumeroAgencia = NumeroAgencia;            
            this.Saldo = 0;
        }

        public ContaCorrente(List<Pessoa> Titulares, int NumeroAgencia)
        {
            this.Titulares = Titulares;
        }

        #endregion
    }
}
