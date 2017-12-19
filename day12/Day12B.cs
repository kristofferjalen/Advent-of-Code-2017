using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public static class Extensions
    {
        public static int GetProgram(this string s) => int.Parse(s.Split(" <-> ")[0]);

        public static IEnumerable<int> GetPipes(this string s) => s.Split(" <-> ")[1].Split(", ").Select(int.Parse);
    }

    class Day12B
    {
        static void Main()
        {
            var lines = System.IO.File.ReadAllLines("input");

            var groups = new List<List<int>>();

            while (lines.Length > groups.SelectMany(x => x).Distinct().Count())
            {
                var first = lines.First(x => !groups.SelectMany(y => y).Contains(x.GetProgram()));
                groups.Add(new List<int>(first.GetPipes().Append(first.GetProgram())));

                var @continue = true;

                while (@continue)
                {
                    @continue = false;

                    foreach (var line in lines.Skip(1))
                    {
                        foreach (var p in line.GetPipes())
                        {
                            var g = groups.SingleOrDefault(x => x.Contains(p) && !x.Contains(line.GetProgram()));

                            if (g == null)
                                continue;

                            g.Add(line.GetProgram());
                            @continue = true;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(groups.Count); // 200 
        }
    }
}
