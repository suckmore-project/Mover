using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mover
{
    public class FileMover
    {
        private ExtensionResolutions _extensionResolutions;

        public FileMover(ExtensionResolutions extensionResolutions)
        {
            this._extensionResolutions = extensionResolutions;
        }

        public void MoveFile(string fileName)
        {
            string extension = System.IO.Path.GetExtension(fileName);
            string directory = _extensionResolutions.GetDirectory(extension);
            string finalDestination = System.IO.Path.Combine(directory, 
                System.IO.Path.GetFileName(fileName));
            System.IO.File.Move(fileName, finalDestination);
        }
    }
}
