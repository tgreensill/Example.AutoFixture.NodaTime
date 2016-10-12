using AutoFixture.NodaTime.Xunit2;
using FluentAssertions;
using NodaTime;
using Xunit;

namespace AutoFixture.NodaTime.Tests.Xunit2
{
    public class InlineNodaTimeAutoDataAttributeTests
    {
        [Theory, InlineNodaTimeAutoData]
        public void InlineDataAttribute_GeneratesLocalDate(LocalDate date)
        {
            // Assert
            date.Should().BeGreaterThan(default(LocalDate), because: "the generated date should be today");
        }

        [Theory, InlineNodaTimeAutoData]
        public void InlineDataAttribute_GeneratesLocalTime(LocalTime time)
        {
            // Assert
            time.Should().BeGreaterThan(default(LocalTime), because: "the generated time should be now");
        }

        [Theory, InlineNodaTimeAutoData]
        public void InlineDataAttribute_GeneratesLocalDateTime(LocalDateTime dateTime)
        {
            // Assert
            dateTime.Should().BeGreaterThan(default(LocalDateTime), because: "the generated date time should be now");
        }

        [Theory, InlineNodaTimeAutoData]
        public void InlineDataAttribute_GeneratesOtherTypes(int number, long bigNumber, string word, System.Guid guid)
        {
            // Assert
            word.Should().NotBeNullOrWhiteSpace(because: "the base functionality should generate a guid like string");
            number.Should().BeGreaterThan(0, because: "the base functionality should generate a random number");
            bigNumber.Should().BeGreaterThan(0, because: "the base functionality should generate a random number");
            guid.Should().NotBeEmpty(because: "the base functionality should generate a random guid");
        }
    }
}
