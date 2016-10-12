using FluentAssertions;
using NodaTime;
using Ploeh.AutoFixture;
using System;
using System.Reflection;
using Xunit;

namespace AutoFixture.NodaTime.Tests
{
    public class NodaTimeCustomizationTests
    {
        [Fact]
        public void CreateNodaTimeType_ThrowsException()
        {
            // Arrange
            var fixture = new Fixture();

            // Act
            Action localDateAction = () => fixture.Create<LocalDate>();
            Action localTimeAction = () => fixture.Create<LocalTime>();
            Action localDateTimeAction = () => fixture.Create<LocalDateTime>();

            // Assert
            localDateAction.ShouldThrow<TargetInvocationException>(because: "LocalDate is not supported out of the box");
            localTimeAction.ShouldThrow<TargetInvocationException>(because: "LocalTime is not supported out of the box");
            localDateTimeAction.ShouldThrow<TargetInvocationException>(because: "LocalDateTime is not supported out of the box");
        }

        [Fact]
        public void CreateNodaTimeType_WithCustomization_ReturnsValues()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new NodaTimeCustomization());

            // Act
            var date = fixture.Create<LocalDate>();
            var time = fixture.Create<LocalTime>();
            var dateTime = fixture.Create<LocalDateTime>();

            // Assert
            date.Should().BeOfType<LocalDate>(because: "the requested type was LocalDate");
            time.Should().BeOfType<LocalTime>(because: "the requested type was LocalTime");
            dateTime.Should().BeOfType<LocalDateTime>(because: "the requested type was LocalDateTime");
        }
    }
}
