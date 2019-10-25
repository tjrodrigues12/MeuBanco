using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExercicio5.Interface
{
    public interface IConta
    {
        bool Sacar(double valor);

       void Depositar(double valor);

    }
}