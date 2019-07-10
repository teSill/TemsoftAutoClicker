using System;
using System.Threading;

namespace TemseiAutoClicker {
    class LeftClickingThread {

        private MouseEventData _mouseEvents = new MouseEventData();

        private float _leftClickSpeed;
        private bool _randomize;
        private float _randomizationAmount;
        private bool _holdCTRL;
        private bool _holdMouse;

        public LeftClickingThread(float leftClickSpeed, bool randomize, float randomizationAmount, bool holdCtrl, bool holdMouse) {
            _leftClickSpeed = leftClickSpeed;
            _randomize = randomize;
            _randomizationAmount = randomizationAmount;
            _holdCTRL = holdCtrl;
            _holdMouse = holdMouse;
        }

        public void Run() {
            if (_holdMouse) {
                _mouseEvents.HoldDownMouse("left");
                return;
            }
            try {
                while(true) {
                    if (_holdCTRL)
                        MouseEventData.keybd_event(MouseEventData.VK_CONTROL, 0, 0, 0); // HOLD DOWN CONTROL
                    _mouseEvents.ClickLeftMouseButtonEvent();
                    Thread.Sleep((int) (_mouseEvents.GetRandomizedClickSpeed(_randomize, _leftClickSpeed, _randomizationAmount) * 1000));
                }
            } catch (Exception exc){
                //MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}