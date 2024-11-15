using Sharprompt;
using static NumberTheory.Congruence;
namespace NumberTheory;

public class CongruenceSystem
{
    public CongruenceSystem()
    {
        var bList = Prompt.List<string>("Please add b coefficient(s): ").Select(int.Parse).ToList();
        var mList = Prompt.List<string>("Please add m coefficient(s): ").Select(int.Parse).ToList();
        if (bList.Count != mList.Count)
        {
            Console.WriteLine("Count of b and m are different.");
            return;
        }
        
        var answer = SolveCongruenceSystem(bList, mList);
        Console.WriteLine(@"The answer is: {0}x = {1} (mod {2})", answer[0], answer[1], answer[2]);
    }

    // Solves system of
    // a1*x = b1 (mod m1),
    // a2*x = b2 (mod m2),
    // ...,
    // an*x = bn (mod mn) 
    // Returns list: [a, b, m]
    public static List<int> SolveCongruenceSystem(List<int> bList, List<int> mList)
    {
        var solvingCount = mList.Count-1;
        var answerForSystem = SolveTwoParametersCongruenceSystem(1, 1, bList[0], bList[1], mList[0], mList[1]);
        for (var i = 0; i < solvingCount - 1; i++)
        {
            answerForSystem = SolveTwoParametersCongruenceSystem(answerForSystem[0], 1, answerForSystem[1], bList[i + 2], answerForSystem[2], mList[i + 2]);
        }

        if (answerForSystem[1] < 0)
        {
            answerForSystem[1] += answerForSystem[2];
        }

        // a, b, m
        return answerForSystem;
    }
    
    // Solves system
    // a1*x = b1 (mod m1)
    // a2*x = b2 (mod m2)
    // Returns list: [a, b, m]
    public static List<int> SolveTwoParametersCongruenceSystem(int a1, int a2, int b1, int b2, int m1, int m2)
    {
        b1 = SolveCongruenceMatchingFractions(a1, b1, (uint)m1);
        b2= SolveCongruenceMatchingFractions(a2, b2, (uint)m2);
        var s = SolveCongruenceMatchingFractions(m1, b2 - b1, (uint)m2);

        // a, b, m
        return [1, (s * m1 + b1)%(m1*m2), m1 * m2];
    }

    
}