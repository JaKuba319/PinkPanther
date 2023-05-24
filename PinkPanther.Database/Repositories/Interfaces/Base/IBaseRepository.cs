using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkPanther.Database
{
    public interface IBaseRepository<Entity> where Entity : BaseEntity
    {
        public bool AddNew(Entity entity);
        public bool Delete(int id);
        public bool Update(Entity entity);
        public bool SaveChanges();
    }
}
