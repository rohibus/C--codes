using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DigitDP
{
    public class MagicNumber
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[][][] dp;
        int digit;
        int mod;
        string n;
        int res_mod = 1000000007;

        public MagicNumber(List<string> list)
        {
            mod = Convert.ToInt32(list[0]);
            digit  = Convert.ToInt32(list[1]);
            var a = AMinOne(list[2].Trim('\r'));
            var b = list[3].Trim('\r');

            var result = SolveStr(b) - SolveStr(a);
            File.AppendAllText(outputPath, $"\nMagicNumber {digit} from {a} to {b} is {result} -- ", Encoding.UTF8);
        }

        public string AMinOne(string s)
        {
            var arr = s.ToCharArray();
            int len = s.Length-1;

            while (arr[len] == '0')
            {
                arr[len] = '9';
                len--;
            }

            arr[len]--;

            return new string(arr);
        }

        public int SolveStr(string s)
        {
            n = s;

            dp = new int[10][][];
            for (int i = 0; i < 10; i++)
            {
                dp[i] = new int[2][];
                dp[i][0] = new int[mod];
                dp[i][1] = new int[mod];

                Array.Fill(dp[i][0], -1);
                Array.Fill(dp[i][1], -1);
            }

            return Solve(0, true, 0);
        }

        //O(n*n*n)
        public int Solve(int index, bool last, int sum_mod)
        {
            if (index == n.Length)
            {
                if (sum_mod == 0)
                    return 1;
                else
                    return 0;
            }

            int lastIndex = last ? 1 : 0;

            if (dp[index][lastIndex][sum_mod] != -1)
            {
                return dp[index][lastIndex][sum_mod];
            }
                
            int ans = 0;

            if (index % 2 == 1)
            {
                if (digit <= n[index] - '0')
                {
                    ans += Solve(index + 1, (last && (n[index] - '0' == digit)), (sum_mod * 10 + digit) % mod);
                    ans %= res_mod;
                }
            }
            else
            {
                int till = last ? n[index] - '0' : 9;

                for (int i = 0; i <= till; i++)
                {
                    if (i == digit)
                        continue;

                    ans += Solve(index + 1, (last && i == till), (sum_mod * 10 + i) % mod);
                    ans %= res_mod;
                }
            }

            dp[index][lastIndex][sum_mod] = ans;
            return ans;
        }

    }
}
