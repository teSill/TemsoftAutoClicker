using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemseiAutoClicker {
    public partial class ListEditForm : Form {

        //private GlobalHotkey _ghk;

        private Application _application;

        private string _originalListName;
        private string _updatedListName;
        private bool _singleLoop;
        private char _hotkey;
        private float _clickSpeed;

        private char _oldHotkey;

        public ListEditForm(Application application, string listName, bool singleLoop, char hotkey, float clickSpeed) {
            _application = application;
            _originalListName = listName;
            _updatedListName = listName;
            _singleLoop = singleLoop;
            _hotkey = hotkey;
            _clickSpeed = clickSpeed;
            _oldHotkey = hotkey;
            InitializeComponent();
        }

        private void CancelButtonClick(object sender, EventArgs e) {
            _application.listEditFormIsOpen = false;
            hotkeyTextBox.Text = "CTRL + " + _oldHotkey;
            Hide();
        }

        private void SaveButtonClick(object sender, EventArgs e) {
            char newKey = GetLastCharacterFromString(hotkeyTextBox.Text);

            if (newKey != _oldHotkey) {
                if (Application.activeHotkeys.Contains(newKey) || !Application.availableLetters.Contains(newKey)) {
                    MessageBox.Show("Couldn't register new hotkey! It's probably already in use.", "Error");
                    Console.WriteLine(Application.availableLetters);
                    return;
                } else {
                    Application.activeHotkeys.Remove(_oldHotkey);
                    Application.activeHotkeys.Add(newKey);

                    Application.availableLetters = Application.availableLetters += _oldHotkey;
                    Application.availableLetters = Application.availableLetters.Replace(newKey.ToString(), string.Empty);
                    hotkeyTextBox.Text = "CTRL + " + newKey;
                    
                    Console.WriteLine("Hotkey is now " + newKey);
                    _hotkey = newKey;
                }
            }

            ClickCollection clickCollection = _application.FindCollectionByName(_originalListName);
            clickCollection.UpdateList(_updatedListName, _singleLoop, _hotkey, _clickSpeed);
            
            _application.UpdateTextBox(_originalListName, _updatedListName, _hotkey);
            _application.listEditFormIsOpen = false;
            Hide();
        }

        private void DeleteButtonClick(object sender, EventArgs e) {
            ClickCollection clickCollection = _application.FindCollectionByName(_updatedListName);
            string filePath = Path.Combine(Application.FolderPath, clickCollection.Name + ".txt");
            try {
                if (Directory.Exists(Application.FolderPath)) {
                
                    if (File.Exists(filePath)) {
                        File.Delete(filePath);
                    }
                }
            } catch(IOException ioe) {
                Console.WriteLine(ioe.Message);
            }

            
            Application.availableLetters += clickCollection.Hotkey.ToString();
            Application.activeHotkeys.Add(clickCollection.Hotkey);
            Console.WriteLine("Added " + clickCollection.Hotkey + " to the list.");
            _application.clickCollections.Remove(clickCollection);

            _application.DeleteTextBox(_updatedListName);
            _application.listEditFormIsOpen = false;
            Hide();
        }

        private void ListEditForm_Load(object sender, EventArgs e) {
            nameTextBox.Text = _updatedListName;
            singleLoopCheckBox.Checked = _singleLoop;
            hotkeyTextBox.Text = "CTRL + " + _hotkey.ToString();
            clickSpeedTextBox.Text = _clickSpeed.ToString();
        }

        private void listEditForm_FormClosing(object sender, FormClosingEventArgs e) {
            _application.listEditFormIsOpen = false;
            hotkeyTextBox.Text = "CTRL + " + _oldHotkey;
        }

        private void HotkeyTextBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyValue >= 0x41 && e.KeyValue <= 0x5A) { // Letters only
                _oldHotkey = Convert.ToChar(GetLastCharacterFromString(hotkeyTextBox.Text));
                hotkeyTextBox.Text = "CTRL + " + e.KeyCode.ToString();
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e) {
            _updatedListName = nameTextBox.Text;
        }

        private void SingleLoopCheckBox_CheckedChanged(object sender, EventArgs e) {
            _singleLoop = singleLoopCheckBox.Checked;
        }

        private void ClickSpeedTextBox_TextChanged(object sender, EventArgs e) {
            float.TryParse(clickSpeedTextBox.Text, out _clickSpeed);
        }

        private Char GetLastCharacterFromString(string str) {
            return Convert.ToChar(str.Substring(str.Length - 1, 1));
        }
    }
}
