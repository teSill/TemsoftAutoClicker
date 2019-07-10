using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    class Save {

        private List<ClickCollection> collections;

        public Save(List<ClickCollection> collections) {
            this.collections = collections;
            SaveFile();
        }

        public void SaveFile() {
            if (!Directory.Exists(Application.FolderPath)) {
                Directory.CreateDirectory(Application.FolderPath);
            }

            try {
                foreach(ClickCollection collection in collections) {
                    File.WriteAllText(Path.Combine(Application.FolderPath, collection.Name + ".txt"), ConvertDataToString(collection));
                }
            } catch (Exception e) {
                System.Diagnostics.Debug.Write(e);
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
