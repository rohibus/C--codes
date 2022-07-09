using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class LongestIncreasingSubSequence
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[] dp;

        public LongestIncreasingSubSequence(List<string> list)
        {
            var nums = list[0].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            var n = nums.Length;
            File.AppendAllText(outputPath, $"\nLongestIncreasingSubSequence for input {n} -- \n", Encoding.UTF8);

            dp = new int[n + 1];
            Array.Fill(dp, 1);

            var result = Solve(n, nums);

            File.AppendAllText(outputPath, $"{result} -- ", Encoding.UTF8);
        }

        //O(n*n)
        public int Solve(int n, int[] nums)
        {

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] >= nums[j])
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);
                    }
                }
            }

            return dp.Max();
        }
    }
}
