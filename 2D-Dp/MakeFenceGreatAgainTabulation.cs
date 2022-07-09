using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		MakeFenceGreatAgain m = new MakeFenceGreatAgain();
	}
	
	public class MakeFenceGreatAgain
	{
		long n;
		long[][] h;
		public MakeFenceGreatAgain()
		{
			int test = Convert.ToInt32(Console.ReadLine());

			while (test > 0)
			{
				test--;
				n = Convert.ToInt64(Console.ReadLine());
				h = new long[n][];
				for (int i = 0; i < n; i++)
					h[i] = Console.ReadLine().Split(' ').Select(a => Convert.ToInt64(a)).ToArray();
				
				long ans = Solve();	
				Console.WriteLine(ans);
			}
		}
		
		public long Solve()
		{
			long[][] dp = new long[n][];
			for (long i = 0; i < n; i++)
			{
				dp[i] = new long[3];
				Array.Fill(dp[i], Int64.MaxValue);
			}
			
			dp[0][0] = 0;
			dp[0][1] = h[0][1];
			dp[0][2] = 2*h[0][1];
			
			for (int i = 1; i < n; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					for (int k = 0; k < 3; k++)
					{
						if (h[i-1][0] + j != h[i][0] + k)
						{
							dp[i][k] = Math.Min(dp[i][k], dp[i-1][j] + k * h[i][1]);
						}
					}
				}
			}
			
			return Math.Min(dp[n-1][0], Math.Min(dp[n-1][1], dp[n-1][2]));
		}
	}
}