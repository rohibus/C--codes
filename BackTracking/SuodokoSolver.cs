using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class SuodokoSolver
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";

        public SuodokoSolver(int n)
        {
            var matrix = new List<List<int>> { 
                new List<int>{ 5, 3, 0, 0, 7, 0, 0, 0, 0 },
                new List<int>{ 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                new List<int>{ 0, 9, 8, 0, 0, 0, 0, 6, 0 },

                new List<int>{ 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                new List<int>{ 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                new List<int>{ 7, 0, 0, 0, 2, 0, 0, 0, 6 },

                new List<int>{ 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                new List<int>{ 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                new List<int>{ 0, 0, 0, 0, 8, 0, 0, 7, 9 }
            };

            Solve(matrix, 0, 0, n);

        }

        public bool Solve(List<List<int>> matrix,int i, int j, int n)
        {
            if (i == n)
            {
                Print(matrix);
                return true; ;
            }

            if (j == n)
            {
                return Solve(matrix, i+1, 0, n);
            }

            if (matrix[i][j] != 0)
            {
                return Solve(matrix, i, j+1, n);
            }

            for (int no = 1; no <= n; no++)
            {
                if (IsValid(no, i, j, matrix, n))
                {
                    matrix[i][j] = no;

                    bool solveSubProblem = Solve(matrix, i, j + 1, n);

                    if (solveSubProblem)
                        return true;
                }
            }

            matrix[i][j] = 0;
            return false;
        }

        public bool IsValid(int no, int i, int j, List<List<int>> matrix, int n)
        {
            for (int k = 0; k < n; k++)
            {
                if (matrix[i][k] == no || matrix[k][j] == no)
                {
                    return false;
                }
            }

            int sx = (i / 3) * 3;
            int sy = (j / 3) * 3;

            for (int x = sx; x < sx+3; x++)
            {
                for (int y = sy; y < sy+3; y++)
                {
                    if (matrix[x][y] == no)
                        return false;
                }
            }

            return true;
        }

        public void Print(List<List<int>> matrix)
        {
            for (int i = 0; i < 9; i++)
            {
                var temp = "";
                for (int j = 0; j < 9; j++)
                {
                    temp += matrix[i][j] + "    ";
                }

                temp += "\n";
                File.AppendAllText(outputPath, temp, Encoding.UTF8);
            }
            
        }
    }
}
