using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;

namespace AutoFixture.NodaTime.Xunit2
{
    public sealed class NodaTimeAutoDataAttribute : AutoDataAttribute
    {
        public NodaTimeAutoDataAttribute()
            : base(new Fixture().Customize(new NodaTimeCustomization()))
        {
        }
    }    
}
