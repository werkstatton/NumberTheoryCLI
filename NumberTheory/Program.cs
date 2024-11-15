using Sharprompt;

namespace NumberTheory;

public static class NumberTheory
{
    public static void Main(string[] args)
    {
        var activeSections = GetActiveSections();
        var prefferedSection = activeSections[Prompt.Select("Select section: ", activeSections.Keys)];
        _ = Activator.CreateInstance(prefferedSection);
    }

    private static Dictionary<string, Type> GetActiveSections()
    {
        return new Dictionary<string, Type>()
        {
            { nameof(PrimeFactorization), typeof(PrimeFactorization) },
            { nameof(GeneralFunctions), typeof(GeneralFunctions) },
            { nameof(EuclideanAlgorithm), typeof(EuclideanAlgorithm) },
            { nameof(SieveOfEratosthenes) , typeof(SieveOfEratosthenes) },
            { nameof(MatchingFractions), typeof(MatchingFractions) },
            { nameof(Congruence), typeof(Congruence) },
            {nameof(CongruenceSystem), typeof(CongruenceSystem)}
        };
    }
}