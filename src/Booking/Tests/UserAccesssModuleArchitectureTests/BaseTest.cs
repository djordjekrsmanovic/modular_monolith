using System.Reflection;

namespace UserAccesssModuleArchitectureTests
{
    public abstract class BaseTest
    {
        protected static readonly Assembly UserAccessDomainAssembly = typeof(Booking.UserAccess.Domain.AssemblyReference).Assembly;

        protected static readonly Assembly UserAccessApplicationAssembly = typeof(Booking.UserAccess.Application.AssemblyReference).Assembly;

        protected static readonly Assembly UserAccessInfrastructureAssembly = typeof(Booking.UserAccess.Infrastructure.AssemblyReference).Assembly;

        protected static readonly Assembly UserAccessPresentationAssembly = typeof(Booking.UserAccess.Presentation.AssemblyReference).Assembly;

        protected const string UserAccessDomainNamespace = "Booking.UserAccess.Domain";

        protected const string UserAccessInfrastructureNamespace = "Booking.UserAccess.Infrastructure";

        protected const string UserAccessApplicationNamespace = "Booking.UserAccess.Application";

        protected const string UserAccessPresentationNamespace = "Booking.UserAccess.Presentation";

        protected const string CommerceDomainNamespace = "Booking.Commerce.Domain";

        protected const string CommerceApplicationNamespace = "Booking.Commerce.Application";

        protected const string CommerceInfrastructureNamespace = "Booking.Commerce.Infrastructure";

        protected const string CommercePresentationNamespace = "Booking.Commerce.Presentation";

        protected const string AccommodationDomainNamespace = "Booking.AccommodationNS.Domain";

        protected const string AccommodationInfrastructureNamespace = "Booking.AccommodationNS.Infrastructure";

        protected const string AccommodationApplicationNamespace = "Booking.AccommodationNS.Application";

        protected const string AccommodationPresentationNamespace = "Booking.AccommodationNS.Presentation";

        protected const string BuildingBlocksDomainNamespace = "Booking.BuildingBlocks.Domain";

        protected const string BuildingBlocksApplicationNamespace = "Booking.BuildingBlocks.Application";

        protected const string BuildingBlocksInfrastructureNamespace = "Booking.BuildingBlocks.Infrastructure";

        protected const string BuildingBlocksPresentationNamespace = "Booking.BuildingBlocks.Presentation";

        protected const string StartupProjectNamespace = "Booking.App";
    }
}
