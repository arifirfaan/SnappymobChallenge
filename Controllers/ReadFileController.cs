using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SnappymobChallengeA.Models;

namespace SnappymobChallengeA.Controllers;

public class ReadFileController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ReadFileController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }


    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            // instead of showing in the console, it will save the upload file in this location
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "UploadedFiles");

            // Check if directory exists
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            string filePath = Path.Combine(uploadPath, file.FileName);

            // Save file to server
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Read file contents
            List<string> fileContents = System.IO.File.ReadAllLines(filePath).ToList();

            foreach (var row in fileContents)
            {
        
                var parts = row.Split(',');

                if (parts.Length == 4)
                {
                    string alphabeticalString = parts[0].Split(':')[1].Trim(); // Extracting after ':'
                    string realNumber = parts[1].Trim();
                    string integer = parts[2].Trim();
                    string alphanumeric = parts[3].Trim(); // Trim spaces before and after

                    Console.WriteLine($"Alphabetical String: {alphabeticalString} ");
                    Console.WriteLine($"Real Number: {realNumber} ");
                    Console.WriteLine($"Integer: {integer} ");
                    Console.WriteLine($"Alphanumeric: {alphanumeric} ");
                    Console.WriteLine("-------------------------");
                }
            }
            

            return View("Index", fileContents);
        }

        return View("Index", new List<string> { "Error: No file uploaded." });
    }

}
