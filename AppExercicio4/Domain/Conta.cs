using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExercicio4.Domain
{
    public class Conta : Banco
    {
        #region properties

        public int NumeroAgencia { get; set; }

        public int NumeroConta { get; set; }

        public string NomeTitular { get; set; }

        public double Saldo { get; set; }

        public char TipoConta { get; set; }

        public Pessoa Titular { get; set; }

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

        public Conta()
        {

        }

        public Conta(string CPF, string NomeDoTitular, string Telefone, int NumeroAgencia, int NumeroConta, char TipoConta)
        {
            Pessoa pessoa = new Pessoa(CPF, NomeDoTitular, Telefone);
            this.Titular = pessoa;
        }

        #endregion
    }

}
