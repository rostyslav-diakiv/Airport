﻿namespace AirportEf.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.DAL.Entities;

    public interface ICrewService : IService<Crew, CrewDto, CrewRequest, int>
    {
    }
}