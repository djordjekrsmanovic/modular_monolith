using Booking.BuildingBlocks.Presentation;
using FluentAssertions;
using NetArchTest.Rules;
using UserAccesssModuleArchitectureTests;

namespace CommerceModuleArchitectureTests
{
    public class PresentationTests : BaseTest
    {
        [Fact]
        public void Presentation_ShoulNotHave_Dependencis_OnOtherProjects()
        {

            var otherProjects = new[] {
                CommerceInfrastructureNamespace,
                AccommodationApplicationNamespace ,
                AccommodationDomainNamespace ,
                AccommodationInfrastructureNamespace ,
                AccommodationPresentationNamespace ,
                UserAccessApplicationNamespace ,
                UserAccessDomainNamespace ,
                UserAccessInfrastructureNamespace ,
                UserAccessPresentationNamespace ,
                BuildingBlocksInfrastructureNamespace,
                StartupProjectNamespace
            };

            var testResult = Types
                .InAssembly(CommercePresentationAssembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();


            testResult.IsSuccessful.Should().BeTrue();

        }

        [Fact]
        public void Requests_ShouldBe_Sealed()
        {

            var testResult = Types
                .InAssembly(CommercePresentationAssembly)
                .That()
                .HaveNameEndingWith("Request")
                .Should()
                .BeSealed()
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();

        }


        [Fact]
        public void Controllers_ShouldHave_ControllerPostfix()
        {

            var testResult = Types
                .InAssembly(CommercePresentationAssembly)
                .That()
                .Inherit(typeof(ApiController))
                .Should()
                .HaveNameEndingWith("Controller")
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();

        }

        [Fact]
        public void Controllers_ShouldHaveDependency_OnMediator()
        {

            var testResult = Types
                .InAssembly(CommercePresentationAssembly)
                .That()
                .Inherit(typeof(ApiController))
                .Should()
                .HaveDependencyOn("MediatR")
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();

        }
    }
}
