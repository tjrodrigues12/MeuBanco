using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Util
{
    public enum TipoConta
    {
        ContaCorrente = 'c',
        Poupanca = 'p'
    }


    public enum TipoOperacao
    {
        AberturaConta = 'A',
        Movimentacao = 'M',
        ListarContas = 'L',
        Transferencia = 'T',
        SairDoPrograma = 'S'
    }

    public enum InfoConta
    {
        Atual = 'A',
        Origem = 'O',
        Destino = 'D'
    }
}
