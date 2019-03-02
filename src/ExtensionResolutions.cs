using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Mover
{
    public class ExtensionResolutions
    {
        private Dictionary<string, string> _extensionDirectory;

        public ExtensionResolutions()
        {
            _extensionDirectory = new Dictionary<string, string>();
        }

        public ExtensionResolutions(Dictionary<string, string> extensionDirectory)
        {
            _extensionDirectory = extensionDirectory;
            foreach (string directory in extensionDirectory.Keys)
            {
                Debug.Assert(Directory.Exists(directory));
            }
        }

        public void AddExtension(string extension, string directory)
        {
            Debug.Assert(Directory.Exists(directory));
            _extensionDirectory.Add(extension, directory);
        }

        public string GetDirectory(string extension)
        {
            Debug.Assert(_extensionDirectory.ContainsKey(extension));
            return _extensionDirectory[extension];
        }
    }
}
