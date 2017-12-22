using System.Collections.Generic;
using System.Linq;

class Day17A
{
    static void Main()
    {
        var list = new List<int> { 0 };

        int curr = 0, i = 0;

        while (i++ < 2017)
        {
            curr = (curr + 370) % list.Count + 1;
            list.Insert(curr, list.Max() + 1);
        }

        System.Console.WriteLine(list[curr + 1]); // 1244
    }
}
