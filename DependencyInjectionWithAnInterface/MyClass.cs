using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class MyClass : IMyClass
    {
        public MyClass()
        {
            MyClass.id++;
        }

        private static int id = -1;

        public void HelloWorld()
        {
            Console.WriteLine("Hello from MyClass{0}", id);
        }
    }
}
