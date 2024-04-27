using ZooManager.Api.Models;

namespace ZooManager.Api.Services.Impl
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ZooManagetDbContext _dbContext;

        public TicketRepository(ZooManagetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Ticket item)
        {
            _dbContext.Tickets.Add(item);
            _dbContext.SaveChanges();
            return item.Id;
        }

        public ICollection<Ticket> GetAll()
        {
            throw new NotImplementedException();
        }

        public Ticket? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ticket item)
        {
            throw new NotImplementedException();
        }
    }
}
