using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IConta
    {
        bool Sacar(double valor);

        void Depositar(double valor);

    }
}