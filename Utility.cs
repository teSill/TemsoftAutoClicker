using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemseiAutoClicker {
    class Utility {

        static Random random = new Random();

        public static string GetStringBetweenCharacters(string @string , string firstCharacter, string lastCharacter) {       
            string finalString;     

            int Pos1 = @string.IndexOf(firstCharacter) + firstCharacter.Length;
            int Pos2 = @string.IndexOf(lastCharacter);
            finalString = @string.Substring(Pos1, Pos2 - Pos1);

            return finalString;
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

    }
}
