﻿namespace AirportEf.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    using Airport.Common.Interfaces.Entities;
    using Airport.Common.Requests;

    public sealed class Pilot : Human<int>
    {
        public override int Id { get; set; }

        [Obsolete("Property 'Experience' should be used instead.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long ExperienceTicks { get; set; }

        [NotMapped]
        public TimeSpan Experience
        {
#pragma warning disable 618
            get { return new TimeSpan(ExperienceTicks); }
            set { ExperienceTicks = value.Ticks; }
#pragma warning restore 618
        }

        public ICollection<Crew> Crews { get; set; }


        public Pilot() { }

        public Pilot(PilotRequest request, int id)
        {
            Id = id;
            FirstName = request.Name;
            FamilyName = request.FamilyName;
            DateOfBirth = request.DateOfBirth;
            Experience = request.Experience;
            Crews = new List<Crew>();
        }
    }
}
