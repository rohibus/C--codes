using System;
					
public class Program
{
	public static void Main()
	{
		MinStepToHome m = new MinStepToHome();
	}
	
	public class MinStepToHome
	{
		int[] dp;
		public MinStepToHome()
		{
			int n = Convert.ToInt32(Console.ReadLine());
			dp = new int[n+1];
			Array.Fill(dp, -1);
			int ans = Solve(n);
			Console.WriteLine(ans);
		}
		
		public int Solve(int n)
		{
			if (n == 1)
				return 0;
			
			if (dp[n] != -1)
				return dp[n];
			
			int ans = 1 + Solve(n-1);
			
			if (n % 2 == 0)
			{
				ans = Math.Min(ans, 1+ Solve(n/2));
			}
			
			if (n % 3 == 0)
			{
				ans = Math.Min(ans, 1+ Solve(n/3));
			}
			
			dp[n] = ans;
			return ans;
		}
	}
}