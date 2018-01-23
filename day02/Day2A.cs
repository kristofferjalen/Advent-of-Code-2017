using System.Linq;

class Day2A
{
    static void Main()
    {
        var checksum = System.IO.File.ReadAllLines("input")
            .Select(x => x.Split("\t").Select(int.Parse).ToList())
            .Sum(x => x.Max() - x.Min());

        System.Console.WriteLine(checksum); // 32121
    }
}