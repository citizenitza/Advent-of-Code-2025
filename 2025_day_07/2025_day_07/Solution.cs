using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_day_07 {
    internal class Solution {
        public uint Result_PartOne;
        public ulong Result_PartTwo;

        public int MatrixSize;
        public string[,] Input;
        public string[,] DrawMap;
        private PriorityQueue<(int,int),int> Beams = new PriorityQueue<(int, int),int>();
        //PartTwo
        private int StartCol = 0;
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
                    Input = new string[MatrixSize+1, MatrixSize];
                    DrawMap = new string[MatrixSize+1, MatrixSize];
                }
                int Col = 0;
                foreach (char c in lineOfText) {
                    DrawMap[Row, Col] = c.ToString();

                    if (c == 'S') {
                        Input[Row, Col] = ".";
                        Beams.Enqueue((Row, Col),Row);
                        //part two
                        StartCol = Col;
                    } else {
                        Input[Row, Col] = c.ToString();
                    }
                    Col++;
                }
                Row++;
            }

        }
        Dictionary<(int x, int y), int> SplitterCache = new Dictionary<(int x, int y), int>();
        Dictionary<(int x, int y), int> SplitterRouteCount = new Dictionary<(int x, int y), int>();
        public void PartOne() {
            while (Beams.Count> 0) {
                var currentBeam = Beams.Dequeue();
                ProcessBeam(currentBeam.Item1,currentBeam.Item2);
                ;
            }
        }
        private void ProcessBeam(int StartRow, int StartCol) {
            List<(int, int)> CurrentLine = new List<(int, int)>();
            int CurrentRow = StartRow;
            int CurrentCol = StartCol;
            DrawMap[CurrentRow, CurrentCol] = "|";
            CurrentLine.Add((CurrentRow, CurrentCol));

            while(CurrentRow < MatrixSize) { // while above edge
                //make a step downward
                CurrentRow += 1;
                CurrentLine.Add((CurrentRow, CurrentCol));
                if (Input[CurrentRow,CurrentCol] == ".") { // empty space
                    DrawMap[CurrentRow, CurrentCol] = "|";
                    continue;
                } else if (Input[CurrentRow, CurrentCol] == "^") { // splitter
                    if (!SplitterCache.TryGetValue((CurrentRow, CurrentCol), out var result)) {
                      //store splitter
                      SplitterCache[(CurrentRow, CurrentCol)] = 1;
                      //create newbeam
                      Beams.Enqueue((CurrentRow, CurrentCol + 1),CurrentRow);
                      //step left and continue downdard
                      CurrentCol -= 1;
                      DrawMap[CurrentRow, CurrentCol] = "|";
                      Result_PartOne++;
                    } else {
                    
                        return;
                    }

                    continue;
                }

            }
        }
        public void Draw() {
            for(int row = 0; row < MatrixSize + 1; row++) {
                string line = "";
                for(int col = 0; col < MatrixSize; col++) {
                    line += DrawMap[row, col] + "";
                }
                Console.WriteLine(line);
            }
        }
        ulong[,] BeamCount;
        public void PartTwo() {
            int currentRow = 0;
            BeamCount = new ulong[MatrixSize+1, MatrixSize];
            BeamCount[0,StartCol] = 1;
            while (currentRow < MatrixSize) {
                //Step with each beam
                currentRow++;
                for (int col = 0; col < MatrixSize; col++) {
                    if (BeamCount[currentRow-1,col] > 0) { //has beam
                        if (Input[currentRow, col] == ".") { // step
                            BeamCount[currentRow, col] += BeamCount[currentRow - 1, col];
                        } else if (Input[currentRow, col] == "^") { // split
                            BeamCount[currentRow, col] = 0;
                            BeamCount[currentRow, col - 1] += BeamCount[currentRow - 1, col];
                            BeamCount[currentRow, col + 1] += BeamCount[currentRow - 1, col];
                        }
                    }
                }
            }
            for (int col = 0; col < MatrixSize; col++) {
                Result_PartTwo += BeamCount[MatrixSize-1,col];
            }
        }
        public void DrawBeamCnt() {
            for (int row = 0; row < MatrixSize + 1; row++) {
                string line = "";
                for (int col = 0; col < MatrixSize; col++) {
                    line += BeamCount[row, col] + "   ";
                }
                Console.WriteLine(line);
            }
        }
    }
}
