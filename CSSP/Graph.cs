using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSP
{
    class Graph
    {
        Vertex[,] vertices;
        Edge[,] edges;
        public Graph(Region r, Aircraft a)
        {
            this.vertices = BuildGraph((int)Math.Ceiling(r.RegionLength/a.MinTurnRadius), (int)Math.Ceiling(r.RegionWidth / a.MinTurnRadius));
            this.edges = BuildEdges(this.vertices);
        }
        public Graph()
        {
            this.vertices = null;
        }

        private Vertex[,] BuildGraph(int rows, int cols)
        {
            Vertex[,] myGraph = new Vertex[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Vertex temp = new Vertex(i, j);
                    if ((i == 0 && j == 0) || (i == rows && j == cols))
                        temp.IsBoundary = true;

                    myGraph[i, j] = temp;
                }
            }

            return myGraph;
        }

        private Edge[,] BuildEdges(Vertex[,] vertices)
        {
            throw new NotImplementedException();
            //return null;
        }
    }

    public class Vertex
    {
        public Vertex(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private bool isBoundary;

        public bool IsBoundary
        {
            get { return isBoundary; }
            set { isBoundary = value; }
        }

        private bool IsAdj(Vertex a, Vertex b)
        {
            return false;
        }

        private double FindAdjDist(Vertex a, Vertex b)
        {
            double d = 0;

            if (a.X == b.X || a.Y == b.Y)
                d = 1;
            else
                d = Math.Sqrt(2.0);

            return d;
        }
    }

    public class Edge
    {
        private int cost;

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }


        private Vertex from;

        public Vertex From
        {
            get { return from; }
            set { from = value; }
        }

        private Vertex to;

        public Vertex To
        {
            get { return to; }
            set { to = value; }
        }


    }

    public class Path
    {
        private LinkedList<Edge> pathToTake;

        public LinkedList<Edge> PathToTake
        {
            get { return this.pathToTake; }
            set { this.pathToTake = value; }
        }
    }
}
