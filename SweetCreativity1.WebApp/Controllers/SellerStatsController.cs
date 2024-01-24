//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using SweetCreativity1.Core.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using SweetCreativity1.Core.Entities;
////using NuGet.Protocol.Core.Types;
////using SweetCreativity1.Core.Context;
////using SweetCreativity1.Core.Entities;
//using SweetCreativity1.Reposotories.Interfaces;
//using SweetCreativity1.Reposotories.Repos;
//using System.Data;
//using static System.Runtime.InteropServices.JavaScript.JSType;
//using SweetCreativity1.Core.Context;

//namespace SweetCreativity.WebApp.Controllers
//{
//    //[Authorize(Roles = "Admin")]
//    public class SellerStatsService
//    {
//        private readonly IListingRepository _listingRepository;

//        public SellerStatsService(IListingRepository listingRepository)
//        {
//            _listingRepository = listingRepository;
//        }

//        public SellerStatsViewModel GetSellerStats(string sellerId)
//        {
//            // Отримати всі оголошення продавця за його ідентифікатором
//            var sellerListings = _listingRepository.GetListingsBySellerId(sellerId);

//            // Логіка визначення статистики продавця на основі оголошень
//            // (загальна кількість оголошень, загальна кількість продажів і т.д.)

//            // Припустимо, що у вас є логіка визначення статистики продавця тут

//            // Створити об'єкт SellerStatsViewModel і повернути його
//            var sellerStats = new SellerStatsViewModel
//            {
//                TotalListings = sellerListings.Count,
//                // Додати інші дані за потребою
//            };

//            return sellerStats;
//        }
//    }


//}