using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		KnapSack k = new KnapSack();
	}
	
	public class KnapSack
	{
		long N, W;
		long[] nums;
		List<long> result;
		Dictionary<(long, long), bool> map;
		long min;
		
		public KnapSack()
		{
			int test = Convert.ToInt32(Console.ReadLine());
			
			while (test > 0)
			{
				test--;
				long[] nm = Console.ReadLine().Split(' ').Select(a => Convert.ToInt64(a)).ToArray();
				N = nm[0];
				W = nm[1];
				nums = Console.ReadLine().Split(' ').Select(a => Convert.ToInt64(a)).ToArray();
				result = new List<long>();
				map = new Dictionary<(long, long), bool>();
				min = (long)Math.Ceiling((double)W/2);
				
				bool ans = Solve(0, 0, new List<long>());
				
				if (ans)
				{
					Console.WriteLine(result.Count());
					var res = String.Join(" ", result);
					Console.WriteLine(res);
				}
				else
				{
					Console.WriteLine(-1);
				}
			}
		}
		
		public bool Solve(long i, long w, List<long> current)
		{			
			if (w >= min && w <= W)
			{
				result = new List<long>(current);
				return true;
			}
			
			if (i == N)
				return false;
			
			if (map.ContainsKey((i, w)))
				return map[(i,w)];
			
			bool ans = false;
			if (w+nums[i] <= W)
			{
				var temp = new List<long>(current);
				temp.Add(i+1);
				ans |= Solve(i+1, w+nums[i], temp);
			}
			
			ans |= Solve(i+1, w, new List<long>(current));
			map.Add((i, w), ans);
	
			return ans;
		}
	}
}