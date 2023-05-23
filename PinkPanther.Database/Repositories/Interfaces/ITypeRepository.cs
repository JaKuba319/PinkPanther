using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkPanther.Database
{
    public interface ITypeRepository : IBaseRepository<Type>
    {
        public IEnumerable<Type> GetTypes();
    }
}
