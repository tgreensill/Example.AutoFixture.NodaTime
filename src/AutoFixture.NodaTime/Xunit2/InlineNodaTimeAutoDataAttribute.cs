using AutoFixture.Xunit2;
using Xunit;

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
