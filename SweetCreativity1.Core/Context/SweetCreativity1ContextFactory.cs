using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetCreativity1.Core.Context;

namespace SweetCreativity1.Core.Context
{
    internal class SweetCreativity1ContextFactory : IDesignTimeDbContextFactory<SweetCreativity1Context>
    {
        public SweetCreativity1Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SweetCreativity1Context>();
            optionsBuilder.UseSqlServer("Server=.;Database=SweetCreativity1DB;Integrated Security=True;TrustServerCertificate=True;");

            return new SweetCreativity1Context(optionsBuilder.Options);
        }
    }
}
