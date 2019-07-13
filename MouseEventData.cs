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

        public static void ClickCurrentPositionEvent(MouseButtons mouseButton) {
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

        public static void LinearSmoothMove(Point newPosition, int steps, int sleepTime, MouseButtons mouseButton) {
            Point start = new Point(Cursor.Position.X, Cursor.Position.Y);
            PointF iterPoint = start;

            // Find the slope of the line segment defined by start and newPosition
            PointF slope = new PointF(newPosition.X - start.X, newPosition.Y - start.Y);

            // Divide by the number of steps
            slope.X = slope.X / steps;
            slope.Y = slope.Y / steps;

            // Move the mouse to each iterative point.
            for (int i = 0; i < steps; i++) {
                iterPoint = new PointF(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                Cursor.Position = Point.Round(iterPoint);
                Thread.Sleep(sleepTime);
            }

            // Move the mouse to the final destination.
            Cursor.Position = newPosition;
            ClickCurrentPositionEvent(mouseButton);
        }
    }
}
