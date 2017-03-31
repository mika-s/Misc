namespace DesignPatterns.FactoryMethod
{
    public sealed class Cv : Document
    {
        public override void Create()
        {
            Pages.Add(new EmploymentPage());
            Pages.Add(new SkillsPage());
        }
    }
}
