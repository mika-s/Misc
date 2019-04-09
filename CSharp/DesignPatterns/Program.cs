using DesignPatterns.DDD.ValueObject;
using DesignPatterns.GoF.Structural.Adapter;
using DesignPatterns.GoF.Structural.Bridge;
using DesignPatterns.GoF.Behavioral.Command;
using DesignPatterns.GoF.Structural.Facade;
using DesignPatterns.GoF.Creational.FactoryMethod;
using DesignPatterns.GoF.Creational.Prototype;
using DesignPatterns.GoF.Creational.SimpleFactory;
using DesignPatterns.GoF.Creational.Singleton;
using DesignPatterns.Other.FluentInterfaceWithContext;
using DesignPatterns.Other.FluentInterfaceWithExtMethods;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueObjectPattern.TestValueObjectPattern();

            //AdapterPattern.TestAdapterPattern();

            //BridgePattern.TestBridgePattern();

            //CommandPattern.TestCommandPattern();

            //FacadePattern.TestFacadePattern();

            //SimpleFactoryPattern.TestSimpleFactory();

            //FactoryMethodPattern.TestFactoryMethod();

            //SingletonPattern.TestSingletonPattern();

            //PrototypePattern.TestPrototypePattern();

            //FluentInterfacePatternWithContext.TestFluentInterfacePattern();

            //FluentInterfacePatternWithExtMethods.TestFluentInterfacePattern();
        }
    }
}
