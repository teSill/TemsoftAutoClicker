using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace TemseiAutoClicker {

    public partial class Application : Form {
        private GlobalHotkey ghk;
        private Thread LeftClickThread;
        private Thread RightClickThread;

        private bool leftClicking = true;
        private bool multiClicking = false;
        private bool randomizeClickSpeed = false;
        private int randomizationAmount;
        private float leftClickingSpeed = 0;
        private float rightClickingSpeed = 0;

        private void Run() {
            if (button1.BackColor != Color.Green) {
                MessageBox.Show("Please click the Ready button to confirm your settings!");
                return;
            }
            try {
                this.WindowState = FormWindowState.Minimized;
                LeftClickingThread leftClickingThread = new LeftClickingThread() { LeftClickSpeed = leftClickingSpeed, Randomize = randomizeClickSpeed, RandomizationAmount = randomizationAmount};
                RightClickingThread rightClickingThread = new RightClickingThread() { RightClickSpeed = rightClickingSpeed, Randomize = randomizeClickSpeed, RandomizationAmount = randomizationAmount};
                if (multiClicking) {
                    LeftClickThread = new Thread(new ThreadStart(leftClickingThread.Run));
                    RightClickThread = new Thread(new ThreadStart(rightClickingThread.Run));
                    LeftClickThread.Start();
                    RightClickThread.Start();
                } else if (leftClicking) {
                    LeftClickThread = new Thread(new ThreadStart(leftClickingThread.Run));
                    LeftClickThread.Start();
                } else {
                    RightClickThread = new Thread(new ThreadStart(rightClickingThread.Run));
                    RightClickThread.Start();
                }
            } catch (Exception exc) {
                MessageBox.Show("Error in the Main method", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void Stop() {
            try {
                this.WindowState = FormWindowState.Normal;
                if (LeftClickThread != null && LeftClickThread.IsAlive) {
                    LeftClickThread.Abort();
                    LeftClickThread.Join();
                    LeftClickThread = null;
                }
                if (RightClickThread != null && RightClickThread.IsAlive) {
                    RightClickThread.Abort();
                    RightClickThread.Join();
                    RightClickThread = null;
                }
            } catch (ThreadAbortException ex) {
                MessageBox.Show("Error stopping the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Application() {
            InitializeComponent();
        }

        private void readyButtonClick(object sender, EventArgs e) {
            if ((leftClicking && !float.TryParse(comboBox1.Text, out leftClickingSpeed)) || (!leftClicking && !float.TryParse(comboBox2.Text, out rightClickingSpeed) 
                || multiClicking && !float.TryParse(comboBox1.Text, out leftClickingSpeed) && !float.TryParse(comboBox2.Text, out rightClickingSpeed))) {
                SetButtonColor(Color.Red);
                MessageBox.Show("Please remove any invalid characters from the click interval text box.", "Error");
                return;
            }
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked) {
                SetButtonColor(Color.Red);
                MessageBox.Show("Please select your desired mouse clicks.", "Error");
                return;
            }
            if (leftClickingSpeed <= 0) {
                SetButtonColor(Color.Red);
                MessageBox.Show("Please set your mouse click interval!", "Error");
                return;
            }
            if (randomizeClickSpeed) {
                if (!int.TryParse(comboBox3.Text.Remove(comboBox3.Text.Length - 1), out randomizationAmount)) {
                    MessageBox.Show("There was a problem setting your randomization percentage. Please try again!", "Error");
                    return;
                }
            }
            SetButtonColor(Color.Green);
            MessageBox.Show("You're ready to start auto clicking! Press your assigned hotkey to run and stop the application.", "Success");
        }

        private void Application_Load(object sender, EventArgs e) {
            if (IsAlreadyRunning()) {
                MessageBox.Show("Application is already running.");
                System.Windows.Forms.Application.Exit();
            }
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 2;
            comboBox3.SelectedIndex = 2;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox1.ReadOnly = true;
            button1.BackColor = Color.Red;
            ghk = new GlobalHotkey(Constants.CTRL , Keys.H, this);
            if (!ghk.Register()) {
                MessageBox.Show("Couldn't register new hotkey!", "Error");
            }
        }

        private void HandleHotkey() {
            if (LeftClickThread != null || RightClickThread != null) {
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

        private void LeftClickIntervalBox_SelectedIndexChanged(object sender, EventArgs e) {
            SetButtonColor(Color.Red);
            if (!float.TryParse(comboBox1.Text, out leftClickingSpeed)) {
                SetButtonColor(Color.Red);
                MessageBox.Show("Please remove any invalid characters from the click interval text box.", "Error");
                return;
            }
        }

        private void RightClickIntervalBox_SelectedIndexChanged(object sender, EventArgs e) {
            SetButtonColor(Color.Red);
            if (!float.TryParse(comboBox2.Text, out rightClickingSpeed)) {
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
