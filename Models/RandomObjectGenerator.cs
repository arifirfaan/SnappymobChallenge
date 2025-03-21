using System;
using System.IO;
using System.Text;

namespace RandomObjectGenerator.Models
{
    public static class RandomFileGenerator
    {

    /// <summary>
    /// The controller will call this function to Generate the file content of 4 random object,
    /// it will generate the content until it reach 10MB
    /// </summary>
    /// <param name="filePath"></param>
        public static void GenerateFile(string filePath)
        {
            Random random = new Random();
            int count = 0;
            StringBuilder sb = new StringBuilder();
            long targetSize = 10 * 1024 * 1024; // 10MB in bytes
            long currentSize = 0;

            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                while (currentSize < targetSize)
                {
                    count = count + 1;
                    string randomString = GenerateAlphabeticalString(); // random Alphabetical String
                    double randomRealNumber = random.NextDouble() * 100; // random Real Number
                    int randomInteger = random.Next(1, 1000); // random Integer
                    string randomAlphaNumeric = GenerateAlphanumeric(); // random alphanumberic

                    // Add spaces before and after alphanumeric (max 10 spaces)
                    string spacedAlphanumeric = new string(' ', random.Next(1, 11)) + randomAlphaNumeric + new string(' ', random.Next(1, 11));

                    // Format the output
                    string line = $"{count} : {randomString}, {randomRealNumber:F2}, {randomInteger}, {spacedAlphanumeric}";
                    
                    // Write to file
                    writer.WriteLine(line);
                    currentSize += Encoding.UTF8.GetByteCount(line + Environment.NewLine); // Track file size
                }
            }
        }

    /// <summary>
    /// Function to generate random Alphabetical String between 5 to 15 characters
    /// </summary>
    /// <returns></returns>
        private static string GenerateAlphabeticalString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            int length = random.Next(5, 15);
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

    /// <summary>
    /// this function generate Alphanumeric with 10 spaces before and after
    /// </summary>
    /// <returns></returns>
        private static string GenerateAlphanumeric()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            int length = random.Next(5, 15);
            string alphanumeric = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            int spacesBefore = random.Next(0, 10);
            int spacesAfter = random.Next(0, 10);
            return new string(' ', spacesBefore) + alphanumeric + new string(' ', spacesAfter);
        }
    }
}
