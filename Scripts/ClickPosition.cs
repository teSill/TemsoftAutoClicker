using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    class ClickPosition {

        private int x;
        private int y;
        private MouseButtons mouseButton;

        public ClickPosition(int x, int y, MouseButtons mouseButton) {
            this.x = x;
            this.y = y;
            this.mouseButton = mouseButton;
        }

        public int GetX() {
            return x;
        }

        public int GetY() {
            return y;
        }

        public MouseButtons GetMouseClickType() {
            return mouseButton;
        }

    }
}
