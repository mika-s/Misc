using System;
using System.Windows.Input;

namespace DesignPatterns.GoF.Behavioral.Command
{
    public sealed class MarkCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine($"Marking text: {(string)parameter}");
        }
    }
}
