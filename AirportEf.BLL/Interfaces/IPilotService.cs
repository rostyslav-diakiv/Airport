﻿namespace AirportEf.BLL.Interfaces
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    public interface IPilotService : IService<PilotDto, PilotRequest, int>
    {
    }
}