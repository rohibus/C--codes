using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnBitMask
{
    public class HamiltonianPathBitMask
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int n, m;
		string s;
		List<int>[] adjecency;
		Dictionary<(int, int), bool> map;

        public HamiltonianPathBitMask(List<string> list)
        {
            int[] mn= list[0].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
			n = mn[0];
			m = mn[1];
			map = new Dictionary<(int, int), bool>();

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
				int mask = (1 << i);
				ans |= DFS(i, mask);
            }
            
			File.AppendAllText(outputPath, $"\nHamiltonian path exist {ans}", Encoding.UTF8);

		}

        public bool DFS(int cur, int mask)
		{
			if (mask == ((1<<n) - 1))
				return true;

			if (map.ContainsKey((cur, mask)))
            {
				return map[(cur, mask)];
            }

			bool ans = false;

			foreach (var x in adjecency[cur])
            {
				int setbit = (mask >> x) & 1;
				if (setbit != 1)
                {
					var temp = mask | (1<<x);
					ans |= DFS(x, temp);
                }
            }

			map.Add((cur, mask), ans);

			return ans;
		}

    }
}
