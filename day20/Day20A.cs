using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("input");

            var particles = new List<Particle>();

            var regex = new Regex(@"<(.+?)>");

            var i = 0;

            foreach (var line in lines)
            {
                var m = regex.Matches(line);


                particles.Add(new Particle
                {
                    Index = i++,
                    PositionX = int.Parse(m[0].Groups[1].Value.Split(",")[0]),
                    PositionY = int.Parse(m[0].Groups[1].Value.Split(",")[1]),
                    PositionZ = int.Parse(m[0].Groups[1].Value.Split(",")[2]),
                    VelocityX = int.Parse(m[1].Groups[1].Value.Split(",")[0]),
                    VelocityY = int.Parse(m[1].Groups[1].Value.Split(",")[1]),
                    VelocityZ = int.Parse(m[1].Groups[1].Value.Split(",")[2]),
                    AccelerationX = int.Parse(m[2].Groups[1].Value.Split(",")[0]),
                    AccelerationY = int.Parse(m[2].Groups[1].Value.Split(",")[1]),
                    AccelerationZ = int.Parse(m[2].Groups[1].Value.Split(",")[2])
                });
            }

            while (true)
            {
                foreach (var p in particles)
                {
                    p.VelocityX += p.AccelerationX;
                    p.VelocityY += p.AccelerationY;
                    p.VelocityZ += p.AccelerationZ;
                    p.PositionX += p.VelocityX;
                    p.PositionY += p.VelocityY;
                    p.PositionZ += p.VelocityZ;
                }
                var foo = particles.OrderBy(p => Math.Abs(p.PositionX) + Math.Abs(p.PositionY) + Math.Abs(p.PositionZ)).First().Index;
                Console.WriteLine(foo); // 150
            }


            Console.WriteLine("Hello World!");
        }
    }

    public class Particle
    {
        public int Index { get; set; }

        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int PositionZ { get; set; }

        public int VelocityX { get; set; }
        public int VelocityY { get; set; }
        public int VelocityZ { get; set; }

        public int AccelerationX { get; set; }
        public int AccelerationY { get; set; }
        public int AccelerationZ { get; set; }

    }
}
