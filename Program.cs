using System;
using System.Web;

namespace PA_PLUGIN
{
    class Program
    {
        static void Main(string[] args)
        {
            Prefab p = Prefab.Load("INPUT FILE");
            Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}
