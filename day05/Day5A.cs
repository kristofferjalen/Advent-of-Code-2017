using System;
using System.IO;
using System.Linq;

namespace ConsoleApp19
{
    class Day5A
    {
        static void Main()
        {
            var input = File.ReadAllLines("input5").Select(int.Parse).ToList();
            int pos = 0, steps = 0;

            while (pos < input.Count && pos >= 0)
            {
                pos += input[pos]++;
                steps++;
            }
            Console.WriteLine(steps);
        }
    }
}
