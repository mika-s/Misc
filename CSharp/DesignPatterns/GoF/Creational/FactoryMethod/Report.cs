namespace DesignPatterns.GoF.Creational.FactoryMethod
{
    public sealed class Report : Document
    {
        public override void Create()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ConclusionPage());
        }
    }
}
