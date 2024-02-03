using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SweetCreativity1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity1.Core.Context
{
    public static class SweetCreativity1InitializerExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            (string admId, string clId, string selId) = seedUsersAndRoles(builder);
            seedListing(builder, new string[] { selId, admId });
            seedCategory(builder);
            // seedUser(builder);
            seedOrder(builder, new string[] { clId, admId });
            seedStatus(builder);
            seedEvent(builder, new string[] { selId, admId });
        }
        private static void seedStatus(ModelBuilder builder)
        {
            builder.Entity<Status>().HasData(
                new Status
                {
                    Id = 1,
                    StatusName = "Прийнято"
                },
                 new Status
                 {
                     Id = 2,
                     StatusName = "Виконується"
                 },
                new Status
                {
                    Id = 3,
                    StatusName = "Не прийнято"
                }
                );


        }
        private static void seedOrder(ModelBuilder builder, string[] clientIds)
        {
            builder.Entity<Order>().HasData(
                new Order
                {
                    Id = 2,
                    NameOrder = "Торт Спартак",
                    Quantity = 1,
                    TotalPrice = 399.99m,
                    CreatedAtOrder = DateTime.Now,
                    CustomerNumber = 0985688735,
                    UserId = clientIds[0],
                    ListingId = 2,
                },
                new Order
                {
                    Id = 1,
                    NameOrder = "Торт Наполеон",
                    Quantity = 1,
                    TotalPrice = 249.99m,
                    CreatedAtOrder = DateTime.Now,
                    CustomerNumber = 0985684335,
                    UserId = clientIds[1],
                    ListingId = 1,
                }
                );
        }


        private static void seedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                 new Category
                 {
                     Id = 1,
                     NameCategory = "Торти"
                 },
                  new Category
                  {
                      Id = 2,
                      NameCategory = "Тістечка"
                  },
                  new Category
                  {
                      Id = 3,
                      NameCategory = "Цукерки"
                  },
                  new Category
                  {
                      Id = 4,
                      NameCategory = "Печиво"
                  },
                  new Category
                  {
                      Id = 5,
                      NameCategory = "Вафлі"
                  }
                 );
        }
        static void seedEvent(ModelBuilder builder, string[] sellerIds)
        {
            builder.Entity<Event>().HasData(
              new Event
              {
                  Id = 1,
                  Text = "Акція на всю продукцію від мене 10%",
                  UserId = sellerIds[0],
                  Date = DateTime.Now
              },
              new Event
              {
                  Id = 2,
                  Text = "Акція на торти нашого виробництва 5%",
                  UserId = sellerIds[1],
                  Date = DateTime.Now
              }
                );
        }
        static void seedListing(ModelBuilder builder, string[] sellerIds)
        {
            builder.Entity<Listing>().HasData(
              new Listing
              {
                  Id = 1,
                  Title = "Торт Наполеон",
                  Description = " Це відомий і популярний торт, який складається з тонких шарів бісквіту і вершкового крему.",
                  Product = "Борошно, вершкове масло, яйця, оцет, цукор, ванільний цукор або ванільний екстракт, кукурудзяний крохмаль, вершки, сіль, прикраси (за бажанням).",
                  Location = "Lviv",
                  CategoryId = 1,
                  UserId = sellerIds[0],
                  Price = 164.99m,
                  Weight = 1000,
              },
              new Listing
              {
                  Id = 2,
                  Title = "Мафіни",
                  Description = "Гармонійне поєднання повітряного шоколадного тіста мафіну з ніжно-солодкою вершковою начинкою.",
                  Product = "Борошно пшеничне, цукор-пісок, суміш “Мафін шоколадний”, олія рослинна, меланж, вода. Начинка: згущене молоко “Іриска”з вершками.",
                  Location = "Rivne",
                  CategoryId = 2,
                  UserId = sellerIds[1],
                  Price = 179.99m,
                  Weight = 80,
              }
                );
        }

        static (string, string, string) seedUsersAndRoles(ModelBuilder builder)
        {
            string CLIENT_ROLE_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string SELLER_ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = CLIENT_ROLE_ID, Name = "Client", NormalizedName = "CLIENT" },
                new IdentityRole { Id = ADMIN_ROLE_ID, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = SELLER_ROLE_ID, Name = "Seller", NormalizedName = "SELLER" }
                );

            string CLIENT_ID = Guid.NewGuid().ToString();
            string ADMIN_ID = Guid.NewGuid().ToString();
            string SELLER_ID = Guid.NewGuid().ToString();

            var client = new User
            {
                Id = CLIENT_ID,
                UserName = "client@sweetcreativity.com",
                Email = "client@sweetcreativity.com",
                FullName = "Олена Ткачук",
                EmailConfirmed = true,
                PhoneNumber = 0986390482,
                UrlSocialnetwork = "@olena_tkachuk",
                NormalizedEmail = "CLIENT@SWEETCREATIVITY.COM",
                NormalizedUserName = "CLIENT@SWEETCREATIVITY.COM"
            };

            var admin = new User
            {
                Id = ADMIN_ID,
                UserName = "admin@sweetcreativity.com",
                Email = "admin@sweetcreativity.com",
                FullName = "Тетяна Бондар",
                EmailConfirmed = true,
                PhoneNumber = 0985674335,
                UrlSocialnetwork = "@taniabondar23",
                NormalizedEmail = "ADMIN@SWEETCREATIVITY.COM",
                NormalizedUserName = "ADMIN@SWEETCREATIVITY.COM"
            };
            var seller = new User
            {
                Id = SELLER_ID,
                UserName = "seller@sweetcreativity.com",
                Email = "seller@sweetcreativity.com",
                FullName = "Адріан Мельник",
                EmailConfirmed = true,
                PhoneNumber = 0984568310,
                UrlSocialnetwork = "@adriannmelnykk",
                NormalizedEmail = "SELLER@SWEETCREATIVITY.COM",
                NormalizedUserName = "SELLER@SWEETCREATIVITY.COM"
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            client.PasswordHash = hasher.HashPassword(client, "client$pass");
            admin.PasswordHash = hasher.HashPassword(admin, "admin$pass");
            seller.PasswordHash = hasher.HashPassword(seller, "seller$pass");

            builder.Entity<User>().HasData(client, admin, seller);

            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },

                new IdentityUserRole<string>
                {
                    RoleId = SELLER_ROLE_ID,
                    UserId = ADMIN_ID
                },

                new IdentityUserRole<string>
                {
                    RoleId = SELLER_ROLE_ID,
                    UserId = SELLER_ID
                },

                new IdentityUserRole<string>
                {
                    RoleId = CLIENT_ROLE_ID,
                    UserId = CLIENT_ID
                }
                );
            return (CLIENT_ID, ADMIN_ID, SELLER_ID);
        }
    }
}


