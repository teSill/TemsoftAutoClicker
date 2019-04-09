using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace TemseiAutoClicker {

    public partial class Application : Form {

        private ClickThreadHelper clickThreadHelper = new ClickThreadHelper();
        private GlobalHotkey ghk;
        private Thread ClickThread;

        private bool leftClicking = true;
        private bool multiClicking = false;
        private float clickSpeed = 0;
        private bool randomizeClickSpeed = false;

        private void Run() {
            if (button1.BackColor != Color.Green) {
                MessageBox.Show("Please click the Ready button to confirm your settings!");
                return;
            }
            try {
                this.WindowState = FormWindowState.Minimized;
                ClickThreadHelper helper = new ClickThreadHelper() { ClickSpeed = clickSpeed, LeftClicking = leftClicking, MultiClicking = multiClicking, Randomize = randomizeClickSpeed};
                ClickThread = new Thread(new ThreadStart(helper.Run));
                ClickThread.Start();
            } catch (Exception exc) {
                MessageBox.Show("Error in the Main method", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void Stop() {
            try {
                if (ClickThread.IsAlive) {
                    ClickThread.Abort();
                    ClickThread.Join();
                    ClickThread = null;
                    //MessageBox.Show("Auto clicking successfully stopped", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //SetButtonColor(Color.Red);
                    this.WindowState = FormWindowState.Normal;
                }
            } catch (ThreadAbortException ex) {
                MessageBox.Show("Error stopping the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Application() {
            InitializeComponent();
        }

        private void readyButtonClick(object sender, EventArgs e) {
            if (!float.TryParse(comboBox1.Text, out clickSpeed)) {
                SetButtonColor(Color.Red);
                MessageBox.Show("Please remove any invalid characters from the click interval text box. JMOI DEBUG: " + comboBox1.Text, "Error");
                return;
            }
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked) {
                SetButtonColor(Color.Red);
                MessageBox.Show("Please select your desired mouse clicks.", "Error");
                return;
            }
            if (clickSpeed <= 0) {
                SetButtonColor(Color.Red);
                MessageBox.Show("Please set your mouse click interval!", "Error");
                return;
            }
            SetButtonColor(Color.Green);
            MessageBox.Show("You're ready to start auto clicking at an interval of " + clickSpeed + " seconds. Press your assigned hotkey to run and stop the application.", "Success");
        }

        private void Application_Load(object sender, EventArgs e) {
            if (IsAlreadyRunning()) {
                MessageBox.Show("Application is already running.");
                System.Windows.Forms.Application.Exit();
            }
            comboBox1.SelectedIndex = 1;
            textBox1.ReadOnly = true;
            button1.BackColor = Color.Red;
            ghk = new GlobalHotkey(Constants.CTRL , Keys.H, this);
            if (!ghk.Register()) {
                MessageBox.Show("Couldn't register new hotkey!", "Error");
            }
        }

        private void HandleHotkey() {
            if (ClickThread != null) {
                Stop();
            } else {
                Run();
            }
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void leftClickButton_CheckedChanged(object sender, EventArgs e) {
            SetButtonColor(Color.Red);
            leftClicking = true;
        }

        private void rightClickButton_CheckedChanged(object sender, EventArgs e) {
            SetButtonColor(Color.Red);
            leftClicking = false;
        }

        private void bothButton_CheckedChanged(object sender, EventArgs e) {
            multiClicking = !multiClicking;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            SetButtonColor(Color.Red);
            if (!float.TryParse(comboBox1.Text, out clickSpeed)) {
                SetButtonColor(Color.Red);
                MessageBox.Show("Please remove any invalid characters from the click interval text box.", "Error");
                return;
            }
        }

        private void hotKeyTextBox_KeyDown(object sender, KeyEventArgs e) {
            SetButtonColor(Color.Red);
            if (e.KeyValue >= 0x41 && e.KeyValue <= 0x5A) { // Letters only
                ghk.Unregister();
                textBox1.Text = "CTRL + " + e.KeyCode.ToString();
                ghk = new GlobalHotkey(Constants.CTRL , e.KeyCode, this);
                if (!ghk.Register()) {
                    MessageBox.Show("Couldn't register new hotkey!", "Error");
                }
            }
        }

        private void randomizeButton_CheckedChanged(object sender, EventArgs e) {
            SetButtonColor(Color.Red);
            randomizeClickSpeed = !randomizeClickSpeed;
        }

        private void SetButtonColor(Color color) {
            if (button1.BackColor != color)
                button1.BackColor = color;
        }

        private static bool IsAlreadyRunning() {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            bool bCreatedNew;

            Mutex mutex = new Mutex(true, "Global\\"+sExeName, out bCreatedNew);
            if (bCreatedNew)
                mutex.ReleaseMutex();

            return !bCreatedNew;
        }
    }
}
