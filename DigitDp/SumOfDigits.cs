using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DigitDP
{
    public class SumOfDigits
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[][][] dp;

        public SumOfDigits(List<string> list)
        {
            
            var a = Convert.ToInt32(list[0]);
            var b = Convert.ToInt32(list[1]);
            dp = new int[10][][];

            for (int i = 0; i < 10; i++)
            {
                dp[i] = new int[2][];
                for (int j = 0; j < 2; j++)
                {
                    dp[i][j] = new int[90];

                    for (int k = 0; k < 90; k++)
                        dp[i][j][k] = -1;
                }
            }

            //dp = Enumerable.Repeat(Enumerable.Repeat(Enumerable.Repeat(-1, 90).ToArray(), 2).ToArray(), 10).ToArray();
            var result1 = Solve(0, b.ToString(), 0, true);
            var result2 = Solve(0, (a-1).ToString(), 0, true);

            var result = result2 - result1;

            

            File.AppendAllText(outputPath, $"\nSumOfDigits of number from {a} to {b} -- {result}", Encoding.UTF8);
        }

        public int Solve(int index, string num, int sum, bool last)
        {
            if (index == num.Length)
            {
                return sum;
            }

            int lastInt = last ? 1 : 0;

            if (dp[index][lastInt][sum] != -1)
            {
                //return dp[index][lastInt][sum];
            }

            int till = last ? num[index] - '0' : 9;
            int ans = 0;

            for (int digit = 0; digit <= till; digit++)
            {
                ans += Solve(index + 1, num, sum + digit, (last && digit == till));
            }

            dp[index][lastInt][sum] = ans;

            return ans;
        }

    }
}
