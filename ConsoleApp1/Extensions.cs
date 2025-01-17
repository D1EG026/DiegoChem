using System.Text.RegularExpressions;

public static class Extensions
{
    public static bool IsUpperCase(this string c) => Regex.IsMatch(c.ToString(), "[A-Z]");

}


