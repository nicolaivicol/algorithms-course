using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1_Week3
{
    class Node
    {
        public int id;
        public List<int> nodesIDs;
        public List<Edge> edges;
        
        public Node(string s)
        {
            nodesIDs = new List<int>();
            edges = new List<Edge>();

            string[] sdel = s.Split('\t');
            id = int.Parse(sdel[0]);
            for (int i = 1; i < sdel.Length; i++)
            {
                try
                {
                    nodesIDs.Add(int.Parse(sdel[i]));
                    edges.Add(new Edge(id, int.Parse(sdel[i])));
                }
                catch
                { }

            }
        }

        public override string ToString()
        {
            string s = id.ToString() + " <-> ";
            foreach (var item in nodesIDs)
            {
                s = s+item.ToString()+", ";
            }

            return s;
        }
    }



}
