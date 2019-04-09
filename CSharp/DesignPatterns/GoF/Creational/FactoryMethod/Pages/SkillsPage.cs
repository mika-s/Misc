namespace DesignPatterns.GoF.Creational.FactoryMethod
{
    public sealed class SkillsPage : IPage
    {
        public SkillsPage()
        {
            Title = "Skills:";
            Content = string.Empty;
        }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
