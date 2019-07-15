using System;
using System.Threading;

namespace TemseiAutoClicker {
    class RightClickingThread {

        private MouseEventData _mouseEvents = new MouseEventData();
        
        private float _rightClickSpeed;
        private bool _randomize;
        private float _randomizationAmount;
        private bool _holdMouse;

        public RightClickingThread(float rightClickSpeed, bool randomize, float randomizationAmount, bool holdMouse) {
            _rightClickSpeed = rightClickSpeed;
            _randomize = randomize;
            _randomizationAmount = randomizationAmount;
            _holdMouse = holdMouse;
        }

        public void Run() {
            if (_holdMouse) {
                _mouseEvents.HoldDownMouse("right");
                return;
            }
            try {
                while(true) {
                    _mouseEvents.ClickRightMouseButtonEvent();
                    Thread.Sleep((int) (_mouseEvents.GetRandomizedClickSpeed(_randomize, _rightClickSpeed, _randomizationAmount) * 1000));
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
