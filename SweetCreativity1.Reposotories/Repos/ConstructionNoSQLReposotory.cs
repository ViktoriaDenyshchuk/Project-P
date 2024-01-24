using SweetCreativity1.Core.Entities;
using SweetCreativity.Reposotories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCreativity1.Reposotories.Repos
{
    internal class ConstructionNoSQLReposotory : IConstructionReposotory
    {
        public ConstructionNoSQLReposotory()
        {

        }
        public void Add(Construction obj)
        {
            throw new NotImplementedException();
        }

        public Construction Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Construction> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Construction obj)
        {
            throw new NotImplementedException();
        }
        public Construction GetConstructionDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}