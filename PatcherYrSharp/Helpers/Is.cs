namespace PatcherYrSharp.Helpers;

public static class Is
{
    public static bool Any(string text, StringComparison comparisonType, params ReadOnlySpan<string> strs
    )
    {
        foreach (var str in strs)
        {
            if (string.Equals(text, str, comparisonType))
                return true;
        }

        return false;
    }

    public static bool All(string text, StringComparison comparisonType, params ReadOnlySpan<string> strs
    )
    {
        foreach (var str in strs)
        {
            if (!string.Equals(text, str, comparisonType))
                return false;
        }

        return true;
    }
}