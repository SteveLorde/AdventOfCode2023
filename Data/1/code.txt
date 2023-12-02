
using System;
using main;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;


namespace main
{
    public class Solution
    {
        public List<int> AllDigits = new List<int>();
        public string datafilepath = "D:\\Apps\\Coding\\Main\\Data\\1\\data.txt";
        public int solutionresult = 0;
        string pattern = @"(?:on?e|tw?o|thre?e|fou?r|fiv?e|si?x|seve?n|eigh?t|nin?e)|\d";
        Dictionary<string, string> wordToDigitMapping = new Dictionary<string,string>
        {
            {"one", "o1e"},
            {"two", "t2o"},
            {"three", "t3e"},
            {"four", "f4r"},
            {"five", "f5e"},
            {"six", "s6x"},
            {"seven", "s7n"},
            {"eight", "e8t"},
            {"nine", "n9e"},
        };
        
        public void readandcalculate()
        {
            
            List<string> temporaryarray = new List<string>();
            StreamReader datareader = new StreamReader(datafilepath);
            string content = datareader.ReadToEnd();
            //split datacontent based on line
            string[] lines = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var modifiedlinetest = line.ToLower().Replace("one", "o1e")
                    .Replace("two", "t2o")
                    .Replace("three", "t3e")
                    .Replace("four", "f4r")
                    .Replace("five", "f5e")
                    .Replace("six", "s6x")
                    .Replace("seven", "s7n")
                    .Replace("eight", "e8t")
                    .Replace("nine", "n9e");
                
                /*
                string modifiedline = Regex.Replace(line, pattern, match => {
                if (wordToDigitMapping.TryGetValue(match.Value.ToLower(), out var replacement))
                {
                    return replacement;
                }
                return match.Value;
                
            },RegexOptions.IgnoreCase);
                
                Console.WriteLine(modifiedline);
                */
                
                for (int i = 0; i < modifiedlinetest.Length; i++ )
                {
                    var character = modifiedlinetest[i];
                    if (char.IsDigit(character))
                    {
                        var stringedcharacter = character.ToString();
                        temporaryarray.Add(stringedcharacter);
                    }
                }
                
                /*
                foreach (Match match in matches)
                {
                    Console.WriteLine("Line: " + line + " Match: " + match.Value);
                    temporaryarray.Add(match.Value);
                }
                */
                
                string string1 = temporaryarray.First();
                string string2 = temporaryarray.Last();
                string combinedstring = string.Concat(string1, string2);
                int digitresult = int.Parse(combinedstring);
                AllDigits.Add(digitresult);
                temporaryarray.Clear();
            }
            Console.Write("Found Digits are: ");
            for (int z = 0; z < AllDigits.Count; z++)
            {
                Console.Write(AllDigits[z] + ",");
                solutionresult += AllDigits[z];
            }
            Console.WriteLine();
            Console.WriteLine("Result is: " + solutionresult);
            
            }
        }
    }

class Program
{
    static void Main()
    {
        Solution dosolution = new Solution();
        dosolution.readandcalculate();
    }
    
}


/*

*/