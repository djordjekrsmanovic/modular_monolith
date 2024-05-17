using Booking.BuildingBlocks.Application.CQRS;
using FluentAssertions;
using NetArchTest.Rules;
using UserAccesssModuleArchitectureTests;

namespace AccommodationModuleArchitectureTests
{
    public class ApplicationTests : BaseTest
    {
        [Fact]
        public void Application_ShoulNotHave_Dependencis_OnOtherProjects()
        {

            var otherProjects = new[] {
                AccommodationInfrastructureNamespace ,
                AccommodationPresentationNamespace ,
                UserAccessInfrastructureNamespace ,
                UserAccessPresentationNamespace ,
                UserAccessDomainNamespace,
                UserAccessApplicationNamespace ,
                CommerceApplicationNamespace ,
                CommerceDomainNamespace ,
                CommerceInfrastructureNamespace ,
                CommercePresentationNamespace ,
                BuildingBlocksPresentationNamespace ,
                BuildingBlocksInfrastructureNamespace ,
                StartupProjectNamespace
            };


            var testResult = Types
                .InAssembly(AccommodationApplicationAssembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();


            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Commands_Should_BeSealed_And_HaveCommandPostfix()
        {

            var result = Types.InAssembly(AccommodationApplicationAssembly)
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

            var result = Types.InAssembly(AccommodationApplicationAssembly)
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

            var testResult = Types.InAssembly(AccommodationApplicationAssembly)
                .That()
                .ImplementInterface(typeof(ICommandHandler<>))
                .Or()
                .ImplementInterface(typeof(IQueryHandler<,>))
                .Should()
                .HaveDependencyOn(AccommodationDomainNamespace)
                .GetResult();


            testResult.IsSuccessful.Should().BeTrue();

        }
    }
}
