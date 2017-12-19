using System;
using System.Linq;

namespace ConsoleApp1
{
    public class Layer
    {
        public int Depth { get; set; }

        public int Range { get; set; }

        public int Position { get; set; }

        public int LastPosition { get; set; }

        public int LastDirection { get; set; } = -1;

        public int Direction { get; set; } = -1;
    }

    class Day13B
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

            var delay = 1;
            bool caught;

            do
            {
                var i = 0;
                caught = false;
                
                foreach (var layer in layers)
                {
                    layer.Position = layer.LastPosition;
                    layer.Direction = layer.LastDirection;
                    
                    if (layer.Position == layer.Range - 1 || layer.Position == 0)
                            layer.Direction *= -1;

                    layer.Position += layer.Direction;
                    layer.LastPosition = layer.Position;
                    layer.LastDirection = layer.Direction;
                }

                while (!caught && i <= layers.Max(x => x.Depth))
                {
                    caught = layers.Any(x => x.Depth == i && x.Position == 0);

                    i++;

                    foreach (var layer in layers)
                    {
                        if (layer.Position == layer.Range - 1 || layer.Position == 0)
                            layer.Direction *= -1;

                        layer.Position += layer.Direction;
                    }
                }

                if (caught)
                    delay++;
                
            } while (caught);
            
            Console.WriteLine(delay); // 3966414
        }
    }
}
