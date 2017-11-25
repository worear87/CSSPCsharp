using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSP
{
    public class Aircraft
    {
        public Aircraft(double d, double mtr)
        {
            this.distance = d;
            this.minTurnRadius = mtr;
        }
        private double distance;

        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        private double minTurnRadius;

        public double MinTurnRadius
        {
            get { return minTurnRadius; }
            set { minTurnRadius = value; }
        }

    }
}
