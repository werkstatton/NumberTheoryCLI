using System.Numerics;
using ConsoleTables;
using Sharprompt;

namespace NumberTheory
{
    internal class EuclideanAlgorithm
    {
        public EuclideanAlgorithm()
        {
            Console.WriteLine("Welcome to Euclidean Algorithm Section! \n You can choose method to find GCD or you need to find LCD:");
            const string answerIsString = "Answer is: ";
            try
            {
                var preferredMethod = Prompt.Select("Select: ", ["GCD", "LCD"]);

                uint b;
                uint a;
                switch (preferredMethod)
                {
                    case "GCD": {
                            var methodGcd = Prompt.Select("We need to know preferred method: ", new[] {
                                nameof(Basic), nameof(Extended), nameof(Recursive)
                            });
                            a = Prompt.Input<uint>("First number: ");
                            b = Prompt.Input<uint>("Second number: ");
                            if (a == 0 || b == 0)
                                throw new ArgumentException("Variables need to be more than 0");
                            switch(methodGcd)
                            {
                                case "Basic": Console.WriteLine(answerIsString + Basic(a, b)); break;
                                case "Extended": Console.WriteLine(answerIsString + Extended(a, b)); break;
                                case "Recursive": Console.WriteLine(answerIsString + Recursive(a, b)); break;
                            }
                            break;
                        }
                    case "LCD":
                        {
                            a = Prompt.Input<uint>("First number: ");
                            b = Prompt.Input<uint>("Second number: ");
                            if (a == 0 || b == 0)
                                throw new ArgumentException("Variables need to be more than 0");

                            Console.WriteLine(answerIsString + Denominator(a, b));
                            break;
                        }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh! There is some mistake! \n Error message is: " + ex.Message);
            }
        }

        public static T Basic<T>(T a, T b) where T : IBinaryInteger<T>
        {
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    (b, a) = (a, b);
                }
            }
            
            return a;
        }

        public static T Extended<T>(T a, T b) where T : IBinaryInteger<T>
        {
            var table = new ConsoleTable(nameof(a),nameof(b));
            while(a % b != T.Zero)
            {
                table.AddRow(a, b);
                var t = b;
                b = a % b;
                a = t;
            }
            
            return b;
        }

        public static T Recursive<T>(T a, T b) where T : IBinaryInteger<T>
        {
            while (true)
            {
                if (b == T.Zero)
                {
                    return a;
                }
                else
                {
                    var a1 = a;
                    a = b;
                    b = a1 % b;
                }
            }
        }

        private static T Denominator<T>(T a, T b) where T : IBinaryInteger<T>
        {
            return (a /  Basic(a, b)) * b;
        }
    }
}
