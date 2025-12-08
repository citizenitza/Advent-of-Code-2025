using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_day_04 {
    public class Tile {
        public string Type;
    }
    internal class Solution {
        public uint Result_PartOne;
        public uint Result_PartTwo;
        Tile[,] Input;
        int MatrixSize = 0;
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
                    MatrixSize = lineOfText.Count();
                    //initialize input
                    Input = new Tile[MatrixSize, MatrixSize];
                }
                int Col = 0;
                foreach (char c in lineOfText) {
                    Input[Row, Col] = new Tile();
                    Input[Row, Col].Type = c.ToString(); ;
                    Col++;
                }
                Row++;
            }

        }

        public void PartOne() {
            for(int Row = 0;Row< MatrixSize; Row++) {
                for (int Col = 0; Col < MatrixSize; Col++) {
                    if (Input[Row, Col].Type == "@") { // if paper
                        if (CheckAccess(Row, Col)) {
                            Result_PartOne++;
                        }
                    }
                }
            }
        }

        private bool CheckAccess(int row, int col) {
            int neighbours = 0;

            for(int i=-1;i<2;i++ ) {
                int rowTest = row+i;
                if(rowTest<0 || rowTest >= MatrixSize) {
                    continue;
                }
                for(int j = -1; j < 2; j++) {
                    int colTest = col+j;
                    if (colTest < 0 || colTest >= MatrixSize) {
                        continue;
                    }
                    if(rowTest == row && colTest == col) {
                        continue;
                    }
                    if (Input[rowTest, colTest].Type == "@") {
                        neighbours++;
                    }
                }
            }
            if (neighbours < 4) {
                return true;
            } else {
                return false;
            }
        }
        List<(int,int)> Toremove = new List<(int,int)>();
        public void PartTwo() {
            uint tmpresult = 1;
            while (tmpresult>0) {
                tmpresult = 0;

                for (int Row = 0; Row < MatrixSize; Row++) {
                    for (int Col = 0; Col < MatrixSize; Col++) {
                        if (Input[Row, Col].Type == "@") { // if paper
                            if (CheckAccess(Row, Col)) {
                                tmpresult++;
                                Toremove.Add((Row, Col));
                            }
                        }
                    }
                }
                foreach ((int, int) coord in Toremove) {
                    Input[coord.Item1, coord.Item2].Type = ".";
                }
                Result_PartTwo += tmpresult;
            }
        }
    }
}
