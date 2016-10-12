using FluentAssertions;
using NodaTime;
using Ploeh.AutoFixture;
using System;
using System.Reflection;
using Xunit;

namespace AutoFixture.NodaTime.Tests
{
    public class LocalTimeGeneratorTests
    {
        [Fact]
        public void CreateLocalTime_ThrowsException()
        {
            // Arrange
            var fixture = new Fixture();

            // Act
            Action action = () => fixture.Create<LocalTime>();

            // Assert
            action.ShouldThrow<TargetInvocationException>(because: "LocalTime is not supported out of the box");
        }

        [Fact]
        public void CreateLocalTime_WithGenerator_ReturnsValue()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customizations.Add(new LocalTimeGenerator());

            // Act
            var time = fixture.Create<LocalTime>();

            // Assert
            time.Should().BeOfType<LocalTime>(because: "the requested type was LocalTime");
            time.Should().BeGreaterThan(default(LocalTime), because: "the generated time should be now");
        }

        [Fact]
        public void CreateLocalTime_WithRegisteredCreator_ReturnsValue()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Register(() => LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks));

            // Act
            var time = fixture.Create<LocalTime>();

            // Assert
            time.Should().BeOfType<LocalTime>(because: "the requested type was LocalTime");
            time.Should().BeGreaterThan(default(LocalTime), because: "the generated time should be now");
        }
    }
}
