using System;
using System.Linq;
using System.IO;

namespace ConsoleApp18
{
    class Day4A
    {
        static void Main()
        {
            var passphrases = File.ReadAllLines("input").Select(x => x.Split(" ").ToList());

            var valids = passphrases.Count(p => p.Distinct().Count() == p.Count);
            
            Console.WriteLine(valids);
        }
    }
}
