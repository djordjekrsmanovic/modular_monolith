using FluentAssertions;
using NetArchTest.Rules;
using UserAccesssModuleArchitectureTests;

namespace AccommodationModuleArchitectureTests
{
    public class InfrastructureTests : BaseTest
    {
        private const string DbContextDependency = "AccommodationDbContext";
        private const string RepositoryNamespace = "Booking.AccommodationNS.Infrastructure.Database.Repositories";

        [Fact]
        public void Infrastructure_ShoulNotHave_Dependencis_OnOtherProjects()
        {

            var otherProjects = new[] {
                AccommodationPresentationNamespace ,
                UserAccessPresentationNamespace,
                UserAccessApplicationNamespace,
                UserAccessDomainNamespace,
                UserAccessInfrastructureNamespace,
                CommerceApplicationNamespace ,
                CommerceDomainNamespace ,
                CommerceInfrastructureNamespace ,
                CommercePresentationNamespace ,
                BuildingBlocksPresentationNamespace,
                StartupProjectNamespace
            };


            var testResult = Types.InAssembly(AccommodationInfrastructureAssembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Repositories_ShoulBe_In_RepositoriesNamespace()
        {


            var testResult = Types
                .InAssembly(UserAccessInfrastructureAssembly)
                .That()
                .HaveDependencyOn(DbContextDependency)
                .Should()
                .ResideInNamespace(RepositoryNamespace)
                .GetResult();


            testResult.IsSuccessful.Should().BeTrue();
        }



        [Fact]
        public void Repositories_Should_HaveRepositoryPostfix()
        {


            var testResult = Types
                .InAssembly(UserAccessInfrastructureAssembly)
                .That()
                .ResideInNamespace(RepositoryNamespace)
                .Should()
                .HaveNameEndingWith("Repository")
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }
    }
}
