using ConsoleTables;
using Sharprompt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    internal class PrimeFactorization
    {
        public PrimeFactorization()
        {
            Console.WriteLine("Welcome to Prime Factorization Section! \n You need to write a number to start algorithm! \n");
            try
            {
                var a = Prompt.Input<uint>("Number: ");
                Console.WriteLine("Answer is ");
                GetPrimeFactorization(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh! There is some mistake! \n Error message is: " + ex.Message);
                return;
            }
        }

        public static void GetPrimeFactorization(uint number)
        {
            var primeNumbers = SieveOfEratosthenes.GetPrimeNumbers(number);
            var factors = GetFactors(number, primeNumbers);

            var resultString = new StringBuilder();

            resultString.Append("Prime factorization of " + number + " is: \n");
            var iterator = 0;
            foreach (var factor in factors)
            {
                if (factor != 0)
                {
                    resultString.Append(primeNumbers.ElementAt(iterator)+ "^" + factor + " * ");
                }
                iterator++;
            }

            Console.WriteLine(resultString.ToString().Substring(0, resultString.Length - 3));
        }

        public static IEnumerable<uint> GetFactors(uint a, IEnumerable<uint> primeNumbers)
        {
            var initialNumber = a;
            uint countFactors = 0;
            foreach (var number in primeNumbers)
            {
                a = initialNumber;
                while (a % number == 0)
                {
                    countFactors++;
                    a /= number;
                }
                yield return countFactors;
                countFactors = 0;
            }
        }
    }
}
