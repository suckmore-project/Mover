using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mover
{
    public partial class MainForm : Form
    {
        private FileMover _fileMover;

        public MainForm(FileMover fileMover)
        {
            _fileMover = fileMover;
            InitializeComponent();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string fileName in fileList)
            {
                _fileMover.MoveFile(fileName);
            }
        }
    }
}
