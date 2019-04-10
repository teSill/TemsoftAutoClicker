using System;
using System.Threading;

namespace TemseiAutoClicker {
    class RightClickingThread {

        MouseEventData mouseClickHandler = new MouseEventData();
        
        public float RightClickSpeed { get; internal set; }
        public bool Randomize { get; internal set; }
        public float RandomizationAmount { get; internal set; }

        public void Run() {
            try {
                while(true) {
                    mouseClickHandler.ClickRightMouseButtonEvent();
                    Thread.Sleep((int) (mouseClickHandler.GetRandomizedClickSpeed(Randomize, RightClickSpeed, RandomizationAmount) * 1000));
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
