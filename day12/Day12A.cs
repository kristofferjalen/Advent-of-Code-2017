using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Day12A
    {
        static void Main()
        {
            var lines = System.IO.File.ReadAllLines("input");

            var group = new List<int>{0};
            group.AddRange(lines[0].Split(" <-> ")[1].Split(", ").Select(int.Parse));

            var @continue = true;

            while (@continue)
            {
                @continue = false;
                
                foreach (var line in lines.Skip(1))
                {
                    var tokens = line.Split(" <-> ");
                    var programs = tokens[1].Split(", ").Select(int.Parse);

                    foreach (var p in programs)
                    {
                        if (group.Any(x => x == p) && group.All(x => x != int.Parse(tokens[0])))
                        {
                            group.Add(int.Parse(tokens[0]));
                            @continue = true;
                            break;
                        }
                    }
                }
            }

            var sum = group.Count;

            Console.WriteLine(sum); // 306
        }
    }
}
