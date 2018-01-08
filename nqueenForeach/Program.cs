using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nqueenForeach
{
    class Program
    {
        public static int totalSolutions = 0;
        public static int N = 4;
        public static int M = 2;
        public static int Master = 0;
        public static int Rank;
        static void Main(string[] args)
        {
            Recursion(new int[N, N], 0, 0);
            Console.WriteLine(totalSolutions);

        }
        public static void Recursion(int[,] board, int row, int col)
        {
            for (int i = row; i < N; i++)
            {
                for (int j = col; j < N; j++)
                {
                    var tempBoard = (int[,])board.Clone();
                    
                    if (canAdd(tempBoard, i,j))
                    {
                        tempBoard[i, j] = 1;
                        if (CheckQueensCount(tempBoard))
                        {
                            totalSolutions++;
                        }
                        
                        Recursion(tempBoard, row+1, 0);
                    }
                }
            }
        }

        public static bool CheckQueensCount(int[,] board)
        {
            var queensCount = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j] == 1)
                    {
                        queensCount++;
                    }
                }
            }
            if (queensCount == M)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static bool canAdd(int[,] board, int row, int col)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j] == 1)
                    {
                        if (i == row||j==col)
                        {
                            return false;
                        }
                        if (((row-col)==(i-j))||((row+col)==(i+j)))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
