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
            DateTime startTime = DateTime.Now;
            //intialize matrices
            Aircraft aircraft = new Aircraft(100, Math.PI / 2);
            Region region = new Region(aircraft, 10, 10);
            region.AddRadarLocation(5, 5, 1);
            region.AddRadarLocation(6, 2, 2);
            //Path optimalPath = region.findPath(Region r);
            region.ToString();

            Edge a = (from Edge e1 in region.MyGraph.Edges where e1.From.Row == 0 && e1.From.Col == 0 && e1.To.Row == 1 && e1.To.Col == 1 select e1).FirstOrDefault<Edge>();
            Edge b = (from Edge e1 in region.MyGraph.Edges where e1.From.Row == 1 && e1.From.Col == 1 && e1.To.Row == 2 && e1.To.Col == 2 select e1).FirstOrDefault<Edge>();
            bool allowed = region.MyGraph.IsPathAllowed(a, b, aircraft);

            Path optimalPath = region.FindPath(region, region.MyGraph.Vertices[4,4]);
            PrintPath(optimalPath);

            DateTime endTime = DateTime.Now;

            TimeSpan runTime = endTime - startTime;
            Console.WriteLine("Runtime is " + runTime.ToString());
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
