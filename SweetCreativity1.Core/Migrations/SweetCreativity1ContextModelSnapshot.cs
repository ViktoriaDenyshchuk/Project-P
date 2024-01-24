﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SweetCreativity1.Core.Context;

#nullable disable

namespace SweetCreativity1.Core.Migrations
{
    [DbContext(typeof(SweetCreativity1Context))]
    partial class SweetCreativity1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "57b0bc3f-9dfe-4403-a276-c16483294027",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        },
                        new
                        {
                            Id = "567b503c-ce59-4b18-80b7-ea2b76097a10",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "5b1842a6-785d-47c2-a3cd-d79b9e97af22",
                            Name = "Seller",
                            NormalizedName = "SELLER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "392dcf24-872e-4a08-b21b-559758df80ea",
                            RoleId = "567b503c-ce59-4b18-80b7-ea2b76097a10"
                        },
                        new
                        {
                            UserId = "392dcf24-872e-4a08-b21b-559758df80ea",
                            RoleId = "5b1842a6-785d-47c2-a3cd-d79b9e97af22"
                        },
                        new
                        {
                            UserId = "960bbaeb-ec6a-4a2c-ba22-2dbb3e4a0047",
                            RoleId = "5b1842a6-785d-47c2-a3cd-d79b9e97af22"
                        },
                        new
                        {
                            UserId = "f5af08d0-d871-4702-a584-69bef5f85043",
                            RoleId = "57b0bc3f-9dfe-4403-a276-c16483294027"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NameCategory")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameCategory = "Торти"
                        },
                        new
                        {
                            Id = 2,
                            NameCategory = "Тістечка"
                        },
                        new
                        {
                            Id = 3,
                            NameCategory = "Цукерки"
                        },
                        new
                        {
                            Id = 4,
                            NameCategory = "Печиво"
                        },
                        new
                        {
                            Id = 5,
                            NameCategory = "Вафлі"
                        });
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ConstructionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAtResponse")
                        .HasColumnType("datetime2");

                    b.Property<string>("TextComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Construction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Additionaly")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAtOrder")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Form")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameConstruction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserSellerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ViewDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Constructions");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ListingId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CoverPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAtListing")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Listings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CoverPath = "\\img\\listing\\no_cover.jpg",
                            CreatedAtListing = new DateTime(2024, 1, 24, 5, 14, 21, 177, DateTimeKind.Local).AddTicks(8806),
                            Description = " Це відомий і популярний торт, який складається з тонких шарів бісквіту і вершкового крему.",
                            Location = "Lviv",
                            Price = 164.99m,
                            Product = "Борошно, вершкове масло, яйця, оцет, цукор, ванільний цукор або ванільний екстракт, кукурудзяний крохмаль, вершки, сіль, прикраси (за бажанням).",
                            Title = "Торт Наполеон",
                            UserId = "960bbaeb-ec6a-4a2c-ba22-2dbb3e4a0047",
                            Weight = 1000
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CoverPath = "\\img\\listing\\no_cover.jpg",
                            CreatedAtListing = new DateTime(2024, 1, 24, 5, 14, 21, 177, DateTimeKind.Local).AddTicks(8925),
                            Description = "Гармонійне поєднання повітряного шоколадного тіста мафіну з ніжно-солодкою вершковою начинкою.",
                            Location = "Rivne",
                            Price = 179.99m,
                            Product = "Борошно пшеничне, цукор-пісок, суміш “Мафін шоколадний”, олія рослинна, меланж, вода. Начинка: згущене молоко “Іриска”з вершками.",
                            Title = "Мафіни",
                            UserId = "f5af08d0-d871-4702-a584-69bef5f85043",
                            Weight = 80
                        });
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAtOrder")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ListingId")
                        .HasColumnType("int");

                    b.Property<string>("ListingPhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOrder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceOne")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAtOrder = new DateTime(2024, 1, 24, 5, 14, 21, 177, DateTimeKind.Local).AddTicks(8993),
                            CustomerNumber = 985684335,
                            ListingId = 1,
                            NameOrder = "Торт Наполеон",
                            PriceOne = 0m,
                            Quantity = 1,
                            TotalPrice = 249.99m,
                            UserId = "392dcf24-872e-4a08-b21b-559758df80ea"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAtOrder = new DateTime(2024, 1, 24, 5, 14, 21, 177, DateTimeKind.Local).AddTicks(9000),
                            CustomerNumber = 985688735,
                            ListingId = 2,
                            NameOrder = "Торт Спартак",
                            PriceOne = 0m,
                            Quantity = 1,
                            TotalPrice = 399.99m,
                            UserId = "f5af08d0-d871-4702-a584-69bef5f85043"
                        });
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<int>("RatingPoint")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAtResponse")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ListingId")
                        .HasColumnType("int");

                    b.Property<string>("TextResponse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("UserId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "Прийнято"
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "Виконується"
                        },
                        new
                        {
                            Id = 3,
                            StatusName = "Не прийнято"
                        });
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeastSoldProductId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("MostSoldProductId")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalListings")
                        .HasColumnType("int");

                    b.Property<int>("TotalSales")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UrlSocialnetwork")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "f5af08d0-d871-4702-a584-69bef5f85043",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a1381f44-49e5-4339-afb9-2a7cc880543a",
                            CoverPath = "\\img\\user\\no_cover.jpg",
                            Email = "client@sweetcreativity.com",
                            EmailConfirmed = true,
                            FullName = "Олена Ткачук",
                            LeastSoldProductId = 0,
                            LockoutEnabled = false,
                            MostSoldProductId = 0,
                            NormalizedEmail = "CLIENT@SWEETCREATIVITY.COM",
                            NormalizedUserName = "CLIENT@SWEETCREATIVITY.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEN0msMX9BiV0EWbUNfOobJJi5dagvgB4MUjlxmcmwzu4ph9DnDsVn3ZVwr0JmQeNJw==",
                            PhoneNumber = 986390482,
                            PhoneNumberConfirmed = false,
                            SalePrice = 0m,
                            SecurityStamp = "fb2d6cca-5d8d-4e4b-a9e9-ed0fe167c4b8",
                            TotalListings = 0,
                            TotalSales = 0,
                            TwoFactorEnabled = false,
                            UrlSocialnetwork = "@olena_tkachuk",
                            UserName = "client@sweetcreativity.com"
                        },
                        new
                        {
                            Id = "392dcf24-872e-4a08-b21b-559758df80ea",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5c9bd798-92d5-4ff4-a89a-00cffebce46f",
                            CoverPath = "\\img\\user\\no_cover.jpg",
                            Email = "admin@sweetcreativity.com",
                            EmailConfirmed = true,
                            FullName = "Тетяна Бондар",
                            LeastSoldProductId = 0,
                            LockoutEnabled = false,
                            MostSoldProductId = 0,
                            NormalizedEmail = "ADMIN@SWEETCREATIVITY.COM",
                            NormalizedUserName = "ADMIN@SWEETCREATIVITY.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMWnFNcIrMFRpU6Vdc5m5DQ5kRKdBc+bF3kFRdAdgIYODFS9BuL6cW1IqLIs/26ldg==",
                            PhoneNumber = 985674335,
                            PhoneNumberConfirmed = false,
                            SalePrice = 0m,
                            SecurityStamp = "5ee9cfbe-1d42-49bc-aa50-82b5d2291b71",
                            TotalListings = 0,
                            TotalSales = 0,
                            TwoFactorEnabled = false,
                            UrlSocialnetwork = "@taniabondar23",
                            UserName = "admin@sweetcreativity.com"
                        },
                        new
                        {
                            Id = "960bbaeb-ec6a-4a2c-ba22-2dbb3e4a0047",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b55dd64e-d0f9-48d8-aefb-ea38ce2553f4",
                            CoverPath = "\\img\\user\\no_cover.jpg",
                            Email = "seller@sweetcreativity.com",
                            EmailConfirmed = true,
                            FullName = "Адріан Мельник",
                            LeastSoldProductId = 0,
                            LockoutEnabled = false,
                            MostSoldProductId = 0,
                            NormalizedEmail = "SELLER@SWEETCREATIVITY.COM",
                            NormalizedUserName = "SELLER@SWEETCREATIVITY.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEXwjvadtz4PbKBbptvxB+Nb2VBR+46N3FHx/VBwgh8VLUTKkkSbf+N4Kkuy8wktoA==",
                            PhoneNumber = 984568310,
                            PhoneNumberConfirmed = false,
                            SalePrice = 0m,
                            SecurityStamp = "78294b2c-edf4-4879-acae-e5ee7b5e2194",
                            TotalListings = 0,
                            TotalSales = 0,
                            TwoFactorEnabled = false,
                            UrlSocialnetwork = "@adriannmelnykk",
                            UserName = "seller@sweetcreativity.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SweetCreativity1.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SweetCreativity1.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SweetCreativity1.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SweetCreativity1.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Comment", b =>
                {
                    b.HasOne("SweetCreativity1.Core.Entities.Construction", "Construction")
                        .WithMany("Comments")
                        .HasForeignKey("ConstructionId");

                    b.HasOne("SweetCreativity1.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Construction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Construction", b =>
                {
                    b.HasOne("SweetCreativity1.Core.Entities.Status", "Status")
                        .WithMany("Constructions")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SweetCreativity1.Core.Entities.User", "User")
                        .WithMany("Constructions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Favorite", b =>
                {
                    b.HasOne("SweetCreativity1.Core.Entities.Listing", "Listing")
                        .WithMany("Favorite")
                        .HasForeignKey("ListingId");

                    b.HasOne("SweetCreativity1.Core.Entities.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId");

                    b.Navigation("Listing");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Listing", b =>
                {
                    b.HasOne("SweetCreativity1.Core.Entities.Category", "Category")
                        .WithMany("Listings")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SweetCreativity1.Core.Entities.User", "User")
                        .WithMany("Listings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Order", b =>
                {
                    b.HasOne("SweetCreativity1.Core.Entities.Listing", "Listing")
                        .WithMany("Orders")
                        .HasForeignKey("ListingId");

                    b.HasOne("SweetCreativity1.Core.Entities.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SweetCreativity1.Core.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Listing");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Rating", b =>
                {
                    b.HasOne("SweetCreativity1.Core.Entities.Listing", "Listing")
                        .WithMany("Ratings")
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SweetCreativity1.Core.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId");

                    b.Navigation("Listing");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Response", b =>
                {
                    b.HasOne("SweetCreativity1.Core.Entities.Listing", "Listing")
                        .WithMany("Responses")
                        .HasForeignKey("ListingId");

                    b.HasOne("SweetCreativity1.Core.Entities.User", "User")
                        .WithMany("Responses")
                        .HasForeignKey("UserId");

                    b.Navigation("Listing");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Category", b =>
                {
                    b.Navigation("Listings");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Construction", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Listing", b =>
                {
                    b.Navigation("Favorite");

                    b.Navigation("Orders");

                    b.Navigation("Ratings");

                    b.Navigation("Responses");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.Status", b =>
                {
                    b.Navigation("Constructions");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SweetCreativity1.Core.Entities.User", b =>
                {
                    b.Navigation("Constructions");

                    b.Navigation("Favorites");

                    b.Navigation("Listings");

                    b.Navigation("Orders");

                    b.Navigation("Ratings");

                    b.Navigation("Responses");
                });
#pragma warning restore 612, 618
        }
    }
}