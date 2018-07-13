namespace Airport.DAL.Repositories
{
    using System.Collections.Generic;

    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class TicketRepository : Repository<Ticket, int>,  ITicketRepository
    {
        public TicketRepository(List<Ticket> entities, IMapper mapper)
            : base(entities, mapper)
        {
        }
    }
}
