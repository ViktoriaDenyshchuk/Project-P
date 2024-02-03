////using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using SweetCreativity1.Core.Context;
using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Interfaces;
using SweetCreativity1.Reposotories.Repos;
using System.Data;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SweetCreativity1.WebApp.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ListingController : Controller
    {
        private readonly IListingReposotory listingReposotory;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SweetCreativity1Context _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager; // Specify the full namespace

        public ListingController(IListingReposotory listingReposotory,
            IWebHostEnvironment webHostEnviroment, [FromServices] SweetCreativity1Context context, Microsoft.AspNetCore.Identity.UserManager<User> userManager) // Specify the full namespace
        {
            this.listingReposotory = listingReposotory;
            this.webHostEnvironment = webHostEnviroment;
            this._context = context;
            this._userManager = userManager;
        }

        public async Task<Listing> GetByIdAsync(int id)
        {
            return await _context.Listings.FindAsync(id);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IActionResult Index()
        {
            var allListings = listingReposotory.GetAll();

            return View(allListings);
        }
        //[HttpGet]
        //public IActionResult Search(string searchTerm)
        //{
        //    var searchResults = listingReposotory.SearchListings(searchTerm);
        //    return View("Index", searchResults);
        //}
        [HttpGet]
        public IActionResult Search(string searchTerm)
        {
            var searchResults = _context.Listings
                .Where(listing => listing.Title.Contains(searchTerm)
                || listing.Description.Contains(searchTerm)
                || listing.Product.Contains(searchTerm)
                || listing.Location.Contains(searchTerm)
                || listing.User.FullName.Contains(searchTerm)
                || listing.Price.ToString().Contains(searchTerm)
                || listing.Weight.ToString().Contains(searchTerm))
                .ToList();

            return View("Index", searchResults);
        }


        [Authorize(Roles = "Seller")]
        public IActionResult MyListings()
        {
            // Отримайте ідентифікатор поточного користувача
            var userId = _userManager.GetUserId(User);

            // Отримайте тільки ті оголошення, які належать поточному користувачеві
            var userOwnedListings = listingReposotory.GetAll().Where(l => l.UserId == userId);

            return View(userOwnedListings);
        }

        public IActionResult Details(int id)
        {
            var listing = _context.Listings
                .Include(l => l.Ratings)
                .Include(l => l.Responses)
                .Include(l => l.User)
                .Include(l => l.Category)
                .FirstOrDefault(l => l.Id == id);

            if (listing == null)
            {
                return NotFound();
            }

            double averageRating = listing.Ratings != null ? CalculateAverageRating(listing.Ratings) : 0.0;

            ViewBag.AverageRating = averageRating; // Передача середнього рейтингу в ViewBag
            ViewBag.OwnerName = listing.User?.FullName; // Передача імені власника в ViewBag
            ViewBag.OwnerCategory = listing.Category?.NameCategory;

            return View(listing);
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult AddRating(int listingId, int ratingPoint)
        {
             // Отримайте оголошення, до якого буде додаватися рейтинг
             var listing = _context.Listings
             .Include(l => l.Ratings)
             .FirstOrDefault(l => l.Id == listingId);

            if (listing == null)
            {
                return NotFound();
            }

            // Перевірте, чи користувач вже залишив рейтинг для даного оголошення

            // Створіть новий рейтинг
            var newRating = new Rating
            {
                RatingPoint = ratingPoint,
                ListingId = listing.Id
            };

            // Додайте новий рейтинг до оголошення
            listing.Ratings.Add(newRating);

            // Збережіть зміни в базі даних
            _context.SaveChanges();

            // Отримайте середній рейтинг після додавання нового рейтингу
            double averageRating = listing.Ratings != null ? CalculateAverageRating(listing.Ratings) : 0.0;

            // Передайте оновлений середній рейтинг до ViewBag
            ViewBag.AverageRating = averageRating;


            return RedirectToAction("Details", new { id = listingId });

        }

        /////////////////
        private double CalculateAverageRating(List<Rating> ratings)
        {
            if (ratings.Count == 0)
            {
                return 0.0; // Повертаємо 0, якщо немає жодного рейтингу
            }

            double totalRating = 0.0;
            foreach (var rating in ratings)
            {
                totalRating += rating.RatingPoint;
            }

            return totalRating / ratings.Count;
        }
        [Authorize(Roles = "Seller")]
        [HttpGet]
        public IActionResult Create()
        {
            // Отримайте список категорій з бази даних
            var categories = _context.Categories.ToList();

            // Передайте список категорій у ваше представлення
            ViewBag.CategoryList = new SelectList(categories, "Id", "NameCategory");

            // Створіть пустий об'єкт Listing та передайте його у представлення
            return View(new Listing());
        }
        [Authorize(Roles = "Seller")]
        [HttpPost]
        public IActionResult Create(Listing model)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName);

                string extension = Path.GetExtension(model.CoverFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.CoverPath = "/img/listing/" + fileName;
                string path = Path.Combine(wwwRootPath + "/img/listing/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.CoverFile.CopyTo(fileStream);
                }

                listingReposotory.Add(model);
                return RedirectToAction(nameof(Index));
            }


            var categories = _context.Categories.ToList();
            ViewBag.CategoryList = new SelectList(categories, "Id", "NameCategory");
            return View(model);
        }
        [Authorize(Roles = "Admin, Seller")]
        public IActionResult Delete(int id)
        {
            var listing = listingReposotory.Get(id);

            if (listing == null)
            {
                return NotFound();
            }

            // Check if the current user is the owner of the listing
            if (User.Identity.IsAuthenticated && (_userManager.GetUserId(User) == listing.UserId || User.IsInRole("Admin")))
            {
                return View(listing);
            }
            else
            {
                // Access forbidden if the current user is not the owner
                return Forbid();
            }
        }

        [Authorize(Roles = "Admin, Seller")]
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var listing = listingReposotory.Get(id);

            // Check if the current user is the owner of the listing
            if (User.Identity.IsAuthenticated && (_userManager.GetUserId(User) == listing.UserId || User.IsInRole("Admin")))
            {
                // Delete related orders first
                var ordersToDelete = _context.Orders.Where(o => o.ListingId == id);
                _context.Orders.RemoveRange(ordersToDelete);

                // Now delete the listing
                listingReposotory.Delete(listing);

                return RedirectToAction("Index");
            }
            else
            {
                // Access forbidden if the current user is not the owner
                return Forbid();
            }
        }


        //////////////////////

        //        [HttpGet]
        [Authorize(Roles = "Admin, Seller")]
[HttpGet]
public IActionResult Edit(int id)
{
    var item = listingReposotory.Get(id);

    if (item == null)
    {
        return NotFound();
    }

    // Check if the current user is the owner of the listing or is an administrator
    if (User.Identity.IsAuthenticated && (_userManager.GetUserId(User) == item.UserId || User.IsInRole("Admin")))
    {
        // Continue with the edit action
        // Get categories for dropdown
        var categories = _context.Categories.ToList();
        ViewBag.CategoryList = new SelectList(categories, "Id", "NameCategory");

        return View(item);
    }
    else
    {
        // If not the owner or an administrator, forbid the action
        return Forbid();
    }
}

[Authorize(Roles = "Admin, Seller")]
[HttpPost]
public IActionResult Edit(Listing item)
{
    if (ModelState.IsValid)
    {
        try
        {
            var existingItem = listingReposotory.Get(item.Id);

            if (existingItem != null)
            {
                // Check if the current user is the owner of the listing or is an administrator
                if (User.Identity.IsAuthenticated && (_userManager.GetUserId(User) == existingItem.UserId || User.IsInRole("Admin")))
                {
                    // Continue with the edit action
                    existingItem.Title = item.Title;
                    existingItem.Description = item.Description;
                    existingItem.Product = item.Product;
                    existingItem.CreatedAtListing = item.CreatedAtListing;
                    existingItem.Location = item.Location;
                    existingItem.Price = item.Price;
                    existingItem.Weight = item.Weight;
                    
                    // Check if a new cover file is provided
                    if (item.CoverFile != null)
                    {
                        // Process the uploaded image if a new one is selected
                        string wwwRootPath = webHostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(item.CoverFile.FileName);
                        string extension = Path.GetExtension(item.CoverFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        existingItem.CoverPath = "/img/listing/" + fileName;
                        string path = Path.Combine(wwwRootPath, "img/listing", fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            item.CoverFile.CopyTo(fileStream);
                        }
                    }

                    existingItem.CategoryId = item.CategoryId;

                    // Update the listing
                    listingReposotory.Update(existingItem);
                    listingReposotory.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // If not the owner or an administrator, forbid the action
                    return Forbid();
                }
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            // Handle the exception
            return View(item);
        }
    }

    // If ModelState is not valid, return to the edit view
    var categories = _context.Categories.ToList();
    ViewBag.CategoryList = new SelectList(categories, "Id", "NameCategory");
    return View(item);
}


        //[Authorize(Roles = "Client")]
        //[HttpPost]
        //public IActionResult AddResponse(int listingId, string textResponse)
        //{
        //    var listing = _context.Listings
        //        .Include(l => l.Responses)
        //        .FirstOrDefault(l => l.Id == listingId);

        //    if (listing == null)
        //    {
        //        return NotFound();
        //    }

        //    var newResponse = new Response
        //    {
        //        TextResponse = textResponse,
        //        CreatedAtResponse = DateTime.Now
        //    };

        //    listing.Responses.Add(newResponse);
        //    _context.SaveChanges();

        //    // Після додавання відгуку перенаправте користувача на сторінку оголошення
        //    return RedirectToAction("Details", new { id = listingId });
        //}
        [Authorize(Roles = "Client")]
        [HttpPost]
        public async Task<IActionResult> AddResponse(int listingId, string textResponse, string userId)
        {
            var listing = await _context.Listings
                .Include(l => l.Responses)
                .FirstOrDefaultAsync(l => l.Id == listingId);

            if (listing == null)
            {
                return NotFound();
            }

            var newResponse = new Response
            {
                TextResponse = textResponse,
                CreatedAtResponse = DateTime.Now,
                UserId = userId // Додайте ідентифікатор користувача до відгуку
            };

            listing.Responses.Add(newResponse);
            await _context.SaveChangesAsync();

            // Після додавання відгуку перенаправте користувача на сторінку оголошення
            return RedirectToAction("Details", new { id = listingId });
        }




        //[HttpPost]
        //public IActionResult AddRatingResponse(int listingId, int ratingPoint, string textResponse)
        //{
        //    // Отримайте оголошення, до якого буде додаватися рейтинг та відгук
        //    var listing = _context.Listings
        //        .Include(l => l.Ratings)
        //        .Include(l => l.Responses)
        //        .FirstOrDefault(l => l.Id == listingId);

        //    if (listing == null)
        //    {
        //        return NotFound();
        //    }

        //    // Додайте рейтинг до оголошення
        //    var newRating = new Rating
        //    {
        //        RatingPoint = ratingPoint,
        //        ListingId = listing.Id
        //    };
        //    listing.Ratings.Add(newRating);

        //    // Додайте відгук до оголошення
        //    var newResponse = new Response
        //    {
        //        TextResponse = textResponse,
        //        CreatedAtResponse = DateTime.Now, // або інша логіка для встановлення дати
        //        ListingId = listing.Id
        //    };
        //    listing.Responses.Add(newResponse);

        //    // Збережіть зміни в базі даних
        //    _context.SaveChanges();

        //    // Обрахуйте середній рейтинг після додавання нового рейтингу
        //    double averageRating = CalculateAverageRating(listing.Ratings);

        //    // Передайте оновлений середній рейтинг та оголошення в представлення
        //    ViewBag.AverageRating = averageRating;
        //    return View(listing);
        //}

        //private double CalculateAverageRating(List<Rating> ratings)
        //{
        //    if (ratings.Count == 0)
        //    {
        //        return 0.0; // Повернути 0, якщо немає жодного рейтингу
        //    }

        //    double totalRating = 0.0;
        //    foreach (var rating in ratings)
        //    {
        //        totalRating += rating.RatingPoint;
        //    }

        //    return totalRating / ratings.Count;
        //}



    }
}



