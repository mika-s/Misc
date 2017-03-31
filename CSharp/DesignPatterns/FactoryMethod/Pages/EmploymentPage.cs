namespace DesignPatterns.FactoryMethod
{
    public sealed class EmploymentPage : IPage
    {
        public EmploymentPage()
        {
            Title = "Employment:";
            Content = string.Empty;
        }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
