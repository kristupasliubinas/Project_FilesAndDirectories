using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Project_FilesAndDirectories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rootDirectory = $"C:{Path.DirectorySeparatorChar}Users{Path.DirectorySeparatorChar}KLiubinas{Path.DirectorySeparatorChar}source{Path.DirectorySeparatorChar}repos{Path.DirectorySeparatorChar}Project_FilesAndDirectories{Path.DirectorySeparatorChar}Project_FilesAndDirectories{Path.DirectorySeparatorChar}CharityMatch{Path.DirectorySeparatorChar}";
            var participantsDirectory = Path.Combine(rootDirectory, "Participants");


            // Create a new directory for the output file
            Directory.CreateDirectory(Path.Combine(rootDirectory, "MatchLineUp"));


            // Read each participant and write to the output file
            var nomineeFiles = FindNomineeFiles(participantsDirectory);

            CreateFinalLineUp(nomineeFiles);
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

        static void CreateFinalLineUp(IEnumerable<string> nomineeFiles) 
        {
            var playerNumber = 1;
            var teamNumber = 1;
            
            foreach (var file in nomineeFiles) 
            {
                if (playerNumber == 1 || playerNumber == 21)
                {
                    if (playerNumber == 21) Console.WriteLine("\n");
                    Console.WriteLine($"**TEAM {teamNumber}**\n");
                    Console.WriteLine("Starters:\n" + "-------------------");
                    parsePlayer(file);
                    playerNumber++;
                }
                else if (playerNumber == 12 || playerNumber == 32)
                {
                    Console.WriteLine("\n" + "Reserves:" + "\n" + "-------------------");
                    parsePlayer(file);
                    playerNumber++;
                    teamNumber++;
                }
                else 
                {
                    parsePlayer(file);
                    playerNumber++;
                }

            }
        }

        static void parsePlayer(string file) 
        {
            // Read
            var nomineeJson = File.ReadAllText(file);
            // Parse
            var nomineeData = JsonConvert.DeserializeObject<Player>(nomineeJson);
            // Print
            Console.WriteLine($"{nomineeData.Forename} {nomineeData.Surname}");
        }
    }

    class Player 
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
    }
}
