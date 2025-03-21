//using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using RandomObjectGenerator.Models;
using System.Text;

namespace RandomObjectGenerator.Controllers
{
    public class RandomGeneratorController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RandomGeneratorController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet] 
        public IActionResult GenerateFile()
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "GeneratedFiles", "4random_object.txt");

            // Ensure directory exists
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            RandomFileGenerator.GenerateFile(filePath);

            // Return a file download response this function sometimes working sometimes not because it 10MB is big to downaload
            //byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            //return File(fileBytes, "text/plain", "4random_object.txt");

            // convert stream 
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return File(stream, "text/plain", "4random_object.txt");
        }

    }
}
