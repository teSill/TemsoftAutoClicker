using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    class Save {

        private List<ClickCollection> _collections;
        private List<ClickCollection> _automatedCollections;

        public Save(List<ClickCollection> collections, List<ClickCollection> automatedCollections) {
            _collections = collections;
            _automatedCollections = automatedCollections;
            SaveFile();
            SaveAutomatedLists();
        }

        private void SaveFile() {
            if (!Directory.Exists(Application.FOLDER_PATH)) {
                Directory.CreateDirectory(Application.FOLDER_PATH);
            }

            try {
                foreach(ClickCollection collection in _collections) {
                    string savedPreviousFile = Path.Combine(Application.FOLDER_PATH, collection.SavedName + ".txt");
                    if (File.Exists(savedPreviousFile) && savedPreviousFile != collection.Name) {
                        File.Delete(savedPreviousFile);
                    }
                    File.WriteAllText(Path.Combine(Application.FOLDER_PATH, collection.Name + ".txt"), ConvertDataToString(collection));
                }
            } catch (Exception e) {
                System.Diagnostics.Debug.Write(e);
            }
        }

        private void SaveAutomatedLists() {
            using(StreamWriter sw = File.CreateText(Path.Combine(Application.FOLDER_PATH, "AutomatedLists.txt"))) {
                foreach(ClickCollection collection in _automatedCollections) {
                    sw.WriteLine(collection.Name);
                }
            }
        }

        private string ConvertDataToString(ClickCollection collection) {
            string contents = "";
            contents += "WARNING: DO NOT MODIFY THE CONTENTS OF THIS FILE - DOING SO COULD CORRUPT THE LIST!" + Environment.NewLine;;
            contents += "SingleLoop:" + collection.SingleLoop + Environment.NewLine;
            contents += "Hotkey:" + collection.Hotkey + Environment.NewLine;
            contents += "ClickInterval:" + collection.ClickInterval + Environment.NewLine;

            contents += Environment.NewLine + "Clicks:" + Environment.NewLine;

            for(int i = 0; i < collection.Clicks.Count; i++) {
                contents += collection.Clicks[i].X + "," + collection.Clicks[i].Y + "-" +  collection.Clicks[i].MouseButton + Environment.NewLine;
            }
            return contents;
        }
    }
}
