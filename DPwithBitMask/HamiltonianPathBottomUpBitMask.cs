using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnBitMask
{
    public class HamiltonianPathButtomUpBitMask
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int n, m;
		string s;
		List<int>[] adjecency;
		Dictionary<(int, int), bool> map;
		int[][] dp;


		public HamiltonianPathButtomUpBitMask(List<string> list)
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

			dp = new int[n][];
			for (int i = 0; i < n; i++)
			{
				dp[i] = new int[(1 << n)];
			}

			DFS();
			bool ans = false;

			for (int i = 0; i < n; i++)
            {
				if (dp[i][(1 << n) - 1] == 1)
					ans |= true;
            }
            
			File.AppendAllText(outputPath, $"\nHamiltonian path exist {ans}", Encoding.UTF8);

		}

        public void DFS()
		{

			for (int i = 0; i < n; i++)
            {
				dp[i][(1 << i)] = 1;
            }

			for (int mask = 0; mask < (1 << n); mask++)
            {
				for (int cur = 0; cur < n; cur++)
                {
					if (dp[cur][mask] == 1)
                    {
						foreach (var x in adjecency[cur])
                        {
							int setbit = (mask >> x) & 1;

							if (setbit != 1)
                            {
								dp[x][(mask | (1 << x))] = 1;
                            }
                        }
                    }
                }
            }
		}

    }
}
