using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Day24B
    {
        static void Main()
        {
            var components = System.IO.File.ReadAllLines("input")
                .Select(x => (int.Parse(x.Split("/")[0]), int.Parse(x.Split("/")[1]))).ToList();
            
            var strength = Rec(new List<(int, int)>(), 0, components)
                .GroupBy(x => x.Count)
                .OrderByDescending(x => x.Key)
                .First()
                .Max(x => x.Sum(c => c.Item1 + c.Item2));

            System.Console.WriteLine(strength); // 1642
        }

        private static IEnumerable<List<(int, int)>> Rec(ICollection<(int, int)> list, int port, List<(int, int)> components)
        {
            var result = new List<List<(int, int)>>();

            foreach (var c in components.Where(x => !list.Contains(x) && (x.Item1 == port || x.Item2 == port)))
            {
                var newList = new List<(int, int)>(list) {c};
                result.Add(newList);
                result.AddRange(Rec(newList, c.Item1 == port ? c.Item2 : c.Item1, components));
            }

            return result;
        }
    }
}
