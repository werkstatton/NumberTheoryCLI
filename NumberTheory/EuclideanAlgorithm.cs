using ConsoleTables;
using Sharprompt;

namespace NumberTheory
{
    internal class EuclideanAlgorithm
    {
        public EuclideanAlgorithm()
        {
            Console.WriteLine("Welcome to Euclidean Algorith Section! \n You can choose method to find GCD or you need to find LCD:");
            uint a, b;
            try
            {
                var prefferedMethod = Prompt.Select("Select: ", new[] {"GCD", "LCD"});
                
                switch (prefferedMethod)
                {
                    case "GCD": {
                            var methodGCD = Prompt.Select("We need to know preferred method: ", new[] {
                                nameof(Basic), nameof(Extended), nameof(Recursive)
                            });
                            a = Prompt.Input<uint>("First number: ");
                            b = Prompt.Input<uint>("Second number: ");
                            if (a == 0 || b == 0)
                                throw new ArgumentException("Variables need to be more than 0");
                            switch(methodGCD)
                            {
                                case "Basic": Console.WriteLine("Answer is: " + Basic(a, b)); break;
                                case "Extended": Console.WriteLine("Answer is: " + Extended(a, b)); break;
                                case "Recursive": Console.WriteLine("Answer is: " + Recursive(a, b)); break;
                            }
                            break;
                        }
                    case "LCD":
                        {
                            a = Prompt.Input<uint>("First number: ");
                            b = Prompt.Input<uint>("Second number: ");
                            if (a == 0 || b == 0)
                                throw new ArgumentException("Variables need to be more than 0");

                            Console.WriteLine("Answer is: " + Denominator(a, b));
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

        public static uint Basic(uint a, uint b)
        {
            var table = new ConsoleTable(nameof(a), nameof(b));
            while (a != b)
            {
                table.AddRow(a, b);
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    (b, a) = (a, b);
                }
            }

            table.Write(Format.Minimal);
            return a;
        }

        public static uint Extended(uint a, uint b)
        {
            var table = new ConsoleTable(nameof(a),nameof(b));
            while(a % b != 0)
            {
                table.AddRow(a, b);
                var t = b;
                b = a % b;
                a = t;
            }

            table
                .AddRow(a, b)
                .Write(Format.Minimal);
            return b;
        }

        public static uint Recursive(uint a, uint b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return Recursive(b, a % b);
            }
        }

        public static uint Denominator(uint a, uint b)
        {
            return (a /  Basic(a, b)) * b;
        }
    }
}
