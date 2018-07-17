namespace Airport.BLL.Tests.Services.Tests.Intergation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Threading.Tasks;

    using Airport.Common.Requests;
    using Airport.Common.Services;

    using AirportEf.BLL.Mapper;
    using AirportEf.BLL.Services;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;
    using AirportEf.DAL.Interfaces.Repositories;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore.Query;

    using Moq;

    using Xunit;

    public class CrewServiceIntegrationTests
    {
        // TODO: Add As a fields to reuse
        // Mock Data
        private List<Crew> GetTestCrews()
        {
            var st1 = new Stewardess()
            {
                Id = 1,
                FirstName = "Alex",
                FamilyName = "Mayer",
                DateOfBirth = new DateTime(1997, 12, 22, 17, 30, 0),
                CrewStewardess = new List<CrewStewardess>()
            };
            var st2 = new Stewardess()
            {
                Id = 2,
                FirstName = "Bobby",
                FamilyName = "Strand",
                DateOfBirth = new DateTime(1996, 12, 22, 17, 30, 0),
                CrewStewardess = new List<CrewStewardess>()
            };
            var st3 = new Stewardess()
            {
                Id = 3,
                FirstName = "Celse",
                FamilyName = "Olead",
                DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                CrewStewardess = new List<CrewStewardess>()
            };
            var st4 = new Stewardess()
            {
                Id = 4,
                FirstName = "Shakira",
                FamilyName = "Pique",
                DateOfBirth = new DateTime(1994, 12, 22, 17, 30, 0),
                CrewStewardess = new List<CrewStewardess>()
            };
            var st5 = new Stewardess()
            {
                Id = 5,
                FirstName = "Olga",
                FamilyName = "Petrenko",
                DateOfBirth = new DateTime(1993, 12, 22, 17, 30, 0),
                CrewStewardess = new List<CrewStewardess>()
            };

            var p1 = new Pilot()
            {
                Id = 1,
                FirstName = "Serg",
                FamilyName = "Karas",
                DateOfBirth = new DateTime(1997, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(800, 00, 00, 00),
                Crews = new List<Crew>()
            };
            var p2 = new Pilot()
            {
                Id = 2,
                FirstName = "Ostap",
                FamilyName = "Bober",
                DateOfBirth = new DateTime(1996, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(3600, 00, 00, 00),
                Crews = new List<Crew>()
            };
            var p3 = new Pilot()
            {
                Id = 3,
                FirstName = "Sanya",
                FamilyName = "Morkva",
                DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(5000, 00, 00, 00),
                Crews = new List<Crew>()
            };
            var p4 = new Pilot()
            {
                Id = 4,
                FirstName = "John",
                FamilyName = "Opler",
                DateOfBirth = new DateTime(1994, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(1500, 00, 00, 00),
                Crews = new List<Crew>()
            };
            var p5 = new Pilot()
            {
                Id = 5,
                FirstName = "Michael",
                FamilyName = "Stoor",
                DateOfBirth = new DateTime(1993, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(2000, 00, 00, 00),
                Crews = new List<Crew>()
            };

            var c1 = new Crew()
            {
                Id = 1,
                Pilot = p1,
                PilotId = p1.Id,
                Departures = new List<Departure>(),
            };
            c1.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c1, Stewardess = st1 },
                                        new CrewStewardess() { Crew = c1, Stewardess = st2 }
                                    };

            var c2 = new Crew()
            {
                Id = 2,
                Pilot = p2,
                PilotId = p2.Id,
                Departures = new List<Departure>()
            };
            c2.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c2, Stewardess = st2 },
                                        new CrewStewardess() { Crew = c2, Stewardess = st3 }
                                    };

            var c3 = new Crew()
            {
                Id = 3,
                Pilot = p3,
                PilotId = p3.Id,
                Departures = new List<Departure>()
            };
            c3.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c3, Stewardess = st3 },
                                        new CrewStewardess() { Crew = c3, Stewardess = st4 }
                                    };

            var c4 = new Crew()
            {
                Id = 4,
                Pilot = p4,
                PilotId = p4.Id,
                Departures = new List<Departure>()
            };
            c4.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c4, Stewardess = st4 },
                                        new CrewStewardess() { Crew = c4, Stewardess = st5 }
                                    };

            var c5 = new Crew()
            {
                Id = 5,
                Pilot = p5,
                PilotId = p5.Id,
                Departures = new List<Departure>()
            };
            c5.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c5, Stewardess = st4 },
                                        new CrewStewardess() { Crew = c5, Stewardess = st5 }
                                    };
            var crews = new List<Crew>() { c1, c2, c3, c4, c5 };
            // context.Crews.AddRange(crews);
            return crews;
        }
    }
}
