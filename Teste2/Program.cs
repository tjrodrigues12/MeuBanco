using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuBanco
{
    class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /* 
             * Sistema Bancário
            */

            //Variáveis
            int agencia = 0;
            int conta = 0;
            string nomeDoTitular = string.Empty;
            string tipoConta;
            double saldo = 0.00;
            double depositoSaque = 0.00;
            string depositoInicial;
            string operacao;
            string tipoOperacao;
            string nomeDoBanco = "Banco .NET";


            //Input dados
            Console.WriteLine("------Bem vindo ao Banco {0}-------", nomeDoBanco);

            Console.Write("Informe o número da Agência: ");
            agencia = int.Parse(Console.ReadLine());
            Console.Write("Informe o número da Conta: ");
            conta = int.Parse(Console.ReadLine());
            Console.Write("Informe o número do Nome do Titular da Conta: ");
            nomeDoTitular = Console.ReadLine();
            Console.Write("Informe o Tipo da Conta: P => Poupanca / C => Conta Corrente ");
            tipoConta = Console.ReadLine();
            Console.Write("Deseja fazer um depósito inicial? S=> Sim / N=> Não ");
            depositoInicial = Console.ReadLine();

            if (depositoInicial.ToLower() == "s")
            {
                Console.Write("Informe o valor de depósito: ");
                saldo = Convert.ToDouble(Console.ReadLine());
            };

            do
            {
                Console.Clear();

                Console.WriteLine("------Bem vindo ao Banco X-------");
                Console.WriteLine("Agência: {0} - Conta: {1}", agencia, conta);
                Console.WriteLine("Nome do Titular {0}", nomeDoTitular);
                Console.WriteLine("Tipo de Conta {0}", tipoConta.ToLower() == "p" ? "Poupança" : "Conta Corrente");
                Console.WriteLine("Saldo {0}", saldo);
                Console.WriteLine("---------------------------------");

                Console.Write("Deseja fazer uma nova operação? S=> Sim / N=> Não");
                operacao = Console.ReadLine();

                if (operacao.ToLower() != "s")
                    continue;

                Console.Write("Escolha qual operação deseja realizar: D=> Depósito / S=> Saque ");
                tipoOperacao = Console.ReadLine();

                switch (tipoOperacao.ToLower())
                {

                    case "d":
                        Console.Write("Informe o valor de depósito: ");
                        depositoSaque = double.Parse(Console.ReadLine());

                        saldo += depositoSaque;

                        break;

                    case "s":
                        Console.Write("Informe o valor de saque: ");
                        depositoSaque = double.Parse(Console.ReadLine());

                        if (saldo < depositoSaque)
                        {
                            Console.Write("Você não tem saldo suficiente! Seu saldo é {0}.", saldo);
                            Console.Read();
                            continue;
                        }

                        saldo -= depositoSaque;

                        break;

                }

                Console.WriteLine("------Bem vindo ao Banco X-------");
                Console.WriteLine("Agência: {0} - Conta: {1}",agencia, conta);
                Console.WriteLine("Nome do Titular {0}", nomeDoTitular);
                Console.WriteLine("Tipo de Conta {0}", tipoConta.ToString().ToLower() == "p" ? "Poupança" : "Conta Corrente");
                Console.WriteLine("Saldo {0}", saldo);
                Console.WriteLine("---------------------------------");

            } while (operacao.ToLower() != "n");


        }
    }
}

