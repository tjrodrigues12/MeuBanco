using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExercicio4
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
            //int numeroAgencia = 0;
            //int numeroConta = 0;
            //string nomeDoTitular = string.Empty;
            //string tipoConta;
            //double saldo = 0.00;
            double valorSaque = 0.00;
            string depositoInicial;
            string operacao;
            string tipoOperacao;
            //string nomeDoBanco = "NET";

            Conta conta = new Conta();
            
            //Input dados
            Console.WriteLine("------Bem vindo ao Banco {0}-------", conta.NomeDoBanco);

            Console.Write("Informe o número da Agência: ");
            conta.NumeroAgencia = int.Parse(Console.ReadLine());
            Console.Write("Informe o número da Conta: ");
            conta.NumeroConta = int.Parse(Console.ReadLine());
            Console.Write("Informe o número do Nome do Titular da Conta: ");
            conta.NomeTitular = Console.ReadLine();
            Console.Write("Informe o Tipo da Conta: P => Poupanca / C => Conta Corrente ");
            conta.TipoConta = Char.Parse(Console.ReadLine());
            Console.Write("Deseja fazer um depósito inicial? S=> Sim / N=> Não ");
            depositoInicial = Console.ReadLine();

            if (depositoInicial.ToLower() == "s")
            {
                Console.Write("Informe o valor de depósito: ");
                conta.Depositar(Convert.ToDouble(Console.ReadLine()));
            };


            //Console.WriteLine("------Bem vindo ao Banco X-------");
            //Console.WriteLine("Agência: {0} - Conta: {1}",agencia, conta);
            //Console.WriteLine("Nome do Titular {0}", nomeDoTitular);
            //Console.WriteLine("Tipo de Conta {0}", tipoConta.ToString().ToLower() == "p" ? "Poupança" : "Conta Corrente");
            //Console.WriteLine("Saldo {0}", saldo);
            //Console.WriteLine("---------------------------------");

            do
            {
                Console.Clear();
                ApresentarDadosConta(conta);

                Console.Write("Deseja fazer uma nova operação? S=> Sim / N=> Não ");
                operacao = Console.ReadLine();

                if (operacao.ToLower() != "s")
                    continue;

                Console.Write("Escolha qual operação deseja realizar: D=> Depósito / S=> Saque ");
                tipoOperacao = Console.ReadLine();

                switch (tipoOperacao.ToLower())
                {

                    case "d":

                        Console.Write("Informe o valor de depósito: ");
                        conta.Depositar(double.Parse(Console.ReadLine()));
                        Console.Clear();

                        break;

                    case "s":

                        Console.Write("Informe o valor de saque: ");
                        valorSaque = double.Parse(Console.ReadLine());

                        if (!conta.PodeSacar(valorSaque))
                        {
                            Console.Write("Você não tem saldo suficiente! Seu saldo é {0}.", conta.Saldo);
                            Console.Read();                            
                            continue;
                        }

                        conta.Sacar(valorSaque);                        
                        break;
                }

                //Console.WriteLine("------Bem vindo ao Banco X-------");
                //Console.WriteLine("Agência: {0} - Conta: {1}",agencia, conta);
                //Console.WriteLine("Nome do Titular {0}", nomeDoTitular);
                //Console.WriteLine("Tipo de Conta {0}", tipoConta.ToString().ToLower() == "p" ? "Poupança" : "Conta Corrente");
                //Console.WriteLine("Saldo {0}", saldo);
                //Console.WriteLine("---------------------------------");

            } while (operacao.ToLower() != "n");

        }

        public static void ApresentarDadosConta(Conta conta)
        {
            Console.WriteLine("------Bem vindo ao Banco X-------");
            Console.WriteLine("Agência: {0} - Conta: {1}", conta.NumeroAgencia, conta.NumeroConta);
            Console.WriteLine("Nome do Titular {0}", conta.NomeTitular);
            Console.WriteLine("{0}", conta.TipoConta.ToString().ToLower() == "p" ? "Poupança" : "Conta Corrente");
            Console.WriteLine("Saldo {0}", conta.Saldo);
            Console.WriteLine("---------------------------------");
        }
    }
}

