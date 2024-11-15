using Sharprompt;
using System.Text;
using static NumberTheory.SieveOfEratosthenes;

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
                var factorizationNumbers =  GetPrimeFactorizationNumbers(a);
                var factors = GetPrimeFactorizationFactors(a);

                ShowPrimeFactorization(factorizationNumbers, factors);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh! There is some mistake! \n Error message is: " + ex.Message);
            }
        }

        public static ICollection<uint> GetPrimeFactorizationNumbers(uint number)
        {
            var primeNumbers = GetPrimeNumbers(number);
            var factors = GetPrimeFactorizationFactors(number);

            var result = new List<uint>();

            var iterator = 0;
            foreach (var factor in factors)
            {
                if (factor != 0)
                {
                    result.Add(primeNumbers.ElementAt(iterator));
                }
                iterator++;
            }

            return result;
        }

        private static void ShowPrimeFactorization(IEnumerable<uint> factorizationNumbers, IEnumerable<uint> factors)
        {
            var resultString = new StringBuilder();

            var iterator = 0;
            foreach (var factor in factors)
            {
                if (factor == 0) continue;
                resultString.Append(factorizationNumbers.ElementAt(iterator) + "^" + factor + " * ");
                iterator++;

            }

            Console.WriteLine(resultString.ToString()[..(resultString.Length - 3)]);
        }

        public static IEnumerable<uint> GetPrimeFactorizationFactors(uint a)
        {
            var initialNumber = a;
            var primeNumbers = GetPrimeNumbers(a);

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
