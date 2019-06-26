using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TemseiAutoClicker {
    class LeftClickingThread {

        MouseEventData mouseEvents = new MouseEventData();

        private float leftClickSpeed;
        private bool randomize;
        private float randomizationAmount;
        private bool holdCTRL;

        public LeftClickingThread(float leftClickSpeed, bool randomize, float randomizationAmount, bool holdCtrl) {
            this.leftClickSpeed = leftClickSpeed;
            this.randomize = randomize;
            this.randomizationAmount = randomizationAmount;
            this.holdCTRL = holdCtrl;
        }

        public void Run() {
            try {
                while(true) {
                    if (holdCTRL)
                        MouseEventData.keybd_event(MouseEventData.VK_CONTROL, 0, 0, 0); // HOLD DOWN CONTROL
                    mouseEvents.ClickLeftMouseButtonEvent();
                    Console.WriteLine("Speed: " + leftClickSpeed);
                    Thread.Sleep((int) (mouseEvents.GetRandomizedClickSpeed(randomize, leftClickSpeed, randomizationAmount) * 1000));
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}