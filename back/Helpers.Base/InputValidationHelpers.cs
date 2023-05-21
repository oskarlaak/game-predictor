namespace Helpers.Base;

public static class InputValidationHelpers
{
    public static bool AnyEmptyOrWhiteSpace(params string[] strings)
    {
        foreach (string s in strings)
        {
            if (string.IsNullOrWhiteSpace(s)) return true;
        }
        return false;
    }
}
