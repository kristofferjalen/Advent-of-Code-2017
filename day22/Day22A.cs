using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Day22A
    {
        static void Main()
        {
            var lines = System.IO.File.ReadAllLines("input");

            const int side = 901;
            const int fill = (side - 25) / 2;
            var grid = Enumerable.Repeat('.', fill * side).ToList();
            foreach (var line in lines)
            {
                grid.AddRange(Enumerable.Repeat('.', fill));
                grid.AddRange(line);
                grid.AddRange(Enumerable.Repeat('.', fill));
            }
            grid.AddRange(Enumerable.Repeat('.', fill * side));

            var ops = new Dictionary<char, Func<int, (int, char)>>
            {
                {'#', d => (((d + 1) % 4 + 4) % 4, '.') },
                {'.', d => (((d - 1) % 4 + 4) % 4, '#') }
            };

            int current = side * side / 2,
                infections = 0,
                direction = 0,
                i = 0;
            while (i++ < 10_000)
            {
                if (grid[current] == '.')
                    infections++;

                direction = ops[grid[current]](direction).Item1;
                grid[current] = ops[grid[current]](direction).Item2;
                current += direction == 0 ? -side : direction == 1 ? 1 : direction == 2 ? side : direction == 3 ? -1 : 0;
            }

            Console.WriteLine(infections); // 5462
        }
    }
}
