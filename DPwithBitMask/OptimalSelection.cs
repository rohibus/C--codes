using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnBitMask
{
    public class OptimalSelection
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int n, m;
		List<int>[] adjecency;

        public OptimalSelection(List<string> list)
        {
            int[] mn= list[0].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
			n = mn[0];
			m = mn[1];

			adjecency = new List<int>[n];
			for (int i = 0; i < n; i++)
            {
				adjecency[i] = new List<int>();
			}

			for (int i = 1; i <= n; i++)
            {
				int[] edge = list[i].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
				for (int j = 0; j < m; j++)
                {
					adjecency[i-1].Add(edge[j]);
				}
			}
			
			int ans = Solve();
            
			File.AppendAllText(outputPath, $"\nOptimalSelection {ans}", Encoding.UTF8);

		}

        public int Solve()
		{
			int[][] dp = new int[1<<n][];
			
			for (int i = 0; i < (1 << n); i++)
			{
				dp[i] = new int[m];
				Array.Fill(dp[i], 10000);
			}
			
			dp[0][0] = 0;
			
			for (int i = 0; i < n; i++)
			{
				dp[1<<i][0] = adjecency[i][0];
			}
			
			for (int mask = 0; mask < (1<<n); mask++)
			{
				for (int d = 1; d < m; d++)
				{
					dp[mask][d] = dp[mask][d-1];
					
					for (int x = 0; x < n; x++)
					{
						if (((mask >> x) & 1) == 1)
						{
							int newMask = mask ^ (1<<x);
							dp[mask][d] = Math.Min(dp[mask][d], dp[newMask][d-1] + adjecency[x][d]);
						}
					}
				}
			}
			
			return dp[(1<<n)-1][m-1];
		}

    }
}
