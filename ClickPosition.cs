using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    public class ClickPosition {

        public int X { get; private set; }
        public int Y { get; private set; }
        public MouseButtons MouseButton;

        public ClickPosition(int x, int y, MouseButtons mouseButton) {
            X = x;
            Y = y;
            MouseButton = mouseButton;
        }
    }
}
