using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnTrees
{
    public class LCA
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[][] par;
        List<int>[] adjencyList;
		int[] f;
		int[] depth;
		int n;
		int m = 20;

        public LCA(List<string> list)
        {
            n = Convert.ToInt32(list[0]);
            adjencyList = new List<int>[n + 1];
            for (int i = 0; i <= n; i++)
            {
                adjencyList[i] = new List<int>();
            }

            par = new int[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                par[i] = new int[m];
            }
			
			f = new int[n+1];
			depth = new int[n+1];
			
            for (int i = 1; i < n; i++)
            {
				var item = list[i].Split(' ').Select(x => Convert.ToInt32(x)).ToList();
				adjencyList[item[0]].Add(item[1]);
				adjencyList[item[1]].Add(item[0]);
			}

			DFS(1, 0);

			int ans = LCAofUV(9, 12);
			File.AppendAllText(outputPath, $"\n LCA of u = 9 , v = 12 parent = {ans}", Encoding.UTF8);
			ans = LCAofUV(10, 8);
			File.AppendAllText(outputPath, $"\n u = 10 , v = 8 parent = {ans}", Encoding.UTF8);
			ans = LCAofUV(9, 11);
			File.AppendAllText(outputPath, $"\n u = 9 , v = 11 parent = {ans}", Encoding.UTF8);

		}

        public void DFS(int current, int parent)
		{
			depth[current] = depth[parent] + 1;
			par[current][0] = parent;
			
			for (int j = 1; j < 20; j++)
			{
				par[current][j] = par[par[current][j-1]][j-1];
			}
			
			foreach (var x in adjencyList[current])
			{
				if (x != parent)
				{
					DFS(x, current);
				}
			}
		}
		
		public int LCAofUV(int u, int v)
		{
			if (u == v)
				return u;

			if (depth[u] < depth[v])
            {
				(u, v) = (v, u);
            }

			int diff = depth[u] - depth[v];

			for (int j = m-1; j >= 0; j--)
            {
				int temp = (diff >> j) &1;
				if (temp == 1)
				{
					u = par[u][j];
				}
            }

			for (int j = m - 1; j >= 0; j--)
			{
				if (par[u][j] != par[v][j])
				{
					u = par[u][j];
					v = par[v][j];
				}
			}

			return par[u][0];
		}


    }
}
