﻿
using System;
using main;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using main.Model;


namespace main
{
    public class Solution
    {
        //path to data txt
        public string datafilepath = "D:\\Apps\\Coding\\AdventOfCode2023\\Data\\2\\data.txt";
        
        public List<Game> AllGames = new List<Game>();

        public static Game CreateGame(string line)
        {
            //1-read line and find gameid + subgames
            string[] lineparts = line.Split(':');
            int gameId = int.Parse(lineparts[0].Trim().Split(' ')[1]);
            string subgamesString = lineparts[1].Trim();

            SubGame subgames = ParseSubgames(subgamesString);
            
            //2-create new game object based on line
            Game game = new Game();
            game.Id = gameId;
            game.subgame = subgames;

            //3-return game
            return game;
        }

        static SubGame ParseSubgames(string subgamesString)
        {
            SubGame subgame = new SubGame();
            List<Color> allcolors = new List<Color>();
            string[] subgameStrings = subgamesString.Split(';');

            foreach (var subgameString in subgameStrings)
            {
                Color color = ParseSubgame(subgameString);
                allcolors.Add(color);
            }

            subgame.colorcount = allcolors;

            return subgame;
        }

        static Color ParseSubgame(string subgameString)
        {
            Color newcolorcount = new Color();
            string[] parts = subgameString.Split(',');
            
            for (int i = 0; i < parts.Length; i++)
            {
                string[] colorCountParts = parts[i].Trim().Split(' ');
                newcolorcount.color = colorCountParts[1];
                newcolorcount.count = int.Parse(colorCountParts[0]);
            }
            return newcolorcount;
        }

        static void CheckDataReading(List<Game> Games)
        {
            Console.WriteLine("Data Result");
            Console.WriteLine("____________");
            for (int i = 0; i < Games.Count; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Game: " + Games[i].Id + " SubGames: ");
                for (int subgamescount = 0; subgamescount < Games[i].subgames.Count; subgamescount++)
                    Console.Write(Games[i].subgames[subgamescount].count + " " + Games[i].subgames[subgamescount].color + " , " );
            }
            Console.WriteLine("");
            Console.WriteLine("Done Parsing and Reading Data Data");
        }
        
        

        
        public int solutionresult = 0;
        string searchpattern = " ";
        
        Dictionary<string, string> wordToDigitMapping = new Dictionary<string,string>
        {
        };
        
        public void dosolution()
        {
            
            List<string> temporaryarray = new List<string>();
            StreamReader datareader = new StreamReader(datafilepath);
            string content = datareader.ReadToEnd();
            //split datacontent based on line
            string[] lines = content.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var line in lines)
            {
                AllGames.Add(CreateGame(line));
            }
            
            CheckDataReading(AllGames);
            
        }
    }
    

    
    class Program
    {
        static void Main()
        {
            Solution solution = new Solution();
            solution.dosolution();
        }
    }
}


/*

*/