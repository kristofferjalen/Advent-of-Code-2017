using System.Linq;

class Day1A
{
    static void Main()
    {
        var input = System.IO.File.ReadAllText("input").Select(x => int.Parse(x.ToString())).ToList();

        var sum = input.Where((t, i) => t == input[(i + 1) % input.Count]).Sum();

        System.Console.WriteLine(sum); // 1049
    }
}