using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Plates
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[][] dp;
        int[][] prefixSum;

        public Plates(List<string> list)
        {
            File.AppendAllText(outputPath, $"\nPlates -- \n", Encoding.UTF8);

            var n = list[0].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            int rows = n[0];
            int columns = n[1];
            int platesCount = n[2];

            dp = new int[rows+1][];
            prefixSum = new int[rows + 1][];

            for (int i = 0; i <= rows; i++)
            {
                dp[i] = new int[platesCount + 1];
                prefixSum[i] = new int[platesCount + 1];
            }

            for (int i = 1; i <= rows; i++)
            {
                var values = list[i].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

                for (int j = 1; j <= columns; j++)
                {
                    prefixSum[i][j] = prefixSum[i][j-1] + values[j-1];
                }
            }

            var answer = Solve(rows, platesCount);

            File.AppendAllText(outputPath, answer.ToString() + "\n", Encoding.UTF8);
        }

        public int Solve(int rows, int plates)
        {
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= plates; j++)
                {
                    for (int k = 0; k <= Math.Min(j, k); k++)
                    {
                        dp[i][j] = Math.Max(dp[i][j], prefixSum[i][k] + dp[i - 1][j - k]);
                    }
                }
            }

            return dp[rows][plates];
        }
    }
}
