using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NqueenMPI
{
    class Program
    {
        public static int totalSolutions = 0;
        public static int num_nodes = 7;
        public static int N = 5;
        public static int M = 5;
        public static int Master = 0;
        //public static int Rank;
        static void Main(string[] args)
        {
            RecursionStart();
            Console.WriteLine(totalSolutions);
        }
        public static void Execute(Action<object> act,int nodeNumber)
        {
            Task.Factory.StartNew(act,nodeNumber);
        }
        public static bool isRankExecutable(int row,int col,int rank)
        {
            row *= N;
            col += 1;
            if (((row*col)% num_nodes) == rank)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void RecursionStart()
        {
            int currentNode = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    var tempBoard = new int[N, N];
                    tempBoard[i, j] = 1;
                       
                    if (true)//isRankExecutable(i,j, currentNode++%num_nodes))
                    {
                        Recursion(tempBoard, i+1 , 0);
                    }
                }
            }
        }
        public static void Recursion(int[,] board, int row, int col)
        {
            for (int i = row; i < N; i++)
            {
                for (int j = col; j < N; j++)
                {
                    var tempBoard = (int[,])board.Clone();

                    if (canAdd(tempBoard, i, j))
                    {
                        tempBoard[i, j] = 1;
                        if (CheckQueensCount(tempBoard))
                        {
                            totalSolutions++;
                        }
                        Recursion(tempBoard, row + 1, 0);
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
                        if (i == row || j == col)
                        {
                            return false;
                        }
                        if (((row - col) == (i - j)) || ((row + col) == (i + j)))
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
