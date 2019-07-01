using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    class Load {

        private Application application;

        public Load(Application application) {
            this.application = application;
            LoadSettings();
        }

        private void LoadSettings() {
            if (!Directory.Exists(Application.FilePath))
                return;

            string[] textContents = File.ReadAllLines(Path.Combine(Application.FilePath, Application.FileName));

            foreach(string line in textContents) {
                application.RegisterNewClickPosition(ConvertStringToPosition(line));
            }
        }

        private ClickPosition ConvertStringToPosition(string line) {
            Console.WriteLine(line);

            Int32.TryParse(line.Substring(0, line.IndexOf(",")), out int x);
            Int32.TryParse(GetStringBetweenCharacters(line, ",", "-"), out int y);
            string mouseButton = line.Substring(line.LastIndexOf("-") + 1);
            MouseButtons mouse = (mouseButton == "Left") ? MouseButtons.Left : MouseButtons.Right;
                
            return new ClickPosition(x, y, mouse);
        }

        private string GetStringBetweenCharacters(string @string , string firstCharacter, string lastCharacter) {       
            string finalString;     

            int Pos1 = @string.IndexOf(firstCharacter) + firstCharacter.Length;
            int Pos2 = @string.IndexOf(lastCharacter);
            finalString = @string.Substring(Pos1, Pos2 - Pos1);

            return finalString;
        }
    }
}
