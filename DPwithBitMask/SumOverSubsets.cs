using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnBitMask
{
    public class SumOverSubsets
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int n, x;
		int[] weights;

        public SumOverSubsets(List<string> list)
        {
            int[] mn= list[0].Split(' ').Select(x1 => Convert.ToInt32(x1)).ToArray();
			n = mn[0];
			
			weights = new int[1<<n];

			weights = Enumerable.Range(5, (1 << n)+5).ToArray();

			//weights = list[1].Split(' ').Select(x1 => Convert.ToInt32(x1)).ToArray();
			
			int ans = Solve();
            
			File.AppendAllText(outputPath, $"\nSumOverSubsets {ans}", Encoding.UTF8);

		}

        public int Solve()
		{
			for (int bit = 0; bit < n; bit++)
			{
				for (int j = 0; j < (1<<n); j++)
				{
					if (((j>>bit)&1) == 1)
					{
						weights[j] += weights[j ^ (1<<bit)];
					}
				}
			}
			
			return weights[(1<<n)-1];
		}

    }
}
