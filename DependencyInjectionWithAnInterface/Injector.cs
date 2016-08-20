using SimpleInjector;
using Microsoft.Practices.Unity;
using System;
using Ninject;

namespace ConsoleApplication2
{
    public class Injector : IInjector
    {
        private Injector()
        {
            this.container = new Container();
            this.Bootstrap();
        }

        public static readonly IInjector instance = new Injector();

        private Container container;

        public T GetInstance<T>()
        {
            object instanceFound = null;

            InstanceProducer[] array = this.container.GetCurrentRegistrations();

            if (array != null)
            {
                InstanceProducer instanceProducer = null;

                try
                {
                    instanceProducer = Array.Find(array, instance => instance.ServiceType == typeof(T));
                }
                catch (ArgumentNullException)
                {
                    // TODO: add to application log, should be a singleton
                }
                finally
                {
                    if (instanceProducer != null)
                    {
                        try
                        {
                            instanceFound = this.container.GetInstance(typeof(T));
                        }
                        catch (ActivationException)
                        {
                            // TODO: add to application log, should be a singleton
                            instanceFound = default(T);
                        }
                    }
                }
            }

            return (T)instanceFound;
        }

        private void Bootstrap()
        {
            this.container.Register<IMyClass, MyClass>();
            this.container.Verify();
        }
    }
}