using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _1D1P
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"E:\Libraries\Documents\GitHub\AoC-2020\2D1P\input.txt";
            List<string> inputList = new List<string>();
            inputList = File.ReadAllLines(inputPath).ToList();
            int currentLine = 1; //just tracking what line the answers are on for final result
            int totalValidPasswords = 0; //final answer variable
            int totalFailedPasswords = 0; //final curiosity variable 
            int substringEndOfNu; //index where the last number for the rule is used
            int substringEndOfCh; //index where the required character is defined
            int[] ruleLocations; //integerarray used for calculations regarding if a string has the correct number of 
            char requiredChar; //character required in the input password
            string inputPassword; //the substring of the input line that only contains a password

            foreach (string currentPassword in inputList)
            {
                substringEndOfNu = currentPassword.IndexOf(" ");
                ruleLocations = Array.ConvertAll(currentPassword.Substring(0, substringEndOfNu).Split("-"), int.Parse);
                requiredChar = char.Parse(currentPassword.Substring(substringEndOfNu+1, 1));//+1 to ignore space
                substringEndOfCh = substringEndOfNu + 4;//+4 to skip the standardized gap of space-char-colon-space (more advenced computational method needed for less standardized inputs)
                inputPassword = currentPassword[substringEndOfCh..];
                if (inputPassword.Length >= ruleLocations[1]) // missed wanted to ensure that the code would run if the given numbers were out of bounds in reference to the input password
                {
                    if (requiredChar == inputPassword[ruleLocations[0] - 1] & requiredChar != inputPassword[ruleLocations[1] - 1] || requiredChar == inputPassword[ruleLocations[1] - 1] & requiredChar != inputPassword[ruleLocations[0] - 1])  // reaaaly hope there is a shorter way of doing an XOR opperator
                    {

                        Console.WriteLine("TRUE: this password passed the test, input: {0}, at line {1}", currentPassword, currentLine);
                        totalValidPasswords += 1;
                    }
                    else
                    {

                        Console.WriteLine("FALSE: this password failed the test, input: {0}, at line {1}", currentPassword, currentLine);
                        totalFailedPasswords += 1;
                    }
                    Console.WriteLine("length of input PW: {0}, Second index call: {1}, Inbounds", inputPassword.Length, ruleLocations[1]);
                } else
                {
                    Console.WriteLine("Outbounds FALSE: this password failed the test, input: {0}, at line {1}, length of input PW: {2}, Second index call: {3}, Outbounds Outbounds", currentPassword, currentLine, inputPassword.Length, ruleLocations[1]);
                }
             currentLine += 1;
            }
            Console.WriteLine("The total number of, correct passwords is: {0}, incorrect ones is: {1}", totalValidPasswords, totalFailedPasswords);
            Console.ReadLine(); // just here to freeze the output
        }
    }
}
