using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algo1_Week3
{
    class Graph
    {
        public Dictionary<int, Node> nodes;

        public Graph(string filepath)
        {
            nodes = new Dictionary<int, Node>();
            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    AddNode(s);
                }
            }
        }
        public Graph(Graph g)
        {
            nodes = new Dictionary<int, Node>();
            foreach (Node n in g.nodes.Values)
            {
                AddNode(new Node(n));
            }
        }
        public void AddNode(string s)
        {
            Node n = new Node(s);
            nodes.Add(n.id, n);
        }
        public void AddNode(Node n)
        {
            nodes.Add(n.id, n);
        }
        public static void MergeNodes(Graph g, Node n1, Node n2)
        {
            // delete edges between n1, n2 (which would become circular)
            for (int i = n1.edges.Count - 1; i >= 0; i--)
            {
                if (n1.edges[i].node1_id == n2.id || n1.edges[i].node2_id == n2.id) { n1.edges.RemoveAt(i); }
            }
            for (int i = n2.edges.Count - 1; i >= 0; i--)
            {
                if (n2.edges[i].node1_id == n1.id || n2.edges[i].node2_id == n1.id) { n2.edges.RemoveAt(i); }
            }

            // create node n1n2 with id of n1, edges of n1 and n2
            Node n1n2 = new Node(n1, n2);

            // replace n1 with n1n2 in graph
            g.nodes[n1.id] = n1n2;

            // remove n2 from graph
            g.nodes.Remove(n2.id);

            // replace (incident) edges of (to) n1 and n2 with edges incident to n1n2 !!!!!! ITERATE OVER ALL NODES AND REPLACE ID of n2
            foreach (Node n in g.nodes.Values)
            {
                for (int i = n.edges.Count - 1; i >= 0; i--)
                {
                    if (n.edges[i].node1_id == n2.id) { n.edges[i].node1_id = n1.id; }
                    if (n.edges[i].node2_id == n2.id) { n.edges[i].node2_id = n1.id; }   
                }
            }
        }
        public static Edge SelectRandomEdge(Graph g)
        {
            int n_e = g.NumberOfEdges();
            Random rnd = new Random();
            int e_i = rnd.Next(0, n_e);
            Edge e = new Edge();
            foreach (Node n in g.nodes.Values)
            {
                if (e_i < n.edges.Count)
                {
                    e = n.edges[e_i];
                    break;
                }
                e_i -= n.edges.Count;
            }
            return e;
        }
        public int NumberOfEdges()
        {
            int n_e = 0;
            foreach (Node n in nodes.Values)
            {
                n_e += n.edges.Count;
            }
            return n_e;
        }
        public int FindMinCut(int iterN)
        {
            int[] mincuts = new int[iterN]; // pocket of min cuts
            for (int i = 0; i < iterN; i++)
            {
                Graph g = new Graph(this); // get a copy of the initial graph used for contraction
                while (g.nodes.Count > 2)
                {
                    Edge e = SelectRandomEdge(g);
                    MergeNodes(g, g.nodes[e.node1_id], g.nodes[e.node2_id]);
                }
                mincuts[i] = g.NumberOfEdges() / 2;
            }
            return mincuts.Min();
        }
    }
}
