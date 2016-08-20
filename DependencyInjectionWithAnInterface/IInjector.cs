using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Microsoft.Practices.Unity;

namespace ConsoleApplication2
{
    public interface IInjector
    {
        T GetInstance<T>();
    }
}
