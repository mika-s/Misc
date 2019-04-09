using System;

namespace DesignPatterns.GoF.Creational.Singleton
{
    public sealed class NonLazyThreadSafeSingleton
    {
        private static NonLazyThreadSafeSingleton instance = new NonLazyThreadSafeSingleton();

        static NonLazyThreadSafeSingleton() { }

        private NonLazyThreadSafeSingleton()
        {
            Console.WriteLine("Creating a new non-lazy thread safe singleton.");
        }

        public static NonLazyThreadSafeSingleton GetInstance()
        {
            Console.WriteLine("Inside GetInstance() for NonLazyThreadSafeSingleton.");

            return instance;
        }
    }
}
