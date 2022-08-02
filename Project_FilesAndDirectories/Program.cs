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
            var nomineeFiles = FindNomineeFiles(participantsDirectory);

            var finalLineUpDirectory = Path.Combine(rootDirectory, "MatchLineUp");
            Directory.CreateDirectory(finalLineUpDirectory);
            var finalLineUpFile = Path.Combine(finalLineUpDirectory, "finalMatchLineUp.txt");

            CreateFinalLineUp(nomineeFiles, finalLineUpFile);
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

        static void CreateFinalLineUp(IEnumerable<string> nomineeFiles, string finalLineUpFile) 
        {
            var playerNumber = 1;
            var teamNumber = 1;
            
            foreach (var nomineeFile in nomineeFiles) 
            {
                if (playerNumber == 1 || playerNumber == 21)
                {
                    if (playerNumber == 21) File.AppendAllText(finalLineUpFile, "\n\n");
                    File.AppendAllText(finalLineUpFile, $"**TEAM {teamNumber}**\n");
                    File.AppendAllText(finalLineUpFile, "\nStarters:\n" + "-------------------\n");
                    parsePlayer(nomineeFile, finalLineUpFile);
                    playerNumber++;
                }
                else if (playerNumber == 12 || playerNumber == 32)
                {
                    File.AppendAllText(finalLineUpFile, "\n" + "Reserves:" + "\n" + "-------------------" + "\n");
                    parsePlayer(nomineeFile, finalLineUpFile);
                    playerNumber++;
                    teamNumber++;
                }
                else 
                {
                    parsePlayer(nomineeFile, finalLineUpFile);
                    playerNumber++;
                }

            }
        }

        static void parsePlayer(string nomineeFile, string finalLineUpFile) 
        {
            // Read
            var nomineeJson = File.ReadAllText(nomineeFile);
            // Parse
            var nomineeData = JsonConvert.DeserializeObject<Player>(nomineeJson);
            // Write to file
            File.AppendAllText(finalLineUpFile, $"{nomineeData.Forename} {nomineeData.Surname}\n");
        }
    }

    class Player 
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
    }
}
