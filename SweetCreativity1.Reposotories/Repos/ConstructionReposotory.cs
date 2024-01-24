using SweetCreativity1.Core.Context;
using SweetCreativity1.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SweetCreativity.Reposotories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SweetCreativity1.Core.Context;
using SweetCreativity1.Core.Entities;

namespace SweetCreativity.Reposotories.Repos
{
    public class ConstructionReposotory : IConstructionReposotory
    {
        private SweetCreativity1Context _context;
        public ConstructionReposotory(SweetCreativity1Context context)
        {
            _context = context;
        }
        public void Add(Construction obj)
        {
            _context.Constructions.Add(obj);
            Save();
        }

        public Construction Get(int id)
        {
            return _context.Constructions.Find(id);

        }

        public IEnumerable<Construction> GetAll()
        {
            return _context.Constructions.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Construction obj)
        {
            _context.Constructions.Update(obj);
        }

        public void UpdateStatus(int constructionId, int statusId)
        {
            var construction = _context.Constructions.Find(constructionId);
            if (construction != null)
            {
                construction.StatusId = statusId;
                _context.SaveChanges();
            }
        }
        public Construction GetConstructionDetails(int id)
        {
            return _context.Constructions
                .Include(c => c.Status) // Включіть статус у конструкцію, якщо потрібно
                .FirstOrDefault(c => c.Id == id);
        }

    }
}