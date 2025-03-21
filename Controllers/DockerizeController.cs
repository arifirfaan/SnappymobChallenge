using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;

namespace SnappymobChallengeA.Controllers
{
    public class DockerizeController : Controller
    {
        private readonly string _inputFilePath = "/app/input/random_data.txt";  // Read input
        private readonly string _outputFilePath = "/app/output/processed_data.txt"; // Save output

        public IActionResult Index()
        {
            List<string> fileContents = new List<string>();

            if (System.IO.File.Exists(_inputFilePath))
            {
                fileContents = new List<string>(System.IO.File.ReadAllLines(_inputFilePath));

                // Process & save output
                List<string> processedLines = new List<string>();
                foreach (var line in fileContents)
                {
                    string processed = ProcessLine(line);
                    processedLines.Add(processed);
                }

                // Write processed output
                System.IO.File.WriteAllLines(_outputFilePath, processedLines);
            }
            else
            {
                fileContents.Add("Error: Input file not found.");
            }

            return View("Index", fileContents);
        }

        private string ProcessLine(string line)
        {
            return line.Trim(); // Example: Strip spaces
        }
    }
}
