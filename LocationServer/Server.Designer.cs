namespace LocationServer
{
    partial class Server
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
            this.RunServerButton = new System.Windows.Forms.Button();
            this.DebugModeCheckBox = new System.Windows.Forms.CheckBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.TimeoutLabel = new System.Windows.Forms.Label();
            this.TimeoutTextBox = new System.Windows.Forms.TextBox();
            this.ConsoleView = new System.Windows.Forms.ListView();
            this.ConsoleViewLabel = new System.Windows.Forms.Label();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.ServerRunningLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RunServerButton
            // 
            this.RunServerButton.Location = new System.Drawing.Point(15, 148);
            this.RunServerButton.Name = "RunServerButton";
            this.RunServerButton.Size = new System.Drawing.Size(136, 40);
            this.RunServerButton.TabIndex = 0;
            this.RunServerButton.Text = "Run Server";
            this.RunServerButton.UseVisualStyleBackColor = true;
            this.RunServerButton.Click += new System.EventHandler(this.RunServerButton_Click);
            // 
            // DebugModeCheckBox
            // 
            this.DebugModeCheckBox.AutoSize = true;
            this.DebugModeCheckBox.Location = new System.Drawing.Point(164, 171);
            this.DebugModeCheckBox.Name = "DebugModeCheckBox";
            this.DebugModeCheckBox.Size = new System.Drawing.Size(88, 17);
            this.DebugModeCheckBox.TabIndex = 1;
            this.DebugModeCheckBox.Text = "Debug Mode";
            this.DebugModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(12, 18);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(26, 13);
            this.PortLabel.TabIndex = 2;
            this.PortLabel.Text = "Port";
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(15, 34);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(109, 20);
            this.PortTextBox.TabIndex = 3;
            // 
            // TimeoutLabel
            // 
            this.TimeoutLabel.AutoSize = true;
            this.TimeoutLabel.Location = new System.Drawing.Point(132, 18);
            this.TimeoutLabel.Name = "TimeoutLabel";
            this.TimeoutLabel.Size = new System.Drawing.Size(45, 13);
            this.TimeoutLabel.TabIndex = 4;
            this.TimeoutLabel.Text = "Timeout";
            // 
            // TimeoutTextBox
            // 
            this.TimeoutTextBox.Location = new System.Drawing.Point(135, 34);
            this.TimeoutTextBox.Name = "TimeoutTextBox";
            this.TimeoutTextBox.Size = new System.Drawing.Size(107, 20);
            this.TimeoutTextBox.TabIndex = 5;
            // 
            // ConsoleView
            // 
            this.ConsoleView.HideSelection = false;
            this.ConsoleView.Location = new System.Drawing.Point(271, 34);
            this.ConsoleView.Name = "ConsoleView";
            this.ConsoleView.Size = new System.Drawing.Size(337, 154);
            this.ConsoleView.TabIndex = 6;
            this.ConsoleView.UseCompatibleStateImageBehavior = false;
            // 
            // ConsoleViewLabel
            // 
            this.ConsoleViewLabel.AutoSize = true;
            this.ConsoleViewLabel.Location = new System.Drawing.Point(268, 18);
            this.ConsoleViewLabel.Name = "ConsoleViewLabel";
            this.ConsoleViewLabel.Size = new System.Drawing.Size(76, 13);
            this.ConsoleViewLabel.TabIndex = 7;
            this.ConsoleViewLabel.Text = "Update viewer";
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Location = new System.Drawing.Point(15, 84);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(227, 20);
            this.FilePathTextBox.TabIndex = 8;
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.AutoSize = true;
            this.FilePathLabel.Location = new System.Drawing.Point(12, 68);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(65, 13);
            this.FilePathLabel.TabIndex = 9;
            this.FilePathLabel.Text = "Log file path";
            // 
            // ServerRunningLabel
            // 
            this.ServerRunningLabel.AutoSize = true;
            this.ServerRunningLabel.Location = new System.Drawing.Point(42, 162);
            this.ServerRunningLabel.Name = "ServerRunningLabel";
            this.ServerRunningLabel.Size = new System.Drawing.Size(85, 13);
            this.ServerRunningLabel.TabIndex = 10;
            this.ServerRunningLabel.Text = "Server running...";
            this.ServerRunningLabel.Visible = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(15, 107);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 40);
            this.SaveButton.TabIndex = 11;
            this.SaveButton.Text = "Save Data";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 199);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ServerRunningLabel);
            this.Controls.Add(this.FilePathLabel);
            this.Controls.Add(this.FilePathTextBox);
            this.Controls.Add(this.ConsoleViewLabel);
            this.Controls.Add(this.ConsoleView);
            this.Controls.Add(this.TimeoutTextBox);
            this.Controls.Add(this.TimeoutLabel);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.DebugModeCheckBox);
            this.Controls.Add(this.RunServerButton);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RunServerButton;
        private System.Windows.Forms.CheckBox DebugModeCheckBox;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label TimeoutLabel;
        private System.Windows.Forms.TextBox TimeoutTextBox;
        private System.Windows.Forms.ListView ConsoleView;
        private System.Windows.Forms.Label ConsoleViewLabel;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.Label ServerRunningLabel;
        private System.Windows.Forms.Button SaveButton;
    }
}

