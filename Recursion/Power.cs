using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Power
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        
        public Power(int a, int n)
        {
			
            bool ans = Solve(a, n);
			Console.WriteLine("Is Array Sorted " + ans);
        }
		
        public int Solve(int a, int n)
        {
			if (n == 0)
				return 1;
			
            return a*Solve(a, n-1);
        }
		
		public int FastPower(int a, int n)
		{
			if (n == 0)
				return 1;
			
			int sub = FastPower(n/2);
			sub *= sub;
			
			if (n % 2 == 1)
			{
				return a*sub;
			}
			else
			{
				return sub;
			}
			
		}
    }
}
