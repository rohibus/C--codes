using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Exponentiation
{
    public class ModularExponentiation
    {
		string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int a, b;
		long mod = 100000000 + 7;

		public ModularExponentiation(List<string> list)
		{
			int[] mn = list[0].Split(' ').Select(x1 => Convert.ToInt32(x1)).ToArray();
			a = mn[0];
			b = mn[1];


			long ans = Power(a, b);

			File.AppendAllText(outputPath, $"\n{a} power {b} =  {ans}", Encoding.UTF8);

		}

		public long Power(long a, long b)
		{
			long res = 1;

			while (b > 0)
            {
				if ((b & 1) == 1)
                {
					res *= a;
					res %= mod;
				}
					
				a *= a;
				a %= mod;
				b /= 2;
            }

			return res;
		}
	}
}
