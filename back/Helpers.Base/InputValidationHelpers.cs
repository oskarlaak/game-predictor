namespace Helpers.Base;

public static class InputValidationHelpers
{
    public static bool AnyNegative(params int[] integers)
    {
        foreach (int i in integers)
        {
            if (i < 0) return true;
        }
        return false;
    }
    
    public static bool AnyEmptyOrWhiteSpace(params string[] strings)
    {
        foreach (string s in strings)
        {
            if (string.IsNullOrWhiteSpace(s)) return true;
        }
        return false;
    }
}
