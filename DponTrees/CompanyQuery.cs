using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnTrees
{
    public class CompanyQuery
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[][] par;
        List<int>[] adjencyList;
		int[] f;
		int[] g;
		int n;
		int m = 20;

        public CompanyQuery(List<string> list)
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
			g = new int[n+1];
			
			var item = list[1].Split(' ').Select( x => Convert.ToInt32(x)).ToList();
            for (int i = 2; i <= n; i++)
            {
                adjencyList[i].Add(item[i-2]);
                adjencyList[item[i-2]].Add(i);
            }

			DFS(1, 0);

			int result = 0;
			
			File.AppendAllText(outputPath, $"\nCompany Query for {n} nodes ", Encoding.UTF8);
			for (int i = 2; i < list.Count(); i++)
			{
				var temp = list[i].Split(' ').Select(a => Convert.ToInt32(a)).ToList();
				int x = temp[0];
				int k = temp[1];
				
				int ans = GiveKthParent(x, k);
				File.AppendAllText(outputPath, $"\n x = {x} , k = {k} parent = {ans}", Encoding.UTF8);
			}

            
        }

        public void DFS(int current, int parent)
		{
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
		
		public int GiveKthParent(int x, int k)
		{
			int current = x;
			
			for (int j = 0; j < 20; j++)
			{
				if (((k >> j) & 1) == 1)
				{
					current = par[current][j];
				}
			}
			
			if (current == 0)
				current = -1;
			
			return current;
		}

    }
}
