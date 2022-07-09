using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class GoodSequence
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[] dp = new int[10000];

        public List<int> GivePrimeDivisors(int n)
        {
            List<int> result = new List<int>();

            for (int i = 2; i*i <= n; i++)
            {
                if (n % i == 0)
                {
                    result.Add(i);
                    while (n % i == 0)
                    {
                        n /= i;
                    }
                }
            }

            if (n > 1)
            {
                result.Add(n);
            }

            return result;
        }

        public GoodSequence(List<string> list)
        {
            var nums = list[0].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            var n = nums.Length;
            File.AppendAllText(outputPath, $"\nGoodSequence for input {n} -- \n", Encoding.UTF8);

            var result = Solve(nums, n);

            File.AppendAllText(outputPath, $"{result} -- ", Encoding.UTF8);
        }

        //O(n*n*n)
        public int Solve(int[] nums, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var primeDivisors = GivePrimeDivisors(nums[i]);

                int bestEnding = 0;

                foreach (var item in primeDivisors)
                {
                    bestEnding = Math.Max(bestEnding, dp[item]);
                }

                foreach (var item in primeDivisors)
                {
                    dp[item] = bestEnding + 1;
                }
            }

            return dp.Max();
        }

    }
}
