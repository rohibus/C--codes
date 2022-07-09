using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Advanced_DS
{
	public class Fenwicktree
	{
		string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";

		public Fenwicktree(List<string> s)
		{
			List<int> nums = s[0].Split(' ').Select(a => Convert.ToInt32(a)).ToList();
			FenwickTree segTree = new FenwickTree(nums);
		}

		public class FenwickTree
		{
			int n;
			int[] fn;

			public FenwickTree(List<int> v)
            {
				int _n = v.Count;
				Init(_n);
				build(v);
			}

			public void Init(int _n)
			{
				n = _n + 1;
				fn = new int[n];
			}

			public void build(List<int> v)
			{
				for (int i = 0; i < v.Count; i++)
				{
					Add(i, v[i]);
				}
			}

			public void Add(int x, int y)
			{
				x++; //one based index
				while (x < n)
				{
					fn[x] += y;
					x += (x & (-x)); // last bit set
				}
			}
			
			public int Sum(int l, int r)
			{
				return Sum(r) - Sum(l-1);
			}

			public int Sum(int x)
			{
				x++;
				int ans = 0;
				
				while (x > 0)
				{
					ans += fn[x];
					x -= (x & (-x));
				}
				
				return ans;
			}

		}

	}
}
