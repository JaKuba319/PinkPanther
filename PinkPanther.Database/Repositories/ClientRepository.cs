using Microsoft.EntityFrameworkCore;

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

        public override bool Update(Client entity)
        {
            var oldEntity = DbSet.Where(_entity => _entity.Id == entity.Id).FirstOrDefault();
            if (oldEntity != null)
            {
                oldEntity.FirstName = entity.FirstName;
                oldEntity.LastName = entity.LastName;
                oldEntity.PhoneNumber = entity.PhoneNumber;
                oldEntity.Email = entity.Email;
                oldEntity.Gender = entity.Gender;
                oldEntity.BirthDate = entity.BirthDate;
                return SaveChanges();
            }
            return false;
        }

    }
}
