using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		ModuloSum m = new ModuloSum();
	}
	
	public class ModuloSum
	{
		int n, m;
		int[] nums;
		int[][] dp;
		public ModuloSum()
		{
			int[] nm = Console.ReadLine().Split(' ').Select(a => Convert.ToInt32(a)).ToArray();
			n = nm[0];
			m = nm[1];
			nums = Console.ReadLine().Split(' ').Select(a => Convert.ToInt32(a)).ToArray();
			
			bool ans = n >= m;
			
			if (!ans)
			{
				dp = new int[n+1][];
				for (int i = 0; i <= n; i++)
				{
					dp[i] = new int[m+1];
					Array.Fill(dp[i], -1);
				}
				ans |= Solve(0, 0);
			}
			Console.WriteLine(ans ? "YES" : "NO");
		}
		
		public bool Solve(int i, int sum)
		{
			if (i == n)
				return false;
			
			if ((nums[i] + sum) % m == 0)
				return true;
			
			if (dp[i][sum] != -1)
			{
				return dp[i][sum] == 1;
			}
			
			bool ans = false;
			
			ans |= Solve(i+1, (nums[i] + sum) % m);
			ans |= Solve(i+1, sum);
			
			dp[i][sum] = ans ? 1 : 0;
			return ans;
		}
	}
}