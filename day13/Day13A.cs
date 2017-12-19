using System;
using System.Linq;

namespace ConsoleApp12
{
    public class Layer
    {
        public int Depth { get; set; }

        public int Range { get; set; }

        public int Position { get; set; }

        public int Direction { get; set; } = -1;
    }

    class Day13A
    {

        static void Main()
        {
            var lines = System.IO.File.ReadAllLines("input");

            var layers = lines.Select(x => new Layer
            {
                    Depth = int.Parse(x.Split(": ")[0]),
                    Range = int.Parse(x.Split(": ")[1])
                }
            ).ToList();

            var i = 0;
            var severity = 0;

            while (i <= layers.Max(x => x.Depth))
            {
                severity += layers.Where(x => x.Depth == i && x.Position == 0).Sum(x => x.Depth * x.Range);

                i++;

                foreach (var layer in layers)
                {
                    if (layer.Position == layer.Range - 1 || layer.Position == 0)
                        layer.Direction *= -1;

                    layer.Position += layer.Direction;
                }
            }

            Console.WriteLine(severity); // 1900
        }
    }
}
