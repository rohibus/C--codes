using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Exponentiation
{
    public class FastMultiplication
    {
		string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int a, b, c;

		public FastMultiplication(List<string> list)
		{
			int[] mn = list[0].Split(' ').Select(x1 => Convert.ToInt32(x1)).ToArray();
			a = mn[0];
			b = mn[1];
			c = mn[2];

			long ans = Multiply(a, b, c);

			File.AppendAllText(outputPath, $"\n{a} * {b} =  {ans}", Encoding.UTF8);

		}

		public long Multiply(long a, long b, int c)
		{
			long res = 0;

			while (b > 0)
            {
				if ((b & 1) == 1)
                {
					res += a;
					res %= c;
				}
					
				a += a;
				a %= c;
				b /= 2;
            }

			return res;
		}
	}
}
