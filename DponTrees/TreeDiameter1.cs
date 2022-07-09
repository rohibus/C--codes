using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnTrees
{
    public class TreeDiameter1
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[][] dp;
        List<int>[] adjencyList;
		int[] f;
		int[] g;

        public TreeDiameter1(List<string> list)
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

			DFS_G(1, -1);
			DFS_F(1, -1, -1);

			var result = string.Join(" ", f);

            File.AppendAllText(outputPath, $"\nTreeDiameter1 for {n} nodes result = {result}", Encoding.UTF8);
        }

        public void DFS_F(int current, int parent, int dist_par)
		{
			int max1 = -1;
			int max2 = -1;
			
			foreach (var x in adjencyList[current])
			{
				if (x != parent)
				{
					if (g[x] > max1)
					{
						max2 = max1;
						max1 = g[x];
					}
					else if (g[x] > max2)
					{
						max2 = g[x];
					}
				}
			}
			
			foreach (var x in adjencyList[current])
			{
				if (x != parent)
				{
					int new_dis_par = dist_par;
					
					//foreach (var y in adjencyList[current])
					//{
					//	if (y != parent && y != x)
					//		new_dis_par = Math.Max(new_dis_par, g[y]);
					//}
					
					if (g[x] == max1)
						new_dis_par = Math.Max(new_dis_par, max2);
					else
						new_dis_par = Math.Max(new_dis_par, max1);
					
					DFS_F(x, current, new_dis_par + 1);

					f[current] = Math.Max(f[current], g[x]+1);
				}
			}

			f[current] = Math.Max(f[current], dist_par+1);
		}
		
		public void DFS_G(int current, int parent)
		{
			foreach (var x in adjencyList[current])
			{
				if (x != parent)
				{
					DFS_G(x, current);
					g[current] = Math.Max(g[current], g[x] + 1);
				}
			}
		}

    }
}
