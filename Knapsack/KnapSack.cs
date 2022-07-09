using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class KnapSack
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        public int[][] dp;

        public KnapSack(List<string> list)
        {
            var W = Convert.ToInt32(list[0]);
            int[] val = list[1].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int[] Wt = list[2].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            dp = new int[val.Length][];

            for (int i = 0; i < val.Length; i++)
            {
                dp[i] = new int[W+1];
                Array.Fill(dp[i], -1);
            }

            File.AppendAllText(outputPath, $"\nKnapSack Output  \n", Encoding.UTF8);

            int answer = Solve(W, Wt, val, val.Length-1);
            File.AppendAllText(outputPath, answer.ToString(), Encoding.UTF8);
        }

        public int Solve(int W, int[] wt, int[] val, int index)
        {
            if (W == 0 || index == -1)
                return 0;

            if (dp[index][W] != -1)
                return dp[index][W];

            int ans = 0;

            if (W - wt[index] >= 0)
            {
                //ans = val[index] + Solve(W - wt[index], wt, val, index); for repetition allowed
                ans = val[index] + Solve(W - wt[index], wt, val, index - 1);
            }

            ans = Math.Max(ans, Solve(W, wt, val, index - 1));

            dp[index][W] = ans;

            return ans;

            /*int[,] dp = new int[wt.Length + 1, W + 1];

            for (int i = 0; i <= wt.Length; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        dp[i, w] = 0;

                    else if (wt[i - 1] <= w)
                    {
                        dp[i, w] = Math.Max(val[i - 1] + dp[i - 1, w - wt[i - 1]], dp[i - 1, w]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            return dp[wt.Length, W];*/
        }
    }
}
