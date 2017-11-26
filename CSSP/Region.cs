using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSP
{
    /// <summary>
    /// A region is defined by a length, width, a graph G=(V,E), a set of no-fly zones, and radars.
    /// </summary>
    class Region
    {
        #region Contructors
        public Region(Aircraft a, double l, double w)
        {
            //default values, no no-fly zones, no radars;
            this.regionLength = l;
            this.regionWidth = w;
            this.myGraph = new Graph(this, a);   
        }
        #endregion
        #region Properties
        private double regionLength;
        public double RegionLength
        {
            get { return regionLength; }
            set { regionLength = value; }
        }
        private double regionWidth;
        public double RegionWidth
        {
            get { return regionWidth; }
            set { regionWidth = value; }
        }
        /// <summary>
        /// This is the set of Vertices and Edges that are imposed over a region. Needs to know the region size, and the aircraft turn radius. And a target.
        /// </summary>
        private Graph myGraph;
        public Graph MyGraph
        {
            get { return myGraph; }
            set { myGraph = value; }
        }

        private List<Radar> radars;
        public List<Radar> Radars
        {
            get { return radars; }
            set { radars = value; }
        }

        private List<NoFlyZone> noFlyZones;
        public List<NoFlyZone> NoFlyZones
        {
            get { return noFlyZones; }
            set { noFlyZones = value; }
        }

        #endregion

        #region Methods
        internal Path FindPath(Region region)
        {
            Path opPath = new Path();

            //go through the region and find the optimal path for the plane starting from the target

            //concatenate the lowest 2 cost paths from the target to the boundary


            return opPath;
        }

        public void AddNoFlyZone(double ulx, double uly, double len, double wid)
        {
            NoFlyZone zone = new NoFlyZone(ulx, uly, len, wid);
            this.noFlyZones.Add(zone);
            AddNoFlyZoneCostToEdges(zone, myGraph);
        }

        public void AddRadarLocation(double x, double y, double radius)
        {
            Radar radar = new Radar(x, y, radius);
            this.radars.Add(radar);
            AddRadarCostToEdges(radar, myGraph);
        }
        /// <summary>
        /// Finds what edges the Radar intersects and adds 1 to the cost of those edges.
        /// </summary>
        /// <param name="radar">the radar</param>
        /// <param name="graph">graph over the region</param>
        public void AddRadarCostToEdges(Radar radar, Graph graph)
        {
            foreach(Edge e in graph.Edges)
            {
                if (DoesRadarCoverEdge(radar, e))
                    e.Cost += 1;
            }
        }

        private bool DoesRadarCoverEdge(Radar radar, Edge edge)
        {
            
            return false;
        }

        /// <summary>
        /// Finds the edges of the graph where the no-fly zone sits on top of and then adds 10 to the cost of those edges.
        /// </summary>
        /// <param name="noFlyZone">the no-fly zone in the region</param>
        /// <param name="graph">graph over the region</param>
        public void AddNoFlyZoneCostToEdges(NoFlyZone noFlyZone, Graph graph)
        {
            foreach(Edge e in graph.Edges)
            {
                if (DoesNoFlyZoneCoverEdge(noFlyZone, e))
                    e.Cost += 10;
            }
        }

        private bool DoesNoFlyZoneCoverEdge(NoFlyZone noFlyZone, Edge edge)
        {
            return false;
        }
        
        #endregion

        #region RegionClasses
        /// <summary>
        /// Class that holds the information for the no-fly zones. A no-fly zone is a rectangle defined by it's upper left x,y location in the region, and its
        /// length and width.
        /// </summary>
        public class NoFlyZone
        {
            public NoFlyZone(double x, double y, double l, double w)
            {
                this.upperLeftX = x;
                this.upperLeftY = y;
                this.length = l;
                this.width = w;
            }
            private double upperLeftX;
            public double UpperLeftX
            {
                get { return upperLeftX; }
                set { upperLeftX = value; }
            }

            private double upperLeftY;
            public double UpperLeftY
            {
                get { return upperLeftY; }
                set { upperLeftY = value; }
            }
            /// <summary>
            /// verticle side
            /// </summary>
            private double length;
            public double Length
            {
                get { return length; }
                set { length = value; }
            }
            /// <summary>
            /// horizontal side
            /// </summary>
            private double width;
            public double Width
            {
                get { return width; }
                set { width = value; }
            }


        }

        /// <summary>
        /// Class that defines a radar. A radar is defined by its center location, and its radius. The X
        /// and Y location must be inside the region.
        /// </summary>
        public class Radar
        {
            public Radar(double x,double y,double r)
            {
                this.centerX = x;
                this.centerY = y;
                this.radius = r;
            }

            private double centerX;
            public double CenterX
            {
                get { return centerX; }
                set { centerX = value; }
            }
            private double centerY;
            public double CenterY
            {
                get { return centerY; }
                set { centerY = value; }
            }

            private double radius;
            public double Radius
            {
                get { return radius; }
                set { radius = value; }
            }
        }
    }
#endregion
}
