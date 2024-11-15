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
                ShowSieve(n);
                 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh! There is some mistake! \n Error message is: " + ex.Message);
            }
        }

        public static void ShowSieve(uint n)
        {
            _ = n <= 0 ? throw new ArgumentOutOfRangeException(nameof(n)) : n;

            var primeNumbers = GetPrimeNumbers(n);
            new ConsoleTable()
                .AddColumn(primeNumbers.Select(n => n.ToString()))
                .Write(Format.Minimal);
        }

        public static IEnumerable<uint> GetPrimeNumbers(uint n)
        {
                var map = new bool[n + 1];

                for (var i = 2; i * i <= n; i++)
                {
                    if (map[i]) continue;
                    for (var j = i * i; j <= n; j += i)
                    {
                        map[j] = true;
                    }
                }

                for (var i = 2; i <= n; i++)
                {
                    if (!map[i])
                    {
                        yield return (uint)i;
                    }
                }
        }
    }
}
