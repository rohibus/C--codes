using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnTrees
{
    public  class BFSVertexCover
    {
		string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int[][] dp;
		bool[] visited;
		List<int>[] adjencyList;
		int n;

		public BFSVertexCover(List<string> list)
		{
			n = Convert.ToInt32(list[0]);
			adjencyList = new List<int>[n + 1];
			for (int i = 0; i <= n; i++)
			{
				adjencyList[i] = new List<int>();
			}

			dp = new int[n + 1][];
			for (int i = 0; i <= n; i++)
			{
				dp[i] = new int[2];
				Array.Fill(dp[i], -1);
			}
			visited = new bool[n + 1];

			for (int i = 1; i < n; i++)
			{
				var item = list[i].Split(' ').Select(x => Convert.ToInt32(x)).ToList();
				adjencyList[item[0]].Add(item[1]);
				adjencyList[item[1]].Add(item[0]);
			}

			int result = BFS();

			File.AppendAllText(outputPath, $"\nVertexCover for {n} nodes result = {result}", Encoding.UTF8);
		}


		public int BFS()
		{
			int root = 0;
			var queue = new Queue<int>();

			for (int i = 1; i <= n; i++)
			{
				if (adjencyList[i].Count() == 1)
				{
					queue.Enqueue(i);
				}
			}

			while (queue.Count > 0)
			{
				int current = queue.Dequeue();
				visited[current] = true;
				dp[current][0] = 0;
				dp[current][1] = 1;
				root = current;

				foreach (var parent in adjencyList[current])
				{
					if (visited[parent])
					{
						dp[current][0] += dp[parent][1];
						dp[current][1] += Math.Min(dp[parent][0], dp[parent][1]);
					}
					else
					{
						queue.Enqueue(parent);

					}
				}
			}

			return Math.Min(dp[root][0], dp[root][1]);
		}
	}
}
