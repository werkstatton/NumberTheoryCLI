using ConsoleTables;
using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    internal class SieveOfEratosthenes
    {
        public SieveOfEratosthenes()
        {
            Console.WriteLine("Welcome to Sieve of Eratosthenes Section! \n You need to write natural number to start algorithm! \n");
            try
            {
                var n = Prompt.Input<uint>("So what is this number?");

                Console.WriteLine("Answer is ");
                GetSieve(n);
                 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh! There is some mistake! \n Error message is: " + ex.Message);
                return;
            }
        }

        public static void GetSieve(uint n)
        {
            _ = n <= 0 ? throw new ArgumentOutOfRangeException(nameof(n)) : n;

            var primeNumbers = GetPrimeNumbers();
            new ConsoleTable()
                .AddColumn(primeNumbers.Select(n => n.ToString()))
                .Write(Format.Minimal);

            IEnumerable<int> GetPrimeNumbers()
            {
                bool[] map = new bool[n + 1];

                for (int i = 2; i * i <= n; i++)
                {
                    if (!map[i])
                    {
                        for (int j = i * i; j <= n; j += i)
                        {
                            map[j] = true;
                        }
                    }
                }

                for (int i = 2; i <= n; i++)
                {
                    if (!map[i])
                    {
                        yield return i;
                    }
                }
            }
        }
    }
}
