using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSP
{
    class Program
    {
        static void Main(string[] args)
        {
            //intialize matrices
            Aircraft aircraft = new Aircraft(100, Math.PI / 2);
            Region region = new Region(aircraft, 10, 10);

            //Path optimalPath = region.findPath(Region r);
            region.ToString();

            Edge a = (from Edge e1 in region.MyGraph.Edges where e1.From.X == 0 && e1.From.Y == 0 && e1.To.X == 1 && e1.To.Y == 1 select e1).FirstOrDefault<Edge>();
            Edge b = (from Edge e1 in region.MyGraph.Edges where e1.From.X == 1 && e1.From.Y == 1 && e1.To.X == 2 && e1.To.Y == 2 select e1).FirstOrDefault<Edge>();
            bool allowed = region.MyGraph.IsPathAllowed(a, b, aircraft);
        }

        static void PrintPath(Path p)
        {
            string rtn = "";
            foreach(Edge e in p.PathToTake)
            {
                rtn = rtn + e.ToString() + "\n";
            }
        }
    }
}
