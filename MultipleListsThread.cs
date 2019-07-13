using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TemseiAutoClicker {
    class MultipleListsThread {

        private List<ClickCollection> _clickCollections = new List<ClickCollection>();

        public MultipleListsThread(List<ClickCollection> clickCollections) {
            _clickCollections = clickCollections;
        }

        public void Run() {
            try {
                while(true) {
                    foreach(ClickCollection collection in _clickCollections) {
                        foreach(ClickPosition click in collection.Clicks) {
                            MouseEventData.LinearSmoothMove(new Point(click.X, click.Y), 5, 10, click.MouseButton);

                            Thread.Sleep((int) (collection.ClickInterval * 1000));
                        }
                    }
                }
            } catch (Exception exc){
                Console.WriteLine(exc.Message);
            }
        }
    }
}
