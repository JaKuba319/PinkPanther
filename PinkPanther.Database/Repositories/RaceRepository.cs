using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkPanther.Database
{
    public class RaceRepository : BaseRepository<Race>, IRaceRepository
    {
        protected override DbSet<Race> DbSet => _dbContext.Races;
        public RaceRepository(PinkPantherDbContex dbContex) : base(dbContex)
        {
        }


        public IEnumerable<Race> GetRaces()
        {
            return DbSet;
        }
    }
}
