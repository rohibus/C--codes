using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class ConsecutiveSequence
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        int[] dp;

        public ConsecutiveSequence(List<string> list)
        {
            var nums = list[0].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            var n = nums.Length;
            File.AppendAllText(outputPath, $"\nConsecutiveSequence for input {n} -- \n", Encoding.UTF8);

            var result = Solve(nums, n);

            File.AppendAllText(outputPath, $"\n{result} -- ", Encoding.UTF8);
        }

        //O(n)
        public int Solve(int[] nums, int n)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i] - 1))
                {
                    map[nums[i]] = map[nums[i]-1] + 1;
                }
                else
                {
                    map.Add(nums[i], 1);
                }
            }

            var key = map.First(i => i.Value == map.Values.Max()).Key;
            var start = key - map.Values.Max() + 1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == start)
                {
                    File.AppendAllText(outputPath, $"{i} -- ", Encoding.UTF8);
                    start++;
                }
                
            }

            return map.Values.Max();
        }

    }
}
