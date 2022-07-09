using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DigitDP
{
    public class NumberAndSumOfDigitsDivisibleByK
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[][][][] dp;
        string n;
        int k;

        public NumberAndSumOfDigitsDivisibleByK(List<string> list)
        {
            var b = Convert.ToInt32(list[1]);
            var a = Convert.ToInt32(list[0]);
            k = Convert.ToInt32(list[2]);
            dp = new int[10][][][];

            int result = SolveStr(b) - SolveStr(a-1);

            File.AppendAllText(outputPath, $"\nNumberAndSumOfDigitsDivisibleBy {k}  from {a} to {b} is {result} -- ", Encoding.UTF8);
        }

        public int SolveStr(int num)
        {
            if (k > 90)
                return 0;

            for (int i = 0; i < 10; i++)
            {
                dp[i] = new int[2][][];
                dp[i][0] = new int[90][];
                dp[i][1] = new int[90][];

                for (int l = 0; l < 90; l++)
                {
                    dp[i][0][l] = new int[90];
                    dp[i][1][l] = new int[90];
                    Array.Fill(dp[i][0][l], -1);
                    Array.Fill(dp[i][1][l], -1);
                }
            }

            n = num.ToString();
            return Solve(0, true, 0, 0);
        }

        //O(n*n*n)
        public int Solve(int index, bool last, int sum_mod, int dig_mod)
        {
            if (index == n.Length)
            {
                if (sum_mod == 0 && dig_mod == 0)
                    return 1;
                else
                    return 0;
            }

            int lastIndex = last ? 1 : 0;

            if (dp[index][lastIndex][sum_mod][dig_mod] != -1)
            {
                return dp[index][lastIndex][sum_mod][dig_mod];
            }

            int till = last ? n[index] - '0' : 9;
            int ans = 0;

            for (int digit = 0; digit <= till; digit++)
            {
                ans += Solve(index + 1, (last && digit == till), (sum_mod * 10 + digit) % k, (dig_mod + digit) % k);
            }

            dp[index][lastIndex][sum_mod][dig_mod] = ans;
            return ans;
        }

    }
}
