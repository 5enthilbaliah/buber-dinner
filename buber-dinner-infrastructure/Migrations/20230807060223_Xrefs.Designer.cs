﻿// <auto-generated />
using System;
using BuberDinner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuberDinner.Infrastructure.Migrations
{
    [DbContext(typeof(BuberDinnerDbContext))]
    [Migration("20230807060223_Xrefs")]
    partial class Xrefs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuberDinner.Domain.Bills.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<Guid>("DinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2(7)");

                    b.HasKey("Id");

                    b.ToTable("Bills", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.Dinners.Dinner", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("EndOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<DateTime?>("EndedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<int>("MaxGuests")
                        .HasColumnType("int");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<DateTime?>("StartedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Dinners", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.Dinners.Entities.DinnerStatusWrapper", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DinnerStatuses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6088),
                            ModifiedOn = new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6089),
                            Name = "Upcoming"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6095),
                            ModifiedOn = new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6095),
                            Name = "InProgress"
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6096),
                            ModifiedOn = new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6097),
                            Name = "Ended"
                        },
                        new
                        {
                            Id = 4,
                            CreatedOn = new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6098),
                            ModifiedOn = new DateTime(2023, 8, 7, 6, 2, 22, 914, DateTimeKind.Utc).AddTicks(6098),
                            Name = "Cancelled"
                        });
                });

            modelBuilder.Entity("BuberDinner.Domain.Dinners.Entities.ReservationStatusWrapper", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ReservationStatuses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2023, 8, 7, 6, 2, 22, 929, DateTimeKind.Utc).AddTicks(3322),
                            ModifiedOn = new DateTime(2023, 8, 7, 6, 2, 22, 929, DateTimeKind.Utc).AddTicks(3324),
                            Name = "PendingGuestConfirmation"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2023, 8, 7, 6, 2, 22, 929, DateTimeKind.Utc).AddTicks(3331),
                            ModifiedOn = new DateTime(2023, 8, 7, 6, 2, 22, 929, DateTimeKind.Utc).AddTicks(3331),
                            Name = "Reserved"
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2023, 8, 7, 6, 2, 22, 929, DateTimeKind.Utc).AddTicks(3332),
                            ModifiedOn = new DateTime(2023, 8, 7, 6, 2, 22, 929, DateTimeKind.Utc).AddTicks(3333),
                            Name = "Cancelled"
                        });
                });

            modelBuilder.Entity("BuberDinner.Domain.Hosts.Host", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Hosts", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.Menus.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.Bills.Bill", b =>
                {
                    b.OwnsOne("BuberDinner.Domain.Common.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("BillId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("money")
                                .HasColumnName("Amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("varchar(10)")
                                .HasColumnName("Currency");

                            b1.HasKey("BillId");

                            b1.ToTable("Bills");

                            b1.WithOwner()
                                .HasForeignKey("BillId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("BuberDinner.Domain.Dinners.Dinner", b =>
                {
                    b.OwnsOne("BuberDinner.Domain.Common.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("money")
                                .HasColumnName("Amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("varchar(10)")
                                .HasColumnName("Currency");

                            b1.HasKey("DinnerId");

                            b1.ToTable("Dinners");

                            b1.WithOwner()
                                .HasForeignKey("DinnerId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Dinners.Entities.Reservation", "Reservations", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("ArrivalOn")
                                .HasColumnType("datetime2(7)");

                            b1.Property<Guid>("BillId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreatedOn")
                                .HasColumnType("datetime2(7)");

                            b1.Property<int>("GuestCount")
                                .HasColumnType("int");

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("ModifiedOn")
                                .HasColumnType("datetime2(7)");

                            b1.Property<int>("ReservationStatus")
                                .HasColumnType("int");

                            b1.HasKey("Id", "DinnerId");

                            b1.HasIndex("DinnerId");

                            b1.ToTable("Reservations", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("DinnerId");
                        });

                    b.OwnsOne("BuberDinner.Domain.Dinners.ValueObjects.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("Address");

                            b1.Property<decimal>("Latitude")
                                .HasColumnType("decimal(8,6)")
                                .HasColumnName("Latitude");

                            b1.Property<decimal>("Longitude")
                                .HasColumnType("decimal(9,6)")
                                .HasColumnName("Longitude");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("LocationName");

                            b1.HasKey("DinnerId");

                            b1.ToTable("Dinners");

                            b1.WithOwner()
                                .HasForeignKey("DinnerId");
                        });

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("BuberDinner.Domain.Hosts.Host", b =>
                {
                    b.OwnsOne("BuberDinner.Domain.Common.ValueObjects.AverageRating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("NumOfRatings")
                                .HasColumnType("int")
                                .HasColumnName("NumOfRatings");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(3,2)")
                                .HasColumnName("AverageRating");

                            b1.HasKey("HostId");

                            b1.ToTable("Hosts");

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Dinners.ValueObjects.DinnerId", "DinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("HostId");

                            b1.ToTable("HostDinnerXrefs", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Menus.ValueObjects.MenuId", "MenuIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("MenuId");

                            b1.HasKey("Id");

                            b1.HasIndex("HostId");

                            b1.ToTable("HostMenuXrefs", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("DinnerIds");

                    b.Navigation("MenuIds");
                });

            modelBuilder.Entity("BuberDinner.Domain.Menus.Menu", b =>
                {
                    b.OwnsMany("BuberDinner.Domain.MenuReview.ValueObjects.MenuReviewId", "MenuReviewIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("MenuReviewId");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuReviewXrefs", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Menus.Entities.MenuSection", "Sections", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("nvarchar(1000)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id", "MenuId");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuSections", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");

                            b1.OwnsMany("BuberDinner.Domain.Menus.Entities.MenuItem", "Items", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("MenuSectionId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("MenuId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(1000)
                                        .HasColumnType("nvarchar(1000)");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.HasKey("Id", "MenuSectionId", "MenuId");

                                    b2.HasIndex("MenuSectionId", "MenuId");

                                    b2.ToTable("MenuItems", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("MenuSectionId", "MenuId");
                                });

                            b1.Navigation("Items");
                        });

                    b.OwnsOne("BuberDinner.Domain.Common.ValueObjects.AverageRating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("NumOfRatings")
                                .HasColumnType("int")
                                .HasColumnName("NumOfRatings");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(3,2)")
                                .HasColumnName("AverageRating");

                            b1.HasKey("MenuId");

                            b1.ToTable("Menus");

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Dinners.ValueObjects.DinnerId", "DinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuDinnerXrefs", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("DinnerIds");

                    b.Navigation("MenuReviewIds");

                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
