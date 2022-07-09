using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class GenerateBrackets
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";

        public GenerateBrackets(int n)
        {
            string output = "";
            int close = 0;
            int open = 0;

            File.AppendAllText(outputPath, $"output for n = {n} " + "\n", Encoding.UTF8);

            Solve(output, open, close, 0, n);
        }

        public void Solve(string output, int open, int close, int index, int n)
        {
            if (index == 2*n)
            {
                File.AppendAllText(outputPath, output + "\n", Encoding.UTF8);
                return;
            }

            if (open < n)
            {
                Solve(output + "(", open + 1, close, index + 1, n);
            }

            if (close < open)
            {
                Solve(output + ")", open, close + 1, index + 1, n);
            }
        }
    }
}
