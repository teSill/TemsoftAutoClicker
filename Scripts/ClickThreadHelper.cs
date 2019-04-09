using System;
using System.Threading;

namespace TemseiAutoClicker {
    internal class ClickThreadHelper {

        MouseEventData mouseClickHandler = new MouseEventData();
        
        static Random random = new Random();

        public float ClickSpeed { get; internal set; }
        public bool LeftClicking { get; internal set; }
        public bool MultiClicking { get; internal set; }
        public bool Randomize { get; internal set; }

        public void Run() {
            try {
                while(true) {
                    if (MultiClicking) {
                        mouseClickHandler.ClickLeftMouseButtonEvent();
                        mouseClickHandler.ClickRightMouseButtonEvent();
                    } else if (LeftClicking) {
                        mouseClickHandler.ClickLeftMouseButtonEvent();
                    } else {
                        mouseClickHandler.ClickRightMouseButtonEvent();
                    }
                    Console.WriteLine(GetRandomizedClickSpeed(ClickSpeed / 1.2, ClickSpeed * 1.2));
                    Thread.Sleep((int) (GetRandomizedClickSpeed(ClickSpeed / 1.2, ClickSpeed * 1.2) * 1000));
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public double GetRandomizedClickSpeed(double min, double max) {
            if(!Randomize)
                return ClickSpeed;

            return random.NextDouble() * (max - min) + min;
        }
    }
}