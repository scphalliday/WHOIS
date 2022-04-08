using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Location
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HTTPtypeComboBox.Text = "Select Protocol";
            ConsoleList.Items.Add("Default Protocol: WHOIS");
            ConsoleList.Items.Add("Default Host: whois.net.dcs.hull.ac.uk");        //loading initial text to the viewer
            ConsoleList.Items.Add("Default Port: 43");
            ConsoleList.Items.Add("Default Timeout: 3000 (3 seconds)");
            ConsoleList.Items.Add("For debug, info shown in console window");
        }

        private void SendRequestButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> info = new List<string>();     //creating a list to add the contents of the text boxes within the UI
                info.Add(UsernameTextBox.Text);
                if (textBox1.Text != "")//location**. design naming error
                {
                    info.Add(textBox1.Text);
                }
                if (HostTextBox.Text != "")
                {
                    info.Add("-h");
                    info.Add(HostTextBox.Text);
                }
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
                if (HTTPtypeComboBox.SelectedText != "Select Protocol")
                {
                    if (HTTPtypeComboBox.Text == "HTTP 0.9")
                    {
                        info.Add("-h9");
                    }
                    else if (HTTPtypeComboBox.Text == "HTTP 1.0")
                    {
                        info.Add("-h0");
                    }
                    else if (HTTPtypeComboBox.Text == "HTTP 1.1")
                    {
                        info.Add("-h1");
                    }
                }
                if (DebugCheckBox.Checked)
                {
                    info.Add("-d");
                }
                string[] args = new string[info.Count];     //creating an array to copy the contents of the list
                for (int i = 0; i < info.Count; i++)
                {
                    args[i] = info[i];
                }
                location loc = new location();
                location.runClient(args);        //running the client with the arugments given by the UI
                ConsoleList.Items.Add(location.output);//printing the output to the UI from the client
                loc = null;//nullifying the client before the next iteration to avoid any issues with duplication 
                info = null;
            }
            catch { }
        }

        private void ConsoleView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearViewerButton_Click(object sender, EventArgs e)
        {
            ConsoleList.Items.Clear();//clear list when button is pressed
        }
    }
}
