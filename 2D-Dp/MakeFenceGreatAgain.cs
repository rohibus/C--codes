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
		Dictionary<(long, long, int), long> map;
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
				
				map = new Dictionary<(long, long, int), long>();
				
				long ans = Solve(0, -1, 0);
				ans = Math.Min(ans, Solve(0, -1, 1));
				ans = Math.Min(ans, Solve(0, -1, 2));
				
				Console.WriteLine(ans);
			}
		}
		
		public long Solve(long i, long pre, int state)
		{
			if (i == n)
				return 0;
			if (map.ContainsKey((i, pre, state)))
				return map[(i, pre, state)];
			long ans = Int64.MaxValue;
			
			if (h[i][0] + 0 != pre)
				ans = Math.Min(ans, Solve(i+1, h[i][0], 0));
			
			if (h[i][0] + 1 != pre)
				ans = Math.Min(ans, h[i][1] + Solve(i+1, h[i][0]+1, 1));
			
			if (h[i][0] + 2 != pre)
				ans = Math.Min(ans, 2*h[i][1] + Solve(i+1, h[i][0]+2, 2));
			
			map[(i, pre, state)] = ans;
			return ans;
		}
	}
}