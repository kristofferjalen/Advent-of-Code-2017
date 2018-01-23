using System.Linq;

class Day2B
{
    static void Main()
    {
        var sum = System.IO.File.ReadAllLines("input").Select(x => x.Split("\t").Select(int.Parse).ToList())
            .SelectMany(line => line, (line, i) => line
                .Where(x => x != i && x % i == 0)
                .Sum(x => x / i))
            .Sum();

        System.Console.WriteLine(sum); // 197
    }
}