using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class BinomialCoefficients
    {
        int[][] dp;
        public BinomialCoefficients(List<string> list)
        {
            var n = Convert.ToInt32(list[0]);

            dp = new int[n+1][];
			for (int i = 0; i <= n; i++)
				dp[i] = new int[n+1];
			
            var result = Solve(n);
			
			for (int i = 1; i <= n; i++)
				Console.Write(dp[n][i]);

        }

        public void Solve(int n)
		{
			dp[0][0] = 1;
			
			for (int i = 1; i <= n; i++)
			{
				for (int j = 1;j <= i; j++)
				{
					dp[i][j] = dp[i-1][j-1] + dp[i-1][j];
				}
			}
		}
    }
}
