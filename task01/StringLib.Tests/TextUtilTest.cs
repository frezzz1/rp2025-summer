using StringLib;

using Xunit;

namespace StringLib.Tests;

public class TextUtilConsonantsTest
{
    [Theory]
    [MemberData(nameof(CountConsonantsParams))]
    public void Can_count_consonants(string input, int expected)
    {
        int result = TextUtil.CountConsonants(input);
        Assert.Equal(expected, result);
    }

    public static TheoryData<string, int> CountConsonantsParams()
    {
        return new TheoryData<string, int>
        {
            // Примеры из задания
            { "The quick brown fox jumps over the lazy dog", 23 },
            { "Съешь же ещё этих мягких французских булок, да выпей чаю.", 26 },
            
            // Английские слова
            { "Hello", 3 },
            { "World", 4 },
            { "rhythm", 5 }, // y не считается согласной
            { "sky", 2 },    // y не считается согласной
            
            // Русские слова
            { "Привет", 4 },
            { "Мир", 2 },
            { "Ёжик", 2 },   // ё - гласная
            { "Йогурт", 4 }, // й - согласная
            
            // Смешанные языки
            { "Hello, мир!", 5 },
            { "Компьютер computer", 10 },
            
            // Краевые случаи
            { null!, 0 },
            { "", 0 },
            { "   ", 0 },
            { "12345", 0 },
            { "@#$%^", 0 },
            { "аеёиоуыэюя", 0 }, // все русские гласные
            { "aeiou", 0 },      // все английские гласные
            
            // Все согласные английские
            { "bcdfghjklmnpqrstvwxz", 20 },
            { "BCDFGHJKLMNPQRSTVWXZ", 20 },
            
            // Все согласные русские
            { "бвгджзйклмнпрстфхцчшщ", 21 },
            { "БВГДЖЗЙКЛМНПРСТФХЦЧШЩ", 21 },
            
            // Слова с апострофами и дефисами
            { "mother-in-law", 7 },
            { "can't", 3 },
            { "up-to-date", 4 },
            { "что-нибудь", 5 },
            
            // Одиночные буквы
            { "а", 0 },
            { "я", 0 },
            { "b", 1 },
            { "z", 1 },
            { "б", 1 },
            { "щ", 1 },
        };
    }
}