using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    class Load {

        private Application _application;
        private List<ClickCollection> _clickCollections;

        public Load(Application application, List<ClickCollection> clickCollections) {
            _application = application;
            _clickCollections = clickCollections;
            LoadSettings();
            LoadAutomatedLists();
        }

        private void LoadSettings() {
            if (!Directory.Exists(Application.FolderPath))
                return;

            foreach(string file in Directory.EnumerateFiles(Application.FolderPath, "*.txt")) {
                if (file.Contains("AutomatedLists")) {
                    continue;
                }
                string[] contents = File.ReadAllLines(file);
                string fileName = Path.GetFileName(file).Substring(0, Path.GetFileName(file).Length -4);
                ClickCollection clickCollection = ConvertFileContentIntoCollection(contents, fileName);
                clickCollection.SavedName = clickCollection.Name;
                _application.clickCollections.Add(clickCollection);
                
            }
            _application.ListsAtStart = _clickCollections.Count;
            _application.UpdateLoadedListData(_clickCollections);
        }

        private ClickCollection ConvertFileContentIntoCollection(string[] fileContent, string name) {
            string collectionName = name;
            string singleLoopText;
            bool singleLoop = false;
            char hotkey = '\0';
            float clickInterval = 0;
            List<ClickPosition> clicks = new List<ClickPosition>();

            int clickStartIndex = 0;
            bool breakLoop = false;
            for(int i = 0; i < fileContent.Length; i++) {
                switch(fileContent[i]) {
                    case string str when str.Contains("SingleLoop"):
                        singleLoopText = fileContent[i].Substring(fileContent[i].IndexOf(':') + 1);
                        singleLoop = singleLoopText == "True" ? true : false;
                    break;
                    case string str when str.Contains("Hotkey"):
                        hotkey = Convert.ToChar(fileContent[i].Substring(fileContent[i].IndexOf(':') + 1));
                        break;
                    case string str when str.Contains("ClickInterval"):
                        float.TryParse(fileContent[i].Substring(fileContent[i].IndexOf(':') + 1), NumberStyles.Any, CultureInfo.InvariantCulture, out clickInterval);
                        break;
                    case string str when str.Contains("Clicks"):
                        clickStartIndex = i + 1;
                        breakLoop = true;
                        break;
                    default:
                        break;
                }
                if (breakLoop)
                    break;
            }

            for(int j = clickStartIndex; j < fileContent.Length; j++) {
                clicks.Add(ConvertStringToPosition(fileContent[j]));
            }

            return new ClickCollection(clicks, collectionName, singleLoop, hotkey, clickInterval);

        }

        private void LoadAutomatedLists() {
            string path = Path.Combine(Application.FolderPath, "AutomatedLists.txt");
            if (!File.Exists(path))
                return;

            List<string> listNames = new List<string>();
            using (StreamReader sr = File.OpenText(path)) {
                string str = "";
                while ((str = sr.ReadLine()) != null) {
                    listNames.Add(str);
                }
            }
            _application.InitializeAutomatedLists(listNames);
        }

        private ClickPosition ConvertStringToPosition(string line) {
            Int32.TryParse(line.Substring(0, line.IndexOf(",")), out int x);
            Int32.TryParse(Utility.GetStringBetweenCharacters(line, ",", "-"), out int y);
            string mouseButton = line.Substring(line.LastIndexOf("-") + 1);
            MouseButtons mouse = (mouseButton == "Left") ? MouseButtons.Left : MouseButtons.Right;
                
            return new ClickPosition(x, y, mouse);
        }
    }
}
