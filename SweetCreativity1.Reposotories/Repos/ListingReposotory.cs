using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SweetCreativity1.Core.Context;
using SweetCreativity1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetCreativity1.Reposotories.Interfaces;

namespace SweetCreativity1.Reposotories.Repos
{
    public class ListingReposotory : IListingReposotory
    {
        private SweetCreativity1Context _context;
        public ListingReposotory(SweetCreativity1Context context)
        {
            _context = context;
        }
        public void Add(Listing obj)
        {
            _context.Listings.Add(obj);
            Save();
        }

        public void Delete(Listing obj)
        {
            _context.Set<Listing>().Remove(obj);
            Save();
        }

        public Listing Get(int id)
        {
           return _context.Listings.Find(id);
            //return _context.Set<Listing>().Find(id);
        }

        public IEnumerable<Listing> GetAll()
        {
            return _context.Listings.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Listing obj)
        {
            _context.Listings.Update(obj);
        }
        public Listing Find(int id)
        {
            return _context.Listings.FirstOrDefault(listing => listing.Id == id);
        }

        public Task<Listing> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        int IListingReposotory.Find(int id)
        {
            throw new NotImplementedException();
        }
        public Task SaveChangesAsync()
        {
            // Реалізація збереження змін в базу даних
            throw new NotImplementedException();
        }

        public Listing GetListingById(int listingId)
        {
            return _context.Listings.Find(listingId);
        }
        //public IEnumerable<Listing> SearchListings(string searchTerm)
        //{
        //    // Ваш код для виконання пошукового запиту в базі даних
        //    // Наприклад, використовуйте LINQ для фільтрації результатів

        //    if (string.IsNullOrEmpty(searchTerm))
        //    {
        //        // Якщо пошуковий термін не вказано, поверніть усі оголошення
        //        return _context.Listings.ToList();
        //    }
        //    else
        //    {
        //        // Використовуйте LINQ для фільтрації результатів за назвою та описом
        //        return _context.Listings
        //            .Where(listing => listing.Title.Contains(searchTerm) || listing.Description.Contains(searchTerm))
        //            .ToList();
        //    }
        //}


    }
}