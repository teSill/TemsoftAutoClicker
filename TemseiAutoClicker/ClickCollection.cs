using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemseiAutoClicker {
    public class ClickCollection {

        public List<ClickPosition> Clicks { get; private set; }
        public string Name { get; private set; }
        public bool SingleLoop { get; private set; }
        public char Hotkey { get; private set; }
        public float ClickInterval { get; private set; }

        public string SavedName { get; set; } // The name the file was saved and loaded as. Use this to delete previous versions of the file

        public ClickCollection(List<ClickPosition> clicks, string name, bool singleLoop, char hotkey, float clickSpeed) {
            Clicks = clicks;
            Name = name;
            SingleLoop = singleLoop;
            Hotkey = hotkey;
            ClickInterval = clickSpeed;
        }

        public void UpdateList(string name, bool singleLoop, char hotkey, float clickSpeed) {
            Name = name;
            SingleLoop = singleLoop;
            Hotkey = hotkey;
            ClickInterval = clickSpeed;
        }

    }
}
