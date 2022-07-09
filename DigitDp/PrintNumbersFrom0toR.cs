using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.DigitDP
{
    public class PrintNumbersFrom0toR
    {

        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";
        string s;

        public PrintNumbersFrom0toR(List<string> list)
        {
            s = list[0].Trim('\r');
            File.AppendAllText(outputPath, $"\nPrint numbers from 0 to {s} -- \n", Encoding.UTF8);
            Solve(0, "", true);
        }

 
        public void Solve(int index, string ans, bool last)
        {
            if (index == s.Length)
            {
                File.AppendAllText(outputPath, $"{ans} \n", Encoding.UTF8);
                return;
            }
            int till = last ? s[index] - '0' : 9;

            for (int i = 0; i <= till; i++)
            {
                Solve(index + 1, ans + i.ToString(), (last && (i == till)));
            }
        }

    }
}
