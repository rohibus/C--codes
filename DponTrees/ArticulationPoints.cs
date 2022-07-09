using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnTrees
{
    public class ArticulationPoints
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[][] dp;
        List<int>[] adjencyList;
		int[] discTime;
		int[] lowTime;
		int time = 1;
        bool[] visited;
        HashSet<int> articulation;
        List<(int, int)> bridges;

        public ArticulationPoints(List<string> list)
        {
            var mn = list[0].Split(' ').Select(x => Convert.ToInt32(x)).ToList();
            var n = mn[0];
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

            discTime = new int[n+1];
			lowTime = new int[n+1];
            visited = new bool[n + 1];
            articulation = new HashSet<int>();
            bridges = new List<(int, int)>();

            for (int i = 1; i <= mn[1]; i++)
            {
                var item = list[i].Split(' ').Select( x => Convert.ToInt32(x)).ToList();
                adjencyList[item[0]].Add(item[1]);
                adjencyList[item[1]].Add(item[0]);
            }

			DFS(1, 0);

            File.AppendAllText(outputPath, $"\nBridges ", Encoding.UTF8);
            foreach (var edge in bridges)
            {
                File.AppendAllText(outputPath, $"\n{edge.Item1} -- {edge.Item2}", Encoding.UTF8);
            }

            File.AppendAllText(outputPath, $"\nArticulation points ", Encoding.UTF8);
            foreach (var point in articulation)
            {
                File.AppendAllText(outputPath, $"\n{point}", Encoding.UTF8);
            }


        }

        public void DFS(int current, int parent)
		{
            visited[current] = true;
            discTime[current] = time;
			lowTime[current] = time;
			time++;
            int child = 0;
			
			foreach (var x in adjencyList[current])
			{
				if (!visited[x])
				{
					DFS(x, current);
                    child++;
					
					lowTime[current] = Math.Min(lowTime[current], lowTime[x]);

                    if (lowTime[x] > discTime[current])
                    {
                        bridges.Add((current, x));
                    }

                    if (parent != 0 && lowTime[x] >= discTime[current])
                    {
                        articulation.Add(current);
                    }
				}
                else if (x != parent)
                {
                    //backedge
                    lowTime[current] = Math.Min(lowTime[current], discTime[x]);
                }
			}

            if (parent == 0 && child > 1)
            {
                articulation.Add(current);
            }
			
		}

    }
}
