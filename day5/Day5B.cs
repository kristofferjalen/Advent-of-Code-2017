using System;
using System.IO;
using System.Linq;

namespace ConsoleApp19
{
    class Day5B
    {
        static void Main()
        {
            var input = File.ReadAllLines("input5").Select(int.Parse).ToList();
            int pos = 0, steps = 0;
            while (pos < input.Count && pos >= 0)
            {
                var offset = input[pos];
                input[pos] = offset >= 3 ? input[pos] - 1 : input[pos] + 1;
                pos += offset;
                steps++;
            }
            
            Console.WriteLine(steps);
        }
    }
}
