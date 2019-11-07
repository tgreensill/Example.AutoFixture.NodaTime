using FluentAssertions;
using NodaTime;
using System;
using System.Reflection;
using Xunit;

namespace AutoFixture.NodaTime.Tests
{
    public class LocalDateTimeGeneratorTests
    {
        [Fact]
        public void CreateLocalDateTime_ThrowsException()
        {
            // Arrange
            var fixture = new Fixture();

            // Act
            Action action = () => fixture.Create<LocalDate>();

            // Assert
            action.Should().Throw<Exception>(because: "LocalDateTime is not supported out of the box");
        }

        [Fact]
        public void CreateLocalDateTime_WithGenerator_ReturnsValue()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customizations.Add(new LocalDateTimeGenerator());

            // Act
            var datetime = fixture.Create<LocalDateTime>();

            // Assert
            datetime.Should().BeOfType<LocalDateTime>(because: "the requested type was LocalDateTime");
            datetime.Should().BeGreaterThan(default(LocalDateTime), because: "the generated date time should be now");
        }

        [Fact]
        public void CreateLocalDateTime_WithRegisteredCreator_ReturnsValue()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Register(() => LocalDateTime.FromDateTime(DateTime.Now));

            // Act
            var datetime = fixture.Create<LocalDateTime>();

            // Assert
            datetime.Should().BeOfType<LocalDateTime>(because: "the requested type was LocalDateTime");
            datetime.Should().BeGreaterThan(default(LocalDateTime), because: "the generated date time should be now");
        }
    }
}
