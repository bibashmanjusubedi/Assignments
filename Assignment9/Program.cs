using System;
namespace Assignment9;
/// <summary>
/// Provides utility methods for working with strings.
/// </summary>

public static class StringUtilities
{
    /// <summary>
    /// Counts the number of words in the input string.
    /// Words are separated by spaces, tabs, or newline characters.
    /// </summary>
    /// <param name="input">The string to evaluate.</param>
    /// <returns>The number of words in the input string.</returns>
    public static int CountWords(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return 0;
        return input.Split(new char[] { ' ', '\t', '\n', '\r' },
            StringSplitOptions.RemoveEmptyEntries).Length;
    }

    /// <summary>
    /// Reverses the content of the input string.
    /// </summary>
    /// <param name="input">The string to reverse.</param>
    /// <returns>The reversed string.</returns>

    public static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    /// <summary>
    /// Checks if the input string is a palindrome.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns>True if the input is a palindrome; otherwise, false.</returns>
    public static bool IsPalindrome(string input)
    {
        string reversed = ReverseString(input.ToLower());
        return string.Equals(input.ToLower(), reversed);
    }



    /// <summary>
    /// Removes all space characters from the input string.
    /// </summary>
    /// <param name="input">The string to process.</param>
    /// <returns>The input string with all spaces removed.</returns>
    public static string RemoveSpaces(string input)
    {
        if (input == null)
            return null;
        return input.Replace(" ", "");
    }
}



/// <summary>
/// Demonstrates usage of StringUtilities methods.
/// </summary>
class Program
{

    /// <summary>
    /// Entry point for demonstration.
    /// </summary>
    static void Main()
    {
        string test = "Bibash Acharya";
        Console.WriteLine(StringUtilities.CountWords(test));
        Console.WriteLine(StringUtilities.ReverseString(test));
        Console.WriteLine(StringUtilities.IsPalindrome(test));
        Console.WriteLine(StringUtilities.RemoveSpaces(test));
    }
}