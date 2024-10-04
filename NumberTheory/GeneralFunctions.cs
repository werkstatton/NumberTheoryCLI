using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    internal class GeneralFunctions
    {

        public GeneralFunctions() 
        {
            Console.WriteLine("Welcome to General Functions Section! \n You need to write a number to start algorithm! \n");
            try
            {
                var prefferedFunction = Prompt.Select("Select: ", new[] { "Whole Part", "Fraction part", "Tau" });

                switch (prefferedFunction)
                {
                    case "Whole Part":
                        {
                            var a = Prompt.Input<decimal>("Number: ");
                            GetWholePart(a);   
                            break;
                        }
                    case "Fraction part":
                        {
                            var a = Prompt.Input<decimal>("Number: ");
                            GetFractionPart(a);
                            break;
                        }
                    case "Tau":
                        {
                            var a = Prompt.Input<uint>("Number: ");
                            Console.WriteLine("Answer is ");
                            GetTau(a);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh! There is some mistake! \n Error message is: " + ex.Message);
                return;
            }
        }

        public static void GetWholePart(decimal a)
        {
            Console.WriteLine("Whole part of " + a + " is: " + Math.Floor(a));
        }

        public static void GetFractionPart(decimal a)
        {
            Console.WriteLine("Fraction part of " + a + " is: " + (a - Math.Floor(a)));
        }

        public static void GetTau(uint a)
        {
            var primeNumbers = SieveOfEratosthenes.GetPrimeNumbers(a);
            var factors = PrimeFactorization.GetFactors(a, primeNumbers);

            var result = 1;
            foreach(var factor in factors)
            {
                result *= ((int)factor + 1);
            }

            Console.WriteLine("Result is: " + result);
        }
    }
}
