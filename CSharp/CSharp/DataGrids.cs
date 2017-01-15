using System;

namespace CSharp
{
    /// <summary>
    /// A simple class for DataGrid examples.
    /// </summary>
    public sealed class SimpleDataGridExample
    {
        public SimpleDataGridExample(double property1, int property2, bool property3, string property4)
        {
            Property1 = property1;
            Property2 = property2;
            Property3 = property3;
            Property4 = property4;
        }

        public double Property1 { get; set; }

        public int Property2 { get; set; }

        public bool Property3 { get; set; }

        public string Property4 { get; set; }
    }

    public sealed class ClassWithFuncExample
    {
        public ClassWithFuncExample(double property1, int property2)
        {
            Property1 = property1;
            Property2 = property2;
        }

        public double Property1 { get; set; }

        public int Property2 { get; set; }

        public Func<DateTime,bool> FuncToRun { get; set; }

        public void RunFunc()
        {
            bool isRun = FuncToRun(DateTime.Now);
        }
    }
}
