using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _3D1P
{
    class Program
    {
        static void Main(string[] _0)
        {
            string inputPath = "../../input.txt";
            List<string> inputList = File.ReadAllLines(inputPath).ToList();
            char toboggan = 'T';
            char collide = 'C';
            char tree = '#';
            int collisions = 0;
            int tobogganX = 0;
            int tobogganY = 0;
            StringBuilder mountainLayer = new StringBuilder();
            foreach (string inputLine in inputList)
            {
                mountainLayer.Append(inputLine);
                if (mountainLayer.Length -1 < tobogganX & tobogganX != 0) //-1 to shift the length into final index value
                {
                    tobogganX -= mountainLayer.Length;
                }

                if (mountainLayer[tobogganX] == tree)
                {
                    mountainLayer[tobogganX] = collide;
                    collisions += 1;
                }
                else
                {
                    mountainLayer[tobogganX] = toboggan;
                }
                tobogganX += 3;
                tobogganY += 1;
                Console.WriteLine(mountainLayer);
                mountainLayer.Clear();
            }
            Console.WriteLine("Collisions: {0}", collisions);
        }
    }
}
