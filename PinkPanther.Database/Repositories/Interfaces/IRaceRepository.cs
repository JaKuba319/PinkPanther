using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkPanther.Database
{
    public interface IRaceRepository : IBaseRepository<Race>
    {
        public IEnumerable<Race> GetRaces();
    }
}
