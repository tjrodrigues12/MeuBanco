using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExercicio2
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int primeiroNumero;
            int segundoNumero;
            char tipoOperacao;

            Console.WriteLine("---------Calculadora Digital--------");
            Console.WriteLine("Vamos efetuar o seu cálculo");

            Console.WriteLine("Informe o primeiro número:");
            primeiroNumero = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Informe letra que corresponde o tipo de operação:");
            Console.WriteLine("( + ) => adição | ( - ) => subtração | ( * )=> multiplicação | ( / ) => divisão");
            tipoOperacao = char.Parse(Console.ReadLine());

            Console.WriteLine("Informe o segundo número:");
            segundoNumero = Int32.Parse(Console.ReadLine());

        }
    }
}
