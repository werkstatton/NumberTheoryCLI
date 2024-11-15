using Sharprompt;
using static NumberTheory.Congruence;
namespace NumberTheory;

public class CongruenceSystem
{
    public CongruenceSystem()
    {
        var aList = Prompt.List<string>("Please add a coefficient(s): ").Select(int.Parse).ToList();
        var bList = Prompt.List<string>("Please add b coefficient(s): ").Select(int.Parse).ToList();
        var mList = Prompt.List<string>("Please add m coefficient(s): ").Select(int.Parse).ToList();
        if (aList.Count != bList.Count || bList.Count != mList.Count)
        {
            Console.WriteLine("Counts of lists are different.");
            return;
        }
        
        var answer = SolveCongruenceSystem(aList, bList, mList);
        Console.WriteLine(@"The answer is: {0}x = {1} (mod {2})", answer[0], answer[1], answer[2]);
    }

    // Solves system of
    // a1*x = b1 (mod m1),
    // a2*x = b2 (mod m2),
    // ...,
    // an*x = bn (mod mn) 
    // Returns list: [a, b, m]
    private static List<int> SolveCongruenceSystem(List<int> aList, List<int> bList, List<int> mList)
    {
        for (var i = 0; i < aList.Count; i++)
        {
            var a = aList[i];
            if (a == 1) continue;
            
            var answer = SolveCongruenceMatchingFractions(a, bList[i], mList[i]);
            aList[i] = answer[0]; bList[i] = answer[1]; mList[i] = answer[2];
        }
        
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
    private static List<int> SolveTwoParametersCongruenceSystem(int a1, int a2, int b1, int b2, int m1, int m2)
    {
        b1 = SolveCongruenceMatchingFractions(a1, b1, m1)[1];
        b2= SolveCongruenceMatchingFractions(a2, b2, m2)[1];
        var s = SolveCongruenceMatchingFractions(m1, b2 - b1, m2)[1];
        
        // a, b, m
        return [1, (s * m1 + b1)%(m1*m2), m1 * m2];
    }

    
}