namespace Airport.BLL.Mapper
{
    using Airport.Common.Dtos;
    using Airport.DAL.Entities;

    using AutoMapper;

    public class TicketsProfile : Profile
    {
        public TicketsProfile()
        {
            CreateMap<Ticket, Ticket>(); // Don't Map Crews because in new obj the are empty!!!
            CreateMap<Ticket, TicketDto>()
                .ForMember(d => d.Flight, o => o.MapFrom(s => s.Flight));
        }
    }
}
