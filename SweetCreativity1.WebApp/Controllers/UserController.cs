using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using SweetCreativity1.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetCreativity1.Core.Entities;
//using NuGet.Protocol.Core.Types;
//using SweetCreativity1.Core.Context;
//using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Interfaces;
using SweetCreativity1.Reposotories.Repos;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SweetCreativity1.Core.Context;

namespace SweetCreativity.WebApp.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserReposotory userReposotory;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<User> _userManager;
        private readonly SweetCreativity1Context _context;

        public UserController(IUserReposotory userReposotory,
            IWebHostEnvironment webHostEnviroment, UserManager<User> userManager, [FromServices] SweetCreativity1Context context)
        {
            this.userReposotory = userReposotory;
            this.webHostEnvironment = webHostEnviroment;
            _userManager = userManager;
            this._context = context;
        }
        public IActionResult Index()
        {
            return View(userReposotory.GetAll());
        }

        public IActionResult Details(string id)
        {
            var user = _context.Users
            .Include(l => l.Listings)
            .FirstOrDefault(l => l.Id == id);
            int totalListings = user.Listings?.Count ?? 0;
            ViewBag.Details = totalListings;
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
            //return View(userReposotory.Get(id));
        }

        //public IActionResult Analitic(string id)
        //{
        //    var user = _context.Users
        //    .Include(l => l.Listings)
        //    .FirstOrDefault(l => l.Id == id);

        //    if (user != null)
        //    {
        //        int totalListings = user.Listings?.Count ?? 0;

        //        // Pass the totalListings value to the view
        //        ViewBag.Analitic = totalListings;

        //        return View(user);
        //    }

        //    return NotFound();
        //}


        [HttpGet]
        public IActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

                string extension = Path.GetExtension(model.CoverFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.CoverPath = "/img/user/" + fileName;
                string path = Path.Combine(wwwRootPath + "/img/user/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.CoverFile.CopyTo(fileStream);
                }

                userReposotory.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }

        [Authorize(Roles = "Admin, Seller, Client")]
        public IActionResult Delete(string id)
        {
            var currentUser = _userManager.GetUserAsync(User).Result;
            var userToDelete = userReposotory.Get(id);

            // Check if the current user has the right to delete this user
            if (!User.IsInRole("Admin") && currentUser.Id != userToDelete.Id)
            {
                // Access forbidden if the current user is not an admin and not the owner
                return Forbid();
            }

            if (userToDelete == null)
            {
                return NotFound(); // User not found
            }

            return View(userToDelete);
        }

        [Authorize(Roles = "Admin, Seller, Client")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var currentUser = _userManager.GetUserAsync(User).Result;
            var userToDelete = userReposotory.Get(id);

            // Check if the current user has the right to delete this user
            if (!User.IsInRole("Admin") && currentUser.Id != userToDelete.Id)
            {
                // Access forbidden if the current user is not an admin and not the owner
                return Forbid();
            }

            if (userToDelete == null)
            {
                return NotFound(); // User not found
            }

            userReposotory.Delete(userToDelete);
            userReposotory.Save(); // Assuming Save() persists changes

            return RedirectToAction(nameof(Index));
        }


        [Authorize(Roles = "Admin, Seller, Client")]
        public IActionResult Edit(string id)
        {
            var currentUser = _userManager.GetUserAsync(User).Result;
            var item = userReposotory.Get(id);

            // Check if the current user has the right to edit this user
            if (!User.IsInRole("Admin") && currentUser.Id != id)
            {
                // Access forbidden if the current user is not an admin and not the owner
                return Forbid();
            }

            if (item == null)
            {
                return NotFound(); // Check if the item exists
            }

            return View(item);
        }

        [Authorize(Roles = "Admin, Seller, Client")]
        [HttpPost]
        public IActionResult Edit(User item)
        {
            var currentUser = _userManager.GetUserAsync(User).Result;

            // Check if the current user has the right to edit this user
            if (!User.IsInRole("Admin") && currentUser.Id != item.Id)
            {
                // Access forbidden if the current user is not an admin and not the owner
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingItem = userReposotory.Get(item.Id);

                    if (existingItem != null)
                    {
                        {
                            existingItem.UserName = item.UserName;
                            existingItem.Email = item.Email;
                            existingItem.FullName = item.FullName;
                            existingItem.PhoneNumber = item.PhoneNumber;
                            existingItem.UrlSocialnetwork = item.UrlSocialnetwork;

                            if (item.CoverFile != null)
                            {
                                // Обробіть завантажене зображення, якщо воно було вибране
                                string wwwRootPath = webHostEnvironment.WebRootPath;
                                string fileName = Path.GetFileNameWithoutExtension(item.CoverFile.FileName);
                                string extension = Path.GetExtension(item.CoverFile.FileName);
                                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                                existingItem.CoverPath = "/img/user/" + fileName;
                                string path = Path.Combine(wwwRootPath, "img/user", fileName);

                                using (var fileStream = new FileStream(path, FileMode.Create))
                                {
                                    item.CoverFile.CopyTo(fileStream);
                                }
                            }

                            userReposotory.Update(existingItem);
                            userReposotory.Save();
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        // Якщо запис не знайдено, обробіть це відповідним чином
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    // Обробте помилку при оновленні даних, якщо вона виникла
                    // Виведіть або збережіть повідомлення про помилку для подальшого аналізу
                    // Ви можете також відправити користувачеві повідомлення про помилку, якщо це потрібно
                    return View(item);
                }
            }
            return View(item);
        }

        public IActionResult Analitic()
        {
           
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return NotFound(); 
            }

           
            var user = _context.Users
                .Include(u => u.Listings)
                .Include(u => u.Orders) 
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound(); 
            }

  
            int totalListings = user.Listings?.Count ?? 0;


            int totalLikes = _context.Favorites
                .Count(like => like.Listing.UserId == userId);

            int totalSales = _context.Orders
                .Count(like => like.Listing.UserId == userId);

            int notAcceptedOrders = _context.Orders
        .Count(order => order.Listing.UserId == userId && order.Status.StatusName == "Не прийнято");
            int AcceptedOrders = _context.Orders
        .Count(order => order.Listing.UserId == userId && order.Status.StatusName == "Прийнято");
            int inProgress = _context.Orders
        .Count(order => order.Listing.UserId == userId && order.Status.StatusName == "Виконується");

            var mostOrderedListing = _context.Orders
    .Where(order => order.Listing.UserId == userId)
    .GroupBy(order => order.Listing)
    .OrderByDescending(group => group.Count())
    .Select(group => group.Key)
    .FirstOrDefault();

            int mostOrderedListingCount = _context.Orders
                .Count(order => order.Listing.UserId == userId && order.Listing == mostOrderedListing);

            decimal acceptedOrdersTotalPrice = _context.Orders
        .Where(order => order.Listing.UserId == userId && order.Status.StatusName == "Прийнято")
        .Sum(order => order.TotalPrice);

            ViewBag.MostOrderedListing = mostOrderedListing;
            ViewBag.MostOrderedListingCount = mostOrderedListingCount;
            ViewBag.TotalListings = totalListings;
            ViewBag.TotalFavorite = totalLikes;
            ViewBag.TotalSales = totalSales;
            ViewBag.AcceptedOrders = AcceptedOrders;
            ViewBag.InProgress = inProgress;
            ViewBag.NotAcceptedOrders = notAcceptedOrders;
            ViewBag.AcceptedOrdersTotalPrice = acceptedOrdersTotalPrice;

            return View();
        }





    }

}