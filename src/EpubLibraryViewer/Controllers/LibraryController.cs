using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Concurrent;
using VersFx.Formats.Text.Epub;

namespace EpubLibraryViewer.Controllers
{
    public class LibraryController : Controller
    {
        public ILibrarySettings LibrarySettings { get; private set; }

        public LibraryController(ILibrarySettings settings)
        {
            LibrarySettings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<IActionResult> Index()
        {
            var concurrentBooks = new ConcurrentBag<EpubBookRef>();

            foreach (var libraryFile in LibrarySettings.LibraryLocation.EnumerateFiles("*.epub", SearchOption.TopDirectoryOnly))
            {
                var book = await EpubReader.OpenBookAsync(libraryFile.FullName);         
                
                concurrentBooks.Add(book);
            }
                             
            var books = concurrentBooks.ToList();

            return View(books);
        }
    }
}