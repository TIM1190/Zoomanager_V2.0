using Microsoft.AspNetCore.Mvc;
using ZooManager.Api.Models;
using ZooManager.Api.Models.Requests;
using ZooManager.Api.Services;

namespace ZooManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpPost("create", Name = "TicketCreate")]
        public ActionResult<int> Create([FromBody] CreateTicketRequest request)
        {
            var ticket = new Ticket()
            {
                No = request.No,
                TicketType = request.TicketType,
                Price = request.Price,
                Excursion = request.Excursion,
                FeedingTheAnimals = request.FeedingTheAnimals,
                Photoshoot = request.Photoshoot
            };
            return Ok(_ticketRepository.Add(ticket));
        }
    }
}
