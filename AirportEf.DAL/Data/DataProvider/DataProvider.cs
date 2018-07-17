namespace AirportEf.DAL.Data.DataProvider
{
    using System;
    using System.Collections.Generic;
    using AirportEf.DAL.Entities;

    public class DataProvider
    {
        public static List<Pilot> GetPilots()
        {
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

            return new List<Pilot>() { p1, p2, p3, p4, p5 };
        }

        public static List<Stewardess> GetStewardesses()
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

            return new List<Stewardess>() { st1, st2, st3, st4, st5 };
        }

        public static List<Crew> GetCrews()
        {
            var pilots = GetPilots();
            var stewardesses = GetStewardesses();
            var c1 = new Crew()
            {
                Id = 1,
                Pilot = pilots[0],
                PilotId = pilots[0].Id,
                Departures = new List<Departure>(),
            };
            c1.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c1, Stewardess = stewardesses[0], CrewId = c1.Id, StewardessId = stewardesses[0].Id },
                                        new CrewStewardess() { Crew = c1, Stewardess = stewardesses[1], CrewId = c1.Id, StewardessId = stewardesses[1].Id }
                                    };

            var c2 = new Crew()
            {
                Id = 2,
                Pilot = pilots[1],
                PilotId = pilots[1].Id,
                Departures = new List<Departure>()
            };
            c2.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c2, Stewardess = stewardesses[1], CrewId = c2.Id, StewardessId = stewardesses[1].Id },
                                        new CrewStewardess() { Crew = c2, Stewardess = stewardesses[2], CrewId = c2.Id, StewardessId = stewardesses[2].Id }
                                    };

            var c3 = new Crew()
            {
                Id = 3,
                Pilot = pilots[2],
                PilotId = pilots[2].Id,
                Departures = new List<Departure>()
            };
            c3.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c3, Stewardess = stewardesses[2], CrewId = c3.Id, StewardessId = stewardesses[2].Id },
                                        new CrewStewardess() { Crew = c3, Stewardess = stewardesses[3], CrewId = c3.Id, StewardessId = stewardesses[3].Id }
                                    };

            var c4 = new Crew()
            {
                Id = 4,
                Pilot = pilots[3],
                PilotId = pilots[3].Id,
                Departures = new List<Departure>()
            };
            c4.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c4, Stewardess = stewardesses[3], CrewId = c4.Id, StewardessId = stewardesses[3].Id },
                                        new CrewStewardess() { Crew = c4, Stewardess = stewardesses[4], CrewId = c4.Id, StewardessId = stewardesses[4].Id }
                                    };

            var c5 = new Crew()
            {
                Id = 5,
                Pilot = pilots[4],
                PilotId = pilots[4].Id,
                Departures = new List<Departure>()
            };
            c5.CrewStewardess = new List<CrewStewardess>()
                                    {
                                        new CrewStewardess() { Crew = c5, Stewardess = stewardesses[0], CrewId = c5.Id, StewardessId = stewardesses[0].Id },
                                        new CrewStewardess() { Crew = c5, Stewardess = stewardesses[4], CrewId = c5.Id, StewardessId = stewardesses[4].Id }
                                    };
            var crews = new List<Crew>() { c1, c2, c3, c4, c5 };
            foreach (var c in crews)
            {
                // Link Crew to Pilot
                c.Pilot.Crews.Add(c);


                // Link CrewStewardess to Stewardesses
                foreach (var cs in c.CrewStewardess)
                {
                    cs.Stewardess.CrewStewardess.Add(cs);
                }
            }

            return crews;
        }

        public static List<PlaneType> GetPlaneTypes()
        {
            var pt1 = new PlaneType()
                          {
                              Id = 1,
                              PlaneModel = "Boeing 737",
                              MaxNumberOfPlaces = 333,
                              MaxCarryingCapacityKg = 45070,
                              Planes = new List<Plane>()
                          };
            var pt2 = new PlaneType()
                          {
                              Id = 2,
                              PlaneModel = "Eclipse 500",
                              MaxNumberOfPlaces = 15,
                              MaxCarryingCapacityKg = 15000,
                              Planes = new List<Plane>()
                          };
            var pt3 = new PlaneType()
                          {
                              Id = 3,
                              PlaneModel = "Boeing 787",
                              MaxNumberOfPlaces = 160,
                              MaxCarryingCapacityKg = 55070,
                              Planes = new List<Plane>()
                          };
            var pt4 = new PlaneType()
                          {
                              Id = 4,
                              PlaneModel = "Hawker Siddeley 125",
                              MaxNumberOfPlaces = 30,
                              MaxCarryingCapacityKg = 10070,
                              Planes = new List<Plane>()
                          };
            var pt5 = new PlaneType()
                          {
                              Id = 5,
                              PlaneModel = "Dassault Falcon 7X",
                              MaxNumberOfPlaces = 150,
                              MaxCarryingCapacityKg = 35070,
                              Planes = new List<Plane>()
                          };

            return new List<PlaneType>() { pt1, pt2, pt3, pt4, pt5 };
        }

        public static List<Plane> GetPlanes()
        {
            var pt = GetPlaneTypes();
            var pl1 = new Plane()
                          {
                              Id = 1,
                              Name = "Bogatyr!",
                              PlaneType = pt[0],
                              PlaneTypeId = pt[0].Id,
                              CreationDate = new DateTime(1999, 09, 12),
                              LifeTime = new TimeSpan(10950, 00, 00, 00),
                              Departures = new List<Departure>()
                          };
            var pl2 = new Plane()
                          {
                              Name = "Serpantyn",
                              Id = 2,
                              PlaneType = pt[1],
                              PlaneTypeId = pt[1].Id,
                              CreationDate = new DateTime(1989, 2, 2),
                              LifeTime = new TimeSpan(8950, 00, 00, 00),
                              Departures = new List<Departure>()
                          };
            var pl3 = new Plane()
                          {
                              Name = "Geffry Lucker",
                              Id = 3,
                              PlaneType = pt[2],
                              PlaneTypeId = pt[2].Id,
                              CreationDate = new DateTime(2001, 11, 12),
                              LifeTime = new TimeSpan(11950, 00, 00, 00),
                              Departures = new List<Departure>()
                          };
            var pl4 = new Plane()
                          {
                              Name = "Sweet Life",
                              Id = 4,
                              PlaneType = pt[3],
                              PlaneTypeId = pt[3].Id,
                              CreationDate = new DateTime(1990, 09, 12),
                              LifeTime = new TimeSpan(12950, 00, 00, 00),
                              Departures = new List<Departure>()
                          };
            var pl5 = new Plane()
                          {
                              Name = "Kassandra",
                              Id = 5,
                              PlaneType = pt[4],
                              PlaneTypeId = pt[4].Id,
                              CreationDate = new DateTime(1998, 09, 12),
                              LifeTime = new TimeSpan(7550, 00, 00, 00),
                              Departures = new List<Departure>()
                          };
            var planes = new List<Plane>() { pl1, pl2, pl3, pl4, pl5 };
            // Link PlaneTypes to Planes that has type of them
            foreach (var pl in planes)
            {
                pl.PlaneType.Planes.Add(pl);
            }

            return planes;
        }

        public static List<Flight> GetFlights()
        {
            var f1 = new Flight()
            {
                Id = "ARY46B",
                DeparturePoint = "USA, Los Angeles",
                Destination = "Ukraine, Kiev",
                DepartureTime = new DateTime(2018, 7, 14, 2, 00, 00),
                DestinationArrivalTime = new DateTime(2018, 7, 17),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            var f2 = new Flight()
            {
                Id = "BARA687",
                DeparturePoint = "Ukraine, Kiev",
                Destination = "USA, Los Angeles",
                DepartureTime = new DateTime(2018, 7, 12, 2, 00, 00),
                DestinationArrivalTime = new DateTime(2018, 7, 15),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            var f3 = new Flight()
            {
                Id = "STAR46",
                DeparturePoint = "USA, New York",
                Destination = "Ukraine, Lviv",
                DepartureTime = new DateTime(2018, 7, 17, 1, 0, 0),
                DestinationArrivalTime = new DateTime(2018, 7, 20),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            var f4 = new Flight()
            {
                Id = "MAYA879",
                DeparturePoint = "China, Hong Kong",
                Destination = "Russia, Moscow",
                DepartureTime = new DateTime(2018, 12, 22, 12, 30, 00),
                DestinationArrivalTime = new DateTime(2018, 12, 24),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            var f5 = new Flight()
            {
                Id = "BMW777",
                DeparturePoint = "USA, Ohio",
                Destination = "Ukraine, Kharkiv",
                DepartureTime = new DateTime(2018, 8, 11, 12, 00, 00),
                DestinationArrivalTime = new DateTime(2018, 7, 13),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };

            return new List<Flight>() { f1, f2, f3, f4, f5 };
        }

        public static List<Ticket> GetTickets()
        {
            var flights = GetFlights();
            var t1 = new Ticket()
                         {
                             Id = 1,
                             Price = 160,
                             Flight = flights[0],
                             FlightId = flights[0].Id
                         };
            var t2 = new Ticket()
                         {
                             Id = 2,
                             Price = 180,
                             Flight = flights[1],
                             FlightId = flights[1].Id
                         };
            var t3 = new Ticket()
                         {
                             Id = 3,
                             Price = 100,
                             Flight = flights[2],
                             FlightId = flights[2].Id
                         };
            var t4 = new Ticket()
                         {
                             Id = 4,
                             Price = 110,
                             Flight = flights[3],
                             FlightId = flights[3].Id
                         };
            var t5 = new Ticket()
                         {
                             Id = 5,
                             Price = 400,
                             Flight = flights[4],
                             FlightId = flights[4].Id
                         };
            var t6 = new Ticket()
                         {
                             Id = 6,
                             Price = 560,
                             Flight = flights[1],
                             FlightId = flights[1].Id
                         };
            var t7 = new Ticket()
                         {
                             Id = 7,
                             Price = 550,
                             Flight = flights[2],
                             FlightId = flights[2].Id
                         };
            var t8 = new Ticket()
                         {
                             Id = 8,
                             Price = 240,
                             Flight = flights[0],
                             FlightId = flights[0].Id
                         };
            var t9 = new Ticket()
                         {
                             Id = 9,
                             Price = 160,
                             Flight = flights[3],
                             FlightId = flights[3].Id
                         };

            var tickets = new List<Ticket> { t1, t2, t3, t4, t5, t6, t7, t8, t9 };

            // Link Tickets and Departures to Flights
            foreach (var t in tickets)
            {
                t.Flight.Tickets.Add(t);
            }

            return tickets;
        }

        public static List<Departure> GetDepartures()
        {
            var flights = GetFlights();
            var crews = GetCrews();
            var planes = GetPlanes();
            var d1 = new Departure
            {
                Id = 1,
                Flight = flights[0],
                FlightId = flights[0].Id,
                DepartureTime = new DateTime(2018, 7, 14, 22, 00, 00),
                Crew = crews[0],
                CrewId = crews[0].Id,
                Plane = planes[0],
                PlaneId = planes[0].Id
            };
            var d2 = new Departure()
            {
                Id = 2,
                Flight = flights[1],
                FlightId = flights[1].Id,
                DepartureTime = new DateTime(2018, 7, 13, 12, 00, 00),
                Crew = crews[1],
                CrewId = crews[1].Id,
                Plane = planes[1],
                PlaneId = planes[1].Id
            };
            var d3 = new Departure()
            {
                Id = 3,
                Flight = flights[2],
                FlightId = flights[2].Id,
                DepartureTime = new DateTime(2018, 7, 18, 12, 00, 00),
                Crew = crews[2],
                CrewId = crews[2].Id,
                Plane = planes[2],
                PlaneId = planes[2].Id
            };
            var d4 = new Departure()
            {
                Id = 4,
                Flight = flights[3],
                FlightId = flights[3].Id,
                DepartureTime = new DateTime(2018, 12, 24, 6, 00, 00),
                Crew = crews[3],
                CrewId = crews[3].Id,
                Plane = planes[3],
                PlaneId = planes[3].Id
            };
            var d5 = new Departure()
            {
                Id = 5,
                Flight = flights[4],
                FlightId = flights[4].Id,
                DepartureTime = new DateTime(2018, 8, 11, 12, 00, 00), // In Time!
                Crew = crews[4],
                CrewId = crews[4].Id,
                Plane = planes[4],
                PlaneId = planes[4].Id
            };
            var d6 = new Departure()
            {
                Id = 6,
                Flight = flights[0],
                FlightId = flights[0].Id,
                DepartureTime = new DateTime(2018, 7, 15, 0, 00, 00),
                Crew = crews[0],
                CrewId = crews[0].Id,
                Plane = planes[0],
                PlaneId = planes[0].Id
            };
            var departures = new List<Departure>() { d1, d2, d3, d4, d5, d6 };

            foreach (var d in departures)
            {
                d.Flight.Departures.Add(d);
                d.Crew.Departures.Add(d);
                d.Plane.Departures.Add(d);
            }

            return departures;
        }
    }
}
