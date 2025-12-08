using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_day_03 {
    internal class Solution {
        public uint Result_PartOne;
        public ulong Result_PartTwo;
        List<string> lineArray = new List<string>();
        public Solution() {
            string lineOfText;
            string ConfigPath = AppDomain.CurrentDomain.BaseDirectory + "input.txt";
            int lineIndex = 0;
            FileStream filestream = new FileStream(ConfigPath,
                                          System.IO.FileMode.Open,
                                          System.IO.FileAccess.Read,
                                          System.IO.FileShare.ReadWrite);
            var reader = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);
            bool firstline = true;
            int Row = 0;
            while ((lineOfText = reader.ReadLine()) != null) {
                lineArray.Add(lineOfText);
                Row++;
            }
        }

        public void PartOne() {
            foreach (string line in lineArray) {
                int FirstHighest = 0;
                int tmp = 0;
                for(int i=0;i<line.Length-1;i++) { //all char except last
                    if ((line[i] - '0') > tmp) {
                        tmp = (line[i] - '0');
                        FirstHighest = i; ;
                    }
                }
                int SecondHighest = 0;
                tmp = 0;
                for (int i = FirstHighest+1; i < line.Length ; i++) { //highest from the first char
                    if ((line[i] - '0') > tmp) {
                        tmp = (line[i] - '0');
                        SecondHighest = i; 
                    }
                }
                //var asd = line[FirstHighest]-'0';
                int joltage = (line[FirstHighest] - '0') *10 + (line[SecondHighest] - '0');
                Result_PartOne += (uint)joltage;
            }
        }
        public void PartTwo() {
            foreach (string line in lineArray) {
                int maxDigits = 12;
                int[] Highest = new int[maxDigits];
                int tmp = 0;
                for(int j=0;j<maxDigits;j++) {
                    tmp = 0;
                    int startdigit = 0;
                    if (j > 0) {
                        startdigit = Highest[j-1]+1;
                    }
                    for (int i = startdigit; i < line.Length - (maxDigits-1-j); i++) { //all char except last
                        if ((line[i] - '0') > tmp) {
                            tmp = (line[i] - '0');
                            Highest[j] = i; ;
                        }
                    }
                }
                ulong joltage = 0;
                for (int j = 0; j < maxDigits; j++) {
                    joltage += (ulong)(line[Highest[j]] - '0') * (ulong)Math.Pow(10, (maxDigits - 1 - j));
                    ;
                }
                
                Result_PartTwo += (ulong)joltage;
            }
        }
    }
}