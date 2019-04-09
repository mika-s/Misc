namespace DesignPatterns.GoF.Creational.FactoryMethod
{
    public sealed class IntroductionPage : IPage
    {
        public IntroductionPage()
        {
            Title = "Introduction:";
            Content = string.Empty;
        }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
