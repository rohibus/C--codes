using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class NQueen
    {
        string outputPath = @"C:\Users\Rohit N\Desktop\Demo\DataStructure\DataStructure\output.txt";

        public NQueen(int n)
        {
            var board = new int[n][];

            for (int i = 0; i < n; i++)
            {
                board[i] = new int[n];
            }

            if (Solve(n, board, 0))
            {
                PrintBoard(board);
            }
            else
            {
                File.AppendAllText(outputPath, $"{n} Queens Can not be placed in {n}x{n} board" + "\n", Encoding.UTF8);
            }
        }

        public bool Solve(int n, int[][] board, int i)
        {
            if (i == n)
            {
                return true;
            }

            for (int j = 0; j < n; j++)
            {
                if (CanPlaceQueen(board, i, j, n))
                {
                    board[i][j] = 1;
                    var success = Solve(n, board, i + 1);

                    if (success == true)
                        return true;
                }

                board[i][j] = 0;
            }

            return false;
        }

        public void PrintBoard(int[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                var result = "";

                for (int j = 0; j < board.Length; j++)
                {
                    result += board[i][j] + "   ";
                }
                File.AppendAllText(outputPath, result + "\n", Encoding.UTF8);
            }
        }

        public bool CanPlaceQueen(int[][] board, int x, int y, int n)
        {
            for (int k = 0; k < x; k++)
            {
                if (board[k][y] == 1)
                    return false;
            }

            int i = x-1;
            int j = y-1;

            while (i >= 0 && j >= 0)
            {
                if (board[i][j] == 1)
                    return false;

                i--;
                j--;
            }

            i = x - 1;
            j = y + 1;

            while (i >= 0 && j < n)
            {
                if (board[i][j] == 1)
                    return false;

                i--;
                j++;
            }

            return true;
        }
    }

    
}
