using System.Numerics;
using ConsoleTables;
using Sharprompt;

namespace NumberTheory
{
    internal class MatchingFractions
    {
        public MatchingFractions()
        {
            Console.WriteLine("Welcome to Matching Fractions Section! \n You need to write two numbers to start algorithm! \n");
            try
            {
                var a = Prompt.Input<uint>("First - numerator: ");
                var b = Prompt.Input<uint>("Second - denominator: ");
                Console.WriteLine("Answer is ");
                GetMatchingFractions(a, b);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh! There is some mistake! \n Error message is: " + ex.Message);
            }
        }

        private static void GetMatchingFractions(uint a, uint b)
        {
            var table = new ConsoleTable(" "," ");
            var coefficients = GetMatchingFractionsCoefficients(a, b);
            table
                .AddColumn(coefficients.Select(n => n.ToString()));

            var p = new List<uint>() { 1 };
            var q = new List<uint>() { 0 };
            for (var i = 0; i < coefficients.Count; i++)
            {
                p.Add(p[i] * coefficients[i] + (i != 0? p[i - 1] : 0));
                q.Add((i == 0? 1 : q[i]) * (i == 0? 1 : coefficients[i]) + (i != 0 ? q[i - 1] : 0));
            }
            table.AddRow(p.Select(t => t.ToString()).Reverse().Append("P").Reverse().ToArray<object>())
                 .AddRow(q.Select(t => t.ToString()).Reverse().Append("Q").Reverse().ToArray<object>());

            table.Write(Format.Alternative);
        }

        public static List<T> GetMatchingFractionsCoefficients<T>(T a, T b) where T : IBinaryInteger<T>
        {
            var coefficients = new List<T>();
            while (b != T.Zero)
            {
                coefficients.Add(a / b);
                var temp = a;
                a = b;
                b = temp % b;
            }
            return coefficients;
        }
    }
}
