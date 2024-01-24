//using SweetCreativity1.Core.Context;
//using SweetCreativity1.Core.Entities;
//using SweetCreativity1.Reposotories.Interfaces;
//using System.Linq;

//namespace SweetCreativity1.Reposotories.Repos
//{
//    public class SalesAnalyticsReposotory : ISalesAnalyticsReposotory
//    {
//        private SweetCreativity1Context _context;

//        public SalesAnalyticsReposotory(SweetCreativity1Context context)
//        {
//            _context = context;
//        }

//        public Statistic GetSellerStatistics(string sellerId)
//        {
//            var totalSales = _context.Statistics.Count(s => s.SellerId == sellerId);
//            var totalEarnings = _context.Statistics.Where(s => s.SellerId == sellerId).Sum(s => s.SalePrice);

//            var mostSoldProduct = _context.Statistics
//                .Where(s => s.SellerId == sellerId)
//                .OrderByDescending(s => s.QuantitySold)
//                .Select(s => s.Listing)
//                .FirstOrDefault();

//            var leastSoldProduct = _context.Statistics
//                .Where(s => s.SellerId == sellerId)
//                .OrderBy(s => s.QuantitySold)
//                .Select(s => s.Listing)
//                .FirstOrDefault();

//            var stats = new Statistic
//            {
//                TotalSales = totalSales,
//                TotalEarnings = totalEarnings,
//                MostSoldProduct = mostSoldProduct,
//                LeastSoldProduct = leastSoldProduct
//            };

//            return stats;
//        }

//        public void Save()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}


