using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace _2025_day_02 {

    internal class Solution {
        public decimal Result_PartOne;
        public decimal Result_PartTwo;
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
                lineArray = lineOfText.Split(',').ToList();
                break;
            }
            PartOne();
        }

        public void PartOne() {
            Result_PartOne = 0;
            foreach (string line in lineArray) {
                string[] tmp = line.Split("-");
                decimal min = Convert.ToDecimal(tmp[0]);
                decimal max = Convert.ToDecimal(tmp[1]);
                decimal count = max - min;
                for (uint i = 0; i <= count; i++) {
                    decimal current = min + i;
                    if (RulePart1(current.ToString())) {
                        Result_PartOne += current;
                    }

                }
            }
        }
        private bool RulePart1(string input) {
            if (input.Length % 2 == 1) {
                return false;
            }
            string firsthalf = input.Substring(0, input.Length / 2);
            string secondhalf = input.Substring(input.Length / 2, input.Length / 2);
            if (firsthalf == secondhalf) {
                return true;
            } else {
                return false;
            }
        }

        public void PartTwo() {
            Result_PartTwo = 0;
            foreach (string line in lineArray) {
                string[] tmp = line.Split("-");
                decimal min = Convert.ToDecimal(tmp[0]);
                decimal max = Convert.ToDecimal(tmp[1]);
                decimal count = max - min;
                for (uint i = 0; i <= count; i++) {
                    decimal current = min + i;
                    if (RulePart2(current.ToString())) {
                        Result_PartTwo += current;
                    }

                }
            }

        }
        private bool RulePart2(string input) {
            string pattern = @"^(\d+)\1+$";
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = reg.Match(input);
            if(match.Success) {
                return true;
            } else {
                return false;
            }
        }
    }
}
