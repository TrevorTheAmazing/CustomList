using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            int z = AddTwoNumbers(6, 4);
            Restaurant mcDonalds = new Restaurant("McDonald's");

            mcDonalds.ChangeName();
        }

        static int AddTwoNumbers(int x, int y)
        {
            return x + y;
        }
    }
}
