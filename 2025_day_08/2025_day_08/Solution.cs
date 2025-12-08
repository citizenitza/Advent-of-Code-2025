using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_day_08 {
    internal class Solution {
        public ulong Result_PartOne;
        public ulong Result_PartTwo;
        List<(int,int,int)> Junctions = new List<(int, int, int)> ();
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
                lineArray = lineOfText.Split(',');
                Junctions.Add((Convert.ToInt32(lineArray[0]), Convert.ToInt32(lineArray[1]), Convert.ToInt32(lineArray[2])));
                Row++;
            }

        }
        Dictionary<(int i, int j), double> Distances = new Dictionary<(int i, int j), double>();
        public void PartOne() {
            int Nodes = Junctions.Count();
            for(int i = 0; i < Nodes; i++) {
                for(int j = i + 1; j < Nodes; j++) {
                    var Distance = GetDistance(Junctions[i], Junctions[j]);
                    if (i == 0 && j == 5){
                        ;
                    }
                    Distances.Add((i, j), Distance);
                }
            }
            var SortedDistances = Distances.OrderBy(kvp => kvp.Value).ToList();
            for (int i = 0; i < 20; i++) {
                WritePair(SortedDistances[i].Key.i, SortedDistances[i].Key.j, SortedDistances[i].Value);
            }
            //Connect Junctions
            List<List<int>> Circuits = new List<List<int>>();
            for(int i = 0; i < Junctions.Count();i++) {
                //initiate ciruits
                List<int> newCirc = new List<int>();
                newCirc.Add(i);
                Circuits.Add(newCirc);
            }
            //part 1
           // int toConnect = 10;
           //part 2
            int toConnect = 1000;
            List<(int,int)> Stack = new List<(int,int)>();
            for(int i = 0;i< SortedDistances.Count(); i++) {
                
                bool iExist = false;
                bool jExist = false;
                int iIndex = 0;
                int jIndex = 0;
                for (int iCirc = 0; iCirc < Circuits.Count; iCirc++) {
                    //i exist
                    if (Circuits[iCirc].Any(x => x == SortedDistances[i].Key.i)) {
                        iExist = true;
                        iIndex = iCirc;
                    }
                    //j exist
                    if (Circuits[iCirc].Any(x => x == SortedDistances[i].Key.j)) {
                        jExist = true;
                        jIndex = iCirc;
                    }
                }
                if (iExist && jExist) {
                  if(iIndex == jIndex) {
                        //already same circuit
                    } else {
                        //connect two circut
                        var temp = Circuits[jIndex];
                        Circuits[iIndex].AddRange(temp);
                        Circuits.RemoveAt(jIndex);
                    }
                } else if (iExist) {
                    //add to existing
                    Circuits[iIndex].Add(SortedDistances[i].Key.j);
                    ;
                } else if (jExist) {
                    //add to existing
                    Circuits[jIndex].Add(SortedDistances[i].Key.i);
                    ;
                } else {
                    //create new
                    List<int> newCircuit = new List<int>();
                    newCircuit.Add(SortedDistances[i].Key.i);
                    newCircuit.Add(SortedDistances[i].Key.j);
                    Circuits.Add(newCircuit);
                    ;
                }
                //Order by size
                if (i == toConnect-1) {
                    Circuits.Sort((a, b) => a.Count - b.Count);
                    Result_PartOne = (ulong)(Circuits[^1].Count() * Circuits[^2].Count() * Circuits[^3].Count());
                }
                Stack.Add((SortedDistances[i].Key.i, SortedDistances[i].Key.j));
                if(Circuits.Count == 1) {
                    Result_PartTwo = (ulong)Junctions[Stack[^1].Item1].Item1 * (ulong)Junctions[Stack[^1].Item2].Item1;
                    break;
                }
            }

            ;
        }

        private void WritePair(int i,int j,double distance) {

            Console.WriteLine(Junctions[i].Item1 + "," + Junctions[i].Item2 + "," + Junctions[i].Item3 + "         " + Junctions[j].Item1 + "," + Junctions[j].Item2 + "," + Junctions[j].Item3 + "   Dist:" + distance);

        }
        private double GetDistance((int, int, int) P1, (int, int, int) P2) {
            long D1 = P1.Item1 - P2.Item1;
            long D2 = P1.Item2 - P2.Item2;
            long D3 = P1.Item3 - P2.Item3;
            double distance = Math.Sqrt(D1 * D1 + D2 * D2 + D3 * D3);
            return distance;
        }
        public void PartTwo() {
        }
    }
}
