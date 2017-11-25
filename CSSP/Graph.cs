using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSP
{
    class Graph
    {
        #region Properties
        private Vertex[,] vertices;
        public Vertex[,] Vertices
        {
            get { return vertices; }
            set { vertices = value; }
        }
        private List<Edge> edges;
        public List<Edge> Edges
        {
            get { return edges; }
            set { edges = value; }
        }
        private List<Vertex> boundarySet;
        public List<Vertex> BoundarySet
        {
            get { return boundarySet; }
            set { boundarySet = value; }
        }
        #endregion
        #region Constructors
        public Graph(Region r, Aircraft a)
        {
            //this.vertices = BuildGraph((int)Math.Ceiling(r.RegionLength/a.MinTurnRadius), (int)Math.Ceiling(r.RegionWidth / a.MinTurnRadius));
            this.vertices = BuildGraph(r.RegionLength, r.RegionWidth, a.MinTurnRadius);
            this.edges = BuildEdges(this.vertices);
            this.boundarySet = (from Vertex v in vertices where v.IsBoundary == true select v).ToList<Vertex>(); 
        }
        public Graph()
        {
            this.vertices = null;
        }
        #endregion
        #region Methods
        private Vertex[,] BuildGraph(double regionLen, double regionWidth, double minTurnRad)
        {
            int rows = (int)Math.Ceiling(regionLen / minTurnRad);
            int cols = (int)Math.Ceiling(regionWidth / minTurnRad);
            Vertex[,] myGraph = new Vertex[rows, cols];

            double currRegXPos = 0, currRegYPos = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Vertex temp = new Vertex(currRegXPos,i,currRegYPos,j);
                    if ((i == 0 || j == 0) || (i == rows - 1 || j == cols - 1))
                        temp.IsBoundary = true;

                    myGraph[i, j] = temp;

                    currRegYPos += minTurnRad;
                }
                currRegYPos = 0;
                currRegXPos += minTurnRad;
            }
            return myGraph;
        }


        private Vertex[,] BuildGraph(int rows, int cols)
        {
            Vertex[,] myGraph = new Vertex[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Vertex temp = new Vertex(i, j);
                    if ((i == 0 || j == 0) || (i == rows-1 || j == cols-1))
                        temp.IsBoundary = true;

                    myGraph[i, j] = temp;
                }
            }

            return myGraph;
        }

        private List<Edge> BuildEdges(Vertex[,] vertices)
        {
            List<Edge> edges = new List<Edge>();
            //loop through the vertices and add 
            for(int i=0; i<vertices.GetLength(0);i++)
            {
                for(int j=0; j<vertices.GetLength(1);j++)
                {
                    //add horizontal
                    AddHozizontalEdges(vertices[i, j],edges);
                    AddVerticalEdges(vertices[i, j], edges);
                    AddDiagonalEdges(vertices[i, j], edges);
                }
            }
            
            return edges;
        }

        private void AddDiagonalEdges(Vertex vertex,List<Edge> list)
        {
            //me to g[X-1,Y-1]
            try { AddEdge(vertex, vertices[vertex.Row - 1, vertex.Col - 1], list,Math.Sqrt(2)); } catch { }
            //me to g[X-1,Y+1]
            try { AddEdge(vertex, vertices[vertex.Row - 1, vertex.Col + 1], list, Math.Sqrt(2)); } catch { }
            //me to g[X+1,Y-1]
            try { AddEdge(vertex, vertices[vertex.Row + 1, vertex.Col - 1], list, Math.Sqrt(2)); } catch { }
            //me to g[X+1,Y+1]
            try { AddEdge(vertex, vertices[vertex.Row + 1, vertex.Col + 1], list, Math.Sqrt(2)); } catch { }
        }

        private void AddVerticalEdges(Vertex vertex, List<Edge> list)
        {
            //me to g[X,Y-1]
            try { AddEdge(vertex, vertices[vertex.Row, vertex.Col - 1],list,1); } catch { }
            //me to g[X,Y+1]
            try { AddEdge(vertex, vertices[vertex.Row, vertex.Col + 1],list,1); } catch { }
        }

        private void AddEdge(Vertex from, Vertex to, List<Edge> list,double d)
        {
            list.Add(new Edge(from, to,0,d));
        }

        private void AddHozizontalEdges(Vertex vertex, List<Edge> list)
        {
            //me to g[X-1,Y]
            try { AddEdge(vertex, vertices[vertex.Row - 1, vertex.Col], list,1); } catch { }
            //me to g[X+1,Y]
            try { AddEdge(vertex, vertices[vertex.Row + 1, vertex.Col], list,1); } catch { }
        }

        public bool IsPathAllowed(Edge a, Edge b, Aircraft ac)
        {
            double dp = DotProduct(a, b);
            double cp = CrossProduct(a, b);
            double ang = Math.Atan2(cp, dp);
            double angDeg = ang * (180/Math.PI);
            double minTurnDeg = ac.MinTurnRadius * (180 / Math.PI);
            if (angDeg < minTurnDeg)
                return false;
            else
                return true;
        }

        private double DotProduct(Edge a, Edge b)
        {
            double BAx, BAy, BCx, BCy;

            BAx = a.From.X - a.To.X;
            BAy = a.From.Y - a.To.Y;
            BCx = b.To.X - a.To.X;
            BCy = b.To.Y - a.To.Y;

            return (BAx * BCx) + (BAy * BCy);
        }

        private double CrossProduct(Edge a, Edge b)
        {
            double BAx, BAy, BCx, BCy;

            BAx = a.From.X - a.To.X;
            BAy = a.From.Y - a.To.Y;
            BCx = b.To.X - a.To.X;
            BCy = b.To.Y - a.To.Y;

            return (BAx * BCy) - (BAy * BCx);
        }

#endregion
    }

    #region GraphClasses
    public class Vertex
    {
        public Vertex(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vertex(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public Vertex(double x, int row, double y, int col)
        {
            this.x = x;
            this.row = row;
            this.y = y;
            this.col = col;
        }

        private double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        private int row;
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        private int col;
        public int Col
        {
            get { return col; }
            set { col = value; }
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
        private double distance;
        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        private double cost;

        public double Cost
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


        public Edge(Vertex f, Vertex t)
        {
            this.from = f;
            this.to = t;
        }
        public Edge(Vertex f, Vertex t, double c,double d)
        {
            this.from = f;
            this.to = t;
            this.cost = c;
            this.distance = d;
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

#endregion
}
