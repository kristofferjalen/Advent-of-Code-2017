using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Day19B
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input");
            var cols = lines[0].Length;

            var grid = lines.SelectMany(q => q).ToList();

            var letters = new List<char>();

            var nonLetters = new [] {'|', '-', '+'};
            var x = grid.IndexOf('|');
            var y = 0;

            var dx = 0;
            var dy = 1;
            var steps = 0;
            
            while (true)
            {                
                while (grid[y * cols + x] != '+' && grid[y * cols + x] != ' ')
                {
                    var c = grid[y * cols + x];
                    if (!nonLetters.Contains(c))
                        letters.Add(c);
                    y += dy;
                    x += dx;
                    steps++;
                }

                if (grid[y * cols + x] == ' ')
                    break;

                if (dy != 0 && grid[y * cols + x + 1] != ' ')
                {
                    dy = 0;
                    dx = 1;
                }
                else if (dy != 0 && grid[y * cols + x - 1] != ' ')
                {
                    dy = 0;
                    dx = -1;
                }
                else if (dx != 0 && grid[(y - 1) * cols + x] != ' ')
                {
                    dy = -1;
                    dx = 0;
                }
                else if (dx != 0 && grid[(y + 1) * cols + x] != ' ')
                {
                    dy = 1;
                    dx = 0;
                }

                x += dx;
                y += dy;
                steps++;
            }

            Console.WriteLine(steps); // 16492
        }
    }
}
