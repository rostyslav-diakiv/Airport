using System;
using System.Collections.Generic;

namespace Airport.DAL.Data
{
    using Airport.DAL.Entities;

    public class DataProvider : IDataProvider
    {
        public List<Stewardess> Stewardesses { get; set; }

        public List<PlaneType> PlaneTypes { get; set; }

        public List<Pilot> Pilots { get; set; }

        public List<Crew> Crews { get; set; }

        public List<Plane> Planes { get; set; }

        public List<Flight> Flights { get; set; }

        public List<Ticket> Tickets { get; set; }

        public List<Departure> Departures { get; set; }


        public DataProvider()
        {
            #region Crew

            var st1 = new Stewardess()
            {
                FirstName = "Alex",
                FamilyName = "Mayer",
                DateOfBirth = new DateTime(1997, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            st1.Id = st1.GetGeneratedId();

            var st2 = new Stewardess()
            {
                Id = st1.GetGeneratedId(),
                FirstName = "Bobby",
                FamilyName = "Strand",
                DateOfBirth = new DateTime(1996, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            var st3 = new Stewardess()
            {
                Id = st1.GetGeneratedId(),
                FirstName = "Celse",
                FamilyName = "Olead",
                DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            var st4 = new Stewardess()
            {
                Id = st1.GetGeneratedId(),
                FirstName = "Shakira",
                FamilyName = "Pique",
                DateOfBirth = new DateTime(1994, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            var st5 = new Stewardess()
            {
                Id = st1.GetGeneratedId(),
                FirstName = "Olga",
                FamilyName = "Petrenko",
                DateOfBirth = new DateTime(1993, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            Stewardesses = new List<Stewardess>() { st1, st2, st3, st4, st5 };

            var p1 = new Pilot()
            {
                FirstName = "Serg",
                FamilyName = "Karas",
                DateOfBirth = new DateTime(1997, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(800, 00, 00, 00),
                Crews = new List<Crew>()
            };
            p1.Id = p1.GetGeneratedId();

            var p2 = new Pilot()
            {
                Id = p1.GetGeneratedId(),
                FirstName = "Ostap",
                FamilyName = "Bober",
                DateOfBirth = new DateTime(1996, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(3600, 00, 00, 00),
                Crews = new List<Crew>()
            };
            var p3 = new Pilot()
            {
                Id = p1.GetGeneratedId(),
                FirstName = "Sanya",
                FamilyName = "Morkva",
                DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(5000, 00, 00, 00),
                Crews = new List<Crew>()
            };
            var p4 = new Pilot()
            {
                Id = p1.GetGeneratedId(),
                FirstName = "John",
                FamilyName = "Opler",
                DateOfBirth = new DateTime(1994, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(1500, 00, 00, 00),
                Crews = new List<Crew>()
            };
            var p5 = new Pilot() // TODO: unused 
            {
                Id = p1.GetGeneratedId(),
                FirstName = "Michael",
                FamilyName = "Stoor",
                DateOfBirth = new DateTime(1993, 12, 22, 17, 30, 0),
                Experience = new TimeSpan(2000, 00, 00, 00),
                Crews = new List<Crew>()
            };
            Pilots = new List<Pilot>() { p1, p2, p3, p4, p5 };

            var c1 = new Crew()
            {
                Pilot = p1,
                PilotId = p1.Id,
                Stewardesses = new List<Stewardess> { st1, st2 },
                Departures = new List<Departure>()
            };
            c1.Id = c1.GetGeneratedId();

            var c2 = new Crew()
            {
                Id = c1.GetGeneratedId(),
                Pilot = p1,
                PilotId = p1.Id,
                Stewardesses = new List<Stewardess>() { st1, st4 },
                Departures = new List<Departure>()
            };
            var c3 = new Crew()
            {
                Id = c1.GetGeneratedId(),
                Pilot = p3,
                PilotId = p3.Id,
                Stewardesses = new List<Stewardess>() { st2, st3, st4 },
                Departures = new List<Departure>()
            };
            var c4 = new Crew()
            {
                Id = c1.GetGeneratedId(),
                Pilot = p2,
                PilotId = p2.Id,
                Stewardesses = new List<Stewardess>() { st5 },
                Departures = new List<Departure>()
            };
            var c5 = new Crew()
            {
                Id = c1.GetGeneratedId(),
                Pilot = p4,
                PilotId = p4.Id,
                Stewardesses = new List<Stewardess>() { st3, st1, st2 },
                Departures = new List<Departure>()
            };
            Crews = new List<Crew>() { c1, c2, c3, c4, c5 };

            foreach (var c in Crews)
            {
                c.Pilot.Crews.Add(c);
                foreach (var s in c.Stewardesses)
                {
                    s.Crews.Add(c);
                }
            }

            #endregion

            #region Planes

            var pt1 = new PlaneType()
            {
                PlaneModel = "Boeing 737",
                MaxNumberOfPlaces = 333,
                MaxCarryingCapacityKg = 45070,
                Planes = new List<Plane>()
            };
            pt1.Id = pt1.GetGeneratedId();

            var pt2 = new PlaneType()
            {
                Id = pt1.GetGeneratedId(),
                PlaneModel = "Eclipse 500",
                MaxNumberOfPlaces = 15,
                MaxCarryingCapacityKg = 15000,
                Planes = new List<Plane>()
            };
            var pt3 = new PlaneType()
            {
                Id = pt1.GetGeneratedId(),
                PlaneModel = "Boeing 787",
                MaxNumberOfPlaces = 160,
                MaxCarryingCapacityKg = 55070,
                Planes = new List<Plane>()
            };
            var pt4 = new PlaneType()
            {
                Id = pt1.GetGeneratedId(),
                PlaneModel = "Hawker Siddeley 125",
                MaxNumberOfPlaces = 30,
                MaxCarryingCapacityKg = 10070,
                Planes = new List<Plane>()
            };
            var pt5 = new PlaneType()
            {
                Id = pt1.GetGeneratedId(),
                PlaneModel = "Dassault Falcon 7X",
                MaxNumberOfPlaces = 150,
                MaxCarryingCapacityKg = 35070,
                Planes = new List<Plane>()
            };
            PlaneTypes = new List<PlaneType>() { pt1, pt2, pt3, pt4, pt5 };

            var pl1 = new Plane()
            {
                Name = "Bogatyr!",
                PlaneType = pt5,
                PlaneTypeId = pt5.Id,
                CreationDate = new DateTime(1999, 09, 12),
                LifeTime = new TimeSpan(10950, 00, 00, 00),
                Departures = new List<Departure>()
            };
            pl1.Id = pl1.GetGeneratedId();

            var pl2 = new Plane()
            {
                Name = "Serpantyn",
                Id = pl1.GetGeneratedId(),
                PlaneType = pt1,
                PlaneTypeId = pt1.Id,
                CreationDate = new DateTime(1989, 2, 2),
                LifeTime = new TimeSpan(8950, 00, 00, 00),
                Departures = new List<Departure>()
            };
            var pl3 = new Plane()
            {
                Name = "Geffry Lucker",
                Id = pl1.GetGeneratedId(),
                PlaneType = pt2,
                PlaneTypeId = pt2.Id,
                CreationDate = new DateTime(2001, 11, 12),
                LifeTime = new TimeSpan(11950, 00, 00, 00),
                Departures = new List<Departure>()
            };
            var pl4 = new Plane()
            {
                Name = "Sweet Life",
                Id = pl1.GetGeneratedId(),
                PlaneType = pt3,
                PlaneTypeId = pt3.Id,
                CreationDate = new DateTime(1990, 09, 12),
                LifeTime = new TimeSpan(12950, 00, 00, 00),
                Departures = new List<Departure>()
            };
            var pl5 = new Plane()
            {
                Name = "Kassandra",
                Id = pl1.GetGeneratedId(),
                PlaneType = pt1,
                PlaneTypeId = pt1.Id,
                CreationDate = new DateTime(1998, 09, 12),
                LifeTime = new TimeSpan(7550, 00, 00, 00),
                Departures = new List<Departure>()
            };
            Planes = new List<Plane>() { pl1, pl2, pl3, pl4, pl5 };

            // Link PlaneTypes to Planes that has type of them
            foreach (var pl in Planes)
            {
                pl.PlaneType.Planes.Add(pl);
            }

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
            f1.Id = f1.GetGeneratedId();

            var f2 = new Flight()
            {
                Id = f1.GetGeneratedId(),
                DeparturePoint = "Ukraine, Kiev",
                Destination = "USA, Los Angeles",
                DepartureTime = new DateTime(2018, 7, 12, 2, 00, 00),
                DestinationArrivalTime = new DateTime(2018, 7, 15),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            var f3 = new Flight()
            {
                Id = f1.GetGeneratedId(),
                DeparturePoint = "USA, New York",
                Destination = "Ukraine, Lviv",
                DepartureTime = new DateTime(2018, 7, 17, 1, 0, 0),
                DestinationArrivalTime = new DateTime(2018, 7, 20),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            var f4 = new Flight()
            {
                Id = f1.GetGeneratedId(),
                DeparturePoint = "China, Hong Kong",
                Destination = "Russia, Moscow",
                DepartureTime = new DateTime(2018, 12, 22, 12, 30, 00),
                DestinationArrivalTime = new DateTime(2018, 12, 24),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            var f5 = new Flight()
            {
                Id = f1.GetGeneratedId(),
                DeparturePoint = "USA, Ohio",
                Destination = "Ukraine, Kharkiv",
                DepartureTime = new DateTime(2018, 8, 11, 12, 00, 00),
                DestinationArrivalTime = new DateTime(2018, 7, 13),
                Tickets = new List<Ticket>(),
                Departures = new List<Departure>()
            };
            Flights = new List<Flight>() { f1, f2, f3, f4, f5 };

            var t1 = new Ticket()
            {
                Price = 160,
                Flight = f2,
                FlightId = f2.Id
            };
            t1.Id = t1.GetGeneratedId();

            var t2 = new Ticket()
            {
                Id = t1.GetGeneratedId(),
                Price = 180,
                Flight = f2,
                FlightId = f2.Id
            };
            var t3 = new Ticket()
            {
                Id = t1.GetGeneratedId(),
                Price = 100,
                Flight = f1,
                FlightId = f1.Id
            };
            var t4 = new Ticket()
            {
                Id = t1.GetGeneratedId(),
                Price = 110,
                Flight = f1,
                FlightId = f1.Id
            };
            var t5 = new Ticket()
            {
                Id = t1.GetGeneratedId(),
                Price = 400,
                Flight = f3,
                FlightId = f3.Id
            };
            var t6 = new Ticket()
            {
                Id = t1.GetGeneratedId(),
                Price = 560,
                Flight = f4,
                FlightId = f4.Id
            };
            var t7 = new Ticket()
            {
                Id = t1.GetGeneratedId(),
                Price = 550,
                Flight = f4,
                FlightId = f4.Id
            };
            var t8 = new Ticket()
            {
                Id = t1.GetGeneratedId(),
                Price = 240,
                Flight = f4,
                FlightId = f4.Id
            };
            var t9 = new Ticket()
            {
                Id = t1.GetGeneratedId(),
                Price = 160,
                Flight = f5,
                FlightId = f5.Id
            };
            Tickets = new List<Ticket>() { t1, t2, t3, t4, t5, t6, t7, t8, t9 };

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
            d1.Id = d1.GetGeneratedId();

            var d2 = new Departure()
            {
                Id = d1.GetGeneratedId(),
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
                Id = d1.GetGeneratedId(),
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
                Id = d1.GetGeneratedId(),
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
                Id = d1.GetGeneratedId(),
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
                Id = d1.GetGeneratedId(),
                Flight = f1,
                FlightId = f1.Id,
                DepartureTime = new DateTime(2018, 7, 15, 0, 00, 00),
                Crew = c1,
                CrewId = c1.Id,
                Plane = pl1,
                PlaneId = pl1.Id
            };
            Departures = new List<Departure>() { d1, d2, d3, d4, d5, d6 };

            // Link Tickets and Departures to Flights
            foreach (var t in Tickets)
            {
                t.Flight.Tickets.Add(t);
            }
            foreach (var d in Departures)
            {
                d.Flight.Departures.Add(d);
                d.Crew.Departures.Add(d);
                d.Plane.Departures.Add(d);
            }
            #endregion
        }
    }
}
