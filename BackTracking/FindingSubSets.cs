using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class FindingSubSets
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";

        public FindingSubSets(char[] s)
        {
            char[] result = new char[s.Length];
            Solve(s, result, 0, 0);
        }

        public void Solve(char[] input, char[] output, int i, int j)
        {
            if (i == input.Length)
            {
                if (j == 0)
                {
                    File.AppendAllText(outputPath, "NULL" + "\n", Encoding.UTF8);
                    return;
                }

                var sb = new StringBuilder();
                for (int k = 0; k < j; k++)
                {
                    sb.Append(output[k]);
                }
                File.AppendAllText(outputPath, sb.ToString() + "\n", Encoding.UTF8);
                return;
            }

            output[j] = input[i];

            Solve(input, output, i+1, j + 1);

            Solve(input, output, i+1, j);
        }
    }
}
