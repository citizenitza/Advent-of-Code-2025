using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_day_06 {
    internal class Solution {
        public decimal Result_PartOne;
        public decimal Result_PartTwo;
        List<string> Operators = new List<string>();
        List<List<uint>> Numbers = new List<List<uint>>();
        List<List<uint>> NumbersPartTwo = new List<List<uint>>();
        public Solution() {
            string lineOfText;
            string ConfigPath = AppDomain.CurrentDomain.BaseDirectory + "input.txt";
            int lineIndex = 0;
            FileStream filestream = new FileStream(ConfigPath,
                                          System.IO.FileMode.Open,
                                          System.IO.FileAccess.Read,
                                          System.IO.FileShare.ReadWrite);
            var reader = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);
            string[] lineArray;
            //int Row = 0;
            bool FirstPart = true;
            while ((lineOfText = reader.ReadLine()) != null) {
                lineArray = lineOfText.Split(' ');
                if (lineArray[0] == "+" || lineArray[0] == "*") {
                    foreach (var element in lineArray) {
                        if (element != "") {
                            Operators.Add(element);
                        }
                    }

                } else {
                    List<uint> newNumbers = new List<uint>();
                    foreach (var element in lineArray) {
                        if (element != "") {
                            newNumbers.Add(Convert.ToUInt32(element.Trim()));
                        }
                    }
                    Numbers.Add(newNumbers);
                }
                //Row++;
            }

            //Part two parse
            filestream.Position = 0;
            reader.DiscardBufferedData();
            reader = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);

            List<string> Lines = new List<string>();
            while ((lineOfText = reader.ReadLine()) != null) {
                if (lineOfText[0] != '+' && lineOfText[0] != '*') {
                    Lines.Add(lineOfText);
                }
            }
            for (int i = 0; i < Lines.Count(); i++) {
                List<uint> tmp = new List<uint>();
                NumbersPartTwo.Add(tmp);
            }
            int Cycle = 0;
            int operatorindex = 0;
            for (int i = 0; i < Lines[0].Length; i++) {

                string currentNumber = "";
                for(int row  = 0; row < Lines.Count(); row++) {
                    currentNumber += Lines[row][i];
                }
                if (currentNumber.Trim() == "") {
                    Cycle = 0;
                    if (Operators[operatorindex] == "+") {
                        if (NumbersPartTwo[2].Count() < NumbersPartTwo[0].Count()) {
                            NumbersPartTwo[2].Add(0);
                        }
                        if (NumbersPartTwo[3].Count() < NumbersPartTwo[0].Count()) {
                            NumbersPartTwo[3].Add(0);
                        }
                    } else {//*
                        if (NumbersPartTwo[2].Count() < NumbersPartTwo[0].Count()) {
                            NumbersPartTwo[2].Add(1);
                        }
                        if (NumbersPartTwo[3].Count() < NumbersPartTwo[0].Count()) {
                            NumbersPartTwo[3].Add(1);
                        }
                    }

                        operatorindex++;
                    continue;
                }
                NumbersPartTwo[Cycle].Add(Convert.ToUInt32(currentNumber.Trim()));
                Cycle++;
            }
            //last check
            if (Operators[^1] == "+") {
                if (NumbersPartTwo[2].Count() < NumbersPartTwo[0].Count()) {
                    NumbersPartTwo[2].Add(0);
                }
                if (NumbersPartTwo[3].Count() < NumbersPartTwo[0].Count()) {
                    NumbersPartTwo[3].Add(0);
                }
            } else {//*
                if (NumbersPartTwo[2].Count() < NumbersPartTwo[0].Count()) {
                    NumbersPartTwo[2].Add(1);
                }
                if (NumbersPartTwo[3].Count() < NumbersPartTwo[0].Count()) {
                    NumbersPartTwo[3].Add(1);
                }
            }
        }

        public void PartOne() {
            int iterations = Numbers[0].Count();
            int NumberCnt = Numbers.Count();
            for (int i = 0; i < iterations; i++) {
                if (Operators[i] == "+") {
                    ulong columnResult = 0;
                    for(int j = 0; j < NumberCnt; j++) {
                        columnResult += Numbers[j][i];
                    }
                    Result_PartOne += columnResult;
                } else if (Operators[i] == "*") {
                    ulong columnResult = 1;
                    for (int j = 0; j < NumberCnt; j++) {
                        columnResult *= Numbers[j][i];

                    }
                    Result_PartOne += columnResult;

                } else {//error
                    ;
                }

            }
        }
        public void PartTwo() {
            int iterations = NumbersPartTwo[0].Count();
            int NumberCnt = NumbersPartTwo.Count();
            for (int i = 0; i < iterations; i++) {
                if (Operators[i] == "+") {
                    ulong columnResult = 0;
                    for (int j = 0; j < NumberCnt; j++) {
                        columnResult += NumbersPartTwo[j][i];
                    }
                    Result_PartTwo += columnResult;
                } else if (Operators[i] == "*") {
                    ulong columnResult = 1;
                    for (int j = 0; j < NumberCnt; j++) {
                        columnResult *= NumbersPartTwo[j][i];

                    }
                    Result_PartTwo += columnResult;

                } else {//error
                    ;
                }

            }
        }

    }
}
