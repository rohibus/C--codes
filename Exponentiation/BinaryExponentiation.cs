using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Exponentiation
{
    public class BinaryExponentiation
    {
		string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int a, b;

		public BinaryExponentiation(List<string> list)
		{
			int[] mn = list[0].Split(' ').Select(x1 => Convert.ToInt32(x1)).ToArray();
			a = mn[0];
			b = mn[1];


			int ans = Power(a, b);

			File.AppendAllText(outputPath, $"\n{a} power {b} =  {ans}", Encoding.UTF8);

		}

		public int Power(int a, int b)
		{
			int res = 1;

			while (b > 0)
            {
				if ((b & 1) == 1)
					res *= a;
				a *= a;
				b /= 2;
            }

			return res;
		}
	}
}
