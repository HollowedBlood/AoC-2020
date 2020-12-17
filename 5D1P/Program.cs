using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _5D1P
{
    class Program
    {
        static void Main(string[] _0)
        {
            string inputPath = "../../input.txt";
            List<string> inputList = File.ReadAllLines(inputPath).ToList();
            int charPosition = 0;
            int currentIndexofList = 0;
            string[] visualization = new string[127];
            StringBuilder currentEditRow = new StringBuilder("", 8);
            char occupied = 'O';
            int currentSeatRow;
            int currentSeatColumn;
            int currentSeatID;
            int[] currentPossibleRows = { 0, 127 };
            int[] currentPossibleColumns = { 0, 7 };
            int[] allTakenIDs = new int[inputList.Count];
            int highestValue = 0;
            for (int i = 0; i < 127; i++)
            {
                visualization[i] = "XXXXXXXX";
            }
            foreach (string currentLine in inputList)
            {
                foreach (char currentChar in currentLine)
                {
                    if (charPosition < 7)
                    {
                        switch (currentChar)
                        {
                            default: Console.WriteLine("how did you even get here"); break;
                            case 'F':
                                {
                                    currentPossibleRows[1] = currentPossibleRows.Sum() / 2;
                                    break;
                                }
                            case 'B':
                                {
                                    currentPossibleRows[0] = (currentPossibleRows.Sum() / 2) + 1;
                                    break;
                                }
                        }
                       //Console.WriteLine("{0}:{1}", currentChar, charPosition);
                       //Console.WriteLine("{0}~{1}", currentPossibleRows[0], currentPossibleRows[1]);
                    }
                    else
                    {
                        switch (currentChar)
                        {
                            default: Console.WriteLine("how did you even get here PART TWO"); break;
                            case 'L':
                                {
                                    currentPossibleColumns[1] = currentPossibleColumns.Sum() / 2;
                                    break;
                                }
                            case 'R':
                                {
                                    currentPossibleColumns[0] = (currentPossibleColumns.Sum() / 2) + 1;
                                    break;
                                }
                        }
                        //Console.WriteLine("{0}:{1}", currentChar, charPosition);
                        //Console.WriteLine("{0}~{1}", currentPossibleColumns[0], currentPossibleColumns[1]);
                    }
                    charPosition += 1;
                }
                currentSeatRow = currentPossibleRows[0];
                currentSeatColumn = currentPossibleColumns[0];
                currentSeatID = currentPossibleRows[0] * 8 + currentPossibleColumns[1];
                allTakenIDs[currentIndexofList] = currentSeatID;

                currentEditRow.Append(visualization[currentSeatRow]);
                currentEditRow.Remove(currentSeatColumn,1);
                currentEditRow.Insert(currentSeatColumn, occupied);
                visualization[currentSeatRow] = currentEditRow.ToString();
                currentEditRow.Clear();


                if (currentSeatID > highestValue)
                {
                    highestValue = currentSeatID;
                }
                //Console.WriteLine("Row: {0}, Column: {1}, ID: {2}", currentSeat[0], currentSeat[1], currentSeat[2]);
                currentPossibleRows[0] = 0;
                currentPossibleColumns[0] = 0;
                currentPossibleRows[1] = 127;
                currentPossibleColumns[1] = 7;
                currentIndexofList += 1;
                charPosition = 0;
            }
            int itterator = 1;
            foreach (int currentID in allTakenIDs)
            {
                foreach (int testingMatch in allTakenIDs.Skip(itterator))
                {
                    if (Math.Abs(currentID - testingMatch) == 2)
                    {
                        //Console.WriteLine("2 is the difference between {0} and {1}", currentID, testingMatch);
                    }
                }
                itterator += 1;
            }
            //Console.WriteLine(highestValue);
            int rowCount = 0;
            int myColumn = 0;
            int myRow = 0;
            int myID;
            foreach (string row in visualization)
            {
                Console.WriteLine(row);
                if (row.Where(c => c == 'X').Count() == 1)
                {
                    myRow = rowCount;
                    myColumn = row.IndexOf("X");
                }
                rowCount ++;
            }
            myID = myRow * 8 + myColumn;
            Console.WriteLine("My seat is at Row: {0}, Column: {1}, ID: {2}", myRow, myColumn, myID);


        }

    }

}
