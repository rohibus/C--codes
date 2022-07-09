using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class TowerOfHonoi
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        
        public TowerOfHonoi(int n)
        {
            Solve(n, "A", "B", "C");
        }
        public void Solve(int n, string from, string auxilary, string to)
        {
            if (n == 0)
                return;

            Solve(n-1, from, to, auxilary);
            var readText = $"Move {n} from {from} to {to}   \n";
            File.AppendAllText(outputPath, readText, Encoding.UTF8);

            Solve(n - 1, auxilary, to, from);
        }
    }
}
