﻿namespace AirportEf.BLL.Services
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.Common.Services;

    using AirportEf.BLL.Interfaces;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    public class TicketService : BaseService<Ticket, TicketDto, TicketRequest, int>, ITicketService
    {
        public TicketService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override async Task<IEnumerable<TicketDto>> GetAllEntitiesAsync()
        {
            var tickets = await uow.TicketRepository.GetRangeAsync(include: ticket => ticket.Include(t => t.Flight));

            var dtos = mapper.Map<List<Ticket>, List<TicketDto>>(tickets);

            return dtos;
        }

        public override async Task<TicketDto> GetEntityByIdAsync(int id)
        {
            var entity = await uow.TicketRepository.GetFirstOrDefaultAsync(
                                        s => s.Id == id, 
                                        include: ticket => ticket.Include(t => t.Flight));

            return MapEntity(entity);
        }

        public override async Task<TicketDto> CreateEntityAsync(TicketRequest request)
        {
            var entity = await InstantiateTicketAsync(request);

            entity = await uow.TicketRepository.CreateAsync(entity);
            var result = await uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            return MapEntity(entity);
        }

        public override async Task<bool> UpdateEntityByIdAsync(TicketRequest request, int id)
        {
            var entity = await InstantiateTicketAsync(request, id);

            var updated = await uow.TicketRepository.UpdateAsync(entity);
            var result = await uow.SaveAsync();

            return result;
        }

        public override async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await uow.TicketRepository.DeleteAsync(id);

            var result = await uow.SaveAsync();

            return result;
        }

        public async Task<Ticket> InstantiateTicketAsync(TicketRequest request, int id = 0)
        {
            var exists = await uow.FlightRepository.ExistAsync(f => f.Id == request.FlightNumber);
            if (!exists)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Flight with number: {request.FlightNumber} doesn't exist");
            }

            return new Ticket(request, id);
        }
    }
}
