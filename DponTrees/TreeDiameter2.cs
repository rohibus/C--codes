using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnTrees
{
    public class TreeDiameter2
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[][] dp;
        List<int>[] adjencyList;
		int[] f;
		int[] g;
		int[] h;
		int n;

        public TreeDiameter2(List<string> list)
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

			f = new int[n + 1];
			g = new int[n + 1];
			h = new int[n + 1];

            for (int i = 1; i < n; i++)
            {
                var item = list[i].Split(' ').Select( x => Convert.ToInt32(x)).ToList();
                adjencyList[item[0]].Add(item[1]);
                adjencyList[item[1]].Add(item[0]);
            }

			DFS_G(1, -1);
			DFS_F(1, -1, 0);

			var result = string.Join(" ", f);

            File.AppendAllText(outputPath, $"\nTreeDiameter1 for {n} nodes result = {result}", Encoding.UTF8);
        }

        public void DFS_F(int current, int parent, int sum_par)
		{
			
			foreach (var x in adjencyList[current])
			{
				if (x != parent)
				{
					int new_sum_par = sum_par + (n - h[current]);

					int current_child_value = g[x] + h[x];

					new_sum_par += g[current] - current_child_value;


					DFS_F(x, current, new_sum_par);

					f[current] += g[x] + h[x];
				}
			}

			f[current] += sum_par + (n - h[current]);
		}
		
		public void DFS_G(int current, int parent)
		{
			foreach (var x in adjencyList[current])
			{
				if (x != parent)
				{
					DFS_G(x, current);
					g[current] += g[x] + h[x];
					h[current] += h[x];
				}
			}

			h[current] += 1;
		}

    }
}
