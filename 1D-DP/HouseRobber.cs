using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    
    public class HouseRobber
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";

        public HouseRobber(string s)
        {
            var list = s.Split(' ').Select(x => Convert.ToInt32(x)).ToList();

            File.AppendAllText(outputPath, $"\nMaximum amount of money robber from {list.Count()} houses " + s + " \n", Encoding.UTF8);

            var count = Solve(list);
            File.AppendAllText(outputPath, count.ToString(), Encoding.UTF8);
        }

        public int Solve(List<int> list)
        {
            int pre2 = 0;
            int pre1 = list[0];

            for (int i = 1; i < list.Count(); i++)
            {
                int current = Math.Max(pre2 + list[i], pre1);
                pre2 = pre1;
                pre1 = current;
            }

            return pre1;
        }
    }
}
