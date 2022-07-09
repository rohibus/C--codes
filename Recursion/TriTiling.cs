using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class TriTiling
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";

        public TriTiling(List<string> list)
        {
            int i = 0;
            int n = Convert.ToInt32(list[i]);

            while (n != -1)
            {
                
                File.AppendAllText(outputPath, $"\nnumber of ways to fill TriTiling for input " + n + " \n", Encoding.UTF8);
                var count = Solve(n);
                File.AppendAllText(outputPath, count.ToString(), Encoding.UTF8);
                i++;
                n = Convert.ToInt32(list[i]);
            }
        }

        public int Solve(int n)
        {
            // A(n) = A(n-2) + 2*B(n-1)
            // B(n) = A(n-1) + B(n-2)

            int[] A = new int[n + 1];
            int[] B = new int[n + 1];

            A[0] = 1; A[1] = 0;
            B[0] = 0; B[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                A[i] = A[i - 2] + 2 * B[i - 1];
                B[i] = A[i - 1] + B[i - 2];
            }

            return A[n];
        }
    }
}
