using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EpubLibraryViewer.Controllers
{
    public class HomeController : Controller
    {
        public IAppInfoSettings AppInfo { get; private set; }

        public HomeController(IAppInfoSettings appInfo)
        {
            this.AppInfo = appInfo ?? throw new ArgumentNullException(nameof(appInfo));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = AppInfo.AboutMessage;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            ViewData["ContactInfo"] = AppInfo.ContactEmail;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
