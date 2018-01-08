using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nqueen_CSharp
{
    class Program
    {
        static int N = 8;
        static int noConflictsCounter=0;

        static int totalSolutions = 0;

        static void Main(string[] args)
        {
            int[] board = new int[N];
            queens(board, 0);
            Console.WriteLine(noConflictsCounter);
            Console.ReadLine();
        }

        static void queens(int[] board, int current)
        {

            int i;
            if (current == N)
            {
                totalSolutions++;
            }
            else{
                for (i = 0; i < N; i++)
                {
                    board[current] = i;
                    if (noConflicts(board, current))
                    {
                        queens(board, current + 1);
                    }
                }
            }
        }

        public static bool noConflicts(int[] board, int current)
        {
            int i;
            for (i = 0; i < current; i++)
            {
                if (board[i] == board[current])
                    return false; // same column
                if (Math.Abs(board[i] - board[current]) == (current - i))
                    return false; // same diagonal
            }
            return true;
        }
    }
}
