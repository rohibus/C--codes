using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Advanced_DS
{
	public class Segmenttree
	{
		string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";

		public Segmenttree(List<string> s)
		{
			List<int> nums = s[0].Split(' ').Select(a => Convert.ToInt32(a)).ToList();
			SegmentTree segTree = new SegmentTree(nums);

			Console.WriteLine(segTree.query(0, 4));
			segTree.update(4, 10);

			Console.WriteLine(segTree.query(2, 6));
			segTree.update(2, 20);

			Console.WriteLine(segTree.query(0, 4));
		}

		public class SegmentTree
		{
			int n;
			int[] st;

			public SegmentTree(List<int> v)
            {
				int _n = v.Count;
				Init(_n);
				build(v);
			}

			public void Init(int _n)
			{
				n = _n;
				st = new int[4*n];
			}

			public void build(List<int> v)
			{
				build(0, n - 1, 0, v);
			}

			public void build(int start, int end, int node, List<int> v)
			{
				if (start == end)
				{
					st[node] = v[start];
					return;
				}

				int mid = start + (end - start) / 2;

				build(start, mid, 2 * node + 1, v);
				build(mid + 1, end, 2 * node + 2, v);

				st[node] = st[2 * node + 1] + st[2 * node + 2];
			}

			public int query(int l, int r)
			{
				return query(0, n - 1, l, r, 0);
			}

			public int query(int start, int end, int l, int r, int node)
			{
				if (start > r || end < l)
				{
					return 0;
				}

				if (start >= l && end <= r)
				{
					return st[node];
				}

				int mid = start + (end - start) / 2;

				int q1 = query(start, mid, l, r, 2 * node + 1);
				int q2 = query(mid + 1, end, l, r, 2 * node + 2);

				return q1 + q2;
			}

			public void update(int index, int value)
			{
				update(0, n - 1, 0, index, value);
			}

			public void update(int start, int end, int node, int index, int value)
			{
				if (start == end)
				{
					st[node] = value;
					return;
				}

				int mid = start + (end - start) / 2;

				if (index <= mid)
				{
					update(start, mid, 2 * node + 1, index, value);
				}
				else
				{
					update(mid + 1, end, 2 * node + 2, index, value);
				}

				st[node] = st[2 * node + 1] + st[2 * node + 2];
			}

		}

	}
}
