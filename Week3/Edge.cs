
namespace Algo1_Week3
{
    public class Edge
    {
        public int node1_id;
        public int node2_id;
        public bool isDirected = false; 

        public Edge(int node1_id, int node2_id)
        {
            this.node1_id = node1_id;
            this.node2_id = node2_id;
        }
        public Edge(int node1_id, int node2_id, bool isDirected) : this(node1_id, node2_id)
        {
            this.isDirected = isDirected;
        }
        public Edge(Edge e)
        {
            node1_id = e.node1_id;
            node2_id = e.node2_id;
        }
        public Edge()
        { }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Edge e = (Edge)obj;
            bool isEqual = node1_id == e.node1_id && node2_id == e.node2_id;
            if (!isDirected)
                isEqual = isEqual || (node1_id == e.node2_id && node2_id == e.node1_id);
            return isEqual;
        }

        public override string ToString()
        {
            if (isDirected)
                return node1_id.ToString() + " -> " + node2_id.ToString();
            else
                return node1_id.ToString() + " <-> " + node2_id.ToString();
        }

    }
}
