using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace TemseiAutoClicker {

    enum ClickType {
        Left,
        Right,
        Multi,
        Custom
    }

    public partial class Application : Form {

        private GlobalHotkey ghk;

        private Thread LeftClickThread;
        private Thread RightClickThread;
        private Thread CustomClickThread;

        private bool randomizeClickSpeed = false;
        private int randomizationAmount;
        private float leftClickingSpeed = 0;
        private float rightClickingSpeed = 0;

        private bool registeringClickPosition = false;
        private List<ClickPosition> clickPositions = new List<ClickPosition>();

        private bool isRunning = false;

        private IKeyboardMouseEvents m_GlobalHook;
        private ClickType clickType = ClickType.Left;

        private bool saveSettings = false;
        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TemseiAutoClicker");
        private string fileName = "settings.txt";
        
        private bool holdCTRL = false; // Not used in the main version and will never be set to true

        private void Run() {
            if (!IsReady()) {
                return;
            }

            try {
                isRunning = true;
                this.WindowState = FormWindowState.Minimized;
                LeftClickingThread leftClickingThread = new LeftClickingThread(leftClickingSpeed, randomizeClickSpeed, randomizationAmount, holdCTRL);
                RightClickingThread rightClickingThread = new RightClickingThread(rightClickingSpeed, randomizeClickSpeed, randomizationAmount);
                CustomClickingThread customClickingThread = new CustomClickingThread(leftClickingSpeed, rightClickingSpeed, randomizeClickSpeed, randomizationAmount, clickPositions);
                switch(clickType) {
                    case ClickType.Custom:
                        CustomClickThread = new Thread(new ThreadStart(customClickingThread.Run));
                        CustomClickThread.Start();
                        break;
                    case ClickType.Multi:
                        LeftClickThread = new Thread(new ThreadStart(leftClickingThread.Run));
                        RightClickThread = new Thread(new ThreadStart(rightClickingThread.Run));
                        LeftClickThread.Start();
                        RightClickThread.Start();
                        break;
                    case ClickType.Left:
                        LeftClickThread = new Thread(new ThreadStart(leftClickingThread.Run));
                        LeftClickThread.Start();
                        break;
                    case ClickType.Right:
                        RightClickThread = new Thread(new ThreadStart(rightClickingThread.Run));
                        RightClickThread.Start();
                        break;
                }
            } catch (Exception exc) {
                MessageBox.Show("Error in the main method!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void ShutdownThread(Thread thread) {
            if (thread != null && thread.IsAlive) {
                thread.Abort();
                thread.Join();
                thread = null;
            }
        }

        private void Stop() {
            try {
                this.WindowState = FormWindowState.Normal;

                Thread[] threads = {LeftClickThread, RightClickThread, CustomClickThread};
                foreach(Thread thread in threads) {
                    ShutdownThread(thread);
                }

                isRunning = false;

                if(holdCTRL)
                    MouseEventData.keybd_event(MouseEventData.VK_CONTROL, 0, MouseEventData.KEYEVENTF_KEYUP, 0);
            } catch (ThreadAbortException ex) {
                MessageBox.Show("Error stopping the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Application() {
            InitializeComponent();
        }

        private void Application_Load(object sender, EventArgs e) {
            if (IsAlreadyRunning()) {
                MessageBox.Show("Application is already running.");
                System.Windows.Forms.Application.ExitThread();
            }
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 2;
            comboBox3.SelectedIndex = 2;
            ghk = new GlobalHotkey(Constants.CTRL , Keys.H, this);
            ghk.Register();
            LoadSettings();
        }

        private void HandleHotkey() {
            if (isRunning) {
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

        private void LeftClickButton_CheckedChanged(object sender, EventArgs e) {
            clickType = ClickType.Left;
        }

        private void RightClickButton_CheckedChanged(object sender, EventArgs e) {
            clickType = ClickType.Right;
        }

        private void BothButton_CheckedChanged(object sender, EventArgs e) {
            clickType = ClickType.Multi;
        }

        private void CustomButton_CheckedChanged(object sender, EventArgs e) {
            if (clickType != ClickType.Custom)
                advancedSettingsPanel.Visible = true;
            clickType = ClickType.Custom;
        }

        private void LeftClickIntervalBox_SelectedIndexChanged(object sender, EventArgs e) {
            float.TryParse(comboBox1.Text, out leftClickingSpeed);
        }

        private void RightClickIntervalBox_SelectedIndexChanged(object sender, EventArgs e) {
            float.TryParse(comboBox2.Text, out rightClickingSpeed);
        }

        private void HotKeyTextBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyValue >= 0x41 && e.KeyValue <= 0x5A) { // Letters only
                ghk.Unregister();
                textBox1.Text = "CTRL + " + e.KeyCode.ToString();
                ghk = new GlobalHotkey(Constants.CTRL , e.KeyCode, this);
                if (!ghk.Register()) {
                    MessageBox.Show("Couldn't register new hotkey!", "Error");
                }
            }
        }

        private void RandomizeButton_CheckedChanged(object sender, EventArgs e) {
            comboBox3.Enabled = !comboBox3.Enabled;
            randomizeClickSpeed = !randomizeClickSpeed;
        }

        private static bool IsAlreadyRunning() {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;

            Mutex mutex = new Mutex(true, "Global\\" + sExeName, out bool bCreatedNew);
            if (bCreatedNew)
                mutex.ReleaseMutex();

            return !bCreatedNew;
        }

        private void RegisterButton_Click(object sender, EventArgs e) {
            registeringClickPosition = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private void CustomizedClicksButton_Click(object sender, EventArgs e) {
            advancedSettingsPanel.Visible = true;
        }

        private void ContinueButton_Click(object sender, EventArgs e) {
            advancedSettingsPanel.Visible = false;
            if (clickPositions.Count > 0) {
                radioButton4.Checked = true;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e) {
            if (clickPositions.Count <= 0) {
                MessageBox.Show("There are no values in the list to clear!", "Error");
            } else {
                clickPositions.Clear();
                listBox1.Items.Clear();
            }
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e) {
            if (!registeringClickPosition)
                return;
            e.Handled = true;
            RegisterNewClickPosition(new ClickPosition(e.X, e.Y, e.Button));
        }

        private void RegisterNewClickPosition(ClickPosition mouseClick) {
            registeringClickPosition = false;
            clickPositions.Add(mouseClick);
            listBox1.Items.Add((clickPositions.IndexOf(mouseClick) + 1) + ". X: " + mouseClick.GetX() + " Y: " + mouseClick.GetY() + " Click Type: " + mouseClick.GetMouseClickType()); 
            this.WindowState = FormWindowState.Normal;
        }

        private void Application_FormClosing_1(object sender, FormClosingEventArgs e) {
            SaveSettings();
            Stop();
            System.Windows.Forms.Application.ExitThread();
        }

        private bool TryParse(ComboBox comboBox, out float speed) {
            if (float.TryParse(comboBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out speed)) {
                return true;
            }  else if (float.TryParse(comboBox.Text, out speed)) {
                return true;
            }
            return false;
        }

        private bool IsReady() {
            if ((clickType == ClickType.Left && !TryParse(comboBox1, out leftClickingSpeed) || 
                clickType == ClickType.Right && !TryParse(comboBox2, out rightClickingSpeed) ||
                clickType == ClickType.Multi && !TryParse(comboBox1, out leftClickingSpeed) && !TryParse(comboBox2, out rightClickingSpeed))) {
                MessageBox.Show("Please remove any invalid characters from the click interval text box!", "Error");
                return false;
            }
            if (randomizeClickSpeed) {
                if (!int.TryParse(comboBox3.Text.Remove(comboBox3.Text.Length - 1), out randomizationAmount)) {
                    MessageBox.Show("There was a problem setting your randomization percentage. Please try again!", "Error");
                    return false;
                }
            }
            if (clickType == ClickType.Custom && clickPositions.Count == 0) {
                MessageBox.Show("Your custom click list is empty! Add some positions for the program to iterate over or choose another clicking mode.", "Error");
                return false;
            }
            return true;
        }

        private void HoldCTRL_CheckedChanged(object sender, EventArgs e) {
            holdCTRL = !holdCTRL;
        }

        private void SaveSettingsToggle(object sender, EventArgs e) {
            saveSettings = !saveSettings;
        }

        private void SaveSettings() {
            if (!saveSettings)
                return;

            if (!Directory.Exists(filePath)) {
                Directory.CreateDirectory(filePath);
            }

            try {
                File.WriteAllText(Path.Combine(filePath, fileName), ConvertDataToString());
            } catch (Exception e) {
                System.Diagnostics.Debug.Write(e);
            }
        }

        private string ConvertDataToString() {
            string contents = "";

            foreach(ClickPosition click in clickPositions) {
                contents += click.GetX() + "," + click.GetY() + "-" +  click.GetMouseClickType() + Environment.NewLine;
            }

            return contents;
        }

        private void LoadSettings() {
            if (!Directory.Exists(filePath))
                return;
            string[] textContents = File.ReadAllLines(Path.Combine(filePath, fileName));

            foreach(string line in textContents) {
                RegisterNewClickPosition(ConvertStringToPosition(line));
            }
        }

        private ClickPosition ConvertStringToPosition(string line) {
            Console.WriteLine(line);

            Int32.TryParse(line.Substring(0, line.IndexOf(",")), out int x);
            Int32.TryParse(GetStringBetweenCharacters(line, ",", "-"), out int y);
            string mouseButton = line.Substring(line.LastIndexOf("-") + 1);
            MouseButtons mouse = (mouseButton == "Left") ? MouseButtons.Left : MouseButtons.Right;
                
            return new ClickPosition(x, y, mouse);
        }

        public string GetStringBetweenCharacters(string @string , string firstCharacter, string lastCharacter) {       
            string finalString;     

            int Pos1 = @string.IndexOf(firstCharacter) + firstCharacter.Length;
            int Pos2 = @string.IndexOf(lastCharacter);
            finalString = @string.Substring(Pos1, Pos2 - Pos1);

            return finalString;
        }
    }
}
