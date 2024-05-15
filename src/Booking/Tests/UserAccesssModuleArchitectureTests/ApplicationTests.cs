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


            var testResult = Types
                .InAssembly(UserAccessApplicationAssembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();


            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Commands_Should_BeSealed_And_HaveCommandPostfix()
        {

            var result = Types.InAssembly(UserAccessApplicationAssembly)
                .That()
                .ImplementInterface(typeof(ICommand<>))
                .Should()
                .BeSealed()
                .And()
                .HaveNameEndingWith("Command")
                .GetResult();


            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Queries_Should_BeSealed_And_HaveQueryPostifx()
        {

            var result = Types.InAssembly(UserAccessApplicationAssembly)
                .That()
                .ImplementInterface(typeof(IQuery<>))
                .Should()
                .BeSealed()
                .And()
                .HaveNameEndingWith("Query")
                .GetResult();


            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Handlers_ShouldHave_Dependency_OnDomain()
        {

            var testResult = Types.InAssembly(UserAccessApplicationAssembly)
                .That().HaveNameEndingWith("Handler")
                .Should()
                .HaveDependencyOn(UserAccessDomainNamespace)
                .GetResult();


            testResult.IsSuccessful.Should().BeTrue();

        }
    }
}
