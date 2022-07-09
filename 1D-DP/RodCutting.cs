using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class RodCutting
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";

        public int[] dp;

        public RodCutting(string s)
        {
            var list = s.Split(' ').Select(x => Convert.ToInt32(x)).ToList();

            dp = new int[list.Count() + 1];
            File.AppendAllText(outputPath, $"\n Maximum price of cutting rod of length {list.Count()} for input price array " + s + " \n", Encoding.UTF8);

            var count = Solve(list, list.Count());
            File.AppendAllText(outputPath, count.ToString(), Encoding.UTF8);
        }

        public int Solve(List<int> price, int n)
        {
            if (n == 0)
                return 0;

            if (dp[n] != 0)
                return dp[n];

            int ans = 0;

            for (int i = 1; i <= n; i++)
            {
                ans = Math.Max(ans, price[i - 1] + Solve(price, n - i));
            }

            dp[n] = ans;
            return dp[n];
        }
    }
}
