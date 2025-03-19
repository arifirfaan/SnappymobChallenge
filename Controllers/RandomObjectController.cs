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

        public IActionResult GenerateFile()
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "GeneratedFiles", "4random_object.txt");

            // Ensure directory exists
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Generate file content
            // string fileContent = "Random Data: " + new System.Random().Next(1, 1000);
            // System.IO.File.WriteAllText(filePath, fileContent, Encoding.UTF8);

            // // Return file as a downloadable response
            // var fileBytes = System.IO.File.ReadAllBytes(filePath);
            // return File(fileBytes, "text/plain", "random_data.txt");
            // Generate file
            RandomFileGenerator.GenerateFile(filePath);

            // Return a file download response
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "text/plain", "4random_object.txt");
        }
    }
}
