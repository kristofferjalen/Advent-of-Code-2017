using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Day6A
    {
        static void Main()
        {
            var redistributions = new List<List<int>> {new List<int> {4, 1, 15, 12, 0, 9, 9, 5, 5, 8, 7, 3, 14, 5, 12, 3}};

            while (redistributions.Count(x => x.SequenceEqual(redistributions.Last())) <= 1)
            {
                redistributions.Add(new List<int>(redistributions.Last()));
                var banks = redistributions.Last();
                var blocks = banks.Max();
                var index = banks.IndexOf(blocks);
                banks[index] = 0;
                for (var i = 1; i <= blocks; i++)
                    banks[(i + index) % banks.Count]++;
            }

            Console.WriteLine(redistributions.Count - 1);
        }
    }
}
