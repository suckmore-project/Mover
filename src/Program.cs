using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Mover
{
    static class Program
    {
        const string CONFIG_FILENAME = "config.conf";
        const string PAIRS_FILENAME = "pairs.conf";

        [STAThread]
        static void Main()
        {
            //load up configuration
            Dictionary<string, string> config = new Dictionary<string, string>();
            foreach (string ln in File.ReadAllLines(CONFIG_FILENAME))
            {
                string[] parts = ln.Split('|');
                config[parts[0]] = parts[1];
            }

            //load up file extension pairings
            ExtensionResolutions extensionResolutions = new ExtensionResolutions();
            foreach (string ln in File.ReadLines(PAIRS_FILENAME))
            {
                string[] parts = ln.Split('|');
                extensionResolutions.AddExtension(parts[0], parts[1]);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FileMover fm = new FileMover(extensionResolutions);
            MainForm mf = new MainForm(fm);

            //set the form background
            mf.BackgroundImage = Image.FromFile(config["bg"]);
            mf.ClientSize = new Size(mf.BackgroundImage.Width, mf.BackgroundImage.Height);

            //check whether the user passed the file names as command line arguments
            //i.e. dropped them on the executable
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                foreach (string fileName in args.Skip(1))
                    fm.MoveFile(fileName);
                Environment.Exit(0);
            }

            Application.Run(mf);
        }
    }
}
