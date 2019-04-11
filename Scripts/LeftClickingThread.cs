using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TemseiAutoClicker {
    class LeftClickingThread {

        MouseEventData mouseEvents = new MouseEventData();

        public float LeftClickSpeed { get; internal set; }
        public bool Randomize { get; internal set; }
        public int RandomizationAmount { get; internal set; }
        public bool HoldCtrl { get; internal set; }

        public void Run() {
            try {
                while(true) {
                    if (HoldCtrl)
                        MouseEventData.keybd_event(MouseEventData.VK_CONTROL, 0, 0, 0); // HOLD DOWN CONTROL
                    mouseEvents.ClickLeftMouseButtonEvent();
                    Thread.Sleep((int) (mouseEvents.GetRandomizedClickSpeed(Randomize, LeftClickSpeed, RandomizationAmount) * 1000));
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}