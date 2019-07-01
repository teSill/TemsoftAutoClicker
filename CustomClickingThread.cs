using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    class CustomClickingThread {

        MouseEventData mouseEvents = new MouseEventData();
        
        private float leftClickSpeed;
        private float rightClickSpeed;
        private bool randomize;
        private float randomizationAmount;
        private bool singleLoop;
        private List<ClickPosition> clickPositions;
        private Application application;

        public CustomClickingThread(float leftClickSpeed, float rightClickSpeed, bool randomize, float randomizationAmount, bool singleLoop, 
            List<ClickPosition> clickPositions, Application application) {
            this.leftClickSpeed = leftClickSpeed;
            this.rightClickSpeed = rightClickSpeed;
            this.randomize = randomize;
            this.randomizationAmount = randomizationAmount;
            this.singleLoop = singleLoop;
            this.clickPositions = clickPositions;
            this.application = application;
        }

        public void Run() {
            try {
                while(true) {
                    foreach(ClickPosition click in clickPositions) {
                        mouseEvents.ClickCustomPositionEvent(click.GetX(), click.GetY(), click.GetMouseClickType());
                        if (click.GetMouseClickType() == MouseButtons.Left) {
                            Thread.Sleep((int) (mouseEvents.GetRandomizedClickSpeed(randomize, leftClickSpeed, randomizationAmount) * 1000));
                        } else {
                            Thread.Sleep((int) (mouseEvents.GetRandomizedClickSpeed(randomize, rightClickSpeed, randomizationAmount) * 1000));
                        }
                    }
                }
               // if (singleLoop)
                    //application.Stop();
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
