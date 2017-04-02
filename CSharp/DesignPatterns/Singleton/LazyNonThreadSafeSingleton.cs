using System;

namespace DesignPatterns.Singleton
{
    public sealed class LazyNonThreadSafeSingleton
    {
        private static LazyNonThreadSafeSingleton instance;

        private LazyNonThreadSafeSingleton()
        {
            Console.WriteLine("Creating a new lazy non-thread safe singleton.");
        }

        public static LazyNonThreadSafeSingleton GetInstance()
        {
            Console.WriteLine("Inside GetInstance() for LazyNonThreadSafeSingleton.");

            if (instance == null)
                instance = new LazyNonThreadSafeSingleton();

            return instance;
        }
    }
}
