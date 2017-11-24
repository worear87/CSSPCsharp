﻿using System;
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
        public Region(Aircraft a, double l, double w)
        {
            //default values, no no-fly zones, no radars;
            this.regionLength = l;
            this.regionWidth = w;
            this.myGraph = new Graph(this, a);
            
        }


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
