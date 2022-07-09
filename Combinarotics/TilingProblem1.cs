using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class TilingProblem1
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        //int[] dp;

        public TilingProblem1(List<string> list)
        {
            File.AppendAllText(outputPath, $"TilingProblem 1 -- \n", Encoding.UTF8);

            var n = Convert.ToInt32(list[0]);

            //dp = new int[n+1];
            var result = Solve(n);

            File.AppendAllText(outputPath, $"Output {result} -- \n", Encoding.UTF8);
        }

        public int Solve(int n)
        {
            if (n == 0)
                return 0;

            int pre = 0;
            int cur = 1;

            for (int i = 1; i <= n; i++)
            {
                int temp = pre + cur;
                pre = cur;
                cur = temp;
            }

            return cur;
        }
    }
}
