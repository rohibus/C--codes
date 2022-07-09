using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class PalindromePartition
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        public string str;
        public Dictionary<int, List<IList<string>>> map;

        public PalindromePartition(string s)
        {
            map = new Dictionary<int, List<IList<string>>>();

            File.AppendAllText(outputPath, $"Print all palindrome partitions of string    " + s + " \n", Encoding.UTF8);
            str = s;

            var result = SolvePartition(0);

            foreach (var item in result)
            {
                var temp = string.Join(",", item);
                File.AppendAllText(outputPath, temp + "\n", Encoding.UTF8);
            }   
            
        }

        public List<IList<string>> SolvePartition(int index)
        {
            if (index == str.Length)
            {
                return new List<IList<string>>();
            }

            if (map.ContainsKey(index))
            {
                //return map[index];
            }

            var answer = new List<IList<string>>();

            for (int i = index; i < str.Length; i++)
            {
                if (IsPalindrome(str.Substring(index, i - index + 1)))
                {
                    List<IList<string>> ans = SolvePartition(i+1);
                    var left = str.Substring(index, i - index + 1);

                    foreach (var item in ans)
                    {
                        item.Insert(0, left);
                    }

                    if (ans.Count == 0)
                    {
                        ans.Add(new List<string> { left });
                    }

                    foreach(var item in ans)
                    {
                        answer.Add(item);
                    }
                }
            }
            
            if (map.ContainsKey(index))
                map.Remove(index);
            map.Add(index, answer);
            

            return map[index];
        }

        public bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length-1;

            while (left < right)
            {
                if (s[left] != s[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}
