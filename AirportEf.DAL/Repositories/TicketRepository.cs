namespace AirportEf.DAL.Repositories
{
    using AirportEf.DAL.Data;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class TicketRepository : Repository<Ticket, int>,  ITicketRepository
    {
        public TicketRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
