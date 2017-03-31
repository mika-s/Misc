namespace DesignPatterns.FactoryMethod
{
    public sealed class ConclusionPage : IPage
    {
        public ConclusionPage()
        {
            Title = "Conclusion:";
            Content = string.Empty;
        }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
