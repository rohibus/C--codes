using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class CountBinaryNumbers
    {
		//101010 no consecutive number
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        
        public CountBinaryNumbers(int n)
        {
            return Count(n);
        }
		
        public int Count(int n)
        {
			if (n <= 1)
				return 1;
			
			return Count(n-1) + Count(n-2);
        }
		
    }
}
