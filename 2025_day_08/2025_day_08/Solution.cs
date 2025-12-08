using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_day_08 {
    internal class Solution {
        public uint Result_PartOne;
        public uint Result_PartTwo;
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
            while ((lineOfText = reader.ReadLine()) != null) {
                if (firstline) {
                    firstline = false;
                    //MatrixSize = lineOfText.Count();
                    //initialize input
                    //Input = new Tile[MatrixSize, MatrixSize];
                }
                int Col = 0;
                foreach (char c in lineOfText) {
                    //Input[Row, Col] = new Tile();
                    //Input[Row, Col].Type = c;
                    //Col++;
                }
                Row++;
            }

        }

        public void PartOne() {
        }
        public void PartTwo() {
        }
    }
}
