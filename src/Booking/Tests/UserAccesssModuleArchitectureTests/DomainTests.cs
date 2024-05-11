using Booking.BuildingBlocks.Domain;
using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;

namespace UserAccesssModuleArchitectureTests
{
    public class DomainTests : BaseTest
    {

        [Fact]
        public void Domain_ShoulNotHave_Dependencis_OnOtherProjects()
        {
            //Arrange
            var otherProjects = new[] {
                UserAccessInfrastructureNamespace ,
                UserAccessApplicationNamespace ,
                UserAccessPresentationNamespace ,
                AccommodationApplicationNamespace ,
                AccommodationDomainNamespace ,
                AccommodationInfrastructureNamespace ,
                AccommodationPresentationNamespace ,
                CommerceApplicationNamespace ,
                CommerceDomainNamespace ,
                CommerceInfrastructureNamespace ,
                CommercePresentationNamespace ,
                BuildingBlocksApplicationNamespace ,
                BuildingBlocksPresentationNamespace ,
                BuildingBlocksInfrastructureNamespace ,
                StartupProjectNamespace
            };

            //Act
            var testResult = Types.InAssembly(UserAccessDomainAssembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();

            // Assert 
            testResult.IsSuccessful.Should().BeTrue();

        }

        [Fact]
        public void DomainEvents_Should_BeSealed()
        {

            var result = Types.InAssembly(UserAccessDomainAssembly)
                .That()
                .Inherit(typeof(DomainEvent))
                .Should()
                .BeSealed()
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void DomainEvents_Should_HaveDomainEventPostfix()
        {
            var result = Types.InAssembly(UserAccessDomainAssembly)
                .That()
                .Inherit(typeof(DomainEvent))
                .Should()
                .HaveNameEndingWith("DomainEvent")
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void EntitiesShouldHavePrivateParameterlessConstructor()
        {
            var entityTypes = Types.InAssembly(UserAccessDomainAssembly)
                                    .GetTypes()
                                    .Where(x => x.IsSubclassOf(typeof(Entity<Guid>)) || x.IsSubclassOf(typeof(Entity<int>)));


            var failingTypes = new List<Type>();

            foreach (var entityType in entityTypes)
            {
                var constuctors = entityType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);


                if (!constuctors.Any(x => x.IsPrivate && x.GetParameters().Length == 0))
                {
                    failingTypes.Add(entityType);
                }

            }

            failingTypes.Should().BeEmpty();
        }

        [Fact]
        public void EntitySetters_ShouldBePrivate()
        {
            var entityTypes = Types.InAssembly(UserAccessDomainAssembly)
                                   .GetTypes()
                                   .Where(x => x.IsSubclassOf(typeof(Entity<Guid>)) || x.IsSubclassOf(typeof(Entity<int>)));

            var failingTypes = new List<Type>();

            foreach (var entityType in entityTypes)
            {
                var properties = entityType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                foreach (var property in properties)
                {
                    var setter = property.GetSetMethod(nonPublic: true);
                    if (setter == null)
                        continue;
                    if (setter.IsPublic)
                    {
                        failingTypes.Add(entityType);
                    }
                }
            }

            failingTypes.Should().BeEmpty();
        }

        [Fact]
        public void EntityConstructors_ShouldBePrivate()
        {
            var entityTypes = Types.InAssembly(UserAccessDomainAssembly)
                                    .GetTypes()
                                    .Where(x => x.IsSubclassOf(typeof(Entity<Guid>)) || x.IsSubclassOf(typeof(Entity<int>)));


            var failingTypes = new List<Type>();

            foreach (var entityType in entityTypes)
            {
                var constuctors = entityType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

                if (!constuctors.Any(x => x.IsPrivate))
                {
                    failingTypes.Add(entityType);
                }

            }

            failingTypes.Should().BeEmpty();
        }
    }
}
