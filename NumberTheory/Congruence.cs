using static NumberTheory.MatchingFractions;
using Sharprompt;

namespace NumberTheory
{
    public class Congruence
    {
        public Congruence()
        {
            Console.WriteLine("Welcome to Congruence Section! \n You need to write a few numbers to start algorithm! \n This section currently solves ax \u2261 b (mod m) \n");
            try
            {
                var a = Prompt.Input<int>("Number a: ");
                var b = Prompt.Input<int>("Number b: ");
                var m = Prompt.Input<int>("Number m (m > 0): ");
                if (m <= 0)
                {
                    throw new ArgumentException("m must be greater than 0");
                }
                
                var x = SolveCongruenceMatchingFractions(a, b, m);

                Console.WriteLine("Answer is " + x);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh! There is some mistake! \n Error message is: " + ex.Message);
            }
        }

        // Returns: [a, b, m]
        public static List<int> SolveCongruenceMatchingFractions(int a, int b, int m)
        {
            var result = 0;
            if(EuclideanAlgorithm.Extended(m, a) == 1)
            {
                result = SolveMatchingFractions(a, b, m);
            }

            return [1, result, m];
        }

        private static int SolveMatchingFractions(int a, int b, int m)
        {
            var matchingFractionCoefficients = GetMatchingFractionsCoefficients(m, a);
            var p = new List<int>() { 1 };

            for (var i = 0; i < matchingFractionCoefficients.Count; i++)
            {
                p.Add(p[i] * matchingFractionCoefficients[i] + (i != 0 ? p[i - 1] : 0));
            }
            var x = (b * p[^2]) % m;
            if (Math.Pow(-1, p.Count - 2) >= 0)
                return x;

            x *= -1;
            x += m;

            return x;
        }
    }
}
