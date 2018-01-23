using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp18
{
    class Day4B
    {
        static void Main()
        {
            bool IsAnagram(string s1, string s2) =>
                s1.OrderBy(s => s).SequenceEqual(s2.OrderBy(s => s));

            var passphrases = File.ReadAllLines("input").Select(x => x.Split(" ").ToList());

            var valids = passphrases
                .Count(p => p.Distinct().Count() - p.Count == 0 &&
                            !p.SelectMany(x => p.Where(pp => pp != x).Select(y => new List<string> {x, y}))
                                .Any(x => IsAnagram(x.First(), x.Last())));
            
            Console.WriteLine(valids);
        }
    }
}
