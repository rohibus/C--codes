using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnBitMask
{
    public class Elevator
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int n, x;
		int[] weights;

        public Elevator(List<string> list)
        {
            int[] mn= list[0].Split(' ').Select(x1 => Convert.ToInt32(x1)).ToArray();
			x = mn[0];
			n = mn[1];

			weights = new int[n];

			weights = list[1].Split(' ').Select(x1 => Convert.ToInt32(x1)).ToArray();
			
			int ans = Solve();
            
			File.AppendAllText(outputPath, $"\nElevator {ans}", Encoding.UTF8);

		}

        public int Solve()
		{
			var dp = new (int, int)[1<<n];
			
			dp[0] = (1, 0);
			
			for (int mask = 1; mask < (1<<n); mask++)
			{
				dp[mask] = (n, 0);
				
				for (int j = 0; j < n; j++)
				{
					if (((mask>>j)&1) == 1)
					{
						int newMask = mask ^ (1<<j);
						(int, int) option = dp[newMask];
						
						if (option.Item2 + weights[j] <= x)
						{
							option.Item1 = option.Item1;
							option.Item2 += weights[j];
						}
						else
						{
							option.Item1++;
							option.Item2 = weights[j];
						}
						
						if (dp[mask].Item1 == option.Item1)
                        {
							dp[mask] = dp[mask].Item2 > option.Item2 ? option : dp[mask];
                        }
						else
                        {
							dp[mask] = dp[mask].Item1 > option.Item1 ? option : dp[mask];
						}
					}
				}
			}
			
			return dp[(1<<n)-1].Item1;
		}

    }
}
