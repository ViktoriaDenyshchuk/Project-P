using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Repos;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using SweetCreativity1.Reposotories.Interfaces;
using System.Reflection;
using SweetCreativity.Reposotories.Repos;

namespace SweetCreativity.WebApp.Controllers
{
    [Authorize(Roles = "Client")]
    public class FavoriteController : Controller
    {
        private readonly IUserReposotory _userRepository;
        private readonly IListingReposotory _listingRepository;
        private readonly IFavoriteReposotory _favoriteRepository;

        public FavoriteController(IUserReposotory userRepository, IListingReposotory listingRepository, IFavoriteReposotory favoriteRepository)
        {
            _userRepository = userRepository;
            _listingRepository = listingRepository;
            _favoriteRepository = favoriteRepository;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userFavorites = _favoriteRepository.GetFavoritesByUserId(userId);

            return View(userFavorites); 
        }



        [Authorize]
        [HttpPost]
        public IActionResult AddToFavorites(int listingId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userRepository.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

           
            var isAlreadyFavorite = _favoriteRepository.GetFavoritesByUserId(userId)
                .Any(f => f.ListingId == listingId);

            if (!isAlreadyFavorite)
            {
                
                var listing = _listingRepository.GetListingById(listingId);

                if (listing == null)
                {
                    return NotFound();
                }

                var favorite = new Favorite
                {
                    User = user,
                    Listing = listing
                };

                user.Favorites.Add(favorite);
                _userRepository.UpdateUser(user);
                _userRepository.Save();
            }
            
            else
            {
           
                TempData["Message"] = "This listing is already in your favorites.";
            }

            
            return RedirectToAction("Index");

        }
       
        public IActionResult Delete(int id)
        {
            return View(_favoriteRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Delete(Favorite favorite)
        {
            _favoriteRepository.Delete(favorite);

            return RedirectToAction("Index");
        }




    }
}