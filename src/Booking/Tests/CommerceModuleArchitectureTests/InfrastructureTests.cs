using FluentAssertions;
using NetArchTest.Rules;
using UserAccesssModuleArchitectureTests;

namespace CommerceModuleArchitectureTests
{
    public class InfrastructureTests : BaseTest
    {
        private const string DbContextDependency = "CommerceDbContext";
        private const string RepositoryNamespace = "Booking.Commerce.Infrastructure.Database.Repositories";

        [Fact]
        public void Infrastructure_ShoulNotHave_Dependencis_OnOtherProjects()
        {

            var otherProjects = new[] {
                CommercePresentationNamespace ,
                AccommodationApplicationNamespace ,
                AccommodationDomainNamespace ,
                AccommodationInfrastructureNamespace ,
                AccommodationPresentationNamespace ,
                UserAccessApplicationNamespace ,
                UserAccessDomainNamespace ,
                UserAccessInfrastructureNamespace ,
                UserAccessPresentationNamespace ,
                BuildingBlocksPresentationNamespace,
                StartupProjectNamespace
            };


            var testResult = Types.InAssembly(CommerceInfrastructureAssembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Repositories_ShoulBe_In_RepositoriesNamespace()
        {


            var testResult = Types
                .InAssembly(CommerceInfrastructureAssembly)
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
                .InAssembly(CommerceInfrastructureAssembly)
                .That()
                .ResideInNamespace(RepositoryNamespace)
                .Should()
                .HaveNameEndingWith("Repository")
                .GetResult();

            testResult.IsSuccessful.Should().BeTrue();
        }
    }
}
