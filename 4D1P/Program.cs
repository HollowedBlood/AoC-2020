using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _4D1P
{
    class Program
    {
        static void Main(string[] _0)
        {
            string inputPath = "../../input.txt";
            List<string> inputList = File.ReadAllLines(inputPath).ToList();
            int passportNumber = 1; // first passport
            int validPassport = 0;
            int invalidPassport = 0;
            int validCheatedPassport = 0;
            int itterator = 1;// indexer for how far into the input list we are starting at 1, because inputList.Lenght starts at 1
            string[] currentKey;
            string[] currentKeyChain;
            bool valid = false;
            int knownFields = 0;
            bool cid = false;


            foreach (string currentLine in inputList)
            {
                if (currentLine == "")
                {

                    Console.WriteLine("passport #{0}, Known fields: {1}", passportNumber, knownFields);
                    if (knownFields == 8 || knownFields == 7 & !cid)
                    {
                        valid = true;
                    }
                    if (valid)
                    {
                        validPassport += 1;
                        Console.WriteLine("passport number: {0}, is valid, CID: {1}", passportNumber, cid);
                    }
                    else
                    {
                        invalidPassport += 1;
                        Console.WriteLine("passport number: {0}, is invalid, CID: {1}", passportNumber, cid);
                    }
                    valid = false;
                    cid = false;
                    knownFields = 0;
                    passportNumber += 1;
                }
                else if(itterator == inputList.Count)
                {
                    currentKeyChain = currentLine.Split(' ');
                    foreach (string currentEvaluation in currentKeyChain)
                    {
                        knownFields += 1;
                        currentKey = currentEvaluation.Split(':');
                        Console.WriteLine("{0}:{1}", currentKey[0], currentKey[1]);
                        if (currentKey[0] == "cid")
                        {
                            cid = true;
                        }

                    }

                    Console.WriteLine("passport #{0}, Known fields: {1}", passportNumber, knownFields);
                    if (knownFields == 8 || knownFields == 7 & !cid)
                    {
                        valid = true;
                    }
                    if (valid)
                    {
                        validPassport += 1;
                        Console.WriteLine("passport number: {0}, is valid, CID: {1}", passportNumber, cid);
                    }
                    else
                    {
                        invalidPassport += 1;
                        Console.WriteLine("passport number: {0}, is invalid, CID: {1}", passportNumber, cid);
                    }
                    valid = false;
                    cid = false;
                    knownFields = 0;
                    passportNumber += 1;
                } else
                {
                    currentKeyChain = currentLine.Split(' ');
                    foreach (string currentEvaluation in currentKeyChain)
                    {
                        knownFields += 1;
                        currentKey = currentEvaluation.Split(':');
                        Console.WriteLine("{0}:{1}", currentKey[0], currentKey[1]);
                        if (currentKey[0] == "cid")
                        {
                            cid = true;
                        }

                    }
                }
                itterator += 1;
            }

            Console.WriteLine("the total number of passports is: {0}, The total Valid ones are: {1}, of which: {2} is cheated.  and {3} failed.", passportNumber, validPassport, validCheatedPassport, invalidPassport);

        }

    }

}
