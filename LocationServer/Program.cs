using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationServer
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 0)     
            {
                if (args[0] == "-w") //whether to run with UI 
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Server());
                }
                else//invalid arguments and runs without UI
                {
                    Console.WriteLine("Unrecognised argument. Starting with default settings");
                    List<string> blank = new List<string>();
                    Locationserver.locationserver.runServer(blank);
                }
            }
            else//run without UI
            {
                List<string> blank = new List<string>();
                Locationserver.locationserver.runServer(blank);
            }
        }
    }
}
