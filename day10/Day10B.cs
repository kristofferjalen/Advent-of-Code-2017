using System;
using System.Linq;

namespace ConsoleApp1
{
    class Day10B
    {
        static void Main()
        {
            var list = Enumerable.Range(0, 256).ToList();
            int pos = 0, skip = 0, round = 0;
            const string input = "192,69,168,160,78,1,166,28,0,83,198,2,254,255,41,12";

            var lengths = (string.Join(",", input.Select(c => (int) c)) + ",17,31,73,47,23").Split(",").Select(int.Parse).ToList();
            
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
            
            var hash = string.Join("", Enumerable.Range(0, 16).Select(b => list.Skip(16 * b).Take(16).Aggregate((s, i) => s ^ i).ToString("x2")));

            Console.WriteLine(hash); // 1c46642b6f2bc21db2a2149d0aeeae5d
        }
    }
}
