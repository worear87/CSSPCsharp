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
            Region region = new Region();
            
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
