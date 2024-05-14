using Booking.BuildingBlocks.Application.CQRS;
using FluentAssertions;
using NetArchTest.Rules;
using UserAccesssModuleArchitectureTests;

namespace CommerceModuleArchitectureTests
{
    public class ApplicationTests : BaseTest
    {
        [Fact]
        public void Application_ShoulNotHave_Dependencis_OnOtherProjects()
        {

            var otherProjects = new[] {
                CommerceInfrastructureNamespace ,
                CommercePresentationNamespace ,
                UserAccessInfrastructureNamespace ,
                UserAccessPresentationNamespace ,
                UserAccessDomainNamespace ,
                UserAccessApplicationNamespace,
                AccommodationApplicationNamespace ,
                AccommodationDomainNamespace ,
                AccommodationInfrastructureNamespace ,
                AccommodationPresentationNamespace ,
                BuildingBlocksPresentationNamespace ,
                BuildingBlocksInfrastructureNamespace ,
                StartupProjectNamespace
            };


            var testResult = Types
                .InAssembly(CommerceApplicationAssembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();


            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Commands_Should_BeSealed_And_HaveCommandPostfix()
        {

            var result = Types.InAssembly(CommerceApplicationAssembly)
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

            var result = Types.InAssembly(CommerceApplicationAssembly)
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

            var testResult = Types.InAssembly(CommerceApplicationAssembly)
                .That().HaveNameEndingWith("Handler")
                .Should()
                .HaveDependencyOn(CommerceDomainNamespace)
                .GetResult();


            testResult.IsSuccessful.Should().BeTrue();

        }
    }
}
