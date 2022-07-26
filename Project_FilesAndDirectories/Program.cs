using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_FilesAndDirectories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get participants

            // Create a new directory for the final file

            // Write final line-up in a txt file


            var currentDircotry = $"C:{Path.DirectorySeparatorChar}Users{Path.DirectorySeparatorChar}KLiubinas{Path.DirectorySeparatorChar}source{Path.DirectorySeparatorChar}repos{Path.DirectorySeparatorChar}Project_FilesAndDirectories{Path.DirectorySeparatorChar}Project_FilesAndDirectories{Path.DirectorySeparatorChar}CharityMatch{Path.DirectorySeparatorChar}Participants";

            var nomineeFiles = FindNomineeFiles(currentDircotry);

        }

        static IEnumerable<string> FindNomineeFiles(string directory)
        {
            var nomineeFiles = new List<string>();

            var allFoundFiles = Directory.EnumerateFiles(directory, "*" ,SearchOption.AllDirectories);

            foreach (var file in allFoundFiles) 
            {
                var extension = Path.GetExtension(file);
                if (extension == ".json")
                    nomineeFiles.Add(file);
            }

            return nomineeFiles;
        }
    }
}
