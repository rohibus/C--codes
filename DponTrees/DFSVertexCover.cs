using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnTrees
{
    public  class DFSVertexCover
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[][] dp;
        List<int>[] adjencyList;

        public DFSVertexCover(List<string> list)
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

            for (int i = 1; i < n; i++)
            {
                var item = list[i].Split(' ').Select(x => Convert.ToInt32(x)).ToList();
                adjencyList[item[0]].Add(item[1]);
                adjencyList[item[1]].Add(item[0]);
            }

            DFS(1, 0);

            int result = Math.Min(dp[1][0], dp[1][1]);

            File.AppendAllText(outputPath, $"\nVertexCover for {n} nodes result = {result}", Encoding.UTF8);
        }

        //O(n*n*n)
        public void DFS(int current, int parent)
        {
            dp[current][0] = 0;
            dp[current][1] = 1;

            foreach (var child in adjencyList[current])
            {
                if (child != parent)
                {
                    DFS(child, current);

                    dp[current][0] += dp[child][1];
                    dp[current][1] += Math.Min(dp[child][0], dp[child][1]);
                }
            }
        }
    }
}
