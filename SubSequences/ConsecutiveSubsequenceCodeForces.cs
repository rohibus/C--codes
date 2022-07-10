using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		ConsecutiveSubsequence c = new ConsecutiveSubsequence();
	}
	
	public class ConsecutiveSubsequence
	{
		public class Pairs
		{
			public long index;
			public long value;
			public Pairs(long index, long value)
			{
				this.index = index;
				this.value = value;
			}
		}
		
		public ConsecutiveSubsequence()
		{
			int n = Convert.ToInt32(Console.ReadLine());
			long[] nums = Console.ReadLine().Split(' ').Select(a => Convert.ToInt64(a)).ToArray();
			Dictionary<long, Pairs> map = new Dictionary<long, Pairs>();
			
			for (int i = 0; i < n; i++)
			{
				long previous = 0;
				if (map.ContainsKey(nums[i]-1))
				{
					previous = map[nums[i]-1].value;
				}
				if (!map.ContainsKey(nums[i]))
				{
					Pairs temp = new Pairs(i+1, previous+1);
					map.Add(nums[i], temp);
				}
				else
				{
					long current = map[nums[i]].value;
					Pairs temp = new Pairs(i+1, Math.Max(current, previous+1));
					map[nums[i]] = temp;
				}
			}
			
			long maxLen = map.Values.Max(i => i.value);
			long key = map.Where(i => i.Value.value == maxLen).First().Key - maxLen+1;
			
			List<long> position = new List<long>();
			
			for (long i = 0; i < n; i++)
			{
				if (nums[i] == key)
				{
					position.Add(i+1);
					key++;
				}
				
				if (position.Count() == (int)maxLen)
					break;
			}
			
			string result = String.Join(' ', position);
			Console.WriteLine(maxLen);
			Console.WriteLine(result);
		}
	}
}