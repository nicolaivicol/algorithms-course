using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1_Week3
{
    class Edge
    {
        public int node1_id;
        public int node2_id;

        //public Node node1;
        //public Node node2;

        public Edge(int node1_id, int node2_id)
        {
            this.node1_id = node1_id;
            this.node2_id = node2_id;
        }

        public override string ToString()
        {
            return node1_id.ToString() + " <-> " + node2_id.ToString();
        }

    }
}
