using System;
using System.Threading;

namespace TemseiAutoClicker {
    class RightClickingThread {

        MouseEventData mouseEvents = new MouseEventData();
        
        private float RightClickSpeed;
        private bool Randomize;
        private float RandomizationAmount;

        public RightClickingThread(float rightClickSpeed, bool randomize, float randomizationAmount) {
            this.RightClickSpeed = rightClickSpeed;
            this.Randomize = randomize;
            this.RandomizationAmount = randomizationAmount;
        }

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
