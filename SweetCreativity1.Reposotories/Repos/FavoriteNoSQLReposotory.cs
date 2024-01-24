
using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity1.Reposotories.Repos
{
    internal class FavoriteNoSQLReposotory : IFavoriteReposotory
    {
        //private readonly MongoDbConnection connection;
        public FavoriteNoSQLReposotory()
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

        //public void Find(int obj)
        //{
        //    throw new NotImplementedException();
        //}

        public Favorite Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Favorite> GetAll()
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

        void IFavoriteReposotory.Add(Favorite obj)
        {
            throw new NotImplementedException();
        }

        void IFavoriteReposotory.Delete(Favorite obj)
        {
            throw new NotImplementedException();
        }

        Favorite IFavoriteReposotory.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Favorite> IFavoriteReposotory.GetAll()
        {
            throw new NotImplementedException();
        }

        void ISave.Save()
        {
            throw new NotImplementedException();
        }

        void IFavoriteReposotory.Update(Favorite obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Favorite> GetFavoritesByUserId(string userId)
        {
            throw new NotImplementedException();
        }

    //public void Find(int obj)
    //{
    //    throw new NotImplementedException();
    //}
}
}