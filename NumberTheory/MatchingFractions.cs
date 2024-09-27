using ConsoleTables;
using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return;
            }
        }

        public static void GetMatchingFractions(uint a, uint b)
        {
            var table = new ConsoleTable(" "," ");
            var coefficients = GetCoefficients(a, b);
            table
                .AddColumn(coefficients.Select(n => n.ToString()));

            var P = new List<uint>() { 1 };
            var Q = new List<uint>() { 0 };
            for (var i = 0; i < coefficients.Count; i++)
            {
                P.Add(P[i] * coefficients[i] + (i != 0? P[i - 1] : 0));
                Q.Add((i == 0? 1 : Q[i]) * (i == 0? 1 : coefficients[i]) + (i != 0 ? Q[i - 1] : 0));
            }
            table.AddRow(P.Select(t => t.ToString()).Reverse().Append("P").Reverse().ToArray())
                 .AddRow(Q.Select(t => t.ToString()).Reverse().Append("Q").Reverse().ToArray());

            table.Write(Format.Alternative);
        }

        private static List<uint> GetCoefficients(uint a, uint b)
        {
            var coefficients = new List<uint>();
            while (b != 0)
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
