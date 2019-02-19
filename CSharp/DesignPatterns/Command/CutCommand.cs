using System;
using System.Windows.Input;

namespace DesignPatterns.Command
{
    public sealed class CutCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine($"Cutting text: {(string)parameter}");
        }
    }
}
