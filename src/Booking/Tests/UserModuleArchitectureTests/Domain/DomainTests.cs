using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Domain.Entities;
using NetArchTest.Rules;
using System.Reflection;

namespace UserModuleArchitectureTests.Domain
{
    internal class DomainTests
    {
        private static readonly Assembly DomainAssembly = typeof(User).Assembly;

        [Fact]
        public void DomainEvents_Should_BeSealed()
        {
            TestResult result = Types.InAssembly(DomainAssembly)
                .That()
                .Inherit(typeof(DomainEvent))
                .Should()
                .BeSealed()
                .GetResult();

            result.IsSuccessful.Should().BeTrue();

        }

    }
}
