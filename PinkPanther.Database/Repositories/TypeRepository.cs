using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkPanther.Database
{
    public class TypeRepository : BaseRepository<Type>, ITypeRepository
    {
        protected override DbSet<Type> DbSet => _dbContext.Types;
        public TypeRepository(PinkPantherDbContex dbContex) : base(dbContex)
        {
        }


        public IEnumerable<Type> GetTypes()
        {
            return DbSet;
        }
    }
}
