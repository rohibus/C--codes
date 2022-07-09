using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DpOnBitMask
{
    public class GenerateAllSubSets
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
		int n;
		string s;

        public GenerateAllSubSets(List<string> list)
        {
            s = list[0];
            n = s.Length;
			File.AppendAllText(outputPath, $"\nGenerate All subsets of {s}", Encoding.UTF8);
			Solve();

		}

        public void Solve()
		{
			for (int i = 0; i < (1 << n); i++)
			{
				string ans = "";
				for (int j = 0; j < n; j++)
				{
					if (((i>>j) & 1) == 1)
					{
						ans += s[j];
					}
				}
				File.AppendAllText(outputPath, $"\n{ans}", Encoding.UTF8);
			}
		}

    }
}
