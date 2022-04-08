using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
class Program
{
    public static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        if (args.Length == 0)  //if without arguments, run wih UI
        {
            Thread t2 = new Thread(() => Application.Run(new Location.Client()));
            t2.Start();
        }
        else //run without UI using the given arguments
        {
            Location.location.runClient(args);
        }


    }
}

