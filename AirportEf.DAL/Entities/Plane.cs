namespace AirportEf.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Airport.Common.Requests;

    public class Plane : Entity<int>
    {
        public override int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Obsolete("Property 'LifeTime' should be used instead.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long LifeTimeTicks { get; set; }

        [NotMapped]
        public TimeSpan LifeTime
        {
#pragma warning disable 618
            get { return new TimeSpan(LifeTimeTicks); }
            set { LifeTimeTicks = value.Ticks; }
#pragma warning restore 618
        }

        public int? PlaneTypeId { get; set; }

        public PlaneType PlaneType { get; set; }

        public ICollection<Departure> Departures { get; set; }

        public Plane() { }

        public Plane(PlaneRequest request, PlaneType planeType, int id = 0)
        {
            Id = id;
            Name = request.Name;
            CreationDate = request.CreationDate;
            LifeTime = request.LifeTime;
            PlaneTypeId = request.PlaneTypeId;
            PlaneType = planeType;
        }
    }
}
