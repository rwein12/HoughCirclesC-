using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter image path");
            string path = Console.ReadLine();
            OpenCVCircleManager.ProcessCircleImage(path);
        }

    }
}
