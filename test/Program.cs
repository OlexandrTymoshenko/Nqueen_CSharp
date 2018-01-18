using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testasdsadsassda
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[2, 2] { {0,0 }, { 0,0} };
            int[,] arr2 = (int[,])arr.Clone();
            arr2[0, 0] = 1;
            Console.WriteLine(arr2[0,0]);
        }
    }
}
