using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class PaintHouse
    {
        public PaintHouse()
        {

        }

        public int solve(List<List<int>> A)
        {
            int[][] dp = new int[3][];

            for (int i = 0; i < 3; i++)
            {
                dp[i] = new int[A.Count()];
            }

            for (int i = 0; i < 3; i++)
            {
                dp[i][0] = A[0][i];
            }

            for (int i = 1; i < A.Count(); i++)
            {
                dp[0][i] = A[i][0] + Math.Min(dp[1][i - 1], dp[2][i - 1]);

                dp[1][i] = A[i][1] + Math.Min(dp[0][i - 1], dp[2][i - 1]);

                dp[2][i] = A[i][2] + Math.Min(dp[0][i - 1], dp[1][i - 1]);
            }

            return Math.Min(dp[0][A.Count() - 1], Math.Min(dp[1][A.Count() - 1], dp[2][A.Count() - 1]));
        }
    }
}
