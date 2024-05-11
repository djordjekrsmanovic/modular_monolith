using FluentAssertions;
using NetArchTest.Rules;

namespace UserAccesssModuleArchitectureTests
{
    public class InfrastructureTests : BaseTest
    {
        private const string DbContextDependency = "UserAccessDbContext";
        private const string RepositoryNamespace = "Booking.UserAccess.Infrastructure.Database.Repositories";

        [Fact]
        public void Infrastructure_ShoulNotHave_Dependencis_OnOtherProjects()
        {
            //Arrange
            var otherProjects = new[] {
                UserAccessPresentationNamespace,
                AccommodationApplicationNamespace ,
                AccommodationDomainNamespace ,
                AccommodationInfrastructureNamespace ,
                AccommodationPresentationNamespace ,
                CommerceApplicationNamespace ,
                CommerceDomainNamespace ,
                CommerceInfrastructureNamespace ,
                CommercePresentationNamespace ,
                BuildingBlocksPresentationNamespace,
                StartupProjectNamespace
            };

            //Act
            var testResult = Types.InAssembly(UserAccessInfrastructureAssembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();

            // Assert 
            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Repositories_ShoulBe_In_RepositoriesNamespace()
        {

            //Act
            var testResult = Types
                .InAssembly(UserAccessInfrastructureAssembly)
                .That()
                .HaveDependencyOn(DbContextDependency)
                .Should()
                .ResideInNamespace(RepositoryNamespace)
                .GetResult();

            // Assert 
            testResult.IsSuccessful.Should().BeTrue();
        }



        [Fact]
        public void Repositories_Should_HaveRepositoryPostfix()
        {

            //Act
            var testResult = Types
                .InAssembly(UserAccessInfrastructureAssembly)
                .That()
                .ResideInNamespace(RepositoryNamespace)
                .Should()
                .HaveNameEndingWith("Repository")
                .GetResult();

            // Assert 
            testResult.IsSuccessful.Should().BeTrue();
        }
    }
}
