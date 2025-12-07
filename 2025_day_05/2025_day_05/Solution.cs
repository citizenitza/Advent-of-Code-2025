namespace _2025_day_05 {
    public class Range {
        public decimal min;
        public decimal max;
    }
    internal class Solution {
        public decimal Result_PartOne;
        public decimal Result_PartTwo;
        List<Range> FreshRanges = new List<Range>();
        List<decimal> Ingriedients = new List<decimal>();
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
            int Row = 0;
            bool FirstPart = true;
            while ((lineOfText = reader.ReadLine()) != null) {
                if(lineOfText == "") {
                    FirstPart = false;
                    continue;
                }
                if (FirstPart) {
                    lineArray = lineOfText.Split('-');
                    Range newRange = new Range();
                    newRange.min = Convert.ToDecimal(lineArray[0]);
                    newRange.max = Convert.ToDecimal(lineArray[1]);
                    FreshRanges.Add(newRange);

                } else {
                    Ingriedients.Add(Convert.ToDecimal(lineOfText));

                }
                    lineArray = lineOfText.Split("   ");
            }
            ;
        }

        public void PartOne() {
            foreach(decimal ing in Ingriedients) {
                bool Fresh = false;
                foreach(Range range in FreshRanges) {
                    if (ing >= range.min && ing <= range.max) {
                        Fresh = true;
                        break;
                    } 
                }
                if (Fresh) {
                    Result_PartOne++;
                }
            }
        }
        public void PartTwo() {
            List<Range> SortedList = FreshRanges.OrderBy(o => o.min).ToList();
            List<Range> ModifedRanges = new List<Range>();
            foreach (Range range in SortedList) {
                if (ModifedRanges.Count() == 0 || ModifedRanges[^1].max < range.min) {
                    ModifedRanges.Add(range);   
                } else {
                    if(range.max > ModifedRanges[^1].max) {
                        ModifedRanges[^1].max = range.max;
                    }

                }
            }
            foreach (Range range in ModifedRanges) {
                var tmp = range.max - range.min + 1;
                Result_PartTwo += tmp;
            }
        }
    }
}
