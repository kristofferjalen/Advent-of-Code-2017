using System;
using System.Linq;

namespace ConsoleApp1
{
    class Day14A
    {
        static void Main()
        {
            const string input = "amgozmfv";
            
            var sum = Enumerable.Range(0, 128).Select(x => Hash($"{input}-{x}").Count(y => y == '1')).Sum();
            
            Console.WriteLine(sum); // 8222
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

            var hash = string.Join("",
                Enumerable.Range(0, 16).Select(b => list.Skip(16 * b).Take(16).Aggregate((s, i) => s ^ i))
                    .Select(x => Convert.ToString(x, 2).PadLeft(4, '0')));

            return hash;
        }
    }
}
