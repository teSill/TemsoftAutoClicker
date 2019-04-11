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
        
        public float LeftClickSpeed { get; internal set; }
        public float RightClickSpeed { get; internal set; }
        public bool Randomize { get; internal set; }
        public float RandomizationAmount { get; internal set; }
        public List<ClickPosition> ClickPositions { get; internal set; }

        public void Run() {
            try {
                while(true) {
                    foreach(ClickPosition click in ClickPositions) {
                        mouseEvents.ClickCustomPositionEvent(click.GetX(), click.GetY(), click.GetMouseClickType());
                        if (click.GetMouseClickType() == MouseButtons.Left) {
                            Thread.Sleep((int) (mouseEvents.GetRandomizedClickSpeed(Randomize, LeftClickSpeed, RandomizationAmount) * 1000));
                        } else {
                            Thread.Sleep((int) (mouseEvents.GetRandomizedClickSpeed(Randomize, RightClickSpeed, RandomizationAmount) * 1000));
                        }
                    }
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
