using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExercicio5.Util
{
    public enum TipoConta
    {
        ContaCorrente = 'C',
        Poupanca = 'P'
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
