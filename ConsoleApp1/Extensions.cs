using System.Text.RegularExpressions;

public static class Extensions
{
    public static bool IsUpperCase(this string c) => Regex.IsMatch(c.ToString(), "[A-Z]");
    public static bool IsLowerCase(this string c) => Regex.IsMatch(c.ToString(), "[a-z]");

    public static bool IsNumber(this string c) => Regex.IsMatch(c.ToString(), "[0-9]");

}


