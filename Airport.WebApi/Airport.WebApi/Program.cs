using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Airport.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Airport.WebApi.Extensions;

    using AirportEf.DAL.Data;
    using AirportEf.DAL.Entities;

    using Microsoft.Extensions.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                        .Build()
                        .Migrate<AirportDbContext>(SeedAction)
                        .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var env = hostingContext.HostingEnvironment;
                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                        config.AddEnvironmentVariables();
                    })
                .UseIISIntegration()
                .UseStartup<Startup>();


        private static void SeedAction(AirportDbContext context)
        {
            if (context.Pilots.Any())
            {
                return;
            }

            var st1 = new Stewardess()
            {
                FirstName = "Alex",
                FamilyName = "Mayer",
                DateOfBirth = new DateTime(1997, 12, 22, 17, 30, 0),
                CrewStewardess = new List<CrewStewardess>()
            };

            var st2 = new Stewardess()
            {
                FirstName = "Bobby",
                FamilyName = "Strand",
                DateOfBirth = new DateTime(1996, 12, 22, 17, 30, 0),
                CrewStewardess = new List<CrewStewardess>()
            };
            var st3 = new Stewardess()
            {
                FirstName = "Celse",
                FamilyName = "Olead",
                DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                CrewStewardess = new List<CrewStewardess>()
            };
            var st4 = new Stewardess()
            {
                FirstName = "Shakira",
                FamilyName = "Pique",
                DateOfBirth = new DateTime(1994, 12, 22, 17, 30, 0),
                CrewStewardess = new List<CrewStewardess>()
            };
            var st5 = new Stewardess()
            {
                FirstName = "Olga",
                FamilyName = "Petrenko",
                DateOfBirth = new DateTime(1993, 12, 22, 17, 30, 0),
                CrewStewardess = new List<CrewStewardess>()
            };
            // var stewardesses = new List<Stewardess>() { st1, st2, st3, st4, st5 };

            var p1 = new Pilot()
            {
                FirstName = "Serg",
                FamilyName = "Karas",
                DateOfBirth = new DateTime(1997, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(800, 00, 00, 00),
                Crews = new List<Crew>()
            };
            var p2 = new Pilot()
            {
                FirstName = "Ostap",
                FamilyName = "Bober",
                DateOfBirth = new DateTime(1996, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(3600, 00, 00, 00),
                Crews = new List<Crew>()
            };
            var p3 = new Pilot()
            {
                FirstName = "Sanya",
                FamilyName = "Morkva",
                DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(5000, 00, 00, 00),
                Crews = new List<Crew>()
            };
            var p4 = new Pilot()
            {
                FirstName = "John",
                FamilyName = "Opler",
                DateOfBirth = new DateTime(1994, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(1500, 00, 00, 00),
                Crews = new List<Crew>()
            };
            var p5 = new Pilot() // TODO: unused 
            {
                FirstName = "Michael",
                FamilyName = "Stoor",
                DateOfBirth = new DateTime(1993, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(2000, 00, 00, 00),
                Crews = new List<Crew>()
            };
            // var pilots = new List<Pilot>() { p1, p2, p3, p4, p5 };

            var c1 = new Crew()
            {
                Pilot = p1,
                PilotId = p1.Id,
                Departures = new List<Departure>(),
                // CrewStewardess = new List<CrewStewardess>()
            };
            c1.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c1, Stewardess = st1 },
                                        new CrewStewardess() { Crew = c1, Stewardess = st2 }
                                    };

            var c2 = new Crew()
            {
                Pilot = p2,
                PilotId = p2.Id,
                Departures = new List<Departure>(),
                // CrewStewardess = new List<CrewStewardess>()
            };
            c2.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c2, Stewardess = st2 },
                                        new CrewStewardess() { Crew = c2, Stewardess = st3 }
                                    };

            var c3 = new Crew()
            {
                Pilot = p3,
                PilotId = p3.Id,
                Departures = new List<Departure>(),
                // CrewStewardess = new List<CrewStewardess>()
            };
            c3.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c3, Stewardess = st3 },
                                        new CrewStewardess() { Crew = c3, Stewardess = st4 }
                                    };

            var c4 = new Crew()
            {
                Pilot = p4,
                PilotId = p4.Id,
                Departures = new List<Departure>(),
                // CrewStewardess = new List<CrewStewardess>()
            };
            c4.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c4, Stewardess = st4 },
                                        new CrewStewardess() { Crew = c4, Stewardess = st5 }
                                    };

            var c5 = new Crew()
            {
                Pilot = p5,
                PilotId = p5.Id,
                Departures = new List<Departure>(),
                // CrewStewardess = new List<CrewStewardess>()
            };
            c5.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c5, Stewardess = st4 },
                                        new CrewStewardess() { Crew = c5, Stewardess = st5 }
                                    };

            var crews = new List<Crew>() { c1, c2, c3, c4, c5 };

            context.Crews.AddRange(crews);


            //foreach (var c in Crews)
            //{
            //    c.Pilot.Crews.Add(c);
            //    foreach (var s in c.Stewardesses)
            //    {
            //        s.Crews.Add(c);
            //    }
            //}

            #region Planes

            var pt1 = new PlaneType()
            {
                PlaneModel = "Boeing 737",
                MaxNumberOfPlaces = 333,
                MaxCarryingCapacityKg = 45070,
                Planes = new List<Plane>()
            };
            var pt2 = new PlaneType()
            {
                PlaneModel = "Eclipse 500",
                MaxNumberOfPlaces = 15,
                MaxCarryingCapacityKg = 15000,
                Planes = new List<Plane>()
            };
            var pt3 = new PlaneType()
            {
                PlaneModel = "Boeing 787",
                MaxNumberOfPlaces = 160,
                MaxCarryingCapacityKg = 55070,
                Planes = new List<Plane>()
            };
            var pt4 = new PlaneType()
            {
                PlaneModel = "Hawker Siddeley 125",
                MaxNumberOfPlaces = 30,
                MaxCarryingCapacityKg = 10070,
                Planes = new List<Plane>()
            };
            var pt5 = new PlaneType()
            {
                PlaneModel = "Dassault Falcon 7X",
                MaxNumberOfPlaces = 150,
                MaxCarryingCapacityKg = 35070,
                Planes = new List<Plane>()
            };
            // var planeTypes = new List<PlaneType>() { pt1, pt2, pt3, pt4, pt5 };

            var pl1 = new Plane()
            {
                Name = "Bogatyr!",
                PlaneType = pt5,
                PlaneTypeId = pt5.Id,
                CreationDate = new DateTime(1999, 09, 12),
                LifeTime = new TimeSpan(10950, 00, 00, 00),
                Departures = new List<Departure>()
            };

            var pl2 = new Plane()
            {
                Name = "Serpantyn",
                PlaneType = pt1,
                PlaneTypeId = pt1.Id,
                CreationDate = new DateTime(1989, 2, 2),
                LifeTime = new TimeSpan(8950, 00, 00, 00),
                Departures = new List<Departure>()
            };
            var pl3 = new Plane()
            {
                Name = "Geffry Lucker",
                PlaneType = pt2,
                PlaneTypeId = pt2.Id,
                CreationDate = new DateTime(2001, 11, 12),
                LifeTime = new TimeSpan(11950, 00, 00, 00),
                Departures = new List<Departure>()
            };
            var pl4 = new Plane()
            {
                Name = "Sweet Life",
                PlaneType = pt3,
                PlaneTypeId = pt3.Id,
                CreationDate = new DateTime(1990, 09, 12),
                LifeTime = new TimeSpan(12950, 00, 00, 00),
                Departures = new List<Departure>()
            };
            var pl5 = new Plane()
            {
                Name = "Kassandra",
                PlaneType = pt1,
                PlaneTypeId = pt1.Id,
                CreationDate = new DateTime(1998, 09, 12),
                LifeTime = new TimeSpan(7550, 00, 00, 00),
                Departures = new List<Departure>()
            };

            var planes = new List<Plane>() { pl1, pl2, pl3, pl4, pl5 };

            //context.Planes.AddRange(planes);

            // Link PlaneTypes to Planes that has type of them
            //foreach (var pl in Planes)
            //{
            //    pl.PlaneType.Planes.Add(pl);
            //}

            #endregion

            #region Flights

            var f1 = new Flight()
            {
                DeparturePoint = "USA, Los Angeles",
                Destination = "Ukraine, Kiev",
                DepartureTime = new DateTime(2018, 7, 14, 2, 00, 00),
                DestinationArrivalTime = new DateTime(2018, 7, 17),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            var f2 = new Flight()
            {
                DeparturePoint = "Ukraine, Kiev",
                Destination = "USA, Los Angeles",
                DepartureTime = new DateTime(2018, 7, 12, 2, 00, 00),
                DestinationArrivalTime = new DateTime(2018, 7, 15),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            var f3 = new Flight()
            {
                DeparturePoint = "USA, New York",
                Destination = "Ukraine, Lviv",
                DepartureTime = new DateTime(2018, 7, 17, 1, 0, 0),
                DestinationArrivalTime = new DateTime(2018, 7, 20),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            var f4 = new Flight()
            {
                DeparturePoint = "China, Hong Kong",
                Destination = "Russia, Moscow",
                DepartureTime = new DateTime(2018, 12, 22, 12, 30, 00),
                DestinationArrivalTime = new DateTime(2018, 12, 24),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            var f5 = new Flight()
            {
                DeparturePoint = "USA, Ohio",
                Destination = "Ukraine, Kharkiv",
                DepartureTime = new DateTime(2018, 8, 11, 12, 00, 00),
                DestinationArrivalTime = new DateTime(2018, 7, 13),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            // var flights = new List<Flight>() { f1, f2, f3, f4, f5 };

            var t1 = new Ticket()
            {
                Price = 160,
                Flight = f2,
                FlightId = f2.Id
            };

            var t2 = new Ticket()
            {
                Price = 180,
                Flight = f2,
                FlightId = f2.Id
            };
            var t3 = new Ticket()
            {
                Price = 100,
                Flight = f1,
                FlightId = f1.Id
            };
            var t4 = new Ticket()
            {
                Price = 110,
                Flight = f1,
                FlightId = f1.Id
            };
            var t5 = new Ticket()
            {
                Price = 400,
                Flight = f3,
                FlightId = f3.Id
            };
            var t6 = new Ticket()
            {
                Price = 560,
                Flight = f4,
                FlightId = f4.Id
            };
            var t7 = new Ticket()
            {
                Price = 550,
                Flight = f4,
                FlightId = f4.Id
            };
            var t8 = new Ticket()
            {
                Price = 240,
                Flight = f4,
                FlightId = f4.Id
            };
            var t9 = new Ticket()
            {
                Price = 160,
                Flight = f5,
                FlightId = f5.Id
            };

            var tickets = new List<Ticket>() { t1, t2, t3, t4, t5, t6, t7, t8, t9 };

            //context.Tickets.AddRange(tickets);

            var d1 = new Departure()
            {
                Flight = f1,
                FlightId = f1.Id,
                DepartureTime = new DateTime(2018, 7, 14, 22, 00, 00),
                Crew = c1,
                CrewId = c1.Id,
                Plane = pl1,
                PlaneId = pl1.Id
            };

            var d2 = new Departure()
            {
                Flight = f2,
                FlightId = f2.Id,
                DepartureTime = new DateTime(2018, 7, 13, 12, 00, 00),
                Crew = c2,
                CrewId = c2.Id,
                Plane = pl2,
                PlaneId = pl2.Id
            };
            var d3 = new Departure()
            {
                Flight = f3,
                FlightId = f3.Id,
                DepartureTime = new DateTime(2018, 7, 18, 12, 00, 00),
                Crew = c3,
                CrewId = c3.Id,
                Plane = pl3,
                PlaneId = pl3.Id
            };
            var d4 = new Departure()
            {
                Flight = f4,
                FlightId = f4.Id,
                DepartureTime = new DateTime(2018, 12, 24, 6, 00, 00),
                Crew = c4,
                CrewId = c4.Id,
                Plane = pl4,
                PlaneId = pl4.Id
            };
            var d5 = new Departure()
            {
                Flight = f5,
                FlightId = f5.Id,
                DepartureTime = new DateTime(2018, 8, 11, 12, 00, 00), // In Time!
                Crew = c5,
                CrewId = c5.Id,
                Plane = pl5,
                PlaneId = pl5.Id
            };
            var d6 = new Departure()
            {
                Flight = f1,
                FlightId = f1.Id,
                DepartureTime = new DateTime(2018, 7, 15, 0, 00, 00),
                Crew = c1,
                CrewId = c1.Id,
                Plane = pl1,
                PlaneId = pl1.Id
            };

            var departures = new List<Departure>() { d1, d2, d3, d4, d5, d6 };

            //context.Departures.AddRange(departures);

            // Link Tickets and Departures to Flights
            //foreach (var t in Tickets)
            //{
            //    t.Flight.Tickets.Add(t);
            //}
            //foreach (var d in Departures)
            //{
            //    d.Flight.Departures.Add(d);
            //    d.Crew.Departures.Add(d);
            //    d.Plane.Departures.Add(d);
            //}
            #endregion

            context.SaveChanges();
        }
    }
}
