using SweetCreativity1.Core.Entities;
using System;
using System.Collections.Generic;

namespace SweetCreativity1.Reposotories.Interfaces
{
    public interface IListingReposotory : ISave
    {
        Listing Get(int id);
        IEnumerable<Listing> GetAll();
        void Add(Listing obj);
        void Update(Listing obj);
        void Delete(Listing obj);

        Task<Listing> GetByIdAsync(int id);
        Task SaveChangesAsync();
        int Find(int id);
        Listing GetListingById(int listingId);
        //IEnumerable<Listing> SearchListings(string searchTerm);
    }
}
