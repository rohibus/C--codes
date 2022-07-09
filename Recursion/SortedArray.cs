using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class SortedArray
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        
		int[] nums;
        public SortedArray(int[] num)
        {
			nums = num;
			
            bool ans = Solve(Int32.MinValue, 0);
			Console.WriteLine("Is Array Sorted " + ans);
        }
		
        public void Solve(int pre, int index)
        {
			if (index == nums.length)
				return true;
			
            return pre <= nums[index] && Solve(nums[index], index+1);
        }
    }
}
