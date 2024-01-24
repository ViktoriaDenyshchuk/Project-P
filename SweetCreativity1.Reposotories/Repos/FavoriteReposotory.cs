using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SweetCreativity1.Core.Context;
using SweetCreativity1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetCreativity1.Reposotories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SweetCreativity1.Reposotories.Repos
{
    public class FavoriteReposotory : IFavoriteReposotory
    {
        private SweetCreativity1Context _context;
        public FavoriteReposotory(SweetCreativity1Context context)
        {
            _context = context;
        }
        public void Add(Favorite obj)
        {
            _context.Favorites.Add(obj);
            Save();
        }

        public void Delete(Favorite obj)
        {
            _context.Set<Favorite>().Remove(obj);
            Save();
        }

        public Favorite Get(int id)
        {
           return _context.Favorites.Find(id);
            //return _context.Set<Listing>().Find(id);
        }

        public IEnumerable<Favorite> GetAll()
        {
            return _context.Favorites.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Favorite obj)
        {
            _context.Favorites.Update(obj);
        }

        Favorite IFavoriteReposotory.Get(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Favorite> GetFavoritesByUserId(string userId)
        {
            return _context.Favorites
                .Include(f => f.Listing)
                .Where(f => f.UserId == userId)
                .ToList();
        }
    }
}