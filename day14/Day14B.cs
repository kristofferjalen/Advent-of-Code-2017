using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp11
{
    class Day14B
    {
        private static List<(bool used, bool inRegion)> _grid;

        static void Main()
        {
            const string input = "amgozmfv";

            _grid = new List<(bool bit, bool group)>(Enumerable.Range(0, 128)
                .SelectMany(y => Hash($"{input}-{y}").Select(x => (x == '1', false))));

            var groups = 0;

            for (var i = 0; i < 128 * 128; i++)
            {
                if (_grid[i].inRegion || !_grid[i].used)
                    continue;

                if (Rec(i).Any())
                    groups++;
            }

            Console.WriteLine(groups); // 1086
        }

        private static IEnumerable<int> Rec(int index)
        {
            _grid[index] = (true, true);

            var neighbours = GetNeighbours(index);

            var result = new List<int>(neighbours.Append(index));

            foreach (var n in neighbours)
            {
                result.AddRange(Rec(n));
            }

            return result;
        }

        private static List<int> GetNeighbours(int index)
        {
            var x = index % 128;
            var y = index / 128;

            var neighbours = new List<int>();

            if (x < 127 && _grid[index + 1].used && !_grid[index + 1].inRegion)
                neighbours.Add(index + 1);

            if (y < 127 && _grid[index + 128].used && !_grid[index + 128].inRegion)
                neighbours.Add(index + 128);

            if (x > 0 && _grid[index - 1].used && !_grid[index - 1].inRegion)
                neighbours.Add(index - 1);

            if (y > 0 && _grid[index - 128].used && !_grid[index - 128].inRegion)
                neighbours.Add(index - 128);

            foreach (var n in neighbours)
                _grid[n] = (true, true);

            return neighbours;
        }

        private static string Hash(string input)
        {
            var list = Enumerable.Range(0, 256).ToList();
            int pos = 0, skip = 0, round = 0;

            var lengths = (string.Join(",", input.Select(c => (int)c)) + ",17,31,73,47,23").Split(",").Select(int.Parse).ToList();

            while (round++ < 64)
            {
                foreach (var length in lengths)
                {
                    var sublist = Enumerable.Range(0, length).Select(a => list[(pos + a) % list.Count]).ToList();

                    sublist.Reverse();

                    var i = sublist.Count;
                    while (--i >= 0)
                        list[(pos + i) % list.Count] = sublist[i];

                    pos += length + skip++;
                }
            }

            var hashNumber = string.Join("", Enumerable.Range(0, 16).Select(b => list.Skip(16 * b).Take(16).Aggregate((s, i) => s ^ i).ToString("x2")));

            var hash = string.Join("",
                hashNumber.Select(x => Convert.ToString(Convert.ToInt32(x.ToString(), 16), 2).PadLeft(4, '0')));

            return hash;
        }
    }
}
