using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class OrderedPair
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[] dp;

        public OrderedPair(List<string> list)
        {
            var n = Convert.ToInt32(list[0]);
            File.AppendAllText(outputPath, $"OrderedPair for input {n} -- \n", Encoding.UTF8);

            dp = new int[n+1];
            Array.Fill(dp, -1);
            var result = Solve(n);

            File.AppendAllText(outputPath, $"Output {result} -- \n", Encoding.UTF8);
        }

        //O(n*n)
        public int Solve(int n)
        {
            if (n == 0)
                return 1;

            if (dp[n] != -1)
                return dp[n];

            int ans = 0;

            for (int i = 1; i <= n; i++)
            {
                ans += Solve(n-i);
            }

            dp[n] = ans;
            return ans;
        }

        //O(n)
        public int Solve1(int n)
        {
            if (n == 0)
                return 1;


            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                dp[i] = sum + 1;
                sum += dp[i];
            }

            return sum;
        }

        //O(1)
        public int Solve2(int n)
        {
            return (int)Math.Pow(n-1, 2);
        }
    }
}
