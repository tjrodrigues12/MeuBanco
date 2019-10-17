using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Interface;

namespace Domain
{
    public abstract class Rendimento
    {
        protected double taxaRendimento = 0.03;
        public abstract void RenderValor();
        
    }
}
