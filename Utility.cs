using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemseiAutoClicker {
    static class Utility {

        static Random random = new Random();

        public static string GetStringBetweenCharacters(string @string , string firstCharacter, string lastCharacter) {       
            string finalString;     

            int Pos1 = @string.IndexOf(firstCharacter) + firstCharacter.Length;
            int Pos2 = @string.IndexOf(lastCharacter);
            finalString = @string.Substring(Pos1, Pos2 - Pos1);

            return finalString;
        }

        public static string GetStringBetweenIndexes(string @string , int firstIndex, int secondIndex) {
            return @string.Substring(firstIndex, secondIndex - firstIndex);
        }

        public static char GetRandomLetter() {
            int num = random.Next(0, Application.availableLetters.Length);
            char letter = Application.availableLetters[num];

            return letter;
        }

        public static string GetRandomString(int length) {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++){
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        public static string GetUntilOrEmpty(this string text, string stopAt = ".") {
            if (!String.IsNullOrWhiteSpace(text)) { 
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0) {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }

    }
}
