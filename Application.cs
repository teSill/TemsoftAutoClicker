using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {

    enum ClickType {
        Left,
        Right,
        Multi
    }

    enum Mode {
        Normal,
        SingleList,
        MultipleList,
        None
    }

    public partial class Application : Form {

        private MouseEventData _mouseEventData = new MouseEventData();

        public static List<char> activeHotkeys = new List<char>();
        private char _defaultHotkey = 'H';
        private char _automationHotkey = 'V';

        private Thread _leftClickThread;
        private Thread _rightClickThread;
        private Thread _customClickThread;
        private Thread _multipleListsThread;

        private bool _randomizeClickSpeed = false;
        private int _randomizationAmount;
        private float _leftClickingSpeed = 0;
        private float _rightClickingSpeed = 0;
        private bool _holdLeftMouseButton;
        private bool _holdRightMouseButton;

        private bool _registeringClickPosition = false;
        private List<ClickPosition> _clickPositions = new List<ClickPosition>();

        public List<ClickCollection> clickCollections = new List<ClickCollection>();
        private List<ClickCollection> _automatedClickCollections = new List<ClickCollection>();
        public static string availableLetters =  "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private bool _isRunning = false;

        private IKeyboardMouseEvents _GlobalHook;
        private ClickType _clickType = ClickType.Left;
        private Mode _mode = Mode.Normal;

        public int ListsAtStart { get; set; }
        private bool _saveSettings = false;
        public static readonly string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TemseiAutoClicker");

        public bool listEditFormIsOpen = false;
        
        private bool _holdCTRL = false; // Not used in the main version and will never be set to true

        private Keys _activeKey; // The key that was last pressed. Used to determine course of action in custom thread running

        private void Run() {
            if (!IsReady()) {
                Console.WriteLine("Not ready!");
                return;
            }
            if (_isRunning) {
                Stop();
                return;
            }

            try {
                _isRunning = true;
                WindowState = FormWindowState.Minimized;
                LeftClickingThread leftClickingThread = new LeftClickingThread(_leftClickingSpeed, _randomizeClickSpeed, _randomizationAmount, _holdCTRL, _holdLeftMouseButton);
                RightClickingThread rightClickingThread = new RightClickingThread(_rightClickingSpeed, _randomizeClickSpeed, _randomizationAmount, _holdRightMouseButton);
                switch(_clickType) {
                    case ClickType.Multi:
                        _leftClickThread = new Thread(new ThreadStart(leftClickingThread.Run));
                        _rightClickThread = new Thread(new ThreadStart(rightClickingThread.Run));
                        _leftClickThread.Start();
                        _rightClickThread.Start();
                        break;
                    case ClickType.Left:
                        _leftClickThread = new Thread(new ThreadStart(leftClickingThread.Run));
                        _leftClickThread.Start();
                        break;
                    case ClickType.Right:
                        _rightClickThread = new Thread(new ThreadStart(rightClickingThread.Run));
                        _rightClickThread.Start();
                        break;
                }
            } catch (Exception exc) {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void RunCustomThread(char key) {
            try {
                if (_activeKey == (Keys) key) { // terminate thread and return if user presses the current hotkey
                    Stop();
                    return;
                }

                if (_activeKey != Keys.None) { // terminate current thread if it exists (but do not return) in preparation for starting the next one
                    Stop();
                }

                ClickCollection clickCollection = FindCollectionByKey((Keys) key);
                if (clickCollection == null) {
                    MessageBox.Show("Couldn't find the right list to activate...", "Error");
                    return;
                }
                if (clickCollection.Clicks.Count == 0) {
                    MessageBox.Show("Your list doesn't contain any clicks.", "Error");
                    return;
                }

                WindowState = FormWindowState.Minimized;

                _activeKey = (Keys) key;

                CustomClickingThread customClickingThread = new CustomClickingThread(clickCollection.ClickInterval, clickCollection.SingleLoop, clickCollection.Clicks);

                if (clickCollection.SingleLoop) {
                    customClickingThread.SingleLoopEvent += () => Invoke(new Action(() => Stop()));
                }

                _customClickThread = new Thread(new ThreadStart(customClickingThread.Run));
                _customClickThread.Start();


            } catch (Exception exc) {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        
        private void RunMultipleLists() {
            if (_isRunning) {
                Stop();
                return;
            }

            WindowState = FormWindowState.Minimized;
            _isRunning = true;

            MultipleListsThread multipleListsThread = new MultipleListsThread(_automatedClickCollections);
            _multipleListsThread = new Thread(new ThreadStart(multipleListsThread.Run));
            _multipleListsThread.Start();
        }

        private void ShutdownThread(Thread thread) {
            if (thread != null && thread.IsAlive) {
                thread.Interrupt();
                thread.Join();
            }
        }

        public void Stop() {
            try {
                WindowState = FormWindowState.Normal;

                Thread[] threads = { _leftClickThread, _rightClickThread, _customClickThread, _multipleListsThread};
                foreach(Thread thread in threads) {
                    ShutdownThread(thread);
                }

                if (_holdLeftMouseButton || _holdRightMouseButton) {
                    if (_holdLeftMouseButton) {
                       _mouseEventData.ReleaseMouse("left");
                    } else {
                        _mouseEventData.ReleaseMouse("right");
                    }
                }

                _isRunning = false;
                _activeKey = Keys.None;

                if(_holdCTRL)
                    MouseEventData.keybd_event(MouseEventData.VK_CONTROL, 0, MouseEventData.KEYEVENTF_KEYUP, 0);
            } catch (ThreadAbortException ex) {
                Console.WriteLine("Error terminating threads: " + ex);
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

            _GlobalHook = Hook.GlobalEvents();
            _GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            _GlobalHook.KeyDown += GlobalHookKeyPress;
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 2;
            comboBox3.SelectedIndex = 2;
            new Load(this, clickCollections);
            activeHotkeys.Add(_defaultHotkey);
            activeHotkeys.Add(_automationHotkey);
        }

        private void PrepareRun(char key) {
            supportBox.Focus();

            switch(_mode) {
                case Mode.Normal:
                    Run();
                    break;
                case Mode.SingleList:
                    RunCustomThread(key);
                    break;
                case Mode.MultipleList:
                    RunMultipleLists();
                    break;
                default:
                    break;
            }
        }

        private void GlobalHookKeyPress(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape && _recordingSequence) {
                StopRecordingMouseClicks();
            }

            if (ModifierKeys == Keys.Control && activeHotkeys.Contains((char) e.KeyCode)) {

                if ((char) e.KeyCode == _defaultHotkey && !advancedSettingsPanel.Visible) {
                    _mode = Mode.Normal;
                } else if ((char) e.KeyCode == _automationHotkey && advancedSettingsPanel.Visible) {
                    _mode = Mode.MultipleList;
                } else if (advancedSettingsPanel.Visible) {
                    _mode = Mode.SingleList;
                } else {
                    _mode = Mode.None;
                }

                PrepareRun((char) e.KeyCode);
                
            }
        }

        private void LeftClickButton_CheckedChanged(object sender, EventArgs e) {
            _clickType = ClickType.Left;
        }

        private void RightClickButton_CheckedChanged(object sender, EventArgs e) {
            _clickType = ClickType.Right;
        }

        private void BothButton_CheckedChanged(object sender, EventArgs e) {
            _clickType = ClickType.Multi;
        }

        private void LeftClickIntervalBox_SelectedIndexChanged(object sender, EventArgs e) {
            float.TryParse(comboBox1.Text, out _leftClickingSpeed);
        }

        private void RightClickIntervalBox_SelectedIndexChanged(object sender, EventArgs e) {
            float.TryParse(comboBox2.Text, out _rightClickingSpeed);
        }

        private void HotKeyTextBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyValue >= 0x41 && e.KeyValue <= 0x5A) { // Letters only
                if (activeHotkeys.Contains((char) e.KeyCode)) {
                    MessageBox.Show("The hotkey '" + e.KeyCode + "' is already in use.");
                    return;
                }
                textBox1.Text = "CTRL + " + e.KeyCode.ToString();
                activeHotkeys.Remove(_defaultHotkey);
                _defaultHotkey = (char) e.KeyCode;
                activeHotkeys.Add(_defaultHotkey);
            }
        }

        private void RandomizeButton_CheckedChanged(object sender, EventArgs e) {
            comboBox3.Enabled = !comboBox3.Enabled;
            _randomizeClickSpeed = !_randomizeClickSpeed;
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

        private void CustomizedClicksButton_Click(object sender, EventArgs e) {
            advancedSettingsPanel.Visible = true;
        }

        private void ContinueButton_Click(object sender, EventArgs e) {
            advancedSettingsPanel.Visible = false;
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e) {
            if (!_registeringClickPosition && !_recordingSequence)
                return;

            
            if (_registeringClickPosition) {
                e.Handled = true;
                RegisterNewClickPosition(new ClickPosition(e.X, e.Y, e.Button));
            } else {
                RegisterClickFromSequence(new ClickPosition(e.X, e.Y, e.Button));
            }
        }

        private bool _recordingSequence;
        private void RegisterSequence_Click(object sender, EventArgs e) {
            if (listBox.SelectedItem == null) {
                MessageBox.Show("Please select the list you want to record clicks for.");
                return;
            }

            DialogResult result = MessageBox.Show("Press OK to start recording and hit the 'ESC' key on your keyboard when you're done.", "Continue", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK) {
                _recordingSequence = true;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void RegisterClickFromSequence(ClickPosition mouseClick) {
            if (!_recordingSequence)
                return;
            Draw.DrawCircle(mouseClick.X, mouseClick.Y);

            ClickCollection collection = GetSelectedClickCollection();
            collection.Clicks.Add(mouseClick);
            clickListBox.Items.Add(collection.Clicks.Count + ". X: " + mouseClick.X + " Y: " + mouseClick.Y + " Type: " + mouseClick.MouseButton); 
        }

        private void StopRecordingMouseClicks() {
            _recordingSequence = false;
            WindowState = FormWindowState.Normal;
        }

        private void RegisterButton_Click(object sender, EventArgs e) {
            _registeringClickPosition = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private void RegisterNewClickPosition(ClickPosition mouseClick) {
            if (listBox.SelectedItem == null)
                return;

            ClickCollection collection = GetSelectedClickCollection();
            _registeringClickPosition = false;
            collection.Clicks.Add(mouseClick);
            clickListBox.Items.Add(collection.Clicks.Count + ". X: " + mouseClick.X + " Y: " + mouseClick.Y + " Type: " + mouseClick.MouseButton); 
            this.WindowState = FormWindowState.Normal;
        }

        private void Application_FormClosing(object sender, FormClosingEventArgs e) {
            if (!_saveSettings && ListsAtStart != clickCollections.Count) {
                DialogResult result = MessageBox.Show("If you exit now, you'll lose your unsaved custom lists. Are you sure you want exit without saving?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) {
                    e.Cancel = true;
                    return;
                }
            }
            
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
            if ((_clickType == ClickType.Left && !TryParse(comboBox1, out _leftClickingSpeed) || 
                _clickType == ClickType.Right && !TryParse(comboBox2, out _rightClickingSpeed) ||
                _clickType == ClickType.Multi && !TryParse(comboBox1, out _leftClickingSpeed) && !TryParse(comboBox2, out _rightClickingSpeed))) {
                MessageBox.Show("Please remove any invalid characters from the click interval text box!", "Error");
                return false;
            }
            if (_randomizeClickSpeed) {
                if (!int.TryParse(comboBox3.Text.Remove(comboBox3.Text.Length - 1), out _randomizationAmount)) {
                    MessageBox.Show("There was a problem setting your randomization percentage. Please try again!", "Error");
                    return false;
                }
            }
            return true;
        }

        private void HoldCTRL_CheckedChanged(object sender, EventArgs e) {
            _holdCTRL = !_holdCTRL;
        }

        private void SaveSettingsToggle(object sender, EventArgs e) {
            _saveSettings = !_saveSettings;
        }

        private void SaveSettings() {
            if (_saveSettings) {
                new Save(clickCollections, _automatedClickCollections);
            }
        }

        private void AddListButton(object sender, EventArgs e) {
            if (availableLetters.Length == 0) {
                MessageBox.Show("You have too many lists! Please remove a list before adding a new one.", "Error");
                return;
            }
            char randomChar = Utility.GetRandomLetter();
            activeHotkeys.Add(randomChar);
            Console.WriteLine(randomChar + " was added.");


            availableLetters = availableLetters.Replace(randomChar.ToString(), string.Empty);

            ClickCollection clickCollection = new ClickCollection(new List<ClickPosition>(), Utility.GetRandomString(4), false, randomChar, 1);
            clickCollections.Add(clickCollection);
            listBox.Items.Add(clickCollection.Name + " - CTRL + " + clickCollection.Hotkey.ToString());
            listBox.SetSelected(listBox.Items.Count - 1, true);
        }

        private void EditListButton(object sender, EventArgs e) {
            if (listEditFormIsOpen)
                return;

            if (listBox.SelectedItem == null) {
                MessageBox.Show("Please select the list you want to edit!");
                return;
            }

            ClickCollection collection = GetSelectedClickCollection();

            if (collection == null) {
                MessageBox.Show("Unexpected problem: couldn't find the selected list. \n Please contact the developer if the problem persists.");
                return;
            }

            ListEditForm listEditForm = new ListEditForm(this, collection.Name, collection.SingleLoop, collection.Hotkey, collection.ClickInterval);
            listEditForm.Show();
            listEditFormIsOpen = true;
        }

        public ClickCollection FindCollectionByName(string str) {
            foreach(ClickCollection collection in clickCollections) {
                if (collection.Name == str)
                    return collection;
            }
            return null;
        }

        private ClickCollection FindCollectionByKey(Keys key) {
            char hotkey = (char) key;
            foreach(ClickCollection collection in clickCollections) {
                if (collection.Hotkey == hotkey)
                    return collection;
            }
            return null;
        }

        public void UpdateTextBox(string oldName, string newName, char hotkey) {
            int index = listBox.FindString(oldName);
            listBox.Items[index] = newName + " - CTRL + " + hotkey;
        }

        public void UpdateLoadedListData(List<ClickCollection> clickCollections) {
            for(int i = 0; i < clickCollections.Count; i++) {
                listBox.Items.Add(clickCollections[i]);
                listBox.Items[i] = clickCollections[i].Name + " - CTRL + " + clickCollections[i].Hotkey;
            }

            foreach(ClickCollection collection in clickCollections) {
                activeHotkeys.Add(collection.Hotkey);
                availableLetters = availableLetters.Replace(collection.Hotkey.ToString().ToUpper(), string.Empty);
            }
        }

        public void InitializeAutomatedLists(List<String> listNames) {
            foreach(string str in listNames) {
                _automatedClickCollections.Add(FindCollectionByName(str));
                automationListBox.Items.Add(str);
            }
        }

        public void DeleteFromTextBox(string name) {
            int index = listBox.FindString(name);
            listBox.Items.RemoveAt(index);
            if (automationListBox.Items.Contains(name)) {
                automationListBox.Items.Remove(name);
                _automatedClickCollections.Remove(FindCollectionByName(name));
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (GetSelectedClickCollection() == null)
                return;

            List<ClickPosition> clicks = GetSelectedClickCollection().Clicks;
            clickListBox.Items.Clear();

            for(int i = 0; i < clicks.Count; i++) {
                clickListBox.Items.Add((i + 1) + ". X: " + clicks[i].X + " Y: " + clicks[i].Y + " Type: " + clicks[i].MouseButton); 
            }
        }

        private ClickCollection GetSelectedClickCollection() {
            if (listBox.Items.Count == 0 || listBox.SelectedItem == null)
                return null;

            int index = listBox.Text.IndexOf("-") - 1;
            string collectionName = listBox.Text.Substring(0, index);
            return FindCollectionByName(collectionName);
        }

        private void clickListBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete && clickListBox.SelectedItem != null) {
                ClickCollection collection = GetSelectedClickCollection();
                if (collection == null)
                    return;

                string str = clickListBox.SelectedItem.ToString();
                int X = Convert.ToInt32(Utility.GetStringBetweenIndexes(str, str.IndexOf("X") + 2, str.IndexOf("Y") - 1));
                int Y = Convert.ToInt32(Utility.GetStringBetweenIndexes(str, str.IndexOf("Y") + 2, str.IndexOf("T") - 1));

                clickListBox.Items.Remove(clickListBox.SelectedItem);
                collection.Clicks.Remove(GetClickPositionByCoordinates(X, Y));

                e.Handled = true;
            }
        }

        private ClickPosition GetClickPositionByCoordinates(int x, int y) {
            foreach(ClickPosition click in GetSelectedClickCollection().Clicks) {
                if (click.X == x && click.Y == y) {
                    return click;
                }
            }
            return null;
        }

        private void twitterLogo_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://twitter.com/Temsoftio");
        }

        private void facebookLogo_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://www.facebook.com/Temsoft-425887708003948/");
        }

        private void githubLogo_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/teSill/TemseiAutoClicker");
        }

        private void holdLeftCheckBox_CheckedChanged(object sender, EventArgs e) {
            _holdLeftMouseButton = !_holdLeftMouseButton;
            clickIntervalsGroupBox.Enabled = (_holdLeftMouseButton || _holdRightMouseButton) ? false : true;
            clickRandomizationGroupBox.Enabled = (_holdLeftMouseButton || _holdRightMouseButton) ? false : true;
        }

        private void holdRightCheckBox_CheckedChanged(object sender, EventArgs e) {
            _holdRightMouseButton = !_holdRightMouseButton;
            clickIntervalsGroupBox.Enabled = (_holdLeftMouseButton || _holdRightMouseButton) ? false : true;
            clickRandomizationGroupBox.Enabled = (_holdLeftMouseButton || _holdRightMouseButton) ? false : true;
        }

        private void automateListButton_Click(object sender, EventArgs e) {
            if (GetSelectedClickCollection() == null) {
                MessageBox.Show("Please select a list to automate.");
                return;
            }

            ClickCollection clickCollection = GetSelectedClickCollection();

            if (_automatedClickCollections.Contains(clickCollection)) {
                MessageBox.Show("You've already automated this list!");
                return;
            }

            if (clickCollection.SingleLoop) {
                MessageBox.Show("Please toggle off your lists 'SingleLoop' setting before automating it.");
                return;
            }
            
            _automatedClickCollections.Add(clickCollection);
            automationListBox.Items.Add(clickCollection.Name);
        }

        private void automationHotkey_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyValue >= 0x41 && e.KeyValue <= 0x5A) { // Letters only
                if (activeHotkeys.Contains((char) e.KeyCode)) {
                    MessageBox.Show("The hotkey '" + e.KeyCode + "' is already in use.");
                    return;
                }
                automationTextBox.Text = "CTRL + " + e.KeyCode.ToString();
                activeHotkeys.Remove(_defaultHotkey);
                _defaultHotkey = (char) e.KeyCode;
                activeHotkeys.Add(_defaultHotkey);
            }
        }

        private void automationListBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete && automationListBox.SelectedItem != null) {
                string str = automationListBox.SelectedItem.ToString();
                string index = str[0].ToString();

                ClickCollection collection = FindCollectionByName(str);

                automationListBox.Items.Remove(automationListBox.SelectedItem);
                _automatedClickCollections.Remove(collection);

                e.Handled = true;
            }
        }
    }
}
