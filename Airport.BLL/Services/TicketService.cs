namespace Airport.BLL.Services
{
    using System.Collections.Generic;
    using System.Net;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.Common.Services;
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public class TicketService : BaseService<Ticket, TicketDto, TicketRequest, int>, ITicketService
    {
        public TicketService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override IEnumerable<TicketDto> GetAllEntity()
        {
            var tickets = uow.TicketRepository.GetRange();

            var dtos = mapper.Map<List<Ticket>, List<TicketDto>>(tickets);

            return dtos;
        }

        public override TicketDto GetEntityById(int id)
        {
            var entity = uow.TicketRepository.GetFirstOrDefault(s => s.Id == id);

            return MapEntity(entity);
        }

        public override TicketDto CreateEntity(TicketRequest request)
        {
            var entity = InstantiateTicket(request);

            entity = uow.TicketRepository.Create(entity);

            return MapEntity(entity);
        }

        public override Ticket UpdateEntityById(TicketRequest request, int id)
        {
            var entity = InstantiateTicket(request, id);

            var updated = uow.TicketRepository.Update(entity);

            return updated;
        }

        public override bool DeleteEntityById(int id)
        {
            var entity = uow.TicketRepository.GetFirstOrDefault(s => s.Id == id);
            var res = uow.TicketRepository.Delete(entity);
            if (!res)
            {
                return false;
            }

            entity.Flight?.Tickets?.Remove(entity);

            return true;
        }

        public Ticket InstantiateTicket(TicketRequest request, int id = 0)
        {
            var flight = uow.FlightRepository.GetFirstOrDefault(f => f.Id == request.FlightNumber);
            if (flight == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Flight with number: {request.FlightNumber} doesn't exist");
            }

            return new Ticket(request, flight, id);
        }
    }
}
