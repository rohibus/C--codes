using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnTrees
{
    public class TreeDiameter
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[][] dp;
        List<int>[] adjencyList;
		int[] f;
		int[] g;

        public TreeDiameter(List<string> list)
        {
            var n = Convert.ToInt32(list[0]);
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
			
			f = new int[n+1];
			g = new int[n+1];

            for (int i = 1; i < n; i++)
            {
                var item = list[i].Split(' ').Select( x => Convert.ToInt32(x)).ToList();
                adjencyList[item[0]].Add(item[1]);
                adjencyList[item[1]].Add(item[0]);
            }

			DFS(1, -1);

			int result = f[1];

            File.AppendAllText(outputPath, $"\nTreeDiameter for {n} nodes result = {result}", Encoding.UTF8);
        }

        public void DFS(int current, int parent)
		{
			int max1 = 0;
			int max2 = 0;
			
			foreach (var x in adjencyList[current])
			{
				if (x != parent)
				{
					DFS(x, current);
					g[current] = Math.Max(g[current], g[x]+1);
					f[current] = Math.Max(f[current], f[x]);
					
					if (g[x] + 1 > max1)
					{
						max2 = max1;
						max1 = g[x] + 1;
					}
					else if (g[x] + 1 > max2)
					{
						max2 = g[x] + 1;
					}
				}
			}
			
			f[current] = Math.Max(f[current], max1 + max2);
		}

    }
}
