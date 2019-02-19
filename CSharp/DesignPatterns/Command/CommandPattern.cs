namespace DesignPatterns.Command
{
    public static class CommandPattern
    {
        public static void TestCommandPattern()
        {
            TextOperation.Do(new CopyCommand(), "test copy");

            TextOperation.Do(new CutCommand(), "test cut");

            TextOperation.Do(new MarkCommand(), "test mark");

            TextOperation.Do(new PasteCommand(), "test paste");
        }
    }
}
