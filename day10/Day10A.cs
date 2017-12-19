using System;
using System.Linq;

namespace ConsoleApp1
{
    class Day10A
    {
        static void Main()
        {
            var list = Enumerable.Range(0, 256).ToList();
            int pos = 0, skip = 0;
            var lengths = new[] {192, 69, 168, 160, 78, 1, 166, 28, 0, 83, 198, 2, 254, 255, 41, 12};

            foreach (var length in lengths)
            {
                var sublist = Enumerable.Range(0, length).Select(a => list[(pos + a) % list.Count]).ToList();

                sublist.Reverse();

                var i = sublist.Count;
                while (--i >= 0)
                    list[(pos + i) % list.Count] = sublist[i];

                pos += length + skip++;
            }

            var product = list[0] * list[1];

            Console.WriteLine(product); // 48705
        }
    }
}
