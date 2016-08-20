using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            GetNewInstance(Injector.instance);
            Console.ReadKey(false);
        }

        private static void GetNewInstance(IInjector injector)
        {
            try
            {
                IMyClass myClass = Injector.instance.GetInstance<IMyClass>();
                if (myClass is MyClass)
                {
                    Console.WriteLine("Is MyClass!");
                    myClass.HelloWorld();                    
                }
                else if (myClass == null)
                {
                    Console.WriteLine("object is null!");
                }
            }
            catch (ActivationException)
            {
                Console.WriteLine("Is not MyClass!");
            }
        }
    }
}
