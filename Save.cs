using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    class Save {

        private List<ClickPosition> savedClicks;

        public Save(List<ClickPosition> clicks) {
            savedClicks = clicks;
            SaveFile();
        }

        public void SaveFile() {
            if (!Directory.Exists(Application.FilePath)) {
                Directory.CreateDirectory(Application.FilePath);
            }

            try {
                File.WriteAllText(Path.Combine(Application.FilePath, Application.FileName), ConvertDataToString());
            } catch (Exception e) {
                System.Diagnostics.Debug.Write(e);
            }
        }

        private string ConvertDataToString() {
            string contents = "";

            foreach(ClickPosition click in savedClicks) {
                contents += click.GetX() + "," + click.GetY() + "-" +  click.GetMouseClickType() + Environment.NewLine;
            }

            return contents;
        }
    }
}
