using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    class MouseEventData {

        static Random random = new Random();
       
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004; 
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;

        public const int KEYEVENTF_KEYUP = 0x02;
        public const int VK_CONTROL = 0x11;

        [DllImport("user32.dll", CharSet = CharSet.Auto,CallingConvention=CallingConvention.StdCall)]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll", SetLastError = true)] 
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);


        public void ClickLeftMouseButtonEvent() {
            mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        public void ClickRightMouseButtonEvent() {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        public void HoldDownMouse(string button) {
            mouse_event((button == "left") ? MOUSEEVENTF_LEFTDOWN : MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        public void ReleaseMouse(string button) {
            mouse_event((button == "left") ? MOUSEEVENTF_LEFTUP : MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        public void ClickCurrentPositionEvent(MouseButtons mouseButton) {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
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
