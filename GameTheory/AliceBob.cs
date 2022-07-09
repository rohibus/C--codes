using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.GameTheory
{
    public class AliceBob
    {
		string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int n;

		public AliceBob(List<string> list)
		{
			int[] mn = list[0].Split(' ').Select(x1 => Convert.ToInt32(x1)).ToArray();
			n = mn[0];


			var ans = Game(n);

			File.AppendAllText(outputPath, $"\nAlice wins  {ans}", Encoding.UTF8);

		}

		public bool Game(int a)
		{
			/*if (n % 4 == 0)
				return false;
			else
				return true;*/

			// for mesere rule (n % 4 == 1) return false;

			if (a == 0)
				return false;

			if (a <= 3)
				return true;

			bool[] dp = new bool[n + 1];

			dp[0] = false;
			dp[1] = dp[2] = dp[3] = true;

			for (int i = 4; i <= n; i++)
			{
				dp[i] = !(dp[i - 1] && dp[i - 2] && dp[i - 3]);
			}

			return dp[n];
		}
	}
}
