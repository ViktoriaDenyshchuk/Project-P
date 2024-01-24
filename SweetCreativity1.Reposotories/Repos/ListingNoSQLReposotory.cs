using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetCreativity1.Reposotories.Repos
{
    internal class ListingNoSQLReposotory : IListingReposotory
    {
        public ListingNoSQLReposotory()
        {

        }

        public void Add(Listing obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Listing obj)
        {
            throw new NotImplementedException();
        }

        public Listing Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Listing> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Listing obj)
        {
            throw new NotImplementedException();
        }

        public Task<Listing> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        int IListingReposotory.Find(int id)
        {
            throw new NotImplementedException();
        }

        Task IListingReposotory.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Listing GetListingById(int listingId)
        {
            throw new NotImplementedException();
        }
    }
}
