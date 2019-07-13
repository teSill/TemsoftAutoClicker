using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    class CustomClickingThread {

        MouseEventData mouseEvents = new MouseEventData();
        
        private float _clickInterval;
        private bool _singleLoop;
        private List<ClickPosition> _clickPositions;

        public event Action SingleLoopEvent;

        public CustomClickingThread(float clickInterval, bool singleLoop, List<ClickPosition> clickPositions) {
            _clickInterval = clickInterval;
            _singleLoop = singleLoop;
            _clickPositions = clickPositions;
        }

        public void Run() {
            int count = 0;
            try {
                while(true) {
                    foreach(ClickPosition click in _clickPositions) {
                        count++;
                        MouseEventData.LinearSmoothMove(new Point(click.X, click.Y), 5, 10, click.MouseButton);

                        if (count < _clickPositions.Count) {
                            Thread.Sleep((int) (_clickInterval * 1000));
                        }
                    }

                    var success = SingleLoopEvent;
                    if (success != null) {
                        success();
                        break;
                    }
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
