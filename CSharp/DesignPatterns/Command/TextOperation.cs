using System.Windows.Input;

namespace DesignPatterns.Command
{
    public static class TextOperation
    {
        public static void Do(ICommand command, string text)
        {
            command.Execute(text);
        }
    }
}
