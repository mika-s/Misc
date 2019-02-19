using DesignPatterns.Command;
using DesignPatterns.FactoryMethod;
using DesignPatterns.FluentInterfaceWithContext;
using DesignPatterns.FluentInterfaceWithExtMethods;
using DesignPatterns.Prototype;
using DesignPatterns.SimpleFactory;
using DesignPatterns.Singleton;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandPattern.TestCommandPattern();

            //SimpleFactoryPattern.TestSimpleFactory();

            //FactoryMethodPattern.TestFactoryMethod();

            //SingletonPattern.TestSingletonPattern();

            //PrototypePattern.TestPrototypePattern();

            //FluentInterfacePatternWithContext.TestFluentInterfacePattern();

            //FluentInterfacePatternWithExtMethods.TestFluentInterfacePattern();
        }
    }
}
