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
            
            region.ToString();
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
