using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkPanther.Database
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        protected override DbSet<Client> DbSet => _dbContext.Clients;

        public ClientRepository(PinkPantherDbContex dbContex) : base(dbContex)
        {
        }


        public IEnumerable<Client> GetClients()
        {
            return DbSet.Include(client => client.Animals);
        }
    }
}
