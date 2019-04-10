using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    class MouseEventData {

        static Random random = new Random();
       
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;

        [DllImport("user32.dll", CharSet = CharSet.Auto,CallingConvention=CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public void ClickLeftMouseButtonEvent() {
            mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        public void ClickRightMouseButtonEvent() {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        public double GetRandomizedClickSpeed(bool randomize, float defaultSpeed, float randomizationAmount) {
            if(!randomize)
                return defaultSpeed;
            
            float multiplier = 1 + (randomizationAmount / 100);

            double min = defaultSpeed * multiplier;
            double max = defaultSpeed / multiplier;

            return random.NextDouble() * (max - min) + min;
        }
    }
}
