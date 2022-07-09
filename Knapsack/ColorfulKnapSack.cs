using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class ColorfulKnapSack
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        public bool[][] dp;

        public ColorfulKnapSack(List<string> list)
        {
            var W = list[0].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int[] Wt = list[1].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int[] val = list[2].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            int n = W[0];
            int m = W[1];
            int weight = W[2];

            dp = new bool[m+1][];

            var colorsArray = new Dictionary<int, List<int>>();

            for (int i = 0; i <= m; i++)
            {
                colorsArray.Add(i, new List<int>());
            }

            for (int i = 0; i < n; i++)
            {
                colorsArray[val[i]].Add(Wt[i]);
            }

            for (int i = 0; i <= m; i++)
            {
                dp[i] = new bool[weight + 1];
            }

            File.AppendAllText(outputPath, $"\nKnapSack Output  \n", Encoding.UTF8);

            int answer = Solve(weight, colorsArray);
            File.AppendAllText(outputPath, answer.ToString(), Encoding.UTF8);
        }

        public int Solve(int W, Dictionary<int, List<int>> colorsArray)
        {

            for (int i = 1; i < colorsArray.Count(); i++)
            {
                foreach (var color in colorsArray[i])
                {
                    if (color <= W && i == 1)
                    {
                        dp[i][color] = true;
                        continue;
                    }

                    for (int j = W; j >= 1; j--)
                    {
                        if (j - color >= 0)
                        {
                            dp[i][j] |= dp[i-1][j-color];
                        }
                    }
                }
            }

            int ans = 0;

            for (int i = W; i > 0; i--)
            {
                if (dp[colorsArray.Count() - 1][i])
                {
                    ans = i;
                    break;
                }
            }

            if (ans == 0)
                return -1;

            return W - ans;
        }
    }
}
