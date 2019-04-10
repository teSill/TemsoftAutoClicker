using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TemseiAutoClicker {
    class LeftClickingThread {

        MouseEventData mouseClickHandler = new MouseEventData();

        public float LeftClickSpeed { get; internal set; }
        public bool Randomize { get; internal set; }
        public int RandomizationAmount { get; internal set; }

        public void Run() {
            try {
                while(true) {
                    mouseClickHandler.ClickLeftMouseButtonEvent();
                    Thread.Sleep((int) (mouseClickHandler.GetRandomizedClickSpeed(Randomize, LeftClickSpeed, RandomizationAmount) * 1000));
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}