using AutoFixture;

namespace AutoFixture.NodaTime
{
    public class NodaTimeCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new LocalDateGenerator());
            fixture.Customizations.Add(new LocalTimeGenerator());
            fixture.Customizations.Add(new LocalDateTimeGenerator());
        }
    }
}
