using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Pessoa
    {
        #region Properties        
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        #endregion

        #region Constructors
        public Pessoa()
        {

        }

        public Pessoa(string CPF, string Nome, string Telefone)
        {
            this.CPF = CPF;
            this.Nome = Nome;
            this.Telefone = Telefone;
        }
        #endregion

    }
}
