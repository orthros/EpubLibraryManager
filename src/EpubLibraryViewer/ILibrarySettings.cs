using System.IO;

namespace EpubLibraryViewer
{
    public interface ILibrarySettings
    {
        DirectoryInfo LibraryLocation { get; }
    }
}