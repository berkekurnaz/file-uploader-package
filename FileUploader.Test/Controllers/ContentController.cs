using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FileUploader.Test.Controllers
{
    public class ContentController : Controller
    {

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Developers()
        {
            return View();
        }

    }
}