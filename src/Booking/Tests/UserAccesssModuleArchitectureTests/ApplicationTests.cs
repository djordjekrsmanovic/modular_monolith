using Booking.BuildingBlocks.Application.CQRS;
using FluentAssertions;
using NetArchTest.Rules;

namespace UserAccesssModuleArchitectureTests
{
    public class ApplicationTests : BaseTest
    {
        [Fact]
        public void Application_ShoulNotHave_Dependencis_OnOtherProjects()
        {
            //Arrange
            var otherProjects = new[] {
                UserAccessInfrastructureNamespace ,
                UserAccessPresentationNamespace ,
                AccommodationApplicationNamespace ,
                AccommodationDomainNamespace ,
                AccommodationInfrastructureNamespace ,
                AccommodationPresentationNamespace ,
                CommerceApplicationNamespace ,
                CommerceDomainNamespace ,
                CommerceInfrastructureNamespace ,
                CommercePresentationNamespace ,
                BuildingBlocksPresentationNamespace ,
                BuildingBlocksInfrastructureNamespace ,
                StartupProjectNamespace
            };

            //Act
            var testResult = Types.InAssembly(UserAccessApplicationAssembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();

            // Assert 
            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Commands_Should_BeSealed_And_HaveCommandPostfix()
        {
            //Act
            var result = Types.InAssembly(UserAccessApplicationAssembly)
                .That()
                .ImplementInterface(typeof(ICommand<>))
                .Should()
                .BeSealed()
                .And()
                .HaveNameEndingWith("Command")
                .GetResult();

            //Asert
            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Queries_Should_BeSealed_And_HaveQueryPostifx()
        {
            //Act
            var result = Types.InAssembly(UserAccessApplicationAssembly)
                .That()
                .ImplementInterface(typeof(IQuery<>))
                .Should()
                .BeSealed()
                .And()
                .HaveNameEndingWith("Query")
                .GetResult();

            //Asert
            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Handlers_ShouldHave_Dependency_OnDomain()
        {
            //Act
            var testResult = Types.InAssembly(UserAccessApplicationAssembly)
                .That().HaveNameEndingWith("Handler")
                .Should()
                .HaveDependencyOn(UserAccessDomainNamespace)
                .GetResult();

            // Assert 
            testResult.IsSuccessful.Should().BeTrue();

        }
    }
}
