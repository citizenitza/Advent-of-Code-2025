using System.Collections.Generic;

namespace _2025_day_01 {
    internal class Solution {
        public int Result_PartOne;
        public int Result_PartTwo;
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
            bool firstline = true;
            int Row = 0;
            int Current = 50;
            //int Current = 0;
            while ((lineOfText = reader.ReadLine()) != null) {
                Current = Rotate(lineOfText.Substring(0, 1), Current, Convert.ToInt32(lineOfText.Substring(1)));
                if (Current == 0) {
                    Result_PartOne++;
                }
                ;
            }
        }
        public int Rotate(string Direction, int Current, int Count) {
            var original = Current;
            if (Direction == "R") { // Right
                Current = Current + Count;
                bool first = true;
                while (Current > 99) {
                    Current -= 100;
                    //if (original == 0) {
                    //    if (!first) {
                    //        Result_PartTwo++;
                    //    }
                    //} else {
                    //    Result_PartTwo++;
                    //}
                    Result_PartTwo++;
                    first = false;
                }

            } else if (Direction == "L") {//left
                Current = Current - Count;
                bool first = true;
                while (Current < 0) {
                    Current += 100;
                    if (original == 0) {
                        if (!first) {
                            Result_PartTwo++;
                        }
                    } else {
                        Result_PartTwo++;
                    }
                    first = false;
                }
                if (Current == 0) {
                    Result_PartTwo++;
                }
            }
            return Current;
        }

        public void PartOne() {

        }
        public void PartTwo() {
        }
    }
}
