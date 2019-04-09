using System;
using System.Windows.Input;

namespace DesignPatterns.GoF.Behavioral.Command
{
    public sealed class PasteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine($"Pasting text: {(string)parameter}");
        }
    }
}
