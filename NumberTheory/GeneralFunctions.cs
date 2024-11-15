using Sharprompt;
using static NumberTheory.PrimeFactorization;

namespace NumberTheory
{
    internal class GeneralFunctions
    {

        public GeneralFunctions() 
        {
            Console.WriteLine("Welcome to General Functions Section! \n You need to write a number to start algorithm! \n");
            try
            {
                var preferredFunction = Prompt.Select("Select: ",
                    ["Whole Part Function", "Fraction part Function", "Tau Function", "Euler Function", "Möbius Function"
                    ]);
                const string numberString = "Number: ";
                const string answerIsString = "Answer is: ";
                switch (preferredFunction)
                {
                    case "Whole Part Function":
                        {
                            var a = Prompt.Input<decimal>(numberString);
                            Console.WriteLine(answerIsString + GetWholePart(a));
                            break;
                        }
                    case "Fraction part Function":
                        {
                            var a = Prompt.Input<decimal>(numberString);
                            Console.WriteLine(answerIsString + GetFractionPart(a));
                            break;
                        }
                    case "Tau Function":
                        {
                            var a = Prompt.Input<uint>(numberString);
                            Console.WriteLine(answerIsString + GetTau(a));
                            break;
                        }
                    case "Euler Function":
                        {
                            var a = Prompt.Input<uint>(numberString);
                            Console.WriteLine(answerIsString + GetEuler(a));
                            break;
                        }
                    case "Möbius Function":
                        {
                            var a = Prompt.Input<uint>(numberString);
                            Console.WriteLine(answerIsString + GetMöbius(a));
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh! There is some mistake! \n Error message is: " + ex.Message);
            }
        }

        private static int GetMöbius(uint a)
        {
            var primeFactorizationNumbers = GetPrimeFactorizationNumbers(a);
            var factors = GetPrimeFactorizationFactors(a);
            if (factors.Contains((uint)2))
            {
                
                return 0;
            }

            return primeFactorizationNumbers.Count % 2 == 0 ? 1 : -1;
        }

        private static int GetEuler(uint a)
        {
            var primeFactorizationNumbers = GetPrimeFactorizationNumbers(a);
            var result = (decimal)a;
            result = primeFactorizationNumbers.Aggregate(result, (current, prime) => current * (1 - (1 / (decimal)prime)));

            if(GetFractionPart(result) == 0)
            {
                return (int)result;
            }

            throw new ArgumentException("Euler function is not integer!");
        }

        public static int GetWholePart(decimal a)
        {
            return (int)Math.Floor(a);
        }

        public static int GetFractionPart(decimal a)
        {
            return (int)(a - Math.Floor(a));
        }

        public static int GetTau(uint a)
        {
            var factors = GetPrimeFactorizationFactors(a);
            return factors.Aggregate(1, (current, factor) => current * ((int)factor + 1));
        }
    }
}
