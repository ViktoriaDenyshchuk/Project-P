using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity.Reposotories.Interfaces
{
    public interface IConstructionReposotory : ISave
    {
        Construction Get(int id);
        IEnumerable<Construction> GetAll();
        void Add(Construction obj);
        void Update(Construction obj);

        // Додайте новий метод для отримання деталей Construction
        Construction GetConstructionDetails(int id);
    }
}