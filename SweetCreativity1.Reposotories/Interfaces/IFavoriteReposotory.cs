
using SweetCreativity1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity1.Reposotories.Interfaces
{
    public interface IFavoriteReposotory : ISave
    {
        Favorite Get(int id);
        IEnumerable<Favorite> GetAll();
        void Add(Favorite obj);
        void Update(Favorite obj);
        void Delete(Favorite obj);
        IEnumerable<Favorite> GetFavoritesByUserId(string userId);
    }
}