using System;
using System.Collections.Generic;

namespace Airport.DAL.Repositories
{
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces.Repositories;

    public class DataProvider : IDataProvider
    {
        public List<Stewardess> Stewardesses { get; set; }

        public List<Pilot> Pilots { get; set; }

        public List<Crew> Crews { get; set; }

        public DataProvider() // Need to execute before instantiating (SingleTon) - Like DB
        {
            var st1 = new Stewardess()
            {
                Id = Stewardess.GetGeneratedId(),
                FirstName = "Alex",
                FamilyName = "Mayer",
                DateOfBirth = new DateTime(1997, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            var st2 = new Stewardess()
            {
                Id = Stewardess.GetGeneratedId(),
                FirstName = "Bobby",
                FamilyName = "Strand",
                DateOfBirth = new DateTime(1996, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            var st3 = new Stewardess()
            {
                Id = Stewardess.GetGeneratedId(),
                FirstName = "Celse",
                FamilyName = "Olead",
                DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            var st4 = new Stewardess()
            {
                Id = Stewardess.GetGeneratedId(),
                FirstName = "Shakira",
                FamilyName = "Pique",
                DateOfBirth = new DateTime(1994, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            var st5 = new Stewardess()
            {
                Id = Stewardess.GetGeneratedId(),
                FirstName = "Olga",
                FamilyName = "Petrenko",
                DateOfBirth = new DateTime(1993, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };

            Stewardesses = new List<Stewardess>() { st1, st2, st3, st4, st5 };

            var p1 = new Pilot()
            {
                Id = Pilot.GetGeneratedId(),
                FirstName = "Serg",
                FamilyName = "Karas",
                DateOfBirth = new DateTime(1997, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            var p2 = new Pilot()
            {
                Id = Pilot.GetGeneratedId(),
                FirstName = "Ostap",
                FamilyName = "Bober",
                DateOfBirth = new DateTime(1996, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            var p3 = new Pilot()
            {
                Id = Pilot.GetGeneratedId(),
                FirstName = "Sanya",
                FamilyName = "Morkva",
                DateOfBirth = new DateTime(1995, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            var p4 = new Pilot()
            {
                Id = Pilot.GetGeneratedId(),
                FirstName = "John",
                FamilyName = "Opler",
                DateOfBirth = new DateTime(1994, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };
            var p5 = new Pilot() // TODO: unused 
            {
                Id = Pilot.GetGeneratedId(),
                FirstName = "Michael",
                FamilyName = "Stoor",
                DateOfBirth = new DateTime(1993, 12, 22, 17, 30, 0),
                Crews = new List<Crew>()
            };

            Pilots = new List<Pilot>() { p1, p2, p3, p4, p5 };

            Crews = new List<Crew>()
                        {
                            new Crew()
                                       {
                                           Id = Crew.GetGeneratedId(),
                                           Pilot = p1,
                                           PilotId = p1.Id,
                                           Stewardesses = new List<Stewardess>() { st1, st2 }
                                       },
                                   new Crew()
                                       {
                                           Id = Crew.GetGeneratedId(),
                                           Pilot = p1,
                                           PilotId = p1.Id,
                                           Stewardesses = new List<Stewardess>() { st1, st4 }
                                       },
                                   new Crew()
                                       {
                                           Id = Crew.GetGeneratedId(),
                                           Pilot = p3,
                                           PilotId = p3.Id,
                                           Stewardesses = new List<Stewardess>() { st2, st3, st4 }
                                       },
                                   new Crew()
                                       {
                                           Id = Crew.GetGeneratedId(),
                                           Pilot = p2,
                                           PilotId = p2.Id,
                                           Stewardesses = new List<Stewardess>() { st5}
                                       },
                                   new Crew()
                                       {
                                           Id = Crew.GetGeneratedId(),
                                           Pilot = p4,
                                           PilotId = p4.Id,
                                           Stewardesses = new List<Stewardess>() { st3, st1, st2 }
                                       }
                        };

            foreach (var c in Crews)
            {
                c.Pilot.Crews.Add(c);
                foreach (var s in c.Stewardesses)
                {
                    s.Crews.Add(c);
                }
            }
        }
    }
}
