namespace PinkPanther.Database
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        public IEnumerable<Client> GetClients();
    }
}
