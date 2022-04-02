using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;

namespace CoreMvcCkFinder.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile upload)
        {
            if (upload.Length <= 0) return null;

            var fileName = upload.FileName;
            var path = Path.Combine($"{Directory.GetCurrentDirectory()}\\Assets\\Images", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);
            }

            var url = $"/Assets/Images/{fileName}";
            return Json(new { uploaded = true, url });
        }
    }
}
