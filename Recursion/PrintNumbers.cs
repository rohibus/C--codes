using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class PrintNumbers
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        
		int nums;
        public PrintNumbers(int num)
        {
			nums = num;
            Increasing(1);
			Decreasing(1);
        }
		
        public void Increasing(int i)
        {
			if (i == num+1)
				return;
			
			Console.Write(i + "	");
			Increasing(i+1);
        }
		
		public void Decreasing(int i)
        {
			if (i == num+1)
				return;
			
			Decreasing(i+1);
			Console.Write(i + "	");
        }
    }
}
