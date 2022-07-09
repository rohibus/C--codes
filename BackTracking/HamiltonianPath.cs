using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class HamiltonianPath
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		List<int>[] adj;
		int n, m;
		bool[] visited;
        public HamiltonianPath()
        {
            n = Convert.ToInt32(Console.ReadLine());
			m = Convert.ToInt32(Console.ReadLine());
			adj = new List<int>[n];
			
			for (int i = 0; i < n; i++)
				adj[i] = new List<int>();
			
			for (int i = 0; i < m; i++)
			{
				int[] edge = Console.ReadLine().Split(' ').Select(a => Convert.ToInt32(a)).ToArray();
				adj[edge[0]].Add(edge[1]);
				adj[edge[1]].Add(edge[0]);
			}

            bool ans = false;
			
			for (int i = 0; i < n; i++)
			{
				visited = new bool[n];
				ans |= Path(i, 1);
			}
			
			Console.WriteLine(ans);
        }

        public bool Path(int cur, int count)
        {
            if (count == n)
				return true;
			
			visited[cur] = true;
			
			foreach (var x in adj[cur])
			{
				if (visited[x] == false)
				{
					return Path(x, count+1);
				}
			}
			visited[cur] = false;
			return false;
        }
    }
}
