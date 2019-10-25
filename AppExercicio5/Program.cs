using System;
using System.Collections.Generic;
using System.Linq;

using AppExercicio5.Domain;
using AppExercicio5.Util;

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

                Console.WriteLine("------Bem vindo ao Banco {0}-------", Banco.ObterNomeBanco());

                Console.WriteLine("Selecione uma operação que deseja realizar:");
                Console.WriteLine("A => Abertura de conta");
                Console.WriteLine("M => Movimentações");
                Console.WriteLine("L => Listar Contas");
                Console.WriteLine("T => Transferência");
                Console.WriteLine("S => Sair do programa");
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
            Console.WriteLine("------Bem vindo ao Banco {0}-------", Banco.ObterNomeBanco());
            Console.WriteLine("Número da Agência: {0}", conta.NumeroAgencia);
            Console.WriteLine("Número da Conta: {0}", conta.NumeroConta);
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
            Console.WriteLine("Informe o Tipo da Conta: P => Poupanca / C => Conta Corrente ");
            Console.Write("=> ");
            tipoConta = (TipoConta)char.Parse(Console.ReadLine().ToUpper());

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

            Console.WriteLine("Dados da conta {0}", arg0: Enum.GetName(infoConta.GetType(), infoConta));
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

                listaClientes.Add(cliente);

                num++;

                Console.WriteLine($"Deseja adicionar o {num} Titular para sua conta? S=> Sim / N=> Não ");
                Console.Write("=> ");
                temMaisTitulares = char.Parse(Console.ReadLine());


            } while (temMaisTitulares.ToString().ToLower() != "n");

            return listaClientes;

        }

        static ContaPoupanca CriarContaPoupanca()
        {

            ContaPoupanca conta = new ContaPoupanca();

            Console.Write("Informe o número da Agência: ");
            conta.NumeroAgencia = int.Parse(Console.ReadLine());
            conta.NumeroConta = Banco.NovoNumeroConta();
            Console.WriteLine($"Seu número da Conta é: {conta.NumeroConta}");

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
            Console.WriteLine($"Seu número da Conta é: {conta.NumeroConta}");

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

            Console.WriteLine("Deseja fazer um depósito inicial? S=> Sim / N=> Não ");
            Console.Write("=> ");
            depInicial = Console.ReadLine();

            if (depInicial.ToLower() == "s")
            {
                Console.Write("Informe o valor de depósito: ");
                valor = Convert.ToDouble(Console.ReadLine());
                retorno = true;
            };

            return retorno;

        }

        static void Movimentar(List<Conta> listaContas)
        {

            string tipoMovimento;

            do
            {
                Conta conta = SolicitarDadosConta(InfoConta.Atual, listaContas);

                if (conta == null)

                    return;

                ApresentarDadosConta(conta);

                Console.WriteLine("Selecione uma movimentação que deseja realizar:");
                Console.WriteLine("D => Depóstio");
                Console.WriteLine("S => Saque");
                Console.WriteLine("R => Retornar ao Menu Anterior");
                Console.Write("=> ");
                tipoMovimento = Console.ReadLine();

                //Sai do loop se o usuário não quer mais realizar a operação
                if (tipoMovimento.ToLower() == "r")
                    break;

                switch (tipoMovimento.ToLower())
                {

                    case "d":

                        Console.Write("Informe o valor de depósito: ");
                        conta.Depositar(double.Parse(Console.ReadLine()));
                        Console.WriteLine("Deposito realizado com sucesso!");                        
                        break;

                    case "s":

                        Console.Write("Informe o valor de saque: ");
                        bool sucesso = conta.Sacar(double.Parse(Console.ReadLine()));

                        if (!sucesso)
                        {
                            Console.WriteLine("Você não tem saldo suficiente! Seu saldo é {0}.", conta.Saldo);                            
                            continue;
                        }

                        Console.WriteLine("Saque realizado com sucesso!");                       

                        break;
                }

            } while (tipoMovimento.ToLower() != "r");

            Console.WriteLine("Pressione uma tecla para retornar...");
            Console.ReadKey();
        }

        static void Transferir(List<Conta> listaContas)
        {
            Conta contaOrigem = SolicitarDadosConta(InfoConta.Origem, listaContas);
            Conta contaDestino = SolicitarDadosConta(InfoConta.Destino, listaContas);

            Console.Write("Informe o valor que deseja transferir: ");
            double valor = Double.Parse(Console.ReadLine());

            if (contaOrigem == null || contaDestino == null)
                return;

            bool confirmado = contaOrigem.Sacar(valor);

            if (!confirmado)
                return;

            contaDestino.Depositar(valor);

            Console.WriteLine("Transferencia realizada com sucesso!");

            Console.WriteLine("Pressione uma tecla para retornar...");
            Console.ReadKey();

        }

        static void ListarContas(List<Conta> listaContas)
        {
            Console.WriteLine("# Listagem de contas cadastradas:");
            foreach (Conta conta in listaContas)
            {
                ApresentarDadosConta(conta);                
            }
            Console.WriteLine("Pressione uma tecla para retornar...");
            Console.ReadKey();
        }
    }
}
