using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem7
{
    class Problem7B
    {
        static void Main()
        {
            // Parse input
            var nodes = new List<Node>();
            var lines = File.ReadAllLines("input").ToList();
            foreach (var line in lines)
            {
                var items = line.Split(" ");
                var weight = int.Parse(items[1].Replace("(", "").Replace(")", ""));
                var node = new Node(items[0], weight);
                var children = items.ToList().Skip(3).Select(x => new Node(x.Replace(",", ""), int.Parse(items[1].Replace("(", "").Replace(")", "")))).ToList();
                node.Children = children;
                nodes.Add(node);
            }

            // Get root node
            var current = nodes.First();
            while (nodes.Any(x => x.Children.Select(y => y.Name).Contains(current.Name)))
                current = nodes.Single(x => x.Children.Select(y => y.Name).Contains(current.Name));

            // Traverse
            var unbalancedTotalWeight = 0;
            var levels = new List<List<Node>>();
            while (true)
            {
                var siblings = new List<Node>();
                foreach (var childName in current.Children.Select(x => x.Name))
                {
                    var child = nodes.Single(x => x.Name == childName);
                    child.TotalWeight = child.Weight + GetWeightOfChildren(nodes, child);
                    siblings.Add(child);
                }

                // Has level all nodes equal total weight?
                if (siblings.Select(x => x.TotalWeight).Distinct().Count() == 1)
                    break;

                // Total weight that is unbalanced
                unbalancedTotalWeight = siblings.GroupBy(x => x.TotalWeight).Where(x => x.Count() == 1).Select(x => x.Key).First();
                
                // Move on to unbalanced node
                current = siblings.Single(x => x.TotalWeight == unbalancedTotalWeight);
                
                levels.Add(siblings);
            }

            var unbalancedNode = levels.Last().Single(x => x.TotalWeight == unbalancedTotalWeight);
            var balancedNode = levels.Last().First(x => x.TotalWeight != unbalancedTotalWeight);
            var newWeight = unbalancedNode.Weight + (balancedNode.TotalWeight - unbalancedTotalWeight);

            Console.WriteLine(newWeight); // 521
        }

        public static int GetWeightOfChildren(List<Node> nodes, Node node)
        {
            if (!node.Children.Any())
                return 0;

            var sum = 0;

            foreach (var childName in node.Children.Select(x => x.Name))
            {
                var child = nodes.Single(x => x.Name == childName);
                sum += child.Weight + GetWeightOfChildren(nodes, child);
            }

            return sum;
        }
    }

    public class Node
    {
        public Node(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int TotalWeight { get; set; }

        public List<Node> Children { get; set; }
    }
}
