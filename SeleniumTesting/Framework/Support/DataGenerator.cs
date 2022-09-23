using System;
using Framework.Support;

namespace Framework.Support
{
    public sealed class DataGenerator
    {
        private readonly Random _random = new();
        private const string _numericChracters = "1234567890";
        private const string _alphaChracters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string _alphaNumericChracters = $"{_alphaChracters}{_numericChracters}";

        public string GenerateRandomString(int length, CharacterSet characterSet)
        {
            string characters = GenerateCharacterSet(characterSet);
            string result = string.Empty;

            for (int i = 0; i < length; i++)
            {
                int chracter = _random.Next(0, characters.Length);
                result += characters[chracter];
            }
            return result;
        }

        private string GenerateCharacterSet(CharacterSet characterSet)
        {
            return characterSet switch
            {
                CharacterSet.Alpha => _alphaChracters,
                CharacterSet.Numeric => _numericChracters,
                CharacterSet.AlphaNumeric => _alphaNumericChracters,
                _ => _alphaNumericChracters,
            };
        }
    }
}
