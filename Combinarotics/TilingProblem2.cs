using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class TilingProblem2
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[] dp;

        public TilingProblem2(List<string> list)
        {
            File.AppendAllText(outputPath, $"TilingProblem 2 -- \n", Encoding.UTF8);

            var n = Convert.ToInt32(list[0]);

            dp = new int[n+1];
            var result = Solve(n);

            File.AppendAllText(outputPath, $"Output {result} -- \n", Encoding.UTF8);
        }

        public int Solve(int n)
        {
            if (n == 0)
                return 0;

            dp[1] = 1;
            dp[2] = 3;

            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + 2 * dp[i - 2];
            }

            return dp[n];
        }
    }
}
