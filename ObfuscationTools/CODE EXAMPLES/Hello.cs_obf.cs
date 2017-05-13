using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using a0.a1;

namespace a0.a1
{
    public class a2
    {
        public string a3
        {
            get;
            private set;

        }
        public string a4;
        private const int a5 = 1;
        public a2()
        {
            Console.WriteLine("constructor");

        }
        public void a6()
        {
            int a5 = 1;
            const int a7 = 20;
            for (int a8 = 0;
            a8 < 5;
            a8++)
            {
                Console.WriteLine("Hello! =)");

            }
        }
        public void a6(string a4)
        {
            Console.WriteLine("Hello, " + a4 + "! =)");

        }
    }
    public static class a9
    {
        public static void a10()
        {

        }
    }
}
namespace a0.a11
{
    public class a12
    {
        private a2 a13 = new a2();
        public a12(a2 a14)
        {
            a13.a6();
            a9.a10();
            var a15 = a13.a3;
            a13.a4 = "Ololosh";

        }
    }
}
