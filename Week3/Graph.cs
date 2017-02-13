using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1_Week3
{
    class Graph
    {
        public Dictionary<int, Node> nodes;
        public List<Edge> edges;

        public Graph(string filepath)
        {
            nodes = new Dictionary<int, Node>();
            edges = new List<Edge>();

            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    this.AddNode(s);
                }
            }


        }

        public void AddNode(string s)
        {
            Node n = new Node(s);
            nodes.Add(n.id, n);
        }


    }


}
