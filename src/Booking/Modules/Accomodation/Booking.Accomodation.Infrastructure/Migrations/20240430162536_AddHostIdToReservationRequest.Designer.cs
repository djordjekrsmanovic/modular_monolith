﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Booking.AccommodationNS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booking.AccommodationNS.Infrastructure.Migrations
{
    [DbContext(typeof(AccommodationDbContext))]
    [Migration("20240430162536_AddHostIdToReservationRequest")]
    partial class AddHostIdToReservationRequest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("accomodaton")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccommodationAdditionalService", b =>
                {
                    b.Property<Guid>("AccommodationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdditionalServicesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccommodationId", "AdditionalServicesId");

                    b.HasIndex("AdditionalServicesId");

                    b.ToTable("AccommodationAdditionalService", "accomodaton");
                });

            modelBuilder.Entity("Booking.Accomodation.Domain.Entities.AvailabilityPeriodChangeTrack", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AvailabilityPeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AvailabilityPeriodChangeTrack", "accomodaton");
                });

            modelBuilder.Entity("Booking.Accomodation.Domain.Entities.GuestFavouriteAccomodation", b =>
                {
                    b.Property<Guid>("AccomodationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FavouriteAccomodationsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccomodationId", "GuestId");

                    b.HasIndex("FavouriteAccomodationsId");

                    b.HasIndex("GuestId");

                    b.ToTable("GuestFavouriteAccomodation", "accomodaton");
                });

            modelBuilder.Entity("Booking.Accomodation.Domain.Entities.GuestVisitedAccomodation", b =>
                {
                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccomodationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VisitedAccomodationsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GuestId", "AccomodationId");

                    b.HasIndex("VisitedAccomodationsId");

                    b.ToTable("GuestVisitedAccomodation", "accomodaton");
                });

            modelBuilder.Entity("Booking.Accomodation.Domain.Entities.PriceChangeTrack", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccomodationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OccuredOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PriceChangeTrack", "accomodaton");
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.Accommodation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Raiting")
                        .HasColumnType("float");

                    b.Property<bool>("ReservationApprovalRequired")
                        .HasColumnType("bit");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "Booking.Booking.Domain.Entities.Accommodation.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Capacity", "Booking.Booking.Domain.Entities.Accommodation.Capacity#GuestCapacity", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("MaxGuestNumber")
                                .HasColumnType("int");

                            b1.Property<int>("MinGuestNumber")
                                .HasColumnType("int");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PricePerGuest", "Booking.Booking.Domain.Entities.Accommodation.PricePerGuest#Money", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<double>("Ammount")
                                .HasColumnType("float");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");
                        });

                    b.HasKey("Id");

                    b.HasIndex("HostId");

                    b.ToTable("Accommodation", "accomodaton");
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.AdditionalService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("AdditionalService", "accomodaton");
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.AvailabilityPeriod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccommodationId")
                        .HasColumnType("uniqueidentifier");

                    b.ComplexProperty<Dictionary<string, object>>("Price", "Booking.Booking.Domain.Entities.AvailabilityPeriod.Price#Money", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<double>("Ammount")
                                .HasColumnType("float");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Slot", "Booking.Booking.Domain.Entities.AvailabilityPeriod.Slot#DateTimeSlot", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<DateTime>("End")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("datetime2");
                        });

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("AvailabilityPeriod", "accomodaton");
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Guest", "accomodaton");
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.Host", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccommodationLimit")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubscriptionExpirationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Host", "accomodaton");
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccomodationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationId");

                    b.ToTable("Image", "accomodaton");
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccomodationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GuestNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("GustId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ReservationRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationId");

                    b.ToTable("Reservation", "accomodaton");
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.ReservationRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccomodationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GuestNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("Price", "Booking.Booking.Domain.Entities.ReservationRequest.Price#Money", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<double>("Ammount")
                                .HasColumnType("float");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Slot", "Booking.Booking.Domain.Entities.ReservationRequest.Slot#DateTimeSlot", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<DateTime>("End")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("datetime2");
                        });

                    b.HasKey("Id");

                    b.HasIndex("AccomodationId");

                    b.HasIndex("GuestId");

                    b.ToTable("ReservationRequest", "accomodaton");
                });

            modelBuilder.Entity("AccommodationAdditionalService", b =>
                {
                    b.HasOne("Booking.Booking.Domain.Entities.Accommodation", null)
                        .WithMany()
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Booking.Domain.Entities.AdditionalService", null)
                        .WithMany()
                        .HasForeignKey("AdditionalServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Accomodation.Domain.Entities.AvailabilityPeriodChangeTrack", b =>
                {
                    b.OwnsOne("Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects.Money", "NewPrice", b1 =>
                        {
                            b1.Property<Guid>("AvailabilityPeriodChangeTrackId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Ammount")
                                .HasColumnType("float");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");

                            b1.HasKey("AvailabilityPeriodChangeTrackId");

                            b1.ToTable("AvailabilityPeriodChangeTrack", "accomodaton");

                            b1.WithOwner()
                                .HasForeignKey("AvailabilityPeriodChangeTrackId");
                        });

                    b.OwnsOne("Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects.DateTimeSlot", "NewTimeSlot", b1 =>
                        {
                            b1.Property<Guid>("AvailabilityPeriodChangeTrackId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("End")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("datetime2");

                            b1.HasKey("AvailabilityPeriodChangeTrackId");

                            b1.ToTable("AvailabilityPeriodChangeTrack", "accomodaton");

                            b1.WithOwner()
                                .HasForeignKey("AvailabilityPeriodChangeTrackId");
                        });

                    b.OwnsOne("Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects.Money", "OldPrice", b1 =>
                        {
                            b1.Property<Guid>("AvailabilityPeriodChangeTrackId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Ammount")
                                .HasColumnType("float");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");

                            b1.HasKey("AvailabilityPeriodChangeTrackId");

                            b1.ToTable("AvailabilityPeriodChangeTrack", "accomodaton");

                            b1.WithOwner()
                                .HasForeignKey("AvailabilityPeriodChangeTrackId");
                        });

                    b.OwnsOne("Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects.DateTimeSlot", "OldTimeSlot", b1 =>
                        {
                            b1.Property<Guid>("AvailabilityPeriodChangeTrackId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("End")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("datetime2");

                            b1.HasKey("AvailabilityPeriodChangeTrackId");

                            b1.ToTable("AvailabilityPeriodChangeTrack", "accomodaton");

                            b1.WithOwner()
                                .HasForeignKey("AvailabilityPeriodChangeTrackId");
                        });

                    b.Navigation("NewPrice")
                        .IsRequired();

                    b.Navigation("NewTimeSlot")
                        .IsRequired();

                    b.Navigation("OldPrice")
                        .IsRequired();

                    b.Navigation("OldTimeSlot")
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Accomodation.Domain.Entities.GuestFavouriteAccomodation", b =>
                {
                    b.HasOne("Booking.Booking.Domain.Entities.Accommodation", null)
                        .WithMany()
                        .HasForeignKey("FavouriteAccomodationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Booking.Domain.Entities.Guest", null)
                        .WithMany()
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Accomodation.Domain.Entities.GuestVisitedAccomodation", b =>
                {
                    b.HasOne("Booking.Booking.Domain.Entities.Guest", null)
                        .WithMany()
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Booking.Domain.Entities.Accommodation", null)
                        .WithMany()
                        .HasForeignKey("VisitedAccomodationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Accomodation.Domain.Entities.PriceChangeTrack", b =>
                {
                    b.OwnsOne("Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects.Money", "NewPrice", b1 =>
                        {
                            b1.Property<Guid>("PriceChangeTrackId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Ammount")
                                .HasColumnType("float");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");

                            b1.HasKey("PriceChangeTrackId");

                            b1.ToTable("PriceChangeTrack", "accomodaton");

                            b1.WithOwner()
                                .HasForeignKey("PriceChangeTrackId");
                        });

                    b.OwnsOne("Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects.Money", "OldPrice", b1 =>
                        {
                            b1.Property<Guid>("PriceChangeTrackId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Ammount")
                                .HasColumnType("float");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");

                            b1.HasKey("PriceChangeTrackId");

                            b1.ToTable("PriceChangeTrack", "accomodaton");

                            b1.WithOwner()
                                .HasForeignKey("PriceChangeTrackId");
                        });

                    b.Navigation("NewPrice")
                        .IsRequired();

                    b.Navigation("OldPrice")
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.Accommodation", b =>
                {
                    b.HasOne("Booking.Booking.Domain.Entities.Host", null)
                        .WithMany()
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.AvailabilityPeriod", b =>
                {
                    b.HasOne("Booking.Booking.Domain.Entities.Accommodation", null)
                        .WithMany("AvailabilityPeriods")
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.Image", b =>
                {
                    b.HasOne("Booking.Booking.Domain.Entities.Accommodation", null)
                        .WithMany("Images")
                        .HasForeignKey("AccomodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Booking.Booking.Domain.Entities.Accommodation", null)
                        .WithMany("Reservations")
                        .HasForeignKey("AccomodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects.DateTimeSlot", "Slot", b1 =>
                        {
                            b1.Property<Guid>("ReservationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("End")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("datetime2");

                            b1.HasKey("ReservationId");

                            b1.ToTable("Reservation", "accomodaton");

                            b1.WithOwner()
                                .HasForeignKey("ReservationId");
                        });

                    b.OwnsOne("Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects.Money", "TotalPrice", b1 =>
                        {
                            b1.Property<Guid>("ReservationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Ammount")
                                .HasColumnType("float");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");

                            b1.HasKey("ReservationId");

                            b1.ToTable("Reservation", "accomodaton");

                            b1.WithOwner()
                                .HasForeignKey("ReservationId");
                        });

                    b.Navigation("Slot")
                        .IsRequired();

                    b.Navigation("TotalPrice")
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.ReservationRequest", b =>
                {
                    b.HasOne("Booking.Booking.Domain.Entities.Accommodation", null)
                        .WithMany()
                        .HasForeignKey("AccomodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Booking.Domain.Entities.Guest", null)
                        .WithMany("ReservationRequests")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.Accommodation", b =>
                {
                    b.Navigation("AvailabilityPeriods");

                    b.Navigation("Images");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Booking.Booking.Domain.Entities.Guest", b =>
                {
                    b.Navigation("ReservationRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
