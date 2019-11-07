using FluentAssertions;
using NodaTime;
using System;
using System.Reflection;
using Xunit;

namespace AutoFixture.NodaTime.Tests
{
    public class LocalDateGeneratorTests
    {
        [Fact]
        public void CreateLocalDate_ThrowsException()
        {
            // Arrange
            var fixture = new Fixture();

            // Act
            Action action = () => fixture.Create<LocalDate>();

            // Assert
            action.Should().Throw<Exception>(because: "LocalDate is not supported out of the box");
        }

        [Fact]
        public void CreateLocalDate_WithGenerator_ReturnsValue()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customizations.Add(new LocalDateGenerator());

            // Act
            var date = fixture.Create<LocalDate>();

            // Assert
            date.Should().BeOfType<LocalDate>(because: "the requested type was LocalDate");
            date.Should().BeGreaterThan(default(LocalDate), because: "the generated date should be today");
        }

        [Fact]
        public void CreateLocalDate_WithRegisteredCreator_ReturnsValue()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Register(() => LocalDate.FromDateTime(DateTime.Today));

            // Act
            var date = fixture.Create<LocalDate>();

            // Assert
            date.Should().BeOfType<LocalDate>(because: "the requested type was LocalDate");
            date.Should().BeGreaterThan(default(LocalDate), because: "the generated date should be today");
        }        
    }
}
