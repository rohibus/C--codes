using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnTrees
{
    public class VertexCover
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[][] dp;
        List<int>[] adjencyList;

        public VertexCover(List<string> list)
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
                var item = list[i].Split(' ').Select( x => Convert.ToInt32(x)).ToList();
                adjencyList[item[0]].Add(item[1]);
                adjencyList[item[1]].Add(item[0]);
            }

            int result = Math.Min(Solve(1, 1, -1), Solve(1, 0, -1));

            File.AppendAllText(outputPath, $"\nVertexCover for {n} nodes result = {result}", Encoding.UTF8);
        }

        //O(n*n*n)
        public int Solve(int current, int take, int parent)
        {
            int ans = take;

            if (dp[current][take] != -1)
                return dp[current][take];

            foreach (var child in adjencyList[current])
            {
                if (child != parent)
                {
                    if (take == 1)
                    {
                        ans += Math.Min(Solve(child, 0, current), Solve(child, 1, current));  
                    }
                    else
                    {
                        ans += Solve(child, 1, current);
                    }
                }
            }
            dp[current][take] = ans;
            return ans;
        }

    }
}
