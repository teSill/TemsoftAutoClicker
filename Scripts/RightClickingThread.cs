using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TemseiAutoClicker {
    class RightClickingThread {
        MouseEventData mouseClickHandler = new MouseEventData();
        
        static Random random = new Random();
        
        public float RightClickSpeed { get; internal set; }
        public bool Randomize { get; internal set; }

        public void Run() {
            try {
                while(true) {
                    mouseClickHandler.ClickRightMouseButtonEvent();
                    Console.WriteLine("Right speed: " + RightClickSpeed);
                    Thread.Sleep((int) (GetRandomizedClickSpeed(RightClickSpeed / 1.2, RightClickSpeed * 1.2) * 1000));
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public double GetRandomizedClickSpeed(double min, double max) {
            if(!Randomize)
                return RightClickSpeed;

            return random.NextDouble() * (max - min) + min;
        }
    }
}
