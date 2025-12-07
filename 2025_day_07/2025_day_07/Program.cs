namespace _2025_day_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            solution.PartOne();
            solution.Draw();
            Console.WriteLine("Part one result: " + solution.Result_PartOne.ToString());
            solution.PartTwo();
            solution.DrawBeamCnt();
            Console.WriteLine("Part two result: " + solution.Result_PartTwo.ToString());
        }
    }
}
