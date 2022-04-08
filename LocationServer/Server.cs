using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationServer
{
    public partial class Server : Form
    {
        
        public Server()
        {
            InitializeComponent();
        }

        private void LocationClientLabel_Click(object sender, EventArgs e)
        {

        }

        private void RunServerButton_Click(object sender, EventArgs e)
        {
            List<string> info = new List<string>();//creating a list to fill with inputs from the text boxes on the ui
            if (PortTextBox.Text != "")
            {
                info.Add("-p");
                info.Add(PortTextBox.Text);
            }
            if (TimeoutTextBox.Text != "")
            {
                info.Add("-t");
                info.Add(TimeoutTextBox.Text);
            }
            if (FilePathTextBox.Text != "")
            {
                info.Add("-l");
                info.Add(FilePathTextBox.Text);
            }
            if (DebugModeCheckBox.Checked)
            {
                info.Add("-d");
            }
            Thread t1 = new Thread(() => Locationserver.locationserver.runServer(info)); //creating a thread for the server ui to run on. this stops the ui being "locked out" after running the server
            t1.Start();
            RunServerButton.Hide();
            ServerRunningLabel.Show();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            FilePathTextBox.Text = "ServerLog.txt";//setting defult log file path
            //Locationserver.locationserver.Load();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Locationserver.locationserver.Save();
        }
    }
}
