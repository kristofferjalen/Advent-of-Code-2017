using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Day11B
    {
        static void Main()
        {
            var input = System.IO.File.ReadAllText("input");

            int x = 0, y = 0, max = 0;
            
            var f = new Dictionary<string, Func<int, int, (int, int)>>
            {
                {"ne", (_, __) => (_ + 1, __ - 1)},
                {"n", (_, __) => (_, __ - 2)},
                {"nw", (_, __) => (_ - 1, __ - 1)},
                {"se", (_, __) => (_ + 1, __ + 1)},
                {"s", (_, __) => (_, __ + 2)},
                {"sw", (_, __) => (_ - 1, __ + 1)}
            };
            
            foreach (var op in input.Split(","))
            {
                (x, y) = f[op](x, y);
                max = Math.Max(max, (Math.Abs(y) + Math.Abs(x)) / 2);
            }
            
            Console.WriteLine(max); // 1457
        }
    }
}