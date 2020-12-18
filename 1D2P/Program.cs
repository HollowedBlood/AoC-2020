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
            int itterationThree = 0;
            foreach (string valueOne in inputList)
            {
                foreach (string valueTwo in inputList.Skip(itterationOne)) // added skip to avoid repeatedly checking invalid combinations
                {
                    foreach (string valueThree in inputList.Skip(itterationOne + itterationTwo))
                    {
                        int cOne = Int32.Parse(valueOne);
                        int cTwo = Int32.Parse(valueTwo);
                        int cThree = Int32.Parse(valueThree);
                        if (cOne + cTwo + cThree == 2020)
                        {
                            string oneDtwoPAnswer;
                            oneDtwoPAnswer = string.Format("Line: {0}, Value: {1}, Line: {2}, Value: {3}, and Line: {4}, Value: {5}.  Final Answer: {6}.", itterationOne, cOne, itterationOne + itterationTwo, cTwo, itterationOne + itterationTwo + itterationThree, cThree, cOne * cTwo * cThree);
                            Console.WriteLine(oneDtwoPAnswer);
                        }
                        itterationThree += 1;
                    }
                    itterationTwo += 1;
                    itterationThree = 0;
                }
                itterationOne += 1;
                itterationTwo = 0;
            }

            Console.ReadLine(); // just here to freeze the output
        }
    }
}
