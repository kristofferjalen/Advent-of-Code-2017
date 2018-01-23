using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem7
{
    class Problem7A
    {
        static void Main()
        {
            var nodes = new List<Node>();
            var lines = File.ReadAllLines("input").ToList();

            foreach (var line in lines)
            {
                var items = line.Split(" ");
                var node = new Node(items[0]);
                var children = items.ToList().Skip(3).Select(x => new Node(x.Replace(",", ""))).ToList();
                node.Children = children;
                nodes.Add(node);
            }

            var current = nodes.First();

            while (nodes.Any(x => x.Children.Select(y => y.Name).Contains(current.Name)))
            {
                current = nodes.Single(x => x.Children.Select(y => y.Name).Contains(current.Name));
            }

            Console.WriteLine(current.Name); // dtacyn
        }
    }

    public class Node
    {
        public Node(string name) => Name = name;

        public string Name { get; set; }

        public List<Node> Children { get; set; }
    }
}
