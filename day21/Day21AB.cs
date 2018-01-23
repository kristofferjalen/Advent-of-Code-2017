using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Day21AB
    {
        static List<(string, string)> _rules;

        static void Main()
        {
            _rules = System.IO.File.ReadAllLines("input").Select(x => (x.Split(" => ")[0].Replace("/", ""), x.Split(" => ")[1].Replace("/", ""))).ToList();
            var grid = ".#...####";

            var iterations = 18; // 5

            var j = 0;
            while (j++ < iterations)
            {
                var size = grid.Length % 2 == 0 ? 2 : 3;
                var itemsPerBlock = size == 2 ? 4 : 9;
                var itemsPerBlockNewGrid = itemsPerBlock == 4 ? 9 : 16;
                var totalBlocks = grid.Length / itemsPerBlock;
                var blocksPerSide = (int)Math.Sqrt(grid.Length / (double)itemsPerBlock);

                var newGrid = new StringBuilder(string.Join("", Enumerable.Repeat(" ", totalBlocks * itemsPerBlockNewGrid)));

                for (var i = 0; i < grid.Length / itemsPerBlock; i++)
                {
                    var inputIndexes = GetIndexes(i, blocksPerSide, size, size == 3 ? 9 : 4);

                    var pattern = string.Join("", inputIndexes.Select(x => grid[x]));

                    var output = Transform(pattern);

                    var outputIndexes = GetIndexes(i, blocksPerSide, size == 3 ? 4 : 3, size == 3 ? 16 : 9);

                    for (var o = 0; o < outputIndexes.Count; o++)
                    {
                        newGrid[outputIndexes[o]] = output[o];
                    }
                }
                grid = newGrid.ToString();
            }

            Console.WriteLine(grid.Count(x => x == '#')); // 164 (5) or 2355110 (18)
        }

        private static List<int> GetIndexes(int i, int blocksPerSide, int rowsInABlock, int indexes)
        {
            var step = (int)Math.Sqrt(indexes);

            var result = new List<int>();

            for (var j = 0; j < indexes; j++)
            {
                result.Add(i / blocksPerSide * blocksPerSide * rowsInABlock * rowsInABlock +
                           j / step * blocksPerSide * rowsInABlock +
                           i % blocksPerSide * rowsInABlock + 
                           j % step);
            }

            return result;
        }

        private static string Transform(string pattern)
        {
            var ops = new Dictionary<int, Func<string, string>>
            {
                {0, Rotate },
                {1, Rotate },
                {2, Rotate },
                {3, p => { p = Rotate(p); return FlipH(p); } },
                {4, Rotate },
                {5, Rotate },
                {6, p => { p = Rotate(p); return FlipV(p); } },
                {7, Rotate },
                {8, Rotate }
            };

            var t = 0;
            while (t < 9 && _rules.All(x => x.Item1 != pattern))
                pattern = ops[t++](pattern);

            return _rules.Single(x => x.Item1 == pattern).Item2;
        }

        private static string Rotate(string pattern) =>
            pattern.Length == 9 ? pattern[6].ToString() + pattern[3] + pattern[0] + pattern[7] + pattern[4] + pattern[1] + pattern[8] + pattern[5] + pattern[2] :
                                    pattern[2].ToString() + pattern[0] + pattern[3] + pattern[1];

        private static string FlipH(string pattern) =>
            pattern.Length == 9 ? pattern[2].ToString() + pattern[1] + pattern[0] + pattern[5] + pattern[4] + pattern[3] + pattern[8] + pattern[7] + pattern[6] :
                                    pattern[1].ToString() + pattern[0] + pattern[3] + pattern[2];

        private static string FlipV(string pattern) =>
            pattern.Length == 9 ? pattern[6].ToString() + pattern[7] + pattern[8] + pattern[3] + pattern[4] + pattern[5] + pattern[0] + pattern[1] + pattern[2] :
                                    pattern[2].ToString() + pattern[3] + pattern[0] + pattern[1];
    }
}
