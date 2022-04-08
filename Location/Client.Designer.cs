namespace Location
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HostTextBox = new System.Windows.Forms.TextBox();
            this.HostLabel = new System.Windows.Forms.Label();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.SendRequestButton = new System.Windows.Forms.Button();
            this.LocationTextBox = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.HTTPtypeComboBox = new System.Windows.Forms.ComboBox();
            this.HTTPTypeLabel = new System.Windows.Forms.Label();
            this.DebugCheckBox = new System.Windows.Forms.CheckBox();
            this.TimeoutLabel = new System.Windows.Forms.Label();
            this.TimeoutTextBox = new System.Windows.Forms.TextBox();
            this.ConsoleViewLabel = new System.Windows.Forms.Label();
            this.ConsoleList = new System.Windows.Forms.ListBox();
            this.ClearViewerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HostTextBox
            // 
            this.HostTextBox.Location = new System.Drawing.Point(146, 32);
            this.HostTextBox.Name = "HostTextBox";
            this.HostTextBox.Size = new System.Drawing.Size(116, 20);
            this.HostTextBox.TabIndex = 0;
            // 
            // HostLabel
            // 
            this.HostLabel.AutoSize = true;
            this.HostLabel.Location = new System.Drawing.Point(143, 16);
            this.HostLabel.Name = "HostLabel";
            this.HostLabel.Size = new System.Drawing.Size(29, 13);
            this.HostLabel.TabIndex = 1;
            this.HostLabel.Text = "Host";
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(146, 77);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(116, 20);
            this.PortTextBox.TabIndex = 2;
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(143, 61);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(26, 13);
            this.PortLabel.TabIndex = 3;
            this.PortLabel.Text = "Port";
            // 
            // SendRequestButton
            // 
            this.SendRequestButton.Location = new System.Drawing.Point(470, 155);
            this.SendRequestButton.Name = "SendRequestButton";
            this.SendRequestButton.Size = new System.Drawing.Size(135, 41);
            this.SendRequestButton.TabIndex = 4;
            this.SendRequestButton.Text = "Send Request";
            this.SendRequestButton.UseVisualStyleBackColor = true;
            this.SendRequestButton.Click += new System.EventHandler(this.SendRequestButton_Click);
            // 
            // LocationTextBox
            // 
            this.LocationTextBox.AutoSize = true;
            this.LocationTextBox.Location = new System.Drawing.Point(9, 61);
            this.LocationTextBox.Name = "LocationTextBox";
            this.LocationTextBox.Size = new System.Drawing.Size(48, 13);
            this.LocationTextBox.TabIndex = 8;
            this.LocationTextBox.Text = "Location";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 20);
            this.textBox1.TabIndex = 7;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(9, 16);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 6;
            this.UsernameLabel.Text = "Username";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(12, 32);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(116, 20);
            this.UsernameTextBox.TabIndex = 5;
            // 
            // HTTPtypeComboBox
            // 
            this.HTTPtypeComboBox.FormattingEnabled = true;
            this.HTTPtypeComboBox.Items.AddRange(new object[] {
            "WHOIS",
            "HTTP 0.9",
            "HTTP 1.0",
            "HTTP 1.1"});
            this.HTTPtypeComboBox.Location = new System.Drawing.Point(12, 128);
            this.HTTPtypeComboBox.Name = "HTTPtypeComboBox";
            this.HTTPtypeComboBox.Size = new System.Drawing.Size(116, 21);
            this.HTTPtypeComboBox.TabIndex = 9;
            // 
            // HTTPTypeLabel
            // 
            this.HTTPTypeLabel.AutoSize = true;
            this.HTTPTypeLabel.Location = new System.Drawing.Point(12, 109);
            this.HTTPTypeLabel.Name = "HTTPTypeLabel";
            this.HTTPTypeLabel.Size = new System.Drawing.Size(78, 13);
            this.HTTPTypeLabel.TabIndex = 10;
            this.HTTPTypeLabel.Text = "HTTP Protocol";
            // 
            // DebugCheckBox
            // 
            this.DebugCheckBox.AutoSize = true;
            this.DebugCheckBox.Location = new System.Drawing.Point(146, 171);
            this.DebugCheckBox.Name = "DebugCheckBox";
            this.DebugCheckBox.Size = new System.Drawing.Size(88, 17);
            this.DebugCheckBox.TabIndex = 11;
            this.DebugCheckBox.Text = "Debug Mode";
            this.DebugCheckBox.UseVisualStyleBackColor = true;
            // 
            // TimeoutLabel
            // 
            this.TimeoutLabel.AutoSize = true;
            this.TimeoutLabel.Location = new System.Drawing.Point(143, 109);
            this.TimeoutLabel.Name = "TimeoutLabel";
            this.TimeoutLabel.Size = new System.Drawing.Size(45, 13);
            this.TimeoutLabel.TabIndex = 12;
            this.TimeoutLabel.Text = "Timeout";
            // 
            // TimeoutTextBox
            // 
            this.TimeoutTextBox.Location = new System.Drawing.Point(146, 129);
            this.TimeoutTextBox.Name = "TimeoutTextBox";
            this.TimeoutTextBox.Size = new System.Drawing.Size(116, 20);
            this.TimeoutTextBox.TabIndex = 13;
            // 
            // ConsoleViewLabel
            // 
            this.ConsoleViewLabel.AutoSize = true;
            this.ConsoleViewLabel.Location = new System.Drawing.Point(287, 16);
            this.ConsoleViewLabel.Name = "ConsoleViewLabel";
            this.ConsoleViewLabel.Size = new System.Drawing.Size(76, 13);
            this.ConsoleViewLabel.TabIndex = 15;
            this.ConsoleViewLabel.Text = "Update viewer";
            // 
            // ConsoleList
            // 
            this.ConsoleList.FormattingEnabled = true;
            this.ConsoleList.Location = new System.Drawing.Point(290, 32);
            this.ConsoleList.Name = "ConsoleList";
            this.ConsoleList.Size = new System.Drawing.Size(315, 121);
            this.ConsoleList.TabIndex = 16;
            // 
            // ClearViewerButton
            // 
            this.ClearViewerButton.Location = new System.Drawing.Point(290, 155);
            this.ClearViewerButton.Name = "ClearViewerButton";
            this.ClearViewerButton.Size = new System.Drawing.Size(75, 41);
            this.ClearViewerButton.TabIndex = 17;
            this.ClearViewerButton.Text = "Clear Viewer";
            this.ClearViewerButton.UseVisualStyleBackColor = true;
            this.ClearViewerButton.Click += new System.EventHandler(this.ClearViewerButton_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 200);
            this.Controls.Add(this.ClearViewerButton);
            this.Controls.Add(this.ConsoleList);
            this.Controls.Add(this.ConsoleViewLabel);
            this.Controls.Add(this.TimeoutTextBox);
            this.Controls.Add(this.TimeoutLabel);
            this.Controls.Add(this.DebugCheckBox);
            this.Controls.Add(this.HTTPTypeLabel);
            this.Controls.Add(this.HTTPtypeComboBox);
            this.Controls.Add(this.LocationTextBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.SendRequestButton);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.HostLabel);
            this.Controls.Add(this.HostTextBox);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HostTextBox;
        private System.Windows.Forms.Label HostLabel;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Button SendRequestButton;
        private System.Windows.Forms.Label LocationTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.ComboBox HTTPtypeComboBox;
        private System.Windows.Forms.Label HTTPTypeLabel;
        private System.Windows.Forms.CheckBox DebugCheckBox;
        private System.Windows.Forms.Label TimeoutLabel;
        private System.Windows.Forms.TextBox TimeoutTextBox;
        private System.Windows.Forms.Label ConsoleViewLabel;
        private System.Windows.Forms.ListBox ConsoleList;
        private System.Windows.Forms.Button ClearViewerButton;
    }
}

