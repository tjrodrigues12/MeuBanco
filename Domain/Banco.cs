using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class Banco
    {
        #region Fields        

        private static string NomeBanco = "Banco .NET";

        private static int NumeracaoConta = 1;

        #endregion

        #region Methods

        public static string ObterNomeBanco()
        {
            return NomeBanco;
        }

        public static int NovoNumeroConta()
        {
            return NumeracaoConta += 1;
        }
        
        #endregion
    }
}
