using Ploeh.AutoFixture.Xunit2;
using Xunit;
using Xunit.Sdk;

namespace AutoFixture.NodaTime.Xunit2
{
    public sealed class InlineNodaTimeAutoDataAttribute : CompositeDataAttribute
    {
        public InlineNodaTimeAutoDataAttribute(params object[] values)
            : base(new InlineDataAttribute(values), new NodaTimeAutoDataAttribute())
        {
        }
    }
}
