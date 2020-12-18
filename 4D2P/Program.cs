using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _4D2P
{
    class Program
    {
        static void Main(string[] _0)
        {
            string inputPath = "../../input.txt";
            List<string> inputList = File.ReadAllLines(inputPath).ToList();
            int passportNumber = 0;
            int validPassport = 0;
            int invalidPassport = 0;
            int itterator = 1;// indexer for how far into the input list we are starting at 1, because inputList.Lenght starts at 1
            string[] currentKey;
            string[] currentKeyChain;
            Boolean byr = false;
            Boolean iyr = false;
            Boolean eyr = false;
            Boolean hgt = false;
            Boolean hcl = false;
            Boolean ecl = false;
            Boolean pid = false;
            Program myFunctions = new Program();

            foreach (string currentLine in inputList)
            {

                if (currentLine == "")
                {
                    passportNumber += 1;
                    if (byr && iyr && eyr && hgt && hcl && ecl && pid)
                    {
                        validPassport += 1;
                        Console.WriteLine("passport number: {0}, is valid", passportNumber);
                        byr = false;
                        iyr = false;
                        eyr = false;
                        hgt = false;
                        hcl = false;
                        ecl = false;
                        pid = false;
                    }
                    else
                    {
                        invalidPassport += 1;
                        Console.WriteLine("passport number: {0}, is invalid", passportNumber);
                        byr = false;
                        iyr = false;
                        eyr = false;
                        hgt = false;
                        hcl = false;
                        ecl = false;
                        pid = false;
                    }
                }
                else if (itterator == inputList.Count)
                {
                    currentKeyChain = currentLine.Split(' ');
                    foreach (string singleKeynData in currentKeyChain)
                    {
                        currentKey = singleKeynData.Split(':');
                        switch (currentKey[0])
                        {
                            default: myFunctions.KeyEvaluation(currentKey); break;
                            case "byr": byr = myFunctions.KeyEvaluation(currentKey); break;
                            case "iyr": iyr = myFunctions.KeyEvaluation(currentKey); break;
                            case "eyr": eyr = myFunctions.KeyEvaluation(currentKey); break;
                            case "hgt": hgt = myFunctions.KeyEvaluation(currentKey); break;
                            case "hcl": hcl = myFunctions.KeyEvaluation(currentKey); break;
                            case "ecl": ecl = myFunctions.KeyEvaluation(currentKey); break;
                            case "pid": pid = myFunctions.KeyEvaluation(currentKey); break;
                            case "cid": break;
                        }

                    }
                    passportNumber += 1;
                       if (byr && iyr && eyr && hgt && hcl && ecl && pid)
                       {
                           validPassport += 1;
                           Console.WriteLine("passport number: {0}, is valid", passportNumber);
                           byr = false;
                           iyr = false;
                           eyr = false;
                           hgt = false;
                           hcl = false;
                           ecl = false;
                           pid = false;
                       }
                       else
                       {
                           invalidPassport += 1;
                           Console.WriteLine("passport number: {0}, is invalid", passportNumber);
                           byr = false;
                           iyr = false;
                           eyr = false;
                           hgt = false;
                           hcl = false;
                           ecl = false;
                           pid = false;
                       }
                    }
                    else
                    {
                        currentKeyChain = currentLine.Split(' ');
                        foreach (string singleKeynData in currentKeyChain)
                        {
                            currentKey = singleKeynData.Split(':');
                            switch (currentKey[0])
                            {
                                default: myFunctions.KeyEvaluation(currentKey); break;
                                case "byr": byr = myFunctions.KeyEvaluation(currentKey); break;
                                case "iyr": iyr = myFunctions.KeyEvaluation(currentKey); break;
                                case "eyr": eyr = myFunctions.KeyEvaluation(currentKey); break;
                                case "hgt": hgt = myFunctions.KeyEvaluation(currentKey); break;
                                case "hcl": hcl = myFunctions.KeyEvaluation(currentKey); break;
                                case "ecl": ecl = myFunctions.KeyEvaluation(currentKey); break;
                                case "pid": pid = myFunctions.KeyEvaluation(currentKey); break;
                                case "cid": break;
                            }

                        }
                    }
                    itterator += 1;
                }
                Console.WriteLine("the total number of passports is: {0}, The total Valid ones are: {1} and {2} failed.", passportNumber, validPassport, invalidPassport);
            }







            public bool KeyEvaluation(string[] currentEvaluation)
            {
                bool retValue = false;
                switch (currentEvaluation[0])
                {
                    default:
                        {
                            Console.WriteLine(currentEvaluation[0]);
                            Console.WriteLine("unknown input above, hit enter to continue");
                            Console.Read();
                            break;
                        }
                    case "byr":
                        {
                            if (1920 <= Int32.Parse(currentEvaluation[1]) && Int32.Parse(currentEvaluation[1]) <= 2002)
                            {
                                retValue = true;
                            }
                            break;
                        }
                    case "iyr":
                        {
                            if (2010 <= Int32.Parse(currentEvaluation[1]) && Int32.Parse(currentEvaluation[1]) <= 2020)
                            {
                                retValue = true;
                            }
                            break;
                        }
                    case "eyr":
                        {
                            if (2020 <= Int32.Parse(currentEvaluation[1]) && Int32.Parse(currentEvaluation[1]) <= 2030)
                            {
                                retValue = true;
                            }
                            break;
                        }
                    case "hgt":
                        {
                            switch (currentEvaluation[1][^2..])
                            {
                                default: break;
                                case "cm":
                                    {
                                        if (150 <= Int32.Parse(currentEvaluation[1][0..^2]) && Int32.Parse(currentEvaluation[1][0..^2]) <= 193)
                                        {
                                            retValue = true;
                                        }
                                        break;
                                    }
                                case "in":
                                    {
                                        if (59 <= Int32.Parse(currentEvaluation[1][0..^2]) && Int32.Parse(currentEvaluation[1][0..^2]) <= 76)
                                        {
                                            retValue = true;
                                        }
                                        break;
                                    }

                            }
                            break;
                        }
                    case "hcl":
                        {
                            if (currentEvaluation[1].Length == 7 && currentEvaluation[1][0] == '#')
                            {
                                int hclTmpCounter = 0;
                                foreach (char c in currentEvaluation[1][1..])
                                {
                                    switch (c)
                                    {
                                        default: Console.WriteLine(c); break;
                                        case '0': hclTmpCounter += 1; break;
                                        case '1': hclTmpCounter += 1; break;
                                        case '2': hclTmpCounter += 1; break;
                                        case '3': hclTmpCounter += 1; break;
                                        case '4': hclTmpCounter += 1; break;
                                        case '5': hclTmpCounter += 1; break;
                                        case '6': hclTmpCounter += 1; break;
                                        case '7': hclTmpCounter += 1; break;
                                        case '8': hclTmpCounter += 1; break;
                                        case '9': hclTmpCounter += 1; break;
                                        case 'a': hclTmpCounter += 1; break;
                                        case 'b': hclTmpCounter += 1; break;
                                        case 'c': hclTmpCounter += 1; break;
                                        case 'd': hclTmpCounter += 1; break;
                                        case 'e': hclTmpCounter += 1; break;
                                        case 'f': hclTmpCounter += 1; break;
                                    }

                                }
                                if (hclTmpCounter == 6)
                                {
                                    retValue = true;
                                }
                            }

                            break;
                        }
                    case "ecl":
                        {
                            if (currentEvaluation[1].Length == 3)
                            {
                                switch (currentEvaluation[1])
                                {
                                    default: break;
                                    case "amb": retValue = true; break;
                                    case "blu": retValue = true; break;
                                    case "brn": retValue = true; break;
                                    case "gry": retValue = true; break;
                                    case "grn": retValue = true; break;
                                    case "hzl": retValue = true; break;
                                    case "oth": retValue = true; break;
                                }
                            }
                            break;
                        }
                    case "pid":
                        {
                            if (currentEvaluation[1].Length == 9)
                            {
                                int pidTmpCounter = 0;
                                foreach (char c in currentEvaluation[1])
                                {
                                    switch (c)
                                    {
                                        default: break;
                                        case '0': pidTmpCounter += 1; break;
                                        case '1': pidTmpCounter += 1; break;
                                        case '2': pidTmpCounter += 1; break;
                                        case '3': pidTmpCounter += 1; break;
                                        case '4': pidTmpCounter += 1; break;
                                        case '5': pidTmpCounter += 1; break;
                                        case '6': pidTmpCounter += 1; break;
                                        case '7': pidTmpCounter += 1; break;
                                        case '8': pidTmpCounter += 1; break;
                                        case '9': pidTmpCounter += 1; break;
                                    }
                                }
                                if (pidTmpCounter == 9)
                                {
                                    retValue = true;
                                }
                            }
                            break;
                        }
                }
                Console.WriteLine("Key: {0}, Value: {1}, valid: {2}", currentEvaluation[0], currentEvaluation[1], retValue);
                return retValue;
            }

        }

    }

