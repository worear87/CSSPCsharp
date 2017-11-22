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
            Graph region = new Graph(6, 6);
            
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
