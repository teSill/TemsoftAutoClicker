using System;
using System.Threading;

namespace TemseiAutoClicker {
    class RightClickingThread {

        MouseEventData mouseEvents = new MouseEventData();
        
        public float RightClickSpeed { get; internal set; }
        public bool Randomize { get; internal set; }
        public float RandomizationAmount { get; internal set; }

        public void Run() {
            try {
                while(true) {
                    mouseEvents.ClickRightMouseButtonEvent();
                    Thread.Sleep((int) (mouseEvents.GetRandomizedClickSpeed(Randomize, RightClickSpeed, RandomizationAmount) * 1000));
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
