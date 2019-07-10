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
        private Application _application;

        public CustomClickingThread(float clickInterval, bool singleLoop, 
            List<ClickPosition> clickPositions, Application application) {
            _clickInterval = clickInterval;
            _singleLoop = singleLoop;
            _clickPositions = clickPositions;
            _application = application;
        }

        public void Run() {
            try {
                while(true) {
                    foreach(ClickPosition click in _clickPositions) {
                        //mouseEvents.ClickCustomPositionEvent(click.X, click.Y, click.MouseButton);
                        LinearSmoothMove(new Point(click.X, click.Y), 5, 10, click.MouseButton);
                        
                        Thread.Sleep((int) (_clickInterval * 1000));
                    }
                }
               // if (singleLoop)
                    //application.Stop();
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LinearSmoothMove(Point newPosition, int steps, int sleepTime, MouseButtons mouseButton) {
            Point start = new Point(Cursor.Position.X, Cursor.Position.Y);
            PointF iterPoint = start;

            // Find the slope of the line segment defined by start and newPosition
            PointF slope = new PointF(newPosition.X - start.X, newPosition.Y - start.Y);

            // Divide by the number of steps
            slope.X = slope.X / steps;
            slope.Y = slope.Y / steps;

            // Move the mouse to each iterative point.
            for (int i = 0; i < steps; i++) {
                iterPoint = new PointF(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                Cursor.Position = Point.Round(iterPoint);
                Thread.Sleep(sleepTime);
            }

            // Move the mouse to the final destination.
            Cursor.Position = newPosition;
            mouseEvents.ClickCurrentPositionEvent(mouseButton);
        }
    }
}
