using System;
using System.IO;
using System.Text;

namespace RandomObjectGenerator.Models
{
    public static class RandomFileGenerator
    {
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
                    string randomString = GenerateAlphabeticalString();
                    double randomRealNumber = random.NextDouble() * 100;
                    int randomInteger = random.Next(1, 1000);
                    string randomAlphaNumeric = GenerateAlphanumeric();

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

        private static string GenerateRandomObject()
        {
            Random random = new Random();
            int type = random.Next(4);

            return type switch
            {
                0 => GenerateAlphabeticalString(),
                1 => GenerateRealNumber(),
                2 => GenerateInteger(),
                3 => GenerateAlphanumeric(),
                _ => "Unknown"
            };
        }

        private static string GenerateAlphabeticalString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            int length = random.Next(5, 15);
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string GenerateRealNumber()
        {
            Random random = new Random();
            return (random.NextDouble() * 100).ToString("F2");
        }

        private static string GenerateInteger()
        {
            Random random = new Random();
            return random.Next(1, 1000).ToString();
        }

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
