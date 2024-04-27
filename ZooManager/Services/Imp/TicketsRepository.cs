using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManager.Models;

namespace ZooManager.Services.Imp
{
    public class TicketsRepository : ITicketsRepository
    {
        private ZooManager.Data.ZooManagerClient _zooManagerClient =
            new Data.ZooManagerClient("http://localhost:5290", new System.Net.Http.HttpClient());

        public void Add(Ticket item)
        {
            var id = _zooManagerClient.TicketCreateAsync(new Data.CreateTicketRequest
            {
                Excursion = item.Excursion,
                FeedingTheAnimals = item.FeedingTheAnimals,
                No = item.No,
                Photoshoot = item.Photoshoot,
                Price = item.Price,
                TicketType = item.TicketType
            }).Result;
        }

        public ObservableCollection<Ticket> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Ticket item)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket item)
        {
            throw new NotImplementedException();
        }
    }
}
