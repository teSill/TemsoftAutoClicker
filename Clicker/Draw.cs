using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace TemseiAutoClicker {
    class Draw {

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);
        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        public static void DrawCircle(int x, int y) {
            IntPtr desktopPtr = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopPtr);
            g.DrawEllipse(Pens.Green, x - 10, y - 10, 20, 20);
            
            Task.Delay(250).ContinueWith(task => {
                InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                g.Dispose();
                ReleaseDC(IntPtr.Zero, desktopPtr);
            });
        }
    }
}
