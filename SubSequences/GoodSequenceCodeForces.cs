using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		GoodSequence g = new GoodSequence();
	}
	
	public class GoodSequence
	{
		List<int> primeNumbers;
		public void Prime()
		{
			int max = 10000;
			bool[] prime = new bool[max+1];
			Array.Fill(prime, true);
			prime[0] = false;
			prime[1] = false;
			
			for (int i= 2; i < max; i++)
			{
				if (prime[i])
				{
					for (int j = i*i; j < max; j += i)
					{
						prime[j] = false;
					}
				}
			}
			primeNumbers.Add(2);
			for (int i= 3; i < max; i+=2)
			{
				if (prime[i])
				{
					primeNumbers.Add(i);
				}
			}
			
		}
		public GoodSequence()
		{
			primeNumbers = new List<int>();
			int n = Convert.ToInt32(Console.ReadLine());
			Prime();
			int[] nums = Console.ReadLine().Split(' ').Select(a => Convert.ToInt32(a)).ToArray();
			Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
			Dictionary<int, int> hset = new Dictionary<int, int>();
			
			for (int i = 0; i < n; i++)
			{
				foreach (var item in primeNumbers)
				{
					if (item > nums[i])
						break;
					if (nums[i] % item == 0)
					{
						if (!map.ContainsKey(nums[i]))
							map.Add(nums[i], new List<int>());
						map[nums[i]].Add(item);
						
						if (!hset.ContainsKey(item))
							hset.Add(item, 0);
					}
				}
			}
			
			for (int i = 0; i < n; i++)
			{
				if (map.ContainsKey(nums[i]))
				{
					int max = 0;
					foreach (var item in map[nums[i]])
					{
						max = Math.Max(max, hset[item]);
					}
					
					foreach (var item in map[nums[i]])
					{
						hset[item] = max+1;
					}
				}
			}
			
			if (hset.Count() > 0)
			{
				Console.Write(hset.Values.Max());
			}
			else
			{
				Console.Write(1);
			}
		}
	}
}