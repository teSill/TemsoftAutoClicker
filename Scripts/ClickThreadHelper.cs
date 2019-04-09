using System;
using System.Threading;

namespace TemseiAutoClicker {
    internal class LeftClickingThread {

        MouseEventData mouseClickHandler = new MouseEventData();
        
        static Random random = new Random();

        public float LeftClickSpeed { get; internal set; }
        public bool Randomize { get; internal set; }

        public void Run() {
            try {
                while(true) {
                    mouseClickHandler.ClickLeftMouseButtonEvent();
                    Console.WriteLine("Left speed: " + LeftClickSpeed);
                    Thread.Sleep((int) (GetRandomizedClickSpeed(LeftClickSpeed / 1.2, LeftClickSpeed * 1.2) * 1000));
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public double GetRandomizedClickSpeed(double min, double max) {
            if(!Randomize)
                return LeftClickSpeed;

            return random.NextDouble() * (max - min) + min;
        }
    }
}