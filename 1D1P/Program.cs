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
            string inputPath = "../../input.txt";
            //string[] inputArray = File.ReadAllLines(inputPath);
            List<string> inputList = new List<string>();
            inputList = File.ReadAllLines(inputPath).ToList();
            int itterationOne = 0;
            int itterationTwo = 0;
            foreach (String valueOne in inputList)
            {
                foreach (string valueTwo in inputList)
                {
                    int cOne = Int32.Parse(valueOne);
                    int cTwo = Int32.Parse(valueTwo);
                    if (itterationOne < itterationTwo && cOne + cTwo == 2020)
                    {
                        string oneDonePAnswer;
                        oneDonePAnswer = string.Format("Line: {0}, Value: {1}, and Line: {2}, Value: {3}.  Final Answer: {4}.", itterationOne, cOne, itterationTwo, cTwo, cOne*cTwo);
                        Console.WriteLine(oneDonePAnswer);
                    }


                    itterationTwo += 1;
                }
                itterationOne += 1;
            }

            Console.ReadLine();
        }
    }
}
