using Booking.BuildingBlocks.Presentation;
using FluentAssertions;
using NetArchTest.Rules;

namespace UserAccesssModuleArchitectureTests
{
    public class PresentationTests : BaseTest
    {
        [Fact]
        public void Presentation_ShoulNotHave_Dependencis_OnOtherProjects()
        {
            //Arrange
            var otherProjects = new[] {
                UserAccessInfrastructureNamespace,
                AccommodationApplicationNamespace ,
                AccommodationDomainNamespace ,
                AccommodationInfrastructureNamespace ,
                AccommodationPresentationNamespace ,
                CommerceApplicationNamespace ,
                CommerceDomainNamespace ,
                CommerceInfrastructureNamespace ,
                CommercePresentationNamespace ,
                BuildingBlocksInfrastructureNamespace,
                StartupProjectNamespace
            };

            //Act
            var testResult = Types.InAssembly(UserAccessPresentationAssembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();

            // Assert 
            testResult.IsSuccessful.Should().BeTrue();

        }

        [Fact]
        public void Requests_ShouldBe_Sealed()
        {
            //Arrange

            var testResult = Types.InAssembly(UserAccessPresentationAssembly).That().HaveNameEndingWith("Request").Should().BeSealed().GetResult();
            // Assert 
            testResult.IsSuccessful.Should().BeTrue();

        }


        [Fact]
        public void Controllers_ShouldHave_ControllerPostfix()
        {
            //Arrange

            var testResult = Types.InAssembly(UserAccessPresentationAssembly).That().Inherit(typeof(ApiController)).Should().HaveNameEndingWith("Controller").GetResult();
            // Assert 
            testResult.IsSuccessful.Should().BeTrue();

        }

        [Fact]
        public void Controllers_ShouldHaveDependency_OnMediator()
        {
            //Arrange
            var testResult = Types.InAssembly(UserAccessPresentationAssembly).That().Inherit(typeof(ApiController)).Should().HaveDependencyOn("MediatR").GetResult();

            // Assert 
            testResult.IsSuccessful.Should().BeTrue();

        }
    }
}
