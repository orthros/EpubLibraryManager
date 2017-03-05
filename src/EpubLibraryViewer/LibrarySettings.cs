using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EpubLibraryViewer
{
    public class LibrarySettings : ILibrarySettings
    {
        public DirectoryInfo LibraryLocation { get; private set; }

        public LibrarySettings(string libraryLocation)
        {
            if (string.IsNullOrWhiteSpace(libraryLocation))
            {
                throw new ArgumentNullException(nameof(libraryLocation));
            }

            if (!Directory.Exists(libraryLocation))
            {
                throw new ArgumentException($"The path {libraryLocation} does not exist");
            }

            LibraryLocation = new DirectoryInfo(libraryLocation);
        }
    }
}
