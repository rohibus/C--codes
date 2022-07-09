using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class AlphaCode
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        public int[] dp;

        public string str;
        public AlphaCode(string s)
        {
            str = s;
            dp = new int[s.Length + 1];
            File.AppendAllText(outputPath, $"\nnumber of AlphaCode for input " + s + " \n", Encoding.UTF8);

            var count = Solve(0);
            File.AppendAllText(outputPath, count.ToString(), Encoding.UTF8);
        }

        public int Solve(int index)
        {
            if (index == str.Length)
                return 1;
            
            if (dp[index] != 0)
                return dp[index];

            int ans = 0;
            if (str[index] >= '1' && str[index] <= '9')
            {
                ans  += Solve(index + 1);
            }

            if (index+1 < str.Length && str[index] == '1')
            {
                ans += Solve(index + 2);
            }

            if (index + 1 < str.Length && str[index] == '2' && str[index+1] <= '6')
            {
                ans += Solve(index + 2);
            }

            dp[index] = ans;

            return dp[index];
        }
    }
}
