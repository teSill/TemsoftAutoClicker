namespace TemseiAutoClicker {
    partial class Application {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.automationListBox = new System.Windows.Forms.ListBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.advancedSettingsPanel = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.automationTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.continueButton = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.clickListBox = new System.Windows.Forms.ListBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.advancedSettingsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clickIntervalsGroupBox = new System.Windows.Forms.GroupBox();
            this.clickRandomizationGroupBox = new System.Windows.Forms.GroupBox();
            this.advancedSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.supportBox = new System.Windows.Forms.GroupBox();
            this.githubLogo = new System.Windows.Forms.PictureBox();
            this.facebookLogo = new System.Windows.Forms.PictureBox();
            this.githubLabel = new System.Windows.Forms.Label();
            this.facebookLabel = new System.Windows.Forms.Label();
            this.twitterLabel = new System.Windows.Forms.Label();
            this.twitterLogo = new System.Windows.Forms.PictureBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.holdRightCheckBox = new System.Windows.Forms.CheckBox();
            this.holdLeftCheckBox = new System.Windows.Forms.CheckBox();
            this.advancedSettingsPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.clickIntervalsGroupBox.SuspendLayout();
            this.clickRandomizationGroupBox.SuspendLayout();
            this.advancedSettingsGroupBox.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.supportBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.githubLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twitterLogo)).BeginInit();
            this.groupBox13.SuspendLayout();
            this.SuspendLayout();
            // 
            // automationListBox
            // 
            this.automationListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.automationListBox.FormattingEnabled = true;
            this.automationListBox.Location = new System.Drawing.Point(3, 16);
            this.automationListBox.Name = "automationListBox";
            this.automationListBox.Size = new System.Drawing.Size(204, 44);
            this.automationListBox.TabIndex = 0;
            this.automationListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.automationListBox_KeyDown);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(6, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(92, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Left Click";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.LeftClickButton_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(104, 17);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(102, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Right Click";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RightClickButton_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0.01",
            "0.05",
            "0.1",
            "0.25",
            "0.5",
            "1",
            "2",
            "3",
            "5",
            "10"});
            this.comboBox1.Location = new System.Drawing.Point(51, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(73, 24);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.LeftClickIntervalBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "START && STOP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(27, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(92, 26);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "CTRL + H";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotKeyTextBox_KeyDown);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(11, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(151, 24);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Randomize clicks";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.RandomizeButton_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(212, 17);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(61, 24);
            this.radioButton3.TabIndex = 11;
            this.radioButton3.Text = "Both";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.BothButton_CheckedChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "0.01",
            "0.05",
            "0.1",
            "0.25",
            "0.5",
            "1",
            "2",
            "3",
            "5",
            "10"});
            this.comboBox2.Location = new System.Drawing.Point(193, 25);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(73, 24);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.RightClickIntervalBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Left";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(140, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Right";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Enabled = false;
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "5%",
            "10%",
            "20%",
            "30%",
            "40%",
            "50%",
            "60%",
            "70%",
            "80%",
            "90%",
            "100%"});
            this.comboBox3.Location = new System.Drawing.Point(199, 20);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(67, 28);
            this.comboBox3.TabIndex = 12;
            // 
            // advancedSettingsPanel
            // 
            this.advancedSettingsPanel.Controls.Add(this.groupBox3);
            this.advancedSettingsPanel.Controls.Add(this.groupBox2);
            this.advancedSettingsPanel.Controls.Add(this.groupBox12);
            this.advancedSettingsPanel.Controls.Add(this.groupBox11);
            this.advancedSettingsPanel.Controls.Add(this.groupBox10);
            this.advancedSettingsPanel.Controls.Add(this.groupBox9);
            this.advancedSettingsPanel.Controls.Add(this.groupBox8);
            this.advancedSettingsPanel.Controls.Add(this.groupBox7);
            this.advancedSettingsPanel.Controls.Add(this.groupBox6);
            this.advancedSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.advancedSettingsPanel.Name = "advancedSettingsPanel";
            this.advancedSettingsPanel.Size = new System.Drawing.Size(444, 318);
            this.advancedSettingsPanel.TabIndex = 2;
            this.advancedSettingsPanel.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.automationTextBox);
            this.groupBox3.Location = new System.Drawing.Point(228, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(116, 63);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Automation Hotkey";
            // 
            // automationTextBox
            // 
            this.automationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.automationTextBox.Location = new System.Drawing.Point(7, 22);
            this.automationTextBox.Name = "automationTextBox";
            this.automationTextBox.ReadOnly = true;
            this.automationTextBox.Size = new System.Drawing.Size(100, 26);
            this.automationTextBox.TabIndex = 0;
            this.automationTextBox.Text = "CTRL + B";
            this.automationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.automationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.automationHotkey_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.automationListBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 252);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 63);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lists Here Will Auto. Run In Order";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.continueButton);
            this.groupBox12.Location = new System.Drawing.Point(348, 252);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(92, 63);
            this.groupBox12.TabIndex = 15;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Main Menu";
            // 
            // continueButton
            // 
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(4, 21);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(84, 31);
            this.continueButton.TabIndex = 3;
            this.continueButton.Text = "Return";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.checkBox3);
            this.groupBox11.Location = new System.Drawing.Point(348, 184);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(93, 61);
            this.groupBox11.TabIndex = 15;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Save Lists?";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBox3.Location = new System.Drawing.Point(11, 23);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(64, 24);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "Save";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.SaveSettingsToggle);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.button3);
            this.groupBox10.Controls.Add(this.button5);
            this.groupBox10.Location = new System.Drawing.Point(348, 66);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(92, 112);
            this.groupBox10.TabIndex = 14;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Register Clicks";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button3.Location = new System.Drawing.Point(6, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 45);
            this.button3.TabIndex = 1;
            this.button3.Text = "Record Sequence";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.RegisterSequence_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button5.Location = new System.Drawing.Point(6, 14);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 45);
            this.button5.TabIndex = 0;
            this.button5.Text = "Single Click";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.clickListBox);
            this.groupBox9.Location = new System.Drawing.Point(156, 66);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(188, 112);
            this.groupBox9.TabIndex = 13;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "List Click Information";
            // 
            // clickListBox
            // 
            this.clickListBox.FormattingEnabled = true;
            this.clickListBox.Location = new System.Drawing.Point(5, 19);
            this.clickListBox.Name = "clickListBox";
            this.clickListBox.Size = new System.Drawing.Size(177, 82);
            this.clickListBox.TabIndex = 5;
            this.clickListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clickListBox_KeyDown);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button2);
            this.groupBox8.Controls.Add(this.button1);
            this.groupBox8.Controls.Add(this.button6);
            this.groupBox8.Location = new System.Drawing.Point(12, 184);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(332, 62);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "List Modification";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button2.Location = new System.Drawing.Point(229, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 30);
            this.button2.TabIndex = 11;
            this.button2.Text = "Automate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.automateListButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button1.Location = new System.Drawing.Point(14, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Add List";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.AddListButton);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.button6.Location = new System.Drawing.Point(120, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 30);
            this.button6.TabIndex = 10;
            this.button6.Text = "Edit List";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.EditListButton);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.listBox);
            this.groupBox7.Location = new System.Drawing.Point(12, 66);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(138, 112);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Lists (Name - Hotkey)";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 19);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(120, 82);
            this.listBox.TabIndex = 8;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Location = new System.Drawing.Point(12, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(429, 64);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Instructions";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(21, 19);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(369, 37);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Add and customize lists for the program to iterate through. Click a registration " +
    "button to add new clicks to the currently selected list.";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // advancedSettingsButton
            // 
            this.advancedSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.advancedSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.advancedSettingsButton.Location = new System.Drawing.Point(138, 19);
            this.advancedSettingsButton.Name = "advancedSettingsButton";
            this.advancedSettingsButton.Size = new System.Drawing.Size(170, 39);
            this.advancedSettingsButton.TabIndex = 13;
            this.advancedSettingsButton.Text = "Advanced Settings";
            this.advancedSettingsButton.UseVisualStyleBackColor = true;
            this.advancedSettingsButton.Click += new System.EventHandler(this.CustomizedClicksButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 47);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Click Type";
            // 
            // clickIntervalsGroupBox
            // 
            this.clickIntervalsGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.clickIntervalsGroupBox.Controls.Add(this.comboBox1);
            this.clickIntervalsGroupBox.Controls.Add(this.comboBox2);
            this.clickIntervalsGroupBox.Controls.Add(this.label3);
            this.clickIntervalsGroupBox.Controls.Add(this.label4);
            this.clickIntervalsGroupBox.Location = new System.Drawing.Point(16, 66);
            this.clickIntervalsGroupBox.Name = "clickIntervalsGroupBox";
            this.clickIntervalsGroupBox.Size = new System.Drawing.Size(276, 63);
            this.clickIntervalsGroupBox.TabIndex = 18;
            this.clickIntervalsGroupBox.TabStop = false;
            this.clickIntervalsGroupBox.Text = "Click Intervals";
            // 
            // clickRandomizationGroupBox
            // 
            this.clickRandomizationGroupBox.Controls.Add(this.checkBox1);
            this.clickRandomizationGroupBox.Controls.Add(this.comboBox3);
            this.clickRandomizationGroupBox.Location = new System.Drawing.Point(16, 135);
            this.clickRandomizationGroupBox.Name = "clickRandomizationGroupBox";
            this.clickRandomizationGroupBox.Size = new System.Drawing.Size(276, 62);
            this.clickRandomizationGroupBox.TabIndex = 19;
            this.clickRandomizationGroupBox.TabStop = false;
            this.clickRandomizationGroupBox.Text = "Click Randomization";
            // 
            // advancedSettingsGroupBox
            // 
            this.advancedSettingsGroupBox.Controls.Add(this.advancedSettingsButton);
            this.advancedSettingsGroupBox.Location = new System.Drawing.Point(3, 254);
            this.advancedSettingsGroupBox.Name = "advancedSettingsGroupBox";
            this.advancedSettingsGroupBox.Size = new System.Drawing.Size(441, 64);
            this.advancedSettingsGroupBox.TabIndex = 20;
            this.advancedSettingsGroupBox.TabStop = false;
            this.advancedSettingsGroupBox.Text = "Perform Complex Click Sequences";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Location = new System.Drawing.Point(304, 154);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(140, 100);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Hotkey Setup";
            // 
            // supportBox
            // 
            this.supportBox.Controls.Add(this.githubLogo);
            this.supportBox.Controls.Add(this.facebookLogo);
            this.supportBox.Controls.Add(this.githubLabel);
            this.supportBox.Controls.Add(this.facebookLabel);
            this.supportBox.Controls.Add(this.twitterLabel);
            this.supportBox.Controls.Add(this.twitterLogo);
            this.supportBox.Location = new System.Drawing.Point(304, 12);
            this.supportBox.Name = "supportBox";
            this.supportBox.Size = new System.Drawing.Size(140, 136);
            this.supportBox.TabIndex = 0;
            this.supportBox.TabStop = false;
            this.supportBox.Text = "Support";
            // 
            // githubLogo
            // 
            this.githubLogo.Image = global::TemsoftAutoClicker.Properties.Resources.GitHubLogo;
            this.githubLogo.Location = new System.Drawing.Point(10, 95);
            this.githubLogo.Name = "githubLogo";
            this.githubLogo.Size = new System.Drawing.Size(28, 28);
            this.githubLogo.TabIndex = 3;
            this.githubLogo.TabStop = false;
            this.githubLogo.Click += new System.EventHandler(this.githubLogo_Click);
            // 
            // facebookLogo
            // 
            this.facebookLogo.Image = global::TemsoftAutoClicker.Properties.Resources.FacebookLogo;
            this.facebookLogo.Location = new System.Drawing.Point(10, 61);
            this.facebookLogo.Name = "facebookLogo";
            this.facebookLogo.Size = new System.Drawing.Size(28, 28);
            this.facebookLogo.TabIndex = 2;
            this.facebookLogo.TabStop = false;
            this.facebookLogo.Click += new System.EventHandler(this.facebookLogo_Click);
            // 
            // githubLabel
            // 
            this.githubLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.githubLabel.Location = new System.Drawing.Point(46, 95);
            this.githubLabel.Name = "githubLabel";
            this.githubLabel.Size = new System.Drawing.Size(90, 28);
            this.githubLabel.TabIndex = 1;
            this.githubLabel.Text = "GitHub";
            this.githubLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.githubLabel.Click += new System.EventHandler(this.githubLogo_Click);
            // 
            // facebookLabel
            // 
            this.facebookLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.facebookLabel.Location = new System.Drawing.Point(46, 61);
            this.facebookLabel.Name = "facebookLabel";
            this.facebookLabel.Size = new System.Drawing.Size(90, 28);
            this.facebookLabel.TabIndex = 1;
            this.facebookLabel.Text = "Facebook";
            this.facebookLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.facebookLabel.Click += new System.EventHandler(this.facebookLogo_Click);
            // 
            // twitterLabel
            // 
            this.twitterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.twitterLabel.Location = new System.Drawing.Point(46, 27);
            this.twitterLabel.Name = "twitterLabel";
            this.twitterLabel.Size = new System.Drawing.Size(90, 28);
            this.twitterLabel.TabIndex = 1;
            this.twitterLabel.Text = "Twitter";
            this.twitterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.twitterLabel.Click += new System.EventHandler(this.twitterLogo_Click);
            // 
            // twitterLogo
            // 
            this.twitterLogo.Image = global::TemsoftAutoClicker.Properties.Resources.TwitterLogo;
            this.twitterLogo.Location = new System.Drawing.Point(10, 27);
            this.twitterLogo.Name = "twitterLogo";
            this.twitterLogo.Size = new System.Drawing.Size(28, 28);
            this.twitterLogo.TabIndex = 0;
            this.twitterLogo.TabStop = false;
            this.twitterLogo.Click += new System.EventHandler(this.twitterLogo_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.holdRightCheckBox);
            this.groupBox13.Controls.Add(this.holdLeftCheckBox);
            this.groupBox13.Location = new System.Drawing.Point(16, 203);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(276, 51);
            this.groupBox13.TabIndex = 19;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Hold down mouse buttons?";
            // 
            // holdRightCheckBox
            // 
            this.holdRightCheckBox.AutoSize = true;
            this.holdRightCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.holdRightCheckBox.Location = new System.Drawing.Point(163, 19);
            this.holdRightCheckBox.Name = "holdRightCheckBox";
            this.holdRightCheckBox.Size = new System.Drawing.Size(103, 24);
            this.holdRightCheckBox.TabIndex = 1;
            this.holdRightCheckBox.Text = "Hold Right";
            this.holdRightCheckBox.UseVisualStyleBackColor = true;
            this.holdRightCheckBox.CheckedChanged += new System.EventHandler(this.holdRightCheckBox_CheckedChanged);
            // 
            // holdLeftCheckBox
            // 
            this.holdLeftCheckBox.AutoSize = true;
            this.holdLeftCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.holdLeftCheckBox.Location = new System.Drawing.Point(10, 19);
            this.holdLeftCheckBox.Name = "holdLeftCheckBox";
            this.holdLeftCheckBox.Size = new System.Drawing.Size(87, 24);
            this.holdLeftCheckBox.TabIndex = 0;
            this.holdLeftCheckBox.Text = "Hold left";
            this.holdLeftCheckBox.UseVisualStyleBackColor = true;
            this.holdLeftCheckBox.CheckedChanged += new System.EventHandler(this.holdLeftCheckBox_CheckedChanged);
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 318);
            this.Controls.Add(this.advancedSettingsPanel);
            this.Controls.Add(this.supportBox);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.advancedSettingsGroupBox);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.clickRandomizationGroupBox);
            this.Controls.Add(this.clickIntervalsGroupBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temsoft Auto Clicker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Application_FormClosing);
            this.Load += new System.EventHandler(this.Application_Load);
            this.advancedSettingsPanel.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.clickIntervalsGroupBox.ResumeLayout(false);
            this.clickIntervalsGroupBox.PerformLayout();
            this.clickRandomizationGroupBox.ResumeLayout(false);
            this.clickRandomizationGroupBox.PerformLayout();
            this.advancedSettingsGroupBox.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.supportBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.githubLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twitterLogo)).EndInit();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Panel advancedSettingsPanel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button advancedSettingsButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox clickListBox;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox clickIntervalsGroupBox;
        private System.Windows.Forms.GroupBox clickRandomizationGroupBox;
        private System.Windows.Forms.GroupBox advancedSettingsGroupBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox supportBox;
        private System.Windows.Forms.PictureBox twitterLogo;
        private System.Windows.Forms.Label facebookLabel;
        private System.Windows.Forms.Label twitterLabel;
        private System.Windows.Forms.PictureBox facebookLogo;
        private System.Windows.Forms.PictureBox githubLogo;
        private System.Windows.Forms.Label githubLabel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.CheckBox holdRightCheckBox;
        private System.Windows.Forms.CheckBox holdLeftCheckBox;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox automationTextBox;
        private System.Windows.Forms.ListBox automationListBox;
        private System.Windows.Forms.Button button3;
    }
}

