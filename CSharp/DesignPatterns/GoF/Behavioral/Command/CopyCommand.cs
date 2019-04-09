using System;
using System.Windows.Input;

namespace DesignPatterns.GoF.Behavioral.Command
{
    public sealed class CopyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine($"Copying text: {(string)parameter}");
        }
    }
}
