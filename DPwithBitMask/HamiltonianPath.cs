using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnBitMask
{
    public class HamiltonianPath
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int n, m;
		string s;
		List<int>[] adjecency;
		Dictionary<(int, HashSet<int>), bool> map;

        public HamiltonianPath(List<string> list)
        {
            int[] mn= list[0].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
			n = mn[0];
			m = mn[1];
			map = new Dictionary<(int, HashSet<int>), bool>();

			adjecency = new List<int>[n];
			for (int i = 0; i < n; i++)
            {
				adjecency[i] = new List<int>();
			}

			for (int i = 1; i <= m; i++)
            {
				int[] edge = list[i].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
				adjecency[edge[0]].Add(edge[1]);
				adjecency[edge[1]].Add(edge[0]);
			}

			bool ans = false;

			for (int i = 0; i < n; i++)
            {
				var set = new HashSet<int>();
				set.Add(i);
				ans |= DFS(i, set);
            }
            
			File.AppendAllText(outputPath, $"\nHamiltonian path exist {ans}", Encoding.UTF8);

		}

        public bool DFS(int cur, HashSet<int> set)
		{
			if (set.Count() == n)
				return true;

			if (map.ContainsKey((cur, set)))
            {
				return map[(cur, set)];
            }

			bool ans = false;

			foreach (var x in adjecency[cur])
            {
				if (!set.Contains(x))
                {
					HashSet<int> temp = new HashSet<int>(set);
					temp.Add(x);
					ans |= DFS(x, temp);
                }
            }

			map.Add((cur, set), ans);

			return ans;
		}

    }
}
