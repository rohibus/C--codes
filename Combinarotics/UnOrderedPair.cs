using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class UnOrderedPair
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[] dp;

        public UnOrderedPair(List<string> list)
        {
            var n = Convert.ToInt32(list[0]);
            File.AppendAllText(outputPath, $"\nUnOrderedPair for input {n} -- \n", Encoding.UTF8);

            dp = new int[n + 1];

            dp1 = new int[n + 1][];

            for (int i = 0; i <= n; i++)
            {
                dp1[i] = new int[n + 1];
                Array.Fill(dp1[i], -1);
            }

            //var result = Solve(1, n);
            for (int i = 1; i <= n; i++)
            {
                var result = Solve2(1, i);

                File.AppendAllText(outputPath, $"{result} -- ", Encoding.UTF8);
            }
        }

        //O(n*n*n)
        public int Solve(int min, int n)
        {
            if (n == 0)
                return 1;

            int ans = 0;

            for (int i = min; i <= n; i++)
            {
                ans += Solve(i, n - i);
            }

            return ans;
        }

        public int Solve1(int n)
        {
            if (n == 0)
                return 1;

            dp[0] = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    dp[j] += dp[j - i];
                }
            }

            return dp[n];
        }

        int[][] dp1;

        public int Solve2(int min, int n)
        {
            if (n == 0)
                return 1;

            if (min > n)
                return 0;

            if (min == n)
                return 1;

            if (dp1[min][n] != -1)
                return dp1[min][n];

            int ans = Solve2(min, n - min) + Solve2(min + 1, n);

            dp1[min][n] = ans;
            return ans;
        }
    }
}
