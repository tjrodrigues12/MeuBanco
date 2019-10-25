using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExercicio4.Domain
{
    public class Pessoa
    {
        public string CPF { get; set; }
        public string NomeDoTitular { get; set; }
        public string Telefone { get; set; }

        public Pessoa(string cpf, string nomeDoTitular, string telefone)
        {
            this.CPF = cpf;
            this.NomeDoTitular = NomeDoTitular;
            this.Telefone = Telefone;
        }
    }
}
