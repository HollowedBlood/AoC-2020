using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _3D2P
{
    class Program
    {
        static void Main(string[] _0)
        {
            string inputPath = @"E:\Libraries\Documents\GitHub\AoC-2020\3D2P\input.txt";
            List<string> inputList = File.ReadAllLines(inputPath).ToList();
            char toboggan = 'T';
            char collide = 'C';
            char tree = '#';
            ulong finalAnswer = 1; //this value (1) is the coeficient of the first slope results.
            int tobogganX = 0; //indexing based on string index, starts on index 0
            int tobogganY = 1; //indexing based on line number, starts on line 1
            int lineNumber = 1; //indexing based on line number, starts on line 1
            int slopeNumber = 0;
            int[][] slopes = new int[][]
            {
//              new int[] {slopeX, slopeY}
                new int[] {1, 1},
                new int[] {3, 1},
                new int[] {5, 1},
                new int[] {7, 1},
                new int[] {1, 2},

            };
            int[] collisions = new int[slopes.Length];
            StringBuilder mountainLayer = new StringBuilder();
            foreach (int[] currentSlope in slopes)
            {
                foreach (string inputLine in inputList)
                {
                    mountainLayer.Append(inputLine);
                    if (mountainLayer.Length - 1 < tobogganX & tobogganX != 0) //-1 to shift the length to the final index
                    {
                        tobogganX -= mountainLayer.Length;
                    }
                    if (lineNumber == tobogganY)
                    {
                        if (mountainLayer[tobogganX] == tree)
                        {
                            mountainLayer[tobogganX] = collide;
                            collisions[slopeNumber] += 1;
                        }
                        else
                        {
                            mountainLayer[tobogganX] = toboggan;
                        }
                        tobogganX += currentSlope[0];
                        tobogganY += currentSlope[1];
                    }
                    //Console.WriteLine(mountainLayer);
                    lineNumber += 1;
                    mountainLayer.Clear();
                }
                Console.WriteLine("Collisions: {0}, slope #{1}, current slope: {2}x, {3}y", collisions[slopeNumber], slopeNumber, currentSlope[0], currentSlope[1]);
                tobogganX = 0;
                tobogganY = 1;
                lineNumber = 1;
                slopeNumber += 1;
            }
            foreach (ulong value in collisions)
            {
                finalAnswer = finalAnswer * value;
            }
            
            Console.WriteLine("The Product is: {0}", finalAnswer);
        }
    }
}
