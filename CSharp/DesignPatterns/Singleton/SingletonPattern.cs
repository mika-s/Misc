namespace DesignPatterns.Singleton
{
    public static class SingletonPattern
    {
        public static void TestSingletonPattern()
        {
            LazyNonThreadSafeSingleton singleton1 = LazyNonThreadSafeSingleton.GetInstance();
            LazyNonThreadSafeSingleton singleton2 = LazyNonThreadSafeSingleton.GetInstance();

            NonLazyThreadSafeSingleton singleton3 = NonLazyThreadSafeSingleton.GetInstance();
            NonLazyThreadSafeSingleton singleton4 = NonLazyThreadSafeSingleton.GetInstance();
        }
    }
}
