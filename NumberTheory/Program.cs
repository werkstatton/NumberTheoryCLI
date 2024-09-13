using Sharprompt;

namespace NumberTheory;

public class NumberTheory
{
    public static void Main(string[] args)
    {
        var activeSections = GetActiveSections();
        var prefferedSection = activeSections[Prompt.Select("Select section: ", activeSections.Keys)];
        _ = Activator.CreateInstance(prefferedSection);

        Console.WriteLine("Goodbye!");
    }

    private static Dictionary<string, Type> GetActiveSections()
    {
        return new Dictionary<string, Type>()
        {
            { nameof(EuclideanAlgorithm), typeof(EuclideanAlgorithm) },
            { nameof(SieveOfEratosthenes) , typeof(SieveOfEratosthenes) },
        };
    }
}