using System;
using System.Collections.Generic;
using System.Linq;

using AppExercicio5.Domain;
using AppExercicio5.Util.Enumerador;

namespace AppExercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Conta> listaContas = new List<Conta>();
            TipoOperacao tipoOperacao;

            do
            {
                Console.Clear();

                Write($"------Bem vindo ao Banco {Banco.ObterNomeBanco()}-------");
                Write("Selecione uma operação que deseja realizar:");
                Write("A => Abertura de conta");
                Write("M => Movimentações");
                Write("L => Listar Contas");
                Write("T => Transferência");
                Write("S => Sair do programa");
                Console.Write("=> ");

                tipoOperacao = (TipoOperacao)char.Parse(Console.ReadLine().ToUpper());

                switch (tipoOperacao)
                {
                    case TipoOperacao.AberturaConta:
                        var conta = AberturaDeConta();
                        listaContas.Add(conta);
                        break;

                    case TipoOperacao.Movimentacao:
                        Movimentar(listaContas);
                        break;

                    case TipoOperacao.ListarContas:
                        ListarContas(listaContas);
                        break;

                    case TipoOperacao.Transferencia:
                        Transferir(listaContas);
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
            Write($"------Bem vindo ao Banco {Banco.ObterNomeBanco()}-------");
            Write($"Número da Agência: {conta.NumeroAgencia}");
            Write($"Número da Conta: {conta.NumeroConta}");
            Write($"{conta.RetornarTipoConta}");
            Write($"Nome do(s) Titular(es):");

            foreach (Cliente cliente in conta.Titulares)
                Console.WriteLine(cliente.Nome);

            Write($"Saldo {conta.Saldo}");
            Write("---------------------------------");
        }

        static Conta AberturaDeConta()
        {

            TipoConta tipoConta;
            Conta conta = null;

            Console.Clear();

            Write($"------Bem vindo ao Banco {Banco.ObterNomeBanco()}-------");
            Write("Vamos criar sua conta");
            tipoConta = (TipoConta)char.Parse(WriteRead("Informe o Tipo da Conta: P => Poupanca / C => Conta Corrente: ").ToUpper());

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

        static Conta SolicitarDadosConta(InfoConta infoConta, List<Conta> listaContas)
        {
            int numeroAgencia;
            int numeroConta;

            Write($"Dados da conta {Enum.GetName(infoConta.GetType(), infoConta)}");
            numeroAgencia = int.Parse(WriteRead("Informe o número da Agência: "));
            numeroConta = int.Parse(WriteRead("Informe o número da Conta: "));

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

                cliente.Nome = WriteRead($"Informe o número do Nome do {num}º Titular da Conta: ");
                cliente.CPF = WriteRead($"Informe o número do CPF do {num}º Titular da Conta: ");

                listaClientes.Add(cliente);

                num++;

                Write($"Deseja adicionar o {num} Titular para sua conta? S=> Sim / N=> Não: ");
                temMaisTitulares = char.Parse(Console.ReadLine());


            } while (temMaisTitulares.ToString().ToLower() != "n");

            return listaClientes;

        }

        static ContaPoupanca CriarContaPoupanca()
        {

            ContaPoupanca conta = new ContaPoupanca(
                int.Parse(WriteRead("Informe o número da Agência: ")),
                Banco.NovoNumeroConta(),
                AdicionarTitular()
                );

            Write($"Seu número da Conta é: {conta.NumeroConta}");

            double valorDeposito;

            if (DepositoInicial(out valorDeposito))
                conta.Depositar(valorDeposito);

            return conta;
        }

        static ContaCorrente CriarContaCorrente()
        {
            ContaCorrente conta = new ContaCorrente(
                int.Parse(WriteRead("Informe o número da Agência: ")),
                Banco.NovoNumeroConta(),
                AdicionarTitular()
                );

            Write($"Seu número da Conta é: {conta.NumeroConta}");

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

            depInicial = WriteRead("Deseja fazer um depósito inicial? S=> Sim / N=> Não: ");

            if (depInicial.ToLower() == "s")
            {
                valor = Convert.ToDouble(WriteRead("Informe o valor de depósito: "));
                retorno = true;
            };

            return retorno;

        }

        static void Movimentar(List<Conta> listaContas)
        {
            string tipoMovimento;

            do
            {
                Write("Selecione uma movimentação que deseja realizar:");
                Write("D => Depóstio");
                Write("S => Saque");
                Write("R => Retornar ao Menu Anterior");
                tipoMovimento = Console.ReadLine();

                Conta conta = SolicitarDadosConta(InfoConta.Atual, listaContas);

                //Se não encontrar a conta volta novamente ao loop
                if (conta == null)
                    return;

                ApresentarDadosConta(conta);

                //Sai do loop se o usuário não quer mais realizar a operação
                if (tipoMovimento.ToLower() == "r")
                    break;

                switch (tipoMovimento.ToLower())
                {
                    case "d":

                        conta.Depositar(double.Parse(WriteRead("Informe o valor de depósito: ")));
                        Write("Deposito realizado com sucesso!");

                        break;

                    case "s":

                        bool sucesso = conta.Sacar(double.Parse(WriteRead("Informe o valor de saque: ")));
                        if (!sucesso)
                        {
                            Write($"Você não tem saldo suficiente! Seu saldo é {conta.Saldo}.");
                            Console.ReadKey();
                            continue;
                        }
                        Write("Saque realizado com sucesso!");

                        break;
                }

            } while (tipoMovimento.ToLower() != "r");

            ReturnText();
        }

        static void Transferir(List<Conta> listaContas)
        {
            Conta contaOrigem = SolicitarDadosConta(InfoConta.Origem, listaContas);
            Conta contaDestino = SolicitarDadosConta(InfoConta.Destino, listaContas);

            double valor = Double.Parse(WriteRead("Informe o valor que deseja transferir: "));

            if (contaOrigem == null || contaDestino == null)
                return;

            bool confirmado = contaOrigem.Sacar(valor);

            if (!confirmado)
                return;

            contaDestino.Depositar(valor);

            Write("Transferencia realizada com sucesso!");

            ReturnText();

        }

        static void ListarContas(List<Conta> listaContas)
        {
            Write("----- Listagem de contas cadastradas: -----");

            foreach (Conta conta in listaContas)
                ApresentarDadosConta(conta);

            ReturnText();
        }

        static void Write(string message)
        {
            Console.WriteLine(message);
        }

        static string WriteRead(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        static void ReturnText()
        {
            Console.WriteLine("Pressione uma tecla para retornar...");
            Console.ReadKey();
        }
    }
}
