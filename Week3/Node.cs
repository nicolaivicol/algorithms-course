using System.Collections.Generic;

namespace Algo1_Week3
{
    class Node
    {
        public int id;
        public List<Edge> edges;

        public Node(string s)
        {
            edges = new List<Edge>();

            string[] sdel = s.Split('\t');
            id = int.Parse(sdel[0]);
            for (int i = 1; i < sdel.Length; i++)
            {
                try
                {
                    edges.Add(new Edge(id, int.Parse(sdel[i])));
                }
                catch
                { }
            }
        }
        public Node(Node n1, Node n2)
        {
            id = n1.id;
            edges = new List<Edge>();
            for (int i = 0; i < n1.edges.Count; i++)
            {
                edges.Add(new Edge(n1.edges[i]));
            }
            for (int i = 0; i < n2.edges.Count; i++)
            {
                edges.Add(new Edge(n2.edges[i]));
            }
        }
        public Node(Node n)
        {
            id = n.id;
            edges = new List<Edge>();
            for (int i = 0; i < n.edges.Count; i++)
            {
                edges.Add(new Edge(n.edges[i]));
            }
        }

        public override string ToString()
        {
            string s = id.ToString() + " <-> ";
            foreach (Edge item in edges)
            {
                s = s + item.node2_id.ToString() + ", ";
            }
            return s;
        }
    }

}
