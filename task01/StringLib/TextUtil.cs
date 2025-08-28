using System.Text.RegularExpressions;

namespace StringLib;

public static class TextUtil
{
    public static List<string> SplitIntoWords(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return [];
        }

        const string pattern = @"\p{L}+(?:[\-\']\p{L}+)*";
        Regex regex = new(pattern, RegexOptions.Compiled);

        return regex.Matches(text)
            .Select(match => match.Value)
            .ToList();
    }

    public static int CountConsonants(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return 0;
        }

        // Согласные буквы английского и русского алфавитов (в нижнем регистре)
        const string englishConsonants = "bcdfghjklmnpqrstvwxz";
        const string russianConsonants = "бвгджзйклмнпрстфхцчшщ";

        int count = 0;
        foreach (char c in text)
        {
            if (!char.IsLetter(c))
            {
                continue;
            }

            char lowerC = char.ToLowerInvariant(c);
            if (englishConsonants.Contains(lowerC) || russianConsonants.Contains(lowerC))
            {
                count++;
            }
        }

        return count;
    }
}