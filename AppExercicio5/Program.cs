using System;
using System.Collections.Generic;
using System.Linq;

using Domain;
using Domain.Util;

namespace AppExercicio5
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            /* 
            * Sistema Bancário
           */

            //Variáveis
            //int numeroAgencia = 0;
            //int numeroConta = 0;
            //string nomeDoTitular = string.Empty;

            //double saldo = 0.00;
            //double valorSaque = 0.00;
            //string depositoInicial;
            //string operacao;
            TipoOperacao tipoOperacao;
            //string nomeDoBanco = "NET";

            //Input dados

            do
            {
                Console.WriteLine("------Bem vindo ao Banco {0}-------", Banco.ObterNomeBanco());

                Console.WriteLine("Selecione uma operação que deseja realizar:");
                Console.WriteLine("A => Abertura de conta");
                Console.WriteLine("M => Movimentações");
                Console.WriteLine("L => Listar Contas");
                Console.WriteLine("T => Transferência");
                Console.WriteLine("S => Sair do programa");

                tipoOperacao = (TipoOperacao)char.Parse(Console.ReadLine());

                switch (tipoOperacao)
                {
                    case TipoOperacao.AberturaConta:
                        var conta = AberturaDeConta();
                        listaContas.Add(conta);
                        break;

                    case TipoOperacao.Movimentacao:
                        Movimentar();
                        break;

                    case TipoOperacao.ListarContas:

                        break;

                    case TipoOperacao.Transferencia:
                        Transferir();
                        break;

                    case TipoOperacao.SairDoPrograma:
                        tipoOperacao = TipoOperacao.SairDoPrograma;
                        break;

                    default:

                        break;

                }

            } while (tipoOperacao != TipoOperacao.SairDoPrograma);
        }

        static void ApresentarDadosConta(Conta conta)
        {
            Console.WriteLine("------Bem vindo ao Banco {0}-------", Banco.ObterNomeBanco());
            Console.WriteLine("Agência: {0} - Conta: {1}", conta.NumeroAgencia, conta.NumeroConta);
            Console.WriteLine("{0}", conta.RetornarTipoConta());
            Console.WriteLine("Nome do(s) Titular(es):");

            foreach (Cliente cliente in conta.Titulares)
                Console.WriteLine(cliente.Nome);

            Console.WriteLine("Saldo {0}", conta.Saldo);
            Console.WriteLine("---------------------------------");
        }

        static Conta AberturaDeConta()
        {

            TipoConta tipoConta;
            Conta conta = null;

            Console.Clear();

            Console.WriteLine("------Bem vindo ao Banco {0}-------", Banco.ObterNomeBanco());
            Console.WriteLine("Vamos criar sua conta", Banco.ObterNomeBanco());
            Console.Write("Informe o Tipo da Conta: P => Poupanca / C => Conta Corrente ");
            tipoConta = (TipoConta)char.Parse(Console.ReadLine());

            switch (tipoConta)
            {
                case TipoConta.ContaCorrente:
                    conta = CriarContaCorrente();
                    break;

                case TipoConta.Poupanca:
                    conta = CriarContaPoupanca();
                    break;

                default:

                    break;
            }

            return conta;

        }

        static Conta SolicitarDadosConta(InfoConta infoConta)
        {
            int numeroAgencia;
            int numeroConta;

            Console.Write("Dados da conta {0}", arg0: Enum.GetName(infoConta.GetType(), infoConta));
            Console.Write("Informe o número da Agência: ");
            numeroAgencia = int.Parse(Console.ReadLine());
            Console.Write("Informe o número da Conta: ");
            numeroConta = int.Parse(Console.ReadLine());

            Conta conta = listaContas.Where(c => c.NumeroAgencia == numeroAgencia
                          && c.NumeroConta == numeroConta).SingleOrDefault();

            return conta;
        }

        static List<Cliente> AdicionarTitular()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            char temMaisTitulares = 'n';
            int num = 1;

            do
            {

                Cliente cliente = new Cliente();

                Console.Write($"Informe o número do Nome do {num} Titular da Conta: ");
                cliente.Nome = Console.ReadLine();
                Console.Write($"Informe o número do CPF do {num} Titular da Conta: ");
                cliente.CPF = Console.ReadLine();
                Console.Write($"Informe o número do Telefone do {num} Titular da Conta: ");
                cliente.Telefone = Console.ReadLine();

                listaClientes.Add(cliente);

                num++;

                Console.Write($"Deseja adicionar o {num} Titular para sua conta? S=> Sim / N=> Não ");
                temMaisTitulares = char.Parse(Console.ReadLine());


            } while (temMaisTitulares.ToString().ToLower() != "s");

            return listaClientes;

        }

        static ContaPoupanca CriarContaPoupanca()
        {

            ContaPoupanca conta = new ContaPoupanca();

            Console.Write("Informe o número da Agência: ");
            conta.NumeroAgencia = int.Parse(Console.ReadLine());
            conta.NumeroConta = Banco.NovoNumeroConta();

            //Console.Write("Informe o número da Conta: ");
            //conta.NumeroConta = int.Parse(Console.ReadLine());

            conta.Titulares = AdicionarTitular();

            double valorDeposito;

            if (DepositoInicial(out valorDeposito))
                conta.Depositar(valorDeposito);

            return conta;
        }

        static ContaCorrente CriarContaCorrente()
        {
            ContaCorrente conta = new ContaCorrente();

            Console.Write("Informe o número da Agência: ");
            conta.NumeroAgencia = int.Parse(Console.ReadLine());
            conta.NumeroConta = Banco.NovoNumeroConta();
            //Console.Write("Informe o número da Conta: ");
            //conta.NumeroConta = int.Parse(Console.ReadLine());

            conta.Titulares = AdicionarTitular();

            double valorDeposito;

            if (DepositoInicial(out valorDeposito))
                conta.Depositar(valorDeposito);

            return conta;

        }

        static bool DepositoInicial(out double valor)
        {

            bool retorno = false;
            string depInicial = string.Empty;
            valor = 0.00;

            Console.Write("Deseja fazer um depósito inicial? S=> Sim / N=> Não ");
            depInicial = Console.ReadLine();

            if (depInicial.ToLower() == "s")
            {
                Console.Write("Informe o valor de depósito: ");
                valor = Convert.ToDouble(Console.ReadLine());
                retorno = true;
            };

            return retorno;

        }

        static void Movimentar()
        {

            string tipoMovimento;

            do
            {
                Console.Clear();

                Conta conta = SolicitarDadosConta(InfoConta.Atual);

                if (conta == null)
                    return;

                ApresentarDadosConta(conta);



                Console.WriteLine("Selecione uma movimentação que deseja realizar:");
                Console.WriteLine("D => Depóstio");
                Console.WriteLine("S => Saque");
                Console.WriteLine("R => Retornar ao Menu Anterior");
                tipoMovimento = Console.ReadLine();

                //Sai do loop se o usuário não quer mais realizar a operação
                if (tipoMovimento.ToLower() != "r")
                    break;

                switch (tipoMovimento.ToLower())
                {

                    case "d":

                        Console.Write("Informe o valor de depósito: ");
                        conta.Depositar(double.Parse(Console.ReadLine()));
                        Console.Clear();

                        break;

                    case "s":

                        Console.Write("Informe o valor de saque: ");
                        bool sucesso = conta.Sacar(double.Parse(Console.ReadLine()));

                        if (!sucesso)
                        {
                            Console.Write("Você não tem saldo suficiente! Seu saldo é {0}.", conta.Saldo);
                            Console.Read();
                            continue;
                        }

                        break;
                }

            } while (tipoMovimento.ToLower() != "r");
        }

        static void Transferir()
        {
            Conta contaOrigem = SolicitarDadosConta(InfoConta.Origem);
            Conta contaDestino = SolicitarDadosConta(InfoConta.Destino);

            Console.Write("Informe o valor que deseja transferir: ");
            double valor = Double.Parse(Console.ReadLine());

            if (contaOrigem == null || contaDestino == null)
                return;

            bool confirmado = contaOrigem.Sacar(valor);

            if (!confirmado)
                return;

            contaDestino.Depositar(valor);

        }

    }
}
