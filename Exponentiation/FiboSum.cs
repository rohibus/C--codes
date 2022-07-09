using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Exponentiation
{
    public class FiboSum
    {
		string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int n;
		long mod = 100000000 + 7;
		

		public FiboSum(List<string> list)
		{
			int[] mn = list[0].Split(' ').Select(x1 => Convert.ToInt32(x1)).ToArray();
			n = mn[0];
			int m = mn[1];


			long ans1 = Fibo(m);
			long ans2 = Fibo(n-1);
			long ans = (ans1 - ans2 + mod) % mod;

			File.AppendAllText(outputPath, $"\n FiboSum from {n} to {m} =  {ans}", Encoding.UTF8);

		}

		public class Mat
        {
			public int[][] m;
			int sz = 3;

			public Mat()
            {
				m = new int[sz][];
				for (int i = 0; i < sz; i++)
                {
					m[i] = new int[sz];
				}
            }

			public void Identity()
            {
				for (int i = 0; i < sz; i++)
                {
					m[i][i] = 1;
                }
            }

			public static Mat operator *(Mat m1, Mat m2)
            {
				int sz = 3;
				int mod = 100000000 + 7;
				Mat res = new Mat();

				for (int i = 0; i < sz; i++)
                {
					for (int j = 0; j < sz; j++)
                    {
						for (int k = 0; k < sz; k++)
                        {
							res.m[i][j] += m1.m[i][k] * m2.m[k][j];
							res.m[i][j] %= mod;
                        }
                    }
                }

				return res;
            }
        }

		public long Fibo(int n)
		{
			if (n == -1)
				return 0;
			
			if (n <= 1)
				return n;
			
			
			Mat res = new Mat();
			res.Identity();
			Mat T = new Mat();
			T.m[0][0] = T.m[0][1] = T.m[0][2] = 1;
			T.m[1][1] = T.m[1][2] = 1;
			T.m[2][1] = 1;

			

			//f(n) = T(n-2)*f(2)
			n -= 1;

			while (n > 0)
            {
				if ((n&1)==1)
                {
					res *= T;
                }
				T *= T;
				n /= 2;
            }

			return (res.m[0][0] + res.m[0][1]) % 100000007;
		}
	}
}
