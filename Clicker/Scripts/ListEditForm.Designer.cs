namespace TemseiAutoClicker {
    partial class ListEditForm {
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.singleLoopLabel = new System.Windows.Forms.Label();
            this.hotkeyLabel = new System.Windows.Forms.Label();
            this.clickSpeedLabel = new System.Windows.Forms.Label();
            this.singleLoopCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.hotkeyTextBox = new System.Windows.Forms.TextBox();
            this.clickSpeedTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nameLabel.Location = new System.Drawing.Point(13, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(55, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // singleLoopLabel
            // 
            this.singleLoopLabel.AutoSize = true;
            this.singleLoopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.singleLoopLabel.Location = new System.Drawing.Point(13, 42);
            this.singleLoopLabel.Name = "singleLoopLabel";
            this.singleLoopLabel.Size = new System.Drawing.Size(97, 20);
            this.singleLoopLabel.TabIndex = 0;
            this.singleLoopLabel.Text = "Single Loop:";
            // 
            // hotkeyLabel
            // 
            this.hotkeyLabel.AutoSize = true;
            this.hotkeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.hotkeyLabel.Location = new System.Drawing.Point(13, 71);
            this.hotkeyLabel.Name = "hotkeyLabel";
            this.hotkeyLabel.Size = new System.Drawing.Size(63, 20);
            this.hotkeyLabel.TabIndex = 0;
            this.hotkeyLabel.Text = "Hotkey:";
            // 
            // clickSpeedLabel
            // 
            this.clickSpeedLabel.AutoSize = true;
            this.clickSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.clickSpeedLabel.Location = new System.Drawing.Point(12, 100);
            this.clickSpeedLabel.Name = "clickSpeedLabel";
            this.clickSpeedLabel.Size = new System.Drawing.Size(102, 20);
            this.clickSpeedLabel.TabIndex = 0;
            this.clickSpeedLabel.Text = "Click Interval:";
            // 
            // singleLoopCheckBox
            // 
            this.singleLoopCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.singleLoopCheckBox.Location = new System.Drawing.Point(116, 41);
            this.singleLoopCheckBox.Name = "singleLoopCheckBox";
            this.singleLoopCheckBox.Size = new System.Drawing.Size(20, 27);
            this.singleLoopCheckBox.TabIndex = 1;
            this.singleLoopCheckBox.UseVisualStyleBackColor = true;
            this.singleLoopCheckBox.CheckedChanged += new System.EventHandler(this.SingleLoopCheckBox_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.saveButton.Location = new System.Drawing.Point(100, 133);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 26);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cancelButton.Location = new System.Drawing.Point(13, 133);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 26);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(75, 14);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 4;
            this.nameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // hotkeyTextBox
            // 
            this.hotkeyTextBox.Location = new System.Drawing.Point(82, 72);
            this.hotkeyTextBox.Name = "hotkeyTextBox";
            this.hotkeyTextBox.ReadOnly = true;
            this.hotkeyTextBox.Size = new System.Drawing.Size(100, 20);
            this.hotkeyTextBox.TabIndex = 4;
            this.hotkeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotkeyTextBox_KeyDown);
            // 
            // clickSpeedTextBox
            // 
            this.clickSpeedTextBox.Location = new System.Drawing.Point(116, 101);
            this.clickSpeedTextBox.Name = "clickSpeedTextBox";
            this.clickSpeedTextBox.Size = new System.Drawing.Size(66, 20);
            this.clickSpeedTextBox.TabIndex = 4;
            this.clickSpeedTextBox.TextChanged += new System.EventHandler(this.ClickSpeedTextBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(52, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // ListEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 193);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clickSpeedTextBox);
            this.Controls.Add(this.hotkeyTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.singleLoopCheckBox);
            this.Controls.Add(this.clickSpeedLabel);
            this.Controls.Add(this.hotkeyLabel);
            this.Controls.Add(this.singleLoopLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "ListEditForm";
            this.Text = "ListEditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.listEditForm_FormClosing);
            this.Load += new System.EventHandler(this.ListEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label singleLoopLabel;
        private System.Windows.Forms.Label hotkeyLabel;
        private System.Windows.Forms.Label clickSpeedLabel;
        private System.Windows.Forms.CheckBox singleLoopCheckBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox hotkeyTextBox;
        private System.Windows.Forms.TextBox clickSpeedTextBox;
        private System.Windows.Forms.Button button1;
    }
}